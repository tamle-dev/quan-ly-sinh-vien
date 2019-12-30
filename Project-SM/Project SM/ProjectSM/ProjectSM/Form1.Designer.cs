namespace ProjectSM
{
    partial class SMForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMForm));
            this.buttonImport = new System.Windows.Forms.Button();
            this.comboBoxClass = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.comboBoxCourses = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxClassCourse = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonModify = new System.Windows.Forms.Button();
            this.comboBoxGrade = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonLogOFF = new System.Windows.Forms.Button();
            this.textBoxGrade = new System.Windows.Forms.TextBox();
            this.buttonAddjust = new System.Windows.Forms.Button();
            this.buttonData = new System.Windows.Forms.Button();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonChangePass = new System.Windows.Forms.Button();
            this.comboBoxViewGrade = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonImport
            // 
            this.buttonImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImport.Location = new System.Drawing.Point(885, 21);
            this.buttonImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonImport.Name = "buttonImport";
            this.buttonImport.Size = new System.Drawing.Size(128, 49);
            this.buttonImport.TabIndex = 1;
            this.buttonImport.Text = "Import CSV";
            this.buttonImport.UseVisualStyleBackColor = true;
            this.buttonImport.Click += new System.EventHandler(this.buttonImport_Click);
            // 
            // comboBoxClass
            // 
            this.comboBoxClass.FormattingEnabled = true;
            this.comboBoxClass.Location = new System.Drawing.Point(1039, 46);
            this.comboBoxClass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClass.Name = "comboBoxClass";
            this.comboBoxClass.Size = new System.Drawing.Size(163, 24);
            this.comboBoxClass.TabIndex = 2;
            this.comboBoxClass.SelectedIndexChanged += new System.EventHandler(this.comboBoxClass_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1040, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "View student in Class:";
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Location = new System.Drawing.Point(885, 79);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(128, 49);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Add Student";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // comboBoxCourses
            // 
            this.comboBoxCourses.FormattingEnabled = true;
            this.comboBoxCourses.Location = new System.Drawing.Point(1039, 102);
            this.comboBoxCourses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxCourses.Name = "comboBoxCourses";
            this.comboBoxCourses.Size = new System.Drawing.Size(163, 24);
            this.comboBoxCourses.TabIndex = 5;
            this.comboBoxCourses.SelectedIndexChanged += new System.EventHandler(this.comboBoxCourses_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1040, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "View courses of Class:";
            // 
            // comboBoxClassCourse
            // 
            this.comboBoxClassCourse.FormattingEnabled = true;
            this.comboBoxClassCourse.Location = new System.Drawing.Point(1039, 158);
            this.comboBoxClassCourse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxClassCourse.Name = "comboBoxClassCourse";
            this.comboBoxClassCourse.Size = new System.Drawing.Size(163, 24);
            this.comboBoxClassCourse.TabIndex = 7;
            this.comboBoxClassCourse.SelectedIndexChanged += new System.EventHandler(this.comboBoxClassCourse_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1039, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "View student in Courses:";
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(1238, 1);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(47, 42);
            this.buttonExit.TabIndex = 9;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonModify
            // 
            this.buttonModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModify.Location = new System.Drawing.Point(885, 134);
            this.buttonModify.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonModify.Name = "buttonModify";
            this.buttonModify.Size = new System.Drawing.Size(128, 49);
            this.buttonModify.TabIndex = 10;
            this.buttonModify.Text = "Modify";
            this.buttonModify.UseVisualStyleBackColor = true;
            this.buttonModify.Click += new System.EventHandler(this.buttonModify_Click);
            // 
            // comboBoxGrade
            // 
            this.comboBoxGrade.FormattingEnabled = true;
            this.comboBoxGrade.Location = new System.Drawing.Point(1039, 212);
            this.comboBoxGrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxGrade.Name = "comboBoxGrade";
            this.comboBoxGrade.Size = new System.Drawing.Size(163, 24);
            this.comboBoxGrade.TabIndex = 11;
            this.comboBoxGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxGrade_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1040, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Grade in Courses:";
            // 
            // buttonLogOFF
            // 
            this.buttonLogOFF.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonLogOFF.BackgroundImage")));
            this.buttonLogOFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOFF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogOFF.Location = new System.Drawing.Point(1226, 412);
            this.buttonLogOFF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogOFF.Name = "buttonLogOFF";
            this.buttonLogOFF.Size = new System.Drawing.Size(59, 62);
            this.buttonLogOFF.TabIndex = 13;
            this.buttonLogOFF.UseVisualStyleBackColor = true;
            this.buttonLogOFF.Click += new System.EventHandler(this.buttonLogOFF_Click);
            // 
            // textBoxGrade
            // 
            this.textBoxGrade.Enabled = false;
            this.textBoxGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGrade.Location = new System.Drawing.Point(1039, 242);
            this.textBoxGrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxGrade.Multiline = true;
            this.textBoxGrade.Name = "textBoxGrade";
            this.textBoxGrade.Size = new System.Drawing.Size(163, 87);
            this.textBoxGrade.TabIndex = 14;
            this.textBoxGrade.Visible = false;
            // 
            // buttonAddjust
            // 
            this.buttonAddjust.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddjust.Location = new System.Drawing.Point(885, 190);
            this.buttonAddjust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAddjust.Name = "buttonAddjust";
            this.buttonAddjust.Size = new System.Drawing.Size(128, 49);
            this.buttonAddjust.TabIndex = 15;
            this.buttonAddjust.Text = "Adjust Grade";
            this.buttonAddjust.UseVisualStyleBackColor = true;
            this.buttonAddjust.Click += new System.EventHandler(this.buttonAddjust_Click);
            // 
            // buttonData
            // 
            this.buttonData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonData.Location = new System.Drawing.Point(885, 242);
            this.buttonData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonData.Name = "buttonData";
            this.buttonData.Size = new System.Drawing.Size(128, 49);
            this.buttonData.TabIndex = 16;
            this.buttonData.Text = "Load Data";
            this.buttonData.UseVisualStyleBackColor = true;
            this.buttonData.Click += new System.EventHandler(this.buttonData_Click);
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.Location = new System.Drawing.Point(941, 362);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(159, 30);
            this.textBoxID.TabIndex = 20;
            // 
            // textBoxPass
            // 
            this.textBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPass.Location = new System.Drawing.Point(941, 404);
            this.textBoxPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(159, 30);
            this.textBoxPass.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(888, 361);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(888, 399);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(33, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // buttonLogin
            // 
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.Location = new System.Drawing.Point(888, 439);
            this.buttonLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(212, 33);
            this.buttonLogin.TabIndex = 24;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonChangePass
            // 
            this.buttonChangePass.Enabled = false;
            this.buttonChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChangePass.Location = new System.Drawing.Point(1105, 362);
            this.buttonChangePass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonChangePass.Name = "buttonChangePass";
            this.buttonChangePass.Size = new System.Drawing.Size(97, 111);
            this.buttonChangePass.TabIndex = 25;
            this.buttonChangePass.Text = "Change Password";
            this.buttonChangePass.UseVisualStyleBackColor = true;
            this.buttonChangePass.Visible = false;
            this.buttonChangePass.Click += new System.EventHandler(this.buttonChangePass_Click);
            // 
            // comboBoxViewGrade
            // 
            this.comboBoxViewGrade.FormattingEnabled = true;
            this.comboBoxViewGrade.Location = new System.Drawing.Point(888, 333);
            this.comboBoxViewGrade.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxViewGrade.Name = "comboBoxViewGrade";
            this.comboBoxViewGrade.Size = new System.Drawing.Size(319, 24);
            this.comboBoxViewGrade.TabIndex = 26;
            this.comboBoxViewGrade.SelectedIndexChanged += new System.EventHandler(this.comboBoxViewGrade_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Location = new System.Drawing.Point(1107, 363);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 30);
            this.buttonSave.TabIndex = 27;
            this.buttonSave.Text = "SAVE";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Visible = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Enabled = false;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Location = new System.Drawing.Point(1107, 404);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(97, 30);
            this.buttonCancel.TabIndex = 28;
            this.buttonCancel.Text = "CANCEL";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Visible = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // listView1
            // 
            this.listView1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("listView1.BackgroundImage")));
            this.listView1.Location = new System.Drawing.Point(5, 2);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(841, 470);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(1227, 46);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 362);
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            // 
            // SMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1286, 476);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxViewGrade);
            this.Controls.Add(this.buttonChangePass);
            this.Controls.Add(this.buttonLogin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxPass);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.buttonData);
            this.Controls.Add(this.buttonAddjust);
            this.Controls.Add(this.textBoxGrade);
            this.Controls.Add(this.buttonLogOFF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxGrade);
            this.Controls.Add(this.buttonModify);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxClassCourse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxCourses);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxClass);
            this.Controls.Add(this.buttonImport);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SMForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Managent";
            this.Load += new System.EventHandler(this.SMForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonImport;
        private System.Windows.Forms.ComboBox comboBoxClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.ComboBox comboBoxCourses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxClassCourse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonModify;
        private System.Windows.Forms.ComboBox comboBoxGrade;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonLogOFF;
        private System.Windows.Forms.TextBox textBoxGrade;
        private System.Windows.Forms.Button buttonAddjust;
        private System.Windows.Forms.Button buttonData;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonChangePass;
        private System.Windows.Forms.ComboBox comboBoxViewGrade;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

