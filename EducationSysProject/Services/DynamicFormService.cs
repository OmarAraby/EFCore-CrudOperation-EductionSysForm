using EducationSysProject.Data.Models;
using EducationSysProject.Data.UintOfWork;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace EducationSysProject.Services
{
    public class DynamicFormService
    {
        private Panel _formPanel;
        private readonly Dictionary<string, Control> _inputControls = new Dictionary<string, Control>();
        private readonly IUnitOfWork _unitOfWork;
        private readonly Dictionary<string, List<ComboBoxItem>> _foreignKeyData;

        public DynamicFormService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _foreignKeyData = new Dictionary<string, List<ComboBoxItem>>();
            PreloadForeignKeyData().GetAwaiter().GetResult(); // Load data synchronously at startup
        }

        private async Task PreloadForeignKeyData()
        {
            var departments = await _unitOfWork.Departments.GetAllAsync();
            _foreignKeyData["Department"] = departments.Select(dept => new ComboBoxItem
            {
                ID = dept.DepartmentID,
                DisplayName = dept.Name
            }).ToList();

            var instructors = await _unitOfWork.Instructors.GetAllAsync();
            _foreignKeyData["Instructor"] = instructors.Select(inst => new ComboBoxItem
            {
                ID = inst.ID,
                DisplayName = $"{inst.FirstName} {inst.LastName}"
            }).ToList();

            var courses = await _unitOfWork.Courses.GetAllAsync();
            _foreignKeyData["Course"] = courses.Select(course => new ComboBoxItem
            {
                ID = course.ID,
                DisplayName = course.Name
            }).ToList();

            var students = await _unitOfWork.Students.GetAllAsync();
            _foreignKeyData["Student"] = students.Select(student => new ComboBoxItem
            {
                ID = student.ID,
                DisplayName = $"{student.FirstName} {student.LastName}"
            }).ToList();

            var sessions = await _unitOfWork.CourseSessions.GetAllAsync();
            _foreignKeyData["CourseSession"] = sessions.Select(session => new ComboBoxItem
            {
                ID = session.ID,
                DisplayName = $"{session.Title} ({session.Date.ToShortDateString()})"
            }).ToList();

            foreach (var key in _foreignKeyData.Keys.ToList())
            {
                _foreignKeyData[key].Insert(0, new ComboBoxItem { ID = Guid.Empty, DisplayName = "-- Select --" });
            }
        }

        public void SetFormPanel(Panel panel)
        {
            _formPanel = panel;
            if (_formPanel.InvokeRequired)
            {
                _formPanel.Invoke(new Action(() =>
                {
                    _formPanel.Controls.Clear();
                    _inputControls.Clear();
                }));
            }
            else
            {
                _formPanel.Controls.Clear();
                _inputControls.Clear();
            }
        }

        public void GenerateFormForType(Type entityType, object existingEntity = null)
        {
            if (_formPanel == null)
                throw new InvalidOperationException("Form panel not set. Call SetFormPanel first.");

            if (_formPanel.InvokeRequired)
            {
                _formPanel.Invoke(new Action(() => GenerateFormForTypeInternal(entityType, existingEntity)));
            }
            else
            {
                GenerateFormForTypeInternal(entityType, existingEntity);
            }
        }

        private void GenerateFormForTypeInternal(Type entityType, object existingEntity = null)
        {
            _formPanel.Controls.Clear();
            _inputControls.Clear();

            var properties = entityType.GetProperties();
            int yPos = 20;

            foreach (var prop in properties)
            {
                if (ShouldSkipProperty(prop, entityType)) continue;

                bool isRequired = IsPropertyRequired(prop, entityType);

                var label = new Label
                {
                    Text = prop.Name + (isRequired ? " *" : ""),
                    Location = new System.Drawing.Point(20, yPos),
                    Width = 100
                };

                Control inputControl;

                if (prop.Name.EndsWith("ID") && prop.PropertyType == typeof(Guid) && !prop.Name.Equals("ID", StringComparison.OrdinalIgnoreCase))
                {
                    inputControl = CreateForeignKeyDropdown(prop, entityType);
                }
                else
                {
                    inputControl = CreateInputControl(prop, yPos);
                }

                inputControl.Location = new System.Drawing.Point(130, yPos);

                if (existingEntity != null)
                {
                    SetControlValue(inputControl, prop.GetValue(existingEntity));
                }

                _formPanel.Controls.Add(label);
                _formPanel.Controls.Add(inputControl);
                _inputControls.Add(prop.Name, inputControl);

                yPos += 30;
            }
        }

        private Control CreateForeignKeyDropdown(PropertyInfo prop, Type entityType)
        {
            var relatedEntityName = prop.Name.EndsWith("ID") ? prop.Name[..^2] : prop.Name;

            if (relatedEntityName.Equals("Manager", StringComparison.OrdinalIgnoreCase))
            {
                relatedEntityName = "Instructor";
            }

            var comboBox = new ComboBox
            {
                Width = 200,
                DisplayMember = "DisplayName",
                ValueMember = "ID"
            };

            if (_foreignKeyData.ContainsKey(relatedEntityName))
            {
                comboBox.DataSource = _foreignKeyData[relatedEntityName].ToList();
            }
            else
            {
                comboBox.DataSource = new List<ComboBoxItem>
            {
                new ComboBoxItem { ID = Guid.Empty, DisplayName = "-- Select --" }
            };
            }

            return comboBox;
        }
        public Dictionary<string, object> GetFormValues()
        {
            var values = new Dictionary<string, object>();

            foreach (var kvp in _inputControls)
            {
                var value = GetControlValue(kvp.Value);

                if (kvp.Key.EndsWith("ID", StringComparison.OrdinalIgnoreCase) ||
                    kvp.Key.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    if (value == null || (value is string strValue && string.IsNullOrWhiteSpace(strValue)))
                    {
                        continue;
                    }

                    if (value is ComboBoxItem comboItem)
                    {
                        if (comboItem.ID != Guid.Empty)
                        {
                            values.Add(kvp.Key, comboItem.ID);
                        }
                    }
                    else if (Guid.TryParse(value.ToString(), out var guidValue))
                    {
                        values.Add(kvp.Key, guidValue);
                    }
                    else
                    {
                        throw new FormatException($"Invalid GUID format for property {kvp.Key}");
                    }
                }
                else
                {
                    values.Add(kvp.Key, value);
                }
            }

            return values;
        }

        public bool ValidateRequiredFields(Type entityType, out string errorMessage)
        {
            errorMessage = string.Empty;
            var properties = entityType.GetProperties();

            foreach (var prop in properties)
            {
                if (ShouldSkipProperty(prop, entityType)) continue;

                if (IsPropertyRequired(prop, entityType) && _inputControls.ContainsKey(prop.Name))
                {
                    var value = GetControlValue(_inputControls[prop.Name]);
                    if (value == null || (value is string strValue && string.IsNullOrWhiteSpace(strValue)) || (value is ComboBoxItem comboItem && comboItem.ID == Guid.Empty))
                    {
                        errorMessage = $"Field '{prop.Name}' is required.";
                        return false;
                    }
                    // Additional validation for CourseSession Date
                    if (entityType == typeof(CourseSession) && prop.Name == "Date")
                    {
                        if (value is DateTime selectedDate)
                        {
                            // Compare with current date (ignoring time for simplicity)
                            var currentDate = DateTime.Now.Date;
                            if (selectedDate.Date < currentDate)
                            {
                                errorMessage = "The 'Date' for a Course Session must be today or a future date.";
                                return false;
                            }
                        }
                        else
                        {
                            errorMessage = "Invalid date format for 'Date' field.";
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool IsPropertyRequired(PropertyInfo prop, Type entityType)
        {
            if (entityType == typeof(Student))
            {
                return prop.Name == "FirstName" || prop.Name == "LastName" || prop.Name == "Phone";
            }
            else if (entityType == typeof(Instructor))
            {
                return prop.Name == "FirstName" || prop.Name == "LastName" || prop.Name == "Email" || prop.Name == "DepartmentID";
            }
            else if (entityType == typeof(Course))
            {
                return prop.Name == "Name" || prop.Name == "Duration" || prop.Name == "DepartmentID" || prop.Name == "InstructorID";
            }
            else if (entityType == typeof(Department))
            {
                return prop.Name == "Name" || prop.Name == "Location" || prop.Name == "ManagerID";
            }
            else if (entityType == typeof(CourseSession))
            {
                return prop.Name == "Title" || prop.Name == "Date" || prop.Name == "CourseID" || prop.Name == "InstructorID";
            }
            else if (entityType == typeof(CourseSessionAttendance))
            {
                return prop.Name == "Grade" || prop.Name == "CourseSessionID" || prop.Name == "StudentID";
            }
            else if (entityType == typeof(CourseStudent))
            {
                return prop.Name == "CourseID" || prop.Name == "StudentID";
            }
            return false;
        }

        public bool ShouldSkipProperty(PropertyInfo prop, Type entityType = null)
        {
            bool isPrimaryKey = string.Equals(prop.Name, "Id", StringComparison.OrdinalIgnoreCase) ||
                                string.Equals(prop.Name, "ID", StringComparison.OrdinalIgnoreCase) ||
                                (entityType != null &&
                                 entityType.Name == "Department" &&
                                 string.Equals(prop.Name, "DepartmentID", StringComparison.OrdinalIgnoreCase));

            bool isNavigationProperty = prop.PropertyType.IsClass &&
                                       prop.PropertyType != typeof(string) &&
                                       !prop.PropertyType.IsPrimitive &&
                                       prop.PropertyType != typeof(DateTime) &&
                                       !prop.PropertyType.IsEnum &&
                                       !prop.Name.EndsWith("ID");

            bool isCollection = typeof(IEnumerable).IsAssignableFrom(prop.PropertyType) &&
                                prop.PropertyType != typeof(string);

            return isPrimaryKey || isNavigationProperty || isCollection;
        }

        private Control CreateInputControl(PropertyInfo prop, int yPos)
        {
            if (prop.PropertyType == typeof(bool))
            {
                return new CheckBox { Location = new System.Drawing.Point(130, yPos) };
            }
            else if (prop.PropertyType == typeof(DateTime))
            {
                return new DateTimePicker
                {
                    Location = new System.Drawing.Point(130, yPos),
                    Width = 200
                };
            }
            else
            {
                return new TextBox
                {
                    Location = new System.Drawing.Point(130, yPos),
                    Width = 200
                };
            }
        }

        private void SetControlValue(Control control, object value)
        {
            if (value == null) return;

            switch (control)
            {
                case TextBox textBox:
                    textBox.Text = value.ToString();
                    break;

                case CheckBox checkBox:
                    checkBox.Checked = (bool)value;
                    break;

                case DateTimePicker datePicker:
                    if (value is DateTime date)
                        datePicker.Value = date;
                    break;

                case ComboBox comboBox:
                    if (value is Guid guid)
                    {
                        var items = comboBox.Items.Cast<ComboBoxItem>();
                        var matchingItem = items.FirstOrDefault(i => i.ID.Equals(guid));
                        if (matchingItem != null)
                        {
                            comboBox.SelectedItem = matchingItem;
                        }
                    }
                    break;
            }
        }

        private object GetControlValue(Control control)
        {
            return control switch
            {
                TextBox textBox => textBox.Text,
                CheckBox checkBox => checkBox.Checked,
                DateTimePicker datePicker => datePicker.Value,
                ComboBox comboBox => comboBox.SelectedItem,
                _ => null
            };
        }
    }

    public class ComboBoxItem
    {
        public Guid ID { get; set; }
        public string DisplayName { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}