namespace EducationSysProject
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.formPanel = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // tabControl
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 400);
            this.tabControl.TabIndex = 0;
            this.tabControl.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.TabControl_DrawItem);

            // formPanel
            this.formPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.formPanel.Location = new System.Drawing.Point(0, 400);
            this.formPanel.Name = "formPanel";
            this.formPanel.Size = new System.Drawing.Size(400, 300);
            this.formPanel.TabIndex = 1;
            this.formPanel.BackColor = System.Drawing.Color.FromArgb(230, 230, 230);
            this.formPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.formPanel.Padding = new System.Windows.Forms.Padding(10);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(440, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSave.MouseEnter += new System.EventHandler(this.BtnSave_MouseEnter);
            this.btnSave.MouseLeave += new System.EventHandler(this.BtnSave_MouseLeave);

            // btnDelete
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(530, 430);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.MouseEnter += new System.EventHandler(this.BtnDelete_MouseEnter);
            this.btnDelete.MouseLeave += new System.EventHandler(this.BtnDelete_MouseLeave);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(620, 430);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCancel.MouseEnter += new System.EventHandler(this.BtnCancel_MouseEnter);
            this.btnCancel.MouseLeave += new System.EventHandler(this.BtnCancel_MouseLeave);

            // MainForm
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.formPanel);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Education System";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.Panel formPanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;

        private void BtnSave_MouseEnter(object sender, EventArgs e)
        {
            btnSave.BackColor = System.Drawing.Color.FromArgb(30, 144, 255);
        }

        private void BtnSave_MouseLeave(object sender, EventArgs e)
        {
            btnSave.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
        }

        private void BtnDelete_MouseEnter(object sender, EventArgs e)
        {
            btnDelete.BackColor = System.Drawing.Color.FromArgb(255, 77, 77);
        }

        private void BtnDelete_MouseLeave(object sender, EventArgs e)
        {
            btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
        }

        private void BtnCancel_MouseEnter(object sender, EventArgs e)
        {
            btnCancel.BackColor = System.Drawing.Color.FromArgb(130, 139, 147);
        }

        private void BtnCancel_MouseLeave(object sender, EventArgs e)
        {
            btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
        }

        private void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle tabBounds = tabControl.GetTabRect(e.Index);

            Brush tabBrush = new SolidBrush(e.State == DrawItemState.Selected ? Color.FromArgb(0, 122, 204) : Color.FromArgb(200, 200, 200));
            Brush textBrush = new SolidBrush(e.State == DrawItemState.Selected ? Color.White : Color.Black);

            e.Graphics.FillRectangle(tabBrush, tabBounds);

            StringFormat stringFlags = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            e.Graphics.DrawString(tabPage.Text, e.Font, textBrush, tabBounds, stringFlags);

            tabBrush.Dispose();
            textBrush.Dispose();
        }

        private void StyleDataGridView(DataGridView grid)
        {
            grid.BackgroundColor = Color.FromArgb(245, 245, 245);
            grid.BorderStyle = BorderStyle.None;
            grid.EnableHeadersVisualStyles = false;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 122, 204);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            grid.DefaultCellStyle.SelectionForeColor = Color.White;

            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 230, 230);

            grid.GridColor = Color.FromArgb(200, 200, 200);
        }
    }
}