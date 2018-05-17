namespace LMS_IS_WF
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.teacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeInformationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCourseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutLMSISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToStudentFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MY_COURSES_LISTVIEW = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.CREATE_COURSE = new System.Windows.Forms.Label();
            this.NAME_VALUE = new System.Windows.Forms.TextBox();
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.CAPACITY_LABEL = new System.Windows.Forms.Label();
            this.CAPACITY_VALUE = new System.Windows.Forms.TextBox();
            this.DETAIL_VALUE = new System.Windows.Forms.RichTextBox();
            this.DETAIL_LABEL = new System.Windows.Forms.Label();
            this.SPECIALIZATION_LABEL = new System.Windows.Forms.Label();
            this.SPECIALIZATION_CB = new System.Windows.Forms.ComboBox();
            this.START_DATE_DP = new System.Windows.Forms.DateTimePicker();
            this.START_DATE_LABEL = new System.Windows.Forms.Label();
            this.CREATE_BUTTON = new System.Windows.Forms.Button();
            this.CANCEL_BUTTON = new System.Windows.Forms.Button();
            this.WAITING_QUEUE_LABEL = new System.Windows.Forms.Label();
            this.WAITING_QUEUE_LW = new System.Windows.Forms.ListView();
            this.loginCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.REFRESH_BUTTON = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.teacherToolStripMenuItem,
            this.courseToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.switchToStudentFormToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(962, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // teacherToolStripMenuItem
            // 
            this.teacherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeInformationsToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.teacherToolStripMenuItem.Name = "teacherToolStripMenuItem";
            this.teacherToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.teacherToolStripMenuItem.Text = "Teacher";
            // 
            // changeInformationsToolStripMenuItem
            // 
            this.changeInformationsToolStripMenuItem.Name = "changeInformationsToolStripMenuItem";
            this.changeInformationsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.changeInformationsToolStripMenuItem.Text = "Change informations";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewCourseToolStripMenuItem,
            this.updateCourseToolStripMenuItem});
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.courseToolStripMenuItem.Text = "Course";
            // 
            // createNewCourseToolStripMenuItem
            // 
            this.createNewCourseToolStripMenuItem.Name = "createNewCourseToolStripMenuItem";
            this.createNewCourseToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.createNewCourseToolStripMenuItem.Text = "Create new course";
            // 
            // updateCourseToolStripMenuItem
            // 
            this.updateCourseToolStripMenuItem.Name = "updateCourseToolStripMenuItem";
            this.updateCourseToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.updateCourseToolStripMenuItem.Text = "Update course";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutLMSISToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutLMSISToolStripMenuItem
            // 
            this.aboutLMSISToolStripMenuItem.Name = "aboutLMSISToolStripMenuItem";
            this.aboutLMSISToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.aboutLMSISToolStripMenuItem.Text = "About LMSIS";
            // 
            // switchToStudentFormToolStripMenuItem
            // 
            this.switchToStudentFormToolStripMenuItem.Name = "switchToStudentFormToolStripMenuItem";
            this.switchToStudentFormToolStripMenuItem.Size = new System.Drawing.Size(140, 20);
            this.switchToStudentFormToolStripMenuItem.Text = "Switch to student form";
            this.switchToStudentFormToolStripMenuItem.Click += new System.EventHandler(this.switchToStudentFormToolStripMenuItem_Click);
            // 
            // MY_COURSES_LISTVIEW
            // 
            this.MY_COURSES_LISTVIEW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.NameColumn});
            this.MY_COURSES_LISTVIEW.FullRowSelect = true;
            this.MY_COURSES_LISTVIEW.Location = new System.Drawing.Point(12, 79);
            this.MY_COURSES_LISTVIEW.Name = "MY_COURSES_LISTVIEW";
            this.MY_COURSES_LISTVIEW.Size = new System.Drawing.Size(212, 423);
            this.MY_COURSES_LISTVIEW.TabIndex = 24;
            this.MY_COURSES_LISTVIEW.UseCompatibleStateImageBehavior = false;
            this.MY_COURSES_LISTVIEW.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            this.ID.Width = 34;
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Name";
            this.NameColumn.Width = 174;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 23;
            this.label1.Text = "My courses";
            // 
            // CREATE_COURSE
            // 
            this.CREATE_COURSE.AutoSize = true;
            this.CREATE_COURSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CREATE_COURSE.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CREATE_COURSE.Location = new System.Drawing.Point(264, 36);
            this.CREATE_COURSE.Name = "CREATE_COURSE";
            this.CREATE_COURSE.Size = new System.Drawing.Size(138, 22);
            this.CREATE_COURSE.TabIndex = 25;
            this.CREATE_COURSE.Text = "Create a course";
            // 
            // NAME_VALUE
            // 
            this.NAME_VALUE.Location = new System.Drawing.Point(265, 98);
            this.NAME_VALUE.Name = "NAME_VALUE";
            this.NAME_VALUE.Size = new System.Drawing.Size(223, 20);
            this.NAME_VALUE.TabIndex = 26;
            // 
            // NAME_LABEL
            // 
            this.NAME_LABEL.AutoSize = true;
            this.NAME_LABEL.Location = new System.Drawing.Point(265, 79);
            this.NAME_LABEL.Name = "NAME_LABEL";
            this.NAME_LABEL.Size = new System.Drawing.Size(35, 13);
            this.NAME_LABEL.TabIndex = 27;
            this.NAME_LABEL.Text = "Name";
            // 
            // CAPACITY_LABEL
            // 
            this.CAPACITY_LABEL.AutoSize = true;
            this.CAPACITY_LABEL.Location = new System.Drawing.Point(265, 134);
            this.CAPACITY_LABEL.Name = "CAPACITY_LABEL";
            this.CAPACITY_LABEL.Size = new System.Drawing.Size(48, 13);
            this.CAPACITY_LABEL.TabIndex = 29;
            this.CAPACITY_LABEL.Text = "Capacity";
            // 
            // CAPACITY_VALUE
            // 
            this.CAPACITY_VALUE.Location = new System.Drawing.Point(265, 153);
            this.CAPACITY_VALUE.Name = "CAPACITY_VALUE";
            this.CAPACITY_VALUE.Size = new System.Drawing.Size(223, 20);
            this.CAPACITY_VALUE.TabIndex = 28;
            // 
            // DETAIL_VALUE
            // 
            this.DETAIL_VALUE.Location = new System.Drawing.Point(265, 211);
            this.DETAIL_VALUE.Name = "DETAIL_VALUE";
            this.DETAIL_VALUE.Size = new System.Drawing.Size(223, 96);
            this.DETAIL_VALUE.TabIndex = 30;
            this.DETAIL_VALUE.Text = "";
            // 
            // DETAIL_LABEL
            // 
            this.DETAIL_LABEL.AutoSize = true;
            this.DETAIL_LABEL.Location = new System.Drawing.Point(265, 192);
            this.DETAIL_LABEL.Name = "DETAIL_LABEL";
            this.DETAIL_LABEL.Size = new System.Drawing.Size(34, 13);
            this.DETAIL_LABEL.TabIndex = 31;
            this.DETAIL_LABEL.Text = "Detail";
            // 
            // SPECIALIZATION_LABEL
            // 
            this.SPECIALIZATION_LABEL.AutoSize = true;
            this.SPECIALIZATION_LABEL.Location = new System.Drawing.Point(265, 324);
            this.SPECIALIZATION_LABEL.Name = "SPECIALIZATION_LABEL";
            this.SPECIALIZATION_LABEL.Size = new System.Drawing.Size(72, 13);
            this.SPECIALIZATION_LABEL.TabIndex = 32;
            this.SPECIALIZATION_LABEL.Text = "Specialization";
            // 
            // SPECIALIZATION_CB
            // 
            this.SPECIALIZATION_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SPECIALIZATION_CB.FormattingEnabled = true;
            this.SPECIALIZATION_CB.Location = new System.Drawing.Point(265, 344);
            this.SPECIALIZATION_CB.Name = "SPECIALIZATION_CB";
            this.SPECIALIZATION_CB.Size = new System.Drawing.Size(223, 21);
            this.SPECIALIZATION_CB.TabIndex = 33;
            // 
            // START_DATE_DP
            // 
            this.START_DATE_DP.Location = new System.Drawing.Point(265, 402);
            this.START_DATE_DP.Name = "START_DATE_DP";
            this.START_DATE_DP.Size = new System.Drawing.Size(223, 20);
            this.START_DATE_DP.TabIndex = 34;
            // 
            // START_DATE_LABEL
            // 
            this.START_DATE_LABEL.AutoSize = true;
            this.START_DATE_LABEL.Location = new System.Drawing.Point(265, 382);
            this.START_DATE_LABEL.Name = "START_DATE_LABEL";
            this.START_DATE_LABEL.Size = new System.Drawing.Size(53, 13);
            this.START_DATE_LABEL.TabIndex = 35;
            this.START_DATE_LABEL.Text = "Start date";
            // 
            // CREATE_BUTTON
            // 
            this.CREATE_BUTTON.Location = new System.Drawing.Point(265, 449);
            this.CREATE_BUTTON.Name = "CREATE_BUTTON";
            this.CREATE_BUTTON.Size = new System.Drawing.Size(106, 23);
            this.CREATE_BUTTON.TabIndex = 36;
            this.CREATE_BUTTON.Text = "Create";
            this.CREATE_BUTTON.UseVisualStyleBackColor = true;
            this.CREATE_BUTTON.Click += new System.EventHandler(this.CREATE_BUTTON_Click);
            // 
            // CANCEL_BUTTON
            // 
            this.CANCEL_BUTTON.Location = new System.Drawing.Point(377, 449);
            this.CANCEL_BUTTON.Name = "CANCEL_BUTTON";
            this.CANCEL_BUTTON.Size = new System.Drawing.Size(111, 23);
            this.CANCEL_BUTTON.TabIndex = 37;
            this.CANCEL_BUTTON.Text = "Cancel";
            this.CANCEL_BUTTON.UseVisualStyleBackColor = true;
            this.CANCEL_BUTTON.Click += new System.EventHandler(this.CANCEL_BUTTON_Click);
            // 
            // WAITING_QUEUE_LABEL
            // 
            this.WAITING_QUEUE_LABEL.AutoSize = true;
            this.WAITING_QUEUE_LABEL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WAITING_QUEUE_LABEL.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.WAITING_QUEUE_LABEL.Location = new System.Drawing.Point(568, 36);
            this.WAITING_QUEUE_LABEL.Name = "WAITING_QUEUE_LABEL";
            this.WAITING_QUEUE_LABEL.Size = new System.Drawing.Size(125, 22);
            this.WAITING_QUEUE_LABEL.TabIndex = 38;
            this.WAITING_QUEUE_LABEL.Text = "Waiting queue";
            // 
            // WAITING_QUEUE_LW
            // 
            this.WAITING_QUEUE_LW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.loginCol,
            this.nameCol});
            this.WAITING_QUEUE_LW.Location = new System.Drawing.Point(572, 79);
            this.WAITING_QUEUE_LW.Name = "WAITING_QUEUE_LW";
            this.WAITING_QUEUE_LW.Size = new System.Drawing.Size(333, 353);
            this.WAITING_QUEUE_LW.TabIndex = 39;
            this.WAITING_QUEUE_LW.UseCompatibleStateImageBehavior = false;
            this.WAITING_QUEUE_LW.View = System.Windows.Forms.View.Details;
            // 
            // loginCol
            // 
            this.loginCol.Text = "Login";
            this.loginCol.Width = 96;
            // 
            // nameCol
            // 
            this.nameCol.Text = "Name";
            this.nameCol.Width = 229;
            // 
            // REFRESH_BUTTON
            // 
            this.REFRESH_BUTTON.Location = new System.Drawing.Point(773, 449);
            this.REFRESH_BUTTON.Name = "REFRESH_BUTTON";
            this.REFRESH_BUTTON.Size = new System.Drawing.Size(132, 23);
            this.REFRESH_BUTTON.TabIndex = 40;
            this.REFRESH_BUTTON.Text = "Refresh waiting queue";
            this.REFRESH_BUTTON.UseVisualStyleBackColor = true;
            this.REFRESH_BUTTON.Click += new System.EventHandler(this.REFRESH_BUTTON_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 546);
            this.Controls.Add(this.REFRESH_BUTTON);
            this.Controls.Add(this.WAITING_QUEUE_LW);
            this.Controls.Add(this.WAITING_QUEUE_LABEL);
            this.Controls.Add(this.CANCEL_BUTTON);
            this.Controls.Add(this.CREATE_BUTTON);
            this.Controls.Add(this.START_DATE_LABEL);
            this.Controls.Add(this.START_DATE_DP);
            this.Controls.Add(this.SPECIALIZATION_CB);
            this.Controls.Add(this.SPECIALIZATION_LABEL);
            this.Controls.Add(this.DETAIL_LABEL);
            this.Controls.Add(this.DETAIL_VALUE);
            this.Controls.Add(this.CAPACITY_LABEL);
            this.Controls.Add(this.CAPACITY_VALUE);
            this.Controls.Add(this.NAME_LABEL);
            this.Controls.Add(this.NAME_VALUE);
            this.Controls.Add(this.CREATE_COURSE);
            this.Controls.Add(this.MY_COURSES_LISTVIEW);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem teacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeInformationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCourseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutLMSISToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToStudentFormToolStripMenuItem;
        private System.Windows.Forms.ListView MY_COURSES_LISTVIEW;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CREATE_COURSE;
        private System.Windows.Forms.TextBox NAME_VALUE;
        private System.Windows.Forms.Label NAME_LABEL;
        private System.Windows.Forms.Label CAPACITY_LABEL;
        private System.Windows.Forms.TextBox CAPACITY_VALUE;
        private System.Windows.Forms.RichTextBox DETAIL_VALUE;
        private System.Windows.Forms.Label DETAIL_LABEL;
        private System.Windows.Forms.Label SPECIALIZATION_LABEL;
        private System.Windows.Forms.ComboBox SPECIALIZATION_CB;
        private System.Windows.Forms.DateTimePicker START_DATE_DP;
        private System.Windows.Forms.Label START_DATE_LABEL;
        private System.Windows.Forms.Button CREATE_BUTTON;
        private System.Windows.Forms.Button CANCEL_BUTTON;
        private System.Windows.Forms.Label WAITING_QUEUE_LABEL;
        private System.Windows.Forms.ListView WAITING_QUEUE_LW;
        private System.Windows.Forms.Button REFRESH_BUTTON;
        private System.Windows.Forms.ColumnHeader loginCol;
        private System.Windows.Forms.ColumnHeader nameCol;
    }
}