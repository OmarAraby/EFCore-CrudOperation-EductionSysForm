using EducationSysProject.Data.Models;
using EducationSysProject.Data.UintOfWork;
using EducationSysProject.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EducationSysProject
{
    public partial class MainForm : Form
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericCrudService _crudService;
        private readonly DynamicFormService _formService;

        private Type _currentEntityType;
        private object _currentEntity;
        private DataGridView _currentGrid;
        private readonly Dictionary<string, Type> _entityTypes;

        public MainForm(IUnitOfWork unitOfWork, IGenericCrudService crudService, DynamicFormService formService)
        {
            _unitOfWork = unitOfWork;
            _crudService = crudService;
            _formService = formService;

            _entityTypes = new Dictionary<string, Type>
            {
                { "Students", typeof(Student) },
                { "Departments", typeof(Department) },
                { "Courses", typeof(Course) },
                { "Instructors", typeof(Instructor) },
                { "Course Students", typeof(CourseStudent) },
                { "Course Sessions", typeof(CourseSession) },
                { "Attendances", typeof(CourseSessionAttendance) }
            };

            InitializeComponent();
            InitializeTabs();
            InitializeForm();
        }


        private void InitializeTabs()
        {
            // Add the "Home" tab first
            var homeTab = new TabPage("Home");
            homeTab.BackColor = Color.FromArgb(245, 245, 245); // Match the form background

            // Create a panel to hold the welcome content
            var homePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245)
            };

            // Add a welcome label
            var welcomeLabel = new Label
            {
                Text = "Welcome to the EducationSys Project",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.FromArgb(0, 122, 204), // Blue to match your theme
                AutoSize = true,
                Location = new Point(250, 130)
            };
            homePanel.Controls.Add(welcomeLabel);

            // Add a description label
            var descriptionLabel = new Label
            {
                Text = "This Project helps you manage students, departments, courses, and more.\n" +
                       "Use the tabs above to navigate through different sections.",
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(33, 37, 41),
                AutoSize = true,
                Location = new Point(250, 180)
            };
            homePanel.Controls.Add(descriptionLabel);

            // Add a "Get Started" button
            var getStartedButton = new Button
            {
                Text = "Get Started",
                Location = new Point(250, 240),
                Size = new Size(120, 35),
                BackColor = Color.FromArgb(0, 122, 204), // Match your Save button color
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            getStartedButton.Click += (s, e) => tabControl.SelectedIndex = 1; // Switch to the "Students" tab
            getStartedButton.MouseEnter += (s, e) => getStartedButton.BackColor = Color.FromArgb(30, 144, 255);
            getStartedButton.MouseLeave += (s, e) => getStartedButton.BackColor = Color.FromArgb(0, 122, 204);
            homePanel.Controls.Add(getStartedButton);

            homeTab.Controls.Add(homePanel);
            tabControl.TabPages.Add(homeTab);

            foreach (var entity in _entityTypes)
            {
                var tabPage = new TabPage(entity.Key);
                tabPage.Tag = entity.Value;

                var dataGridView = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    ReadOnly = true,
                    MultiSelect = false,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };

                StyleDataGridView(dataGridView); // Apply styling to the DataGridView
                dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
                tabPage.Controls.Add(dataGridView);

                tabControl.TabPages.Add(tabPage);
            }
        }


        private void InitializeForm()
        {
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnCancel.Click += BtnCancel_Click;

            tabControl.SelectedIndexChanged += async (s, e) =>
            {
                if (tabControl.SelectedTab.Text == "Home")
                {
                    if (formPanel.InvokeRequired)
                    {
                        formPanel.Invoke(new Action(() =>
                        {
                            formPanel.Controls.Clear();
                            formPanel.Visible = false;
                            btnSave.Visible = false;
                            btnDelete.Visible = false;
                            btnCancel.Visible = false;
                        }));
                    }
                    else
                    {
                        formPanel.Controls.Clear();
                        formPanel.Visible = false;
                        btnSave.Visible = false;
                        btnDelete.Visible = false;
                        btnCancel.Visible = false;
                    }
                    return;
                }

                if (tabControl.SelectedTab != null && tabControl.SelectedTab.Tag is Type entityType)
                {
                    _currentEntityType = entityType;
                    _currentGrid = (DataGridView)tabControl.SelectedTab.Controls[0];
                    _formService.SetFormPanel(formPanel);
                    await LoadEntities();
                    ResetFormState();
                    if (formPanel.InvokeRequired)
                    {
                        formPanel.Invoke(new Action(() =>
                        {
                            formPanel.Visible = true;
                            btnSave.Visible = true;
                            btnDelete.Visible = true;
                            btnCancel.Visible = true;
                            btnSave.Enabled = true;
                        }));
                    }
                    else
                    {
                        formPanel.Visible = true;
                        btnSave.Visible = true;
                        btnDelete.Visible = true;
                        btnCancel.Visible = true;
                        btnSave.Enabled = true;
                    }
                }
            };

            if (tabControl.TabPages.Count > 0)
            {
                if (tabControl.InvokeRequired)
                {
                    tabControl.Invoke(new Action(() =>
                    {
                        tabControl.SelectedIndex = 0;
                        formPanel.Visible = false;
                        btnSave.Visible = false;
                        btnDelete.Visible = false;
                        btnCancel.Visible = false;
                    }));
                }
                else
                {
                    tabControl.SelectedIndex = 0;
                    formPanel.Visible = false;
                    btnSave.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = false;
                }
            }
        }
        private async void DataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dataGridView = (DataGridView)sender;
            _currentEntity = dataGridView.Rows[e.RowIndex].DataBoundItem;

            _formService.GenerateFormForType(_currentEntityType, _currentEntity);
            btnSave.Text = "Update";
            btnDelete.Enabled = true;
        }


        private async Task LoadEntities()
        {
            if (_currentEntityType == null) return;

            try
            {
                var getAllMethod = typeof(IGenericCrudService).GetMethod("GetAllAsync");
                var genericGetAllMethod = getAllMethod.MakeGenericMethod(_currentEntityType);
                var task = (Task)genericGetAllMethod.Invoke(_crudService, null);
                await task.ConfigureAwait(false);
                var resultProperty = task.GetType().GetProperty("Result");
                var entities = (IEnumerable)resultProperty.GetValue(task);

                var entityCount = entities?.Cast<object>().Count() ?? 0;
                System.Diagnostics.Debug.WriteLine($"Loaded {entityCount} entities of type {_currentEntityType.Name}");

                var objectEntities = entities?.Cast<object>().ToList();
                if (objectEntities == null || !objectEntities.Any())
                {
                    if (_currentGrid.InvokeRequired)
                    {
                        _currentGrid.Invoke(new Action(() =>
                        {
                            _currentGrid.DataSource = null;
                            MessageBox.Show($"No {_currentEntityType.Name} data found.");
                        }));
                    }
                    else
                    {
                        _currentGrid.DataSource = null;
                        MessageBox.Show($"No {_currentEntityType.Name} data found.");
                    }
                    return;
                }

                var bindingSource = new BindingSource();
                bindingSource.DataSource = objectEntities;

                if (_currentGrid.InvokeRequired)
                {
                    _currentGrid.Invoke(new Action(() =>
                    {
                        _currentGrid.DataSource = bindingSource;

                        foreach (DataGridViewColumn column in _currentGrid.Columns)
                        {
                            PropertyInfo prop = _currentEntityType.GetProperty(column.Name);
                            if (prop != null &&
                                ((prop.PropertyType.IsClass && prop.PropertyType != typeof(string)) ||
                                 prop.PropertyType.IsInterface))
                            {
                                column.Visible = false;
                            }
                            else if (prop == null)
                            {
                                column.Visible = false;
                            }
                        }
                    }));
                }
                else
                {
                    _currentGrid.DataSource = bindingSource;

                    foreach (DataGridViewColumn column in _currentGrid.Columns)
                    {
                        PropertyInfo prop = _currentEntityType.GetProperty(column.Name);
                        if (prop != null &&
                            ((prop.PropertyType.IsClass && prop.PropertyType != typeof(string)) ||
                             prop.PropertyType.IsInterface))
                        {
                            column.Visible = false;
                        }
                        else if (prop == null)
                        {
                            column.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (InvokeRequired)
                {
                    Invoke(new Action(() =>
                    {
                        MessageBox.Show($"Error loading data: {ex.Message}\nInner Exception: {(ex.InnerException != null ? ex.InnerException.Message : "None")}");
                    }));
                }
                else
                {
                    MessageBox.Show($"Error loading data: {ex.Message}\nInner Exception: {(ex.InnerException != null ? ex.InnerException.Message : "None")}");
                }
            }
        }
        private async void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate required fields
                if (!_formService.ValidateRequiredFields(_currentEntityType, out string errorMessage))
                {
                    MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var formValues = _formService.GetFormValues();
                var entity = _currentEntity ?? Activator.CreateInstance(_currentEntityType);

                // Set the ID for a new entity
                if (_currentEntity == null)
                {
                    var idProperty = _currentEntityType.GetProperty("ID");
                    if (idProperty != null && idProperty.PropertyType == typeof(Guid))
                    {
                        idProperty.SetValue(entity, Guid.NewGuid());
                    }
                }

            foreach (var prop in _currentEntityType.GetProperties())
            {
                if (formValues.TryGetValue(prop.Name, out var value) && value != null)
                {
                    try
                    {
                        // التعامل مع الأنواع المختلفة
                        object convertedValue = null;

                        // لو البروبرتي من نوع Guid أو Guid?
                        if (prop.PropertyType == typeof(Guid) || prop.PropertyType == typeof(Guid?))
                        {
                            if (value is Guid guidValue)
                            {
                                convertedValue = guidValue;
                            }
                            else if (value is string strValue && Guid.TryParse(strValue, out var parsedGuid))
                            {
                                convertedValue = parsedGuid;
                            }
                            else
                            {
                                throw new FormatException($"Cannot convert value '{value}' to Guid for property '{prop.Name}'.");
                            }
                        }
                        // لو البروبرتي من نوع DateTime أو DateTime?
                        else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                        {
                            if (value is DateTime dateTimeValue)
                            {
                                convertedValue = dateTimeValue;
                            }
                            else if (value is string strValue && DateTime.TryParse(strValue, out var parsedDateTime))
                            {
                                convertedValue = parsedDateTime;
                            }
                            else
                            {
                                throw new FormatException($"Cannot convert value '{value}' to DateTime for property '{prop.Name}'.");
                            }
                        }
                     
                        else if (prop.PropertyType == typeof(bool))
                        {
                            if (value is bool boolValue)
                            {
                                convertedValue = boolValue;
                            }
                            else if (value is string strValue && bool.TryParse(strValue, out var parsedBool))
                            {
                                convertedValue = parsedBool;
                            }
                            else
                            {
                                throw new FormatException($"Cannot convert value '{value}' to bool for property '{prop.Name}'.");
                            }
                        }
                       
                        else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                        {
                            if (value is int intValue)
                            {
                                convertedValue = intValue;
                            }
                            else if (value is string strValue && int.TryParse(strValue, out var parsedInt))
                            {
                                convertedValue = parsedInt;
                            }
                            else
                            {
                                throw new FormatException($"Cannot convert value '{value}' to int for property '{prop.Name}'.");
                            }
                        }
                     
                        else if (prop.PropertyType == typeof(string))
                        {
                            convertedValue = value.ToString();
                        }
                        else
                        {
                            convertedValue = Convert.ChangeType(value, prop.PropertyType);
                        }

                      
                        prop.SetValue(entity, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException($"Error setting property '{prop.Name}' on entity type '{_currentEntityType.Name}': {ex.Message}", ex);
                    }
                }
            }

            if (_currentEntity == null)
                {
                    await _crudService.CreateAsync((dynamic)entity);
                    MessageBox.Show("Created successfully!");
                }
                else
                {
                    await _crudService.UpdateAsync((dynamic)entity);
                    MessageBox.Show("Updated successfully!");
                }
                await _formService.RefreshForeignKeyData(); 
                await LoadEntities();
                ResetFormState();
        }
            catch (Exception ex)
            {
                string errorMessage = $"Error: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nInner Exception: {ex.InnerException.Message}";
                }
    MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_currentEntity == null) return;

            if (MessageBox.Show("Are you sure you want to delete this record?",
                "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _crudService.DeleteAsync((dynamic)_currentEntity);
                    await _formService.RefreshForeignKeyData(); // تحديث الـ Foreign Key Data
                    await LoadEntities();
                    MessageBox.Show("Deleted successfully!");
                    ResetFormState();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting: {ex.Message}");
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            ResetFormState();
        }

        private void ResetFormState()
        {
            _currentEntity = null;
            _formService.GenerateFormForType(_currentEntityType);
            btnSave.Text = "Save";
            btnDelete.Enabled = false;
            btnSave.Visible = true;
            btnDelete.Visible = true;
            btnCancel.Visible = true;
            formPanel.Visible = true;
        }
    }
}