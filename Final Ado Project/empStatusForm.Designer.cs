
namespace ADOProject
{
    partial class empStatusForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.refContactBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.refNameBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.salaryBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Department = new System.Windows.Forms.Label();
            this.designationBox = new System.Windows.Forms.ComboBox();
            this.departmentBox = new System.Windows.Forms.ComboBox();
            this.empNameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearES = new System.Windows.Forms.Button();
            this.btnSaveES = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.empIDBox = new System.Windows.Forms.ComboBox();
            this.personalInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.empManagementSystemDataSet = new ADOProject.EmpManagementSystemDataSet();
            this.personalInfoTableAdapter = new ADOProject.EmpManagementSystemDataSetTableAdapters.personalInfoTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personalInfoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.empManagementSystemDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.refContactBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.refNameBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(61, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(611, 75);
            this.panel1.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(270, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 5;
            this.label6.Text = "Contact Number";
            // 
            // refContactBox
            // 
            this.refContactBox.Location = new System.Drawing.Point(390, 45);
            this.refContactBox.Name = "refContactBox";
            this.refContactBox.Size = new System.Drawing.Size(209, 20);
            this.refContactBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(270, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Referrence Name";
            // 
            // refNameBox
            // 
            this.refNameBox.Location = new System.Drawing.Point(390, 12);
            this.refNameBox.Name = "refNameBox";
            this.refNameBox.Size = new System.Drawing.Size(209, 20);
            this.refNameBox.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Referrence List";
            // 
            // salaryBox
            // 
            this.salaryBox.Location = new System.Drawing.Point(250, 206);
            this.salaryBox.Name = "salaryBox";
            this.salaryBox.Size = new System.Drawing.Size(254, 20);
            this.salaryBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(145, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "Salary";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(144, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "Designation";
            // 
            // Department
            // 
            this.Department.AutoSize = true;
            this.Department.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Department.Location = new System.Drawing.Point(145, 111);
            this.Department.Name = "Department";
            this.Department.Size = new System.Drawing.Size(82, 15);
            this.Department.TabIndex = 15;
            this.Department.Text = "Department";
            // 
            // designationBox
            // 
            this.designationBox.FormattingEnabled = true;
            this.designationBox.Items.AddRange(new object[] {
            "Manager",
            "Deputy Manager",
            "Assistant Manager",
            "Senior Officer",
            "Officer",
            "Assistant Officer",
            "Trainee Officer"});
            this.designationBox.Location = new System.Drawing.Point(250, 161);
            this.designationBox.Name = "designationBox";
            this.designationBox.Size = new System.Drawing.Size(254, 21);
            this.designationBox.TabIndex = 14;
            // 
            // departmentBox
            // 
            this.departmentBox.FormattingEnabled = true;
            this.departmentBox.Items.AddRange(new object[] {
            "Human Resource",
            "IT",
            "Accounts",
            "Marketing"});
            this.departmentBox.Location = new System.Drawing.Point(250, 111);
            this.departmentBox.Name = "departmentBox";
            this.departmentBox.Size = new System.Drawing.Size(254, 21);
            this.departmentBox.TabIndex = 13;
            // 
            // empNameBox
            // 
            this.empNameBox.Location = new System.Drawing.Point(250, 62);
            this.empNameBox.Name = "empNameBox";
            this.empNameBox.Size = new System.Drawing.Size(254, 20);
            this.empNameBox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(145, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name";
            // 
            // btnClearES
            // 
            this.btnClearES.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnClearES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnClearES.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearES.Location = new System.Drawing.Point(396, 354);
            this.btnClearES.Name = "btnClearES";
            this.btnClearES.Size = new System.Drawing.Size(75, 32);
            this.btnClearES.TabIndex = 21;
            this.btnClearES.Text = "Clear";
            this.btnClearES.UseVisualStyleBackColor = false;
            this.btnClearES.Click += new System.EventHandler(this.btnClearES_Click);
            // 
            // btnSaveES
            // 
            this.btnSaveES.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveES.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveES.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSaveES.Location = new System.Drawing.Point(269, 354);
            this.btnSaveES.Name = "btnSaveES";
            this.btnSaveES.Size = new System.Drawing.Size(75, 32);
            this.btnSaveES.TabIndex = 20;
            this.btnSaveES.Text = "Save";
            this.btnSaveES.UseVisualStyleBackColor = false;
            this.btnSaveES.Click += new System.EventHandler(this.btnSaveES_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(148, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 15);
            this.label7.TabIndex = 22;
            this.label7.Text = "EmpID";
            // 
            // empIDBox
            // 
            this.empIDBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.personalInfoBindingSource, "empID", true));
            this.empIDBox.DataSource = this.personalInfoBindingSource;
            this.empIDBox.DisplayMember = "empID";
            this.empIDBox.FormattingEnabled = true;
            this.empIDBox.Location = new System.Drawing.Point(250, 19);
            this.empIDBox.Name = "empIDBox";
            this.empIDBox.Size = new System.Drawing.Size(254, 21);
            this.empIDBox.TabIndex = 23;
            this.empIDBox.ValueMember = "empID";
            // 
            // personalInfoBindingSource
            // 
            this.personalInfoBindingSource.DataMember = "personalInfo";
            this.personalInfoBindingSource.DataSource = this.empManagementSystemDataSet;
            // 
            // empManagementSystemDataSet
            // 
            this.empManagementSystemDataSet.DataSetName = "EmpManagementSystemDataSet";
            this.empManagementSystemDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personalInfoTableAdapter
            // 
            this.personalInfoTableAdapter.ClearBeforeFill = true;
            // 
            // empStatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.empIDBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.salaryBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Department);
            this.Controls.Add(this.designationBox);
            this.Controls.Add(this.departmentBox);
            this.Controls.Add(this.empNameBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClearES);
            this.Controls.Add(this.btnSaveES);
            this.Name = "empStatusForm";
            this.Size = new System.Drawing.Size(732, 415);
            this.Load += new System.EventHandler(this.empStatusForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personalInfoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.empManagementSystemDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox refContactBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox refNameBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox salaryBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Department;
        private System.Windows.Forms.ComboBox designationBox;
        private System.Windows.Forms.ComboBox departmentBox;
        private System.Windows.Forms.TextBox empNameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearES;
        private System.Windows.Forms.Button btnSaveES;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox empIDBox;
        private System.Windows.Forms.BindingSource personalInfoBindingSource;
        private EmpManagementSystemDataSet empManagementSystemDataSet;
        private EmpManagementSystemDataSetTableAdapters.personalInfoTableAdapter personalInfoTableAdapter;
    }
}
