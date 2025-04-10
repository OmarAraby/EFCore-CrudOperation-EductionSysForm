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

        //private void InitializeTabs()
        //{
        //    // Add the "Home" tab first
        //    var homeTab = new TabPage("Home");
        //    homeTab.BackColor = Color.FromArgb(220, 220, 220); // Match the form background

        //    // Create a panel to hold the welcome content
        //    var homePanel = new Panel
        //    {
        //        Dock = DockStyle.Fill,
        //        BackColor = Color.FromArgb(220, 220, 220)
        //    };

        //    // Add a welcome label
        //    var welcomeLabel = new Label
        //    {
        //        Text = "Welcome to the EducationSys Project",
        //        Font = new Font("Segoe UI", 16F, FontStyle.Bold),
        //        ForeColor = Color.FromArgb(40, 167, 69), // Green to match the theme
        //        AutoSize = true,
        //        Location = new Point(250, 130)
        //    };
        //    homePanel.Controls.Add(welcomeLabel);

        //    // Add a description label
        //    var descriptionLabel = new Label
        //    {
        //        Text = "This Project helps you manage students, departments, courses, and more.\n" +
        //               "Use the tabs above to navigate through different sections.",
        //        Font = new Font("Segoe UI", 10F, FontStyle.Regular),
        //        ForeColor = Color.FromArgb(33, 37, 41),
        //        AutoSize = true,
        //        Location = new Point(250, 180)
        //    };
        //    homePanel.Controls.Add(descriptionLabel);



        //    homeTab.Controls.Add(homePanel);
        //    tabControl.TabPages.Add(homeTab);
        //    foreach (var entity in _entityTypes)
        //    {
        //        var tabPage = new TabPage(entity.Key);
        //        tabPage.Tag = entity.Value;

        //        var dataGridView = new DataGridView
        //        {
        //            Dock = DockStyle.Fill,
        //            AllowUserToAddRows = false,
        //            AllowUserToDeleteRows = false,
        //            ReadOnly = true,
        //            MultiSelect = false,
        //            SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        //            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        //        };

        //        dataGridView.CellDoubleClick += DataGridView_CellDoubleClick;
        //        tabPage.Controls.Add(dataGridView);

        //        tabControl.TabPages.Add(tabPage);
        //    }
        //}

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
        //private void InitializeForm()
        //{
        //    btnSave.Click += BtnSave_Click;
        //    btnDelete.Click += BtnDelete_Click;
        //    btnCancel.Click += BtnCancel_Click;

        //    tabControl.SelectedIndexChanged += async (s, e) =>
        //    {
        //        if (tabControl.SelectedTab != null && tabControl.SelectedTab.Tag is Type entityType)
        //        {
        //            _currentEntityType = entityType;
        //            _currentGrid = (DataGridView)tabControl.SelectedTab.Controls[0];
        //            _formService.SetFormPanel(formPanel);
        //            await LoadEntities();
        //            ResetFormState();
        //        }
        //    };

        //    if (tabControl.TabPages.Count > 0)
        //    {
        //        tabControl.SelectedIndex = 0;
        //    }
        //}

        private void InitializeForm()
        {
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnCancel.Click += BtnCancel_Click;

            tabControl.SelectedIndexChanged += async (s, e) =>
            {
                // Skip if the "Home" tab is selected
                if (tabControl.SelectedTab.Text == "Home")
                {
                    formPanel.Controls.Clear(); // Clear the form panel
                    formPanel.Visible = false; // Hide the form panel
                    btnSave.Visible = false; // Hide the Save button
                    btnDelete.Visible = false; // Hide the Delete button
                    btnCancel.Visible = false; // Hide the Cancel button
                    return;
                }

                if (tabControl.SelectedTab != null && tabControl.SelectedTab.Tag is Type entityType)
                {
                    _currentEntityType = entityType;
                    _currentGrid = (DataGridView)tabControl.SelectedTab.Controls[0];
                    _formService.SetFormPanel(formPanel);
                    await LoadEntities();
                    ResetFormState();
                    formPanel.Visible = true; 
                    btnSave.Visible = true;
                    btnDelete.Visible = true; 
                    btnCancel.Visible = true; 
                    btnSave.Enabled = true; 
                }
            };

            if (tabControl.TabPages.Count > 0)
            {
                tabControl.SelectedIndex = 0; // Set "Home" tab as default
                                              // Since "Home" tab is selected by default, hide the elements initially
                formPanel.Visible = false;
                btnSave.Visible = false;
                btnDelete.Visible = false;
                btnCancel.Visible = false;
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

        //private async Task LoadEntities()
        //{
        //    if (_currentEntityType == null) return;

        //    try
        //    {
        //        // Use reflection to dynamically invoke GetAllAsync with the current entity type
        //        var getAllMethod = typeof(IGenericCrudService).GetMethod("GetAllAsync");
        //        var genericGetAllMethod = getAllMethod.MakeGenericMethod(_currentEntityType);

        //        // Invoke the generic method, which returns Task<IEnumerable<T>>
        //        var task = (Task)genericGetAllMethod.Invoke(_crudService, null);

        //        // Await the task dynamically to get IEnumerable<T>
        //        await task.ConfigureAwait(false);

        //        // Use reflection to get the result (IEnumerable<T>) from the Task
        //        var resultProperty = task.GetType().GetProperty("Result");
        //        var entities = (IEnumerable)resultProperty.GetValue(task);

        //        // Cast the entities to IEnumerable<object>
        //        var objectEntities = entities.Cast<object>().ToList();

        //        var bindingSource = new BindingSource();
        //        bindingSource.DataSource = objectEntities;
        //        _currentGrid.DataSource = bindingSource;

        //        // Hide navigation properties
        //        foreach (DataGridViewColumn column in _currentGrid.Columns)
        //        {
        //            PropertyInfo prop = _currentEntityType.GetProperty(column.Name);
        //            if (prop != null &&
        //                ((prop.PropertyType.IsClass && prop.PropertyType != typeof(string)) ||
        //                 prop.PropertyType.IsInterface))
        //            {
        //                column.Visible = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading data: {ex.Message}");
        //    }
        //}


        private async Task LoadEntities()
        {
            if (_currentEntityType == null) return;

            try
            {
                // Use reflection to dynamically invoke GetAllAsync with the current entity type
                var getAllMethod = typeof(IGenericCrudService).GetMethod("GetAllAsync");
                var genericGetAllMethod = getAllMethod.MakeGenericMethod(_currentEntityType);

                // Invoke the generic method, which returns Task<IEnumerable<T>>
                var task = (Task)genericGetAllMethod.Invoke(_crudService, null);

                // Await the task dynamically to get IEnumerable<T>
                await task.ConfigureAwait(false);

                // Use reflection to get the result (IEnumerable<T>) from the Task
                var resultProperty = task.GetType().GetProperty("Result");
                var entities = (IEnumerable)resultProperty.GetValue(task);

                // Log the number of entities retrieved
                var entityCount = entities?.Cast<object>().Count() ?? 0;
                System.Diagnostics.Debug.WriteLine($"Loaded {entityCount} entities of type {_currentEntityType.Name}");

                // Cast the entities to IEnumerable<object>
                var objectEntities = entities?.Cast<object>().ToList();

                // Check if the data is null or empty
                if (objectEntities == null || !objectEntities.Any())
                {
                    _currentGrid.DataSource = null; // Clear the DataGridView if no data
                    MessageBox.Show($"No {_currentEntityType.Name} data found.");
                    return;
                }

                var bindingSource = new BindingSource();
                bindingSource.DataSource = objectEntities;
                _currentGrid.DataSource = bindingSource;

                // Hide navigation properties
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}\nInner Exception: {(ex.InnerException != null ? ex.InnerException.Message : "None")}");
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
                        var convertedValue = Convert.ChangeType(value, prop.PropertyType);
                        prop.SetValue(entity, convertedValue);
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