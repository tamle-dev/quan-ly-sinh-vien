namespace ProjectSM
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.comboBoxSt = new System.Windows.Forms.ComboBox();
            this.comboBoxCs = new System.Windows.Forms.ComboBox();
            this.comboBoxSt2 = new System.Windows.Forms.ComboBox();
            this.comboBoxCs2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAdd
            // 
            this.buttonAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAdd.Location = new System.Drawing.Point(36, 41);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(93, 29);
            this.buttonAdd.TabIndex = 0;
            this.buttonAdd.Text = "Add student";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.Location = new System.Drawing.Point(36, 84);
            this.buttonRemove.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(93, 29);
            this.buttonRemove.TabIndex = 1;
            this.buttonRemove.Text = "Remove student";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // comboBoxSt
            // 
            this.comboBoxSt.FormattingEnabled = true;
            this.comboBoxSt.Location = new System.Drawing.Point(142, 47);
            this.comboBoxSt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxSt.Name = "comboBoxSt";
            this.comboBoxSt.Size = new System.Drawing.Size(143, 21);
            this.comboBoxSt.TabIndex = 2;
            // 
            // comboBoxCs
            // 
            this.comboBoxCs.FormattingEnabled = true;
            this.comboBoxCs.Location = new System.Drawing.Point(329, 47);
            this.comboBoxCs.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCs.Name = "comboBoxCs";
            this.comboBoxCs.Size = new System.Drawing.Size(143, 21);
            this.comboBoxCs.TabIndex = 3;
            // 
            // comboBoxSt2
            // 
            this.comboBoxSt2.FormattingEnabled = true;
            this.comboBoxSt2.Location = new System.Drawing.Point(142, 89);
            this.comboBoxSt2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxSt2.Name = "comboBoxSt2";
            this.comboBoxSt2.Size = new System.Drawing.Size(143, 21);
            this.comboBoxSt2.TabIndex = 4;
            // 
            // comboBoxCs2
            // 
            this.comboBoxCs2.FormattingEnabled = true;
            this.comboBoxCs2.Location = new System.Drawing.Point(329, 92);
            this.comboBoxCs2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxCs2.Name = "comboBoxCs2";
            this.comboBoxCs2.Size = new System.Drawing.Size(143, 21);
            this.comboBoxCs2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "TO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(289, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "FROM";
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Location = new System.Drawing.Point(476, 0);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(35, 34);
            this.buttonExit.TabIndex = 8;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 151);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCs2);
            this.Controls.Add(this.comboBoxSt2);
            this.Controls.Add(this.comboBoxCs);
            this.Controls.Add(this.comboBoxSt);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modify ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.ComboBox comboBoxSt;
        private System.Windows.Forms.ComboBox comboBoxCs;
        private System.Windows.Forms.ComboBox comboBoxSt2;
        private System.Windows.Forms.ComboBox comboBoxCs2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonExit;
    }
}