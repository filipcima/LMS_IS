namespace LMS_IS_WF
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
            this.UPDATE_BUTTON = new System.Windows.Forms.Button();
            this.START_DATE_LABEL = new System.Windows.Forms.Label();
            this.START_DATE_DP = new System.Windows.Forms.DateTimePicker();
            this.SPECIALIZATION_CB = new System.Windows.Forms.ComboBox();
            this.SPECIALIZATION_LABEL = new System.Windows.Forms.Label();
            this.DETAIL_LABEL = new System.Windows.Forms.Label();
            this.DETAIL_VALUE = new System.Windows.Forms.RichTextBox();
            this.CAPACITY_LABEL = new System.Windows.Forms.Label();
            this.CAPACITY_VALUE = new System.Windows.Forms.TextBox();
            this.NAME_LABEL = new System.Windows.Forms.Label();
            this.NAME_VALUE = new System.Windows.Forms.TextBox();
            this.UPDATE_COURSE = new System.Windows.Forms.Label();
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
            this.COURSE_NAME = new System.Windows.Forms.Label();
            this.COURSE_CAPACITY = new System.Windows.Forms.Label();
            this.COURSE_SPECIALIZATION = new System.Windows.Forms.Label();
            this.COURSE_DESC = new System.Windows.Forms.Label();
            this.PAST_TESTS = new System.Windows.Forms.Label();
            this.UPC_TESTS = new System.Windows.Forms.Label();
            this.AVG_MARK = new System.Windows.Forms.Label();
            this.PAST_TESTS_LISTVIEW = new System.Windows.Forms.ListView();
            this.IdPisemka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MarkColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UPCOMING_TESTS_LISTVIEW = new System.Windows.Forms.ListView();
            this.IdCourse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.END_COURSE_BUTTON = new System.Windows.Forms.Button();
            this.CREATE_COURSE_BUTTON = new System.Windows.Forms.Button();
            this.ENDED = new System.Windows.Forms.Label();
            this.CREATE_TEST = new System.Windows.Forms.Button();
            this.TEST_DP = new System.Windows.Forms.DateTimePicker();
            this.TEST_DATE = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // UPDATE_BUTTON
            // 
            this.UPDATE_BUTTON.Location = new System.Drawing.Point(713, 455);
            this.UPDATE_BUTTON.Name = "UPDATE_BUTTON";
            this.UPDATE_BUTTON.Size = new System.Drawing.Size(223, 23);
            this.UPDATE_BUTTON.TabIndex = 55;
            this.UPDATE_BUTTON.Text = "Update";
            this.UPDATE_BUTTON.UseVisualStyleBackColor = true;
            this.UPDATE_BUTTON.Click += new System.EventHandler(this.UPDATE_BUTTON_Click);
            // 
            // START_DATE_LABEL
            // 
            this.START_DATE_LABEL.AutoSize = true;
            this.START_DATE_LABEL.Location = new System.Drawing.Point(713, 388);
            this.START_DATE_LABEL.Name = "START_DATE_LABEL";
            this.START_DATE_LABEL.Size = new System.Drawing.Size(53, 13);
            this.START_DATE_LABEL.TabIndex = 54;
            this.START_DATE_LABEL.Text = "Start date";
            // 
            // START_DATE_DP
            // 
            this.START_DATE_DP.Location = new System.Drawing.Point(713, 408);
            this.START_DATE_DP.Name = "START_DATE_DP";
            this.START_DATE_DP.Size = new System.Drawing.Size(223, 20);
            this.START_DATE_DP.TabIndex = 53;
            // 
            // SPECIALIZATION_CB
            // 
            this.SPECIALIZATION_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SPECIALIZATION_CB.FormattingEnabled = true;
            this.SPECIALIZATION_CB.Location = new System.Drawing.Point(713, 350);
            this.SPECIALIZATION_CB.Name = "SPECIALIZATION_CB";
            this.SPECIALIZATION_CB.Size = new System.Drawing.Size(223, 21);
            this.SPECIALIZATION_CB.TabIndex = 52;
            // 
            // SPECIALIZATION_LABEL
            // 
            this.SPECIALIZATION_LABEL.AutoSize = true;
            this.SPECIALIZATION_LABEL.Location = new System.Drawing.Point(713, 330);
            this.SPECIALIZATION_LABEL.Name = "SPECIALIZATION_LABEL";
            this.SPECIALIZATION_LABEL.Size = new System.Drawing.Size(72, 13);
            this.SPECIALIZATION_LABEL.TabIndex = 51;
            this.SPECIALIZATION_LABEL.Text = "Specialization";
            // 
            // DETAIL_LABEL
            // 
            this.DETAIL_LABEL.AutoSize = true;
            this.DETAIL_LABEL.Location = new System.Drawing.Point(713, 198);
            this.DETAIL_LABEL.Name = "DETAIL_LABEL";
            this.DETAIL_LABEL.Size = new System.Drawing.Size(34, 13);
            this.DETAIL_LABEL.TabIndex = 50;
            this.DETAIL_LABEL.Text = "Detail";
            // 
            // DETAIL_VALUE
            // 
            this.DETAIL_VALUE.Location = new System.Drawing.Point(713, 217);
            this.DETAIL_VALUE.Name = "DETAIL_VALUE";
            this.DETAIL_VALUE.Size = new System.Drawing.Size(223, 96);
            this.DETAIL_VALUE.TabIndex = 49;
            this.DETAIL_VALUE.Text = "";
            // 
            // CAPACITY_LABEL
            // 
            this.CAPACITY_LABEL.AutoSize = true;
            this.CAPACITY_LABEL.Location = new System.Drawing.Point(713, 140);
            this.CAPACITY_LABEL.Name = "CAPACITY_LABEL";
            this.CAPACITY_LABEL.Size = new System.Drawing.Size(48, 13);
            this.CAPACITY_LABEL.TabIndex = 48;
            this.CAPACITY_LABEL.Text = "Capacity";
            // 
            // CAPACITY_VALUE
            // 
            this.CAPACITY_VALUE.Location = new System.Drawing.Point(713, 159);
            this.CAPACITY_VALUE.Name = "CAPACITY_VALUE";
            this.CAPACITY_VALUE.Size = new System.Drawing.Size(223, 20);
            this.CAPACITY_VALUE.TabIndex = 47;
            // 
            // NAME_LABEL
            // 
            this.NAME_LABEL.AutoSize = true;
            this.NAME_LABEL.Location = new System.Drawing.Point(713, 85);
            this.NAME_LABEL.Name = "NAME_LABEL";
            this.NAME_LABEL.Size = new System.Drawing.Size(35, 13);
            this.NAME_LABEL.TabIndex = 46;
            this.NAME_LABEL.Text = "Name";
            // 
            // NAME_VALUE
            // 
            this.NAME_VALUE.Location = new System.Drawing.Point(713, 104);
            this.NAME_VALUE.Name = "NAME_VALUE";
            this.NAME_VALUE.Size = new System.Drawing.Size(223, 20);
            this.NAME_VALUE.TabIndex = 45;
            // 
            // UPDATE_COURSE
            // 
            this.UPDATE_COURSE.AutoSize = true;
            this.UPDATE_COURSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UPDATE_COURSE.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UPDATE_COURSE.Location = new System.Drawing.Point(709, 41);
            this.UPDATE_COURSE.Name = "UPDATE_COURSE";
            this.UPDATE_COURSE.Size = new System.Drawing.Size(160, 22);
            this.UPDATE_COURSE.TabIndex = 44;
            this.UPDATE_COURSE.Text = "Update this course";
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
            this.menuStrip1.Size = new System.Drawing.Size(961, 24);
            this.menuStrip1.TabIndex = 41;
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
            this.MY_COURSES_LISTVIEW.Location = new System.Drawing.Point(12, 75);
            this.MY_COURSES_LISTVIEW.Name = "MY_COURSES_LISTVIEW";
            this.MY_COURSES_LISTVIEW.Size = new System.Drawing.Size(212, 403);
            this.MY_COURSES_LISTVIEW.TabIndex = 43;
            this.MY_COURSES_LISTVIEW.UseCompatibleStateImageBehavior = false;
            this.MY_COURSES_LISTVIEW.View = System.Windows.Forms.View.Details;
            this.MY_COURSES_LISTVIEW.SelectedIndexChanged += new System.EventHandler(this.MY_COURSES_LISTVIEW_SelectedIndexChanged);
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
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 22);
            this.label1.TabIndex = 42;
            this.label1.Text = "My courses";
            // 
            // COURSE_NAME
            // 
            this.COURSE_NAME.AutoSize = true;
            this.COURSE_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.COURSE_NAME.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.COURSE_NAME.Location = new System.Drawing.Point(254, 41);
            this.COURSE_NAME.Name = "COURSE_NAME";
            this.COURSE_NAME.Size = new System.Drawing.Size(148, 22);
            this.COURSE_NAME.TabIndex = 56;
            this.COURSE_NAME.Text = "COURSE_NAME";
            // 
            // COURSE_CAPACITY
            // 
            this.COURSE_CAPACITY.AutoSize = true;
            this.COURSE_CAPACITY.Location = new System.Drawing.Point(257, 82);
            this.COURSE_CAPACITY.Name = "COURSE_CAPACITY";
            this.COURSE_CAPACITY.Size = new System.Drawing.Size(110, 13);
            this.COURSE_CAPACITY.TabIndex = 57;
            this.COURSE_CAPACITY.Text = "COURSE_CAPACITY";
            // 
            // COURSE_SPECIALIZATION
            // 
            this.COURSE_SPECIALIZATION.AutoSize = true;
            this.COURSE_SPECIALIZATION.Location = new System.Drawing.Point(257, 111);
            this.COURSE_SPECIALIZATION.Name = "COURSE_SPECIALIZATION";
            this.COURSE_SPECIALIZATION.Size = new System.Drawing.Size(145, 13);
            this.COURSE_SPECIALIZATION.TabIndex = 58;
            this.COURSE_SPECIALIZATION.Text = "COURSE_SPECIALIZATION";
            // 
            // COURSE_DESC
            // 
            this.COURSE_DESC.AutoSize = true;
            this.COURSE_DESC.Location = new System.Drawing.Point(257, 140);
            this.COURSE_DESC.Name = "COURSE_DESC";
            this.COURSE_DESC.Size = new System.Drawing.Size(87, 13);
            this.COURSE_DESC.TabIndex = 59;
            this.COURSE_DESC.Text = "COURSE_DESC";
            // 
            // PAST_TESTS
            // 
            this.PAST_TESTS.AutoSize = true;
            this.PAST_TESTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PAST_TESTS.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PAST_TESTS.Location = new System.Drawing.Point(516, 204);
            this.PAST_TESTS.Name = "PAST_TESTS";
            this.PAST_TESTS.Size = new System.Drawing.Size(89, 22);
            this.PAST_TESTS.TabIndex = 61;
            this.PAST_TESTS.Text = "Past tests";
            // 
            // UPC_TESTS
            // 
            this.UPC_TESTS.AutoSize = true;
            this.UPC_TESTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UPC_TESTS.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UPC_TESTS.Location = new System.Drawing.Point(285, 204);
            this.UPC_TESTS.Name = "UPC_TESTS";
            this.UPC_TESTS.Size = new System.Drawing.Size(133, 22);
            this.UPC_TESTS.TabIndex = 62;
            this.UPC_TESTS.Text = "Upcoming tests";
            // 
            // AVG_MARK
            // 
            this.AVG_MARK.AutoSize = true;
            this.AVG_MARK.Location = new System.Drawing.Point(257, 388);
            this.AVG_MARK.Name = "AVG_MARK";
            this.AVG_MARK.Size = new System.Drawing.Size(66, 13);
            this.AVG_MARK.TabIndex = 63;
            this.AVG_MARK.Text = "AVG_MARK";
            // 
            // PAST_TESTS_LISTVIEW
            // 
            this.PAST_TESTS_LISTVIEW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdPisemka,
            this.columnHeader2,
            this.MarkColumn});
            this.PAST_TESTS_LISTVIEW.FullRowSelect = true;
            this.PAST_TESTS_LISTVIEW.Location = new System.Drawing.Point(473, 243);
            this.PAST_TESTS_LISTVIEW.Name = "PAST_TESTS_LISTVIEW";
            this.PAST_TESTS_LISTVIEW.Size = new System.Drawing.Size(181, 113);
            this.PAST_TESTS_LISTVIEW.TabIndex = 65;
            this.PAST_TESTS_LISTVIEW.UseCompatibleStateImageBehavior = false;
            this.PAST_TESTS_LISTVIEW.View = System.Windows.Forms.View.Details;
            // 
            // IdPisemka
            // 
            this.IdPisemka.Text = "ID";
            this.IdPisemka.Width = 28;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            this.columnHeader2.Width = 110;
            // 
            // MarkColumn
            // 
            this.MarkColumn.Text = "Mark";
            this.MarkColumn.Width = 37;
            // 
            // UPCOMING_TESTS_LISTVIEW
            // 
            this.UPCOMING_TESTS_LISTVIEW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdCourse,
            this.DateColumn});
            this.UPCOMING_TESTS_LISTVIEW.FullRowSelect = true;
            this.UPCOMING_TESTS_LISTVIEW.Location = new System.Drawing.Point(263, 243);
            this.UPCOMING_TESTS_LISTVIEW.Name = "UPCOMING_TESTS_LISTVIEW";
            this.UPCOMING_TESTS_LISTVIEW.Size = new System.Drawing.Size(181, 113);
            this.UPCOMING_TESTS_LISTVIEW.TabIndex = 64;
            this.UPCOMING_TESTS_LISTVIEW.UseCompatibleStateImageBehavior = false;
            this.UPCOMING_TESTS_LISTVIEW.View = System.Windows.Forms.View.Details;
            // 
            // IdCourse
            // 
            this.IdCourse.Text = "ID";
            this.IdCourse.Width = 30;
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Date";
            this.DateColumn.Width = 145;
            // 
            // END_COURSE_BUTTON
            // 
            this.END_COURSE_BUTTON.Location = new System.Drawing.Point(126, 484);
            this.END_COURSE_BUTTON.Name = "END_COURSE_BUTTON";
            this.END_COURSE_BUTTON.Size = new System.Drawing.Size(98, 23);
            this.END_COURSE_BUTTON.TabIndex = 66;
            this.END_COURSE_BUTTON.Text = "End course";
            this.END_COURSE_BUTTON.UseVisualStyleBackColor = true;
            this.END_COURSE_BUTTON.Click += new System.EventHandler(this.END_COURSE_BUTTON_Click);
            // 
            // CREATE_COURSE_BUTTON
            // 
            this.CREATE_COURSE_BUTTON.Location = new System.Drawing.Point(12, 484);
            this.CREATE_COURSE_BUTTON.Name = "CREATE_COURSE_BUTTON";
            this.CREATE_COURSE_BUTTON.Size = new System.Drawing.Size(98, 23);
            this.CREATE_COURSE_BUTTON.TabIndex = 67;
            this.CREATE_COURSE_BUTTON.Text = "Create course";
            this.CREATE_COURSE_BUTTON.UseVisualStyleBackColor = true;
            this.CREATE_COURSE_BUTTON.Click += new System.EventHandler(this.CREATE_COURSE_BUTTON_Click);
            // 
            // ENDED
            // 
            this.ENDED.AutoSize = true;
            this.ENDED.Location = new System.Drawing.Point(257, 414);
            this.ENDED.Name = "ENDED";
            this.ENDED.Size = new System.Drawing.Size(45, 13);
            this.ENDED.TabIndex = 68;
            this.ENDED.Text = "ENDED";
            // 
            // CREATE_TEST
            // 
            this.CREATE_TEST.Location = new System.Drawing.Point(430, 455);
            this.CREATE_TEST.Name = "CREATE_TEST";
            this.CREATE_TEST.Size = new System.Drawing.Size(224, 23);
            this.CREATE_TEST.TabIndex = 69;
            this.CREATE_TEST.Text = "Create test";
            this.CREATE_TEST.UseVisualStyleBackColor = true;
            this.CREATE_TEST.Click += new System.EventHandler(this.CREATE_TEST_Click);
            // 
            // TEST_DP
            // 
            this.TEST_DP.Location = new System.Drawing.Point(431, 418);
            this.TEST_DP.Name = "TEST_DP";
            this.TEST_DP.Size = new System.Drawing.Size(223, 20);
            this.TEST_DP.TabIndex = 70;
            // 
            // TEST_DATE
            // 
            this.TEST_DATE.AutoSize = true;
            this.TEST_DATE.Location = new System.Drawing.Point(428, 397);
            this.TEST_DATE.Name = "TEST_DATE";
            this.TEST_DATE.Size = new System.Drawing.Size(52, 13);
            this.TEST_DATE.TabIndex = 71;
            this.TEST_DATE.Text = "Test date";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 547);
            this.Controls.Add(this.TEST_DATE);
            this.Controls.Add(this.TEST_DP);
            this.Controls.Add(this.CREATE_TEST);
            this.Controls.Add(this.ENDED);
            this.Controls.Add(this.CREATE_COURSE_BUTTON);
            this.Controls.Add(this.END_COURSE_BUTTON);
            this.Controls.Add(this.PAST_TESTS_LISTVIEW);
            this.Controls.Add(this.UPCOMING_TESTS_LISTVIEW);
            this.Controls.Add(this.AVG_MARK);
            this.Controls.Add(this.UPC_TESTS);
            this.Controls.Add(this.PAST_TESTS);
            this.Controls.Add(this.COURSE_DESC);
            this.Controls.Add(this.COURSE_SPECIALIZATION);
            this.Controls.Add(this.COURSE_CAPACITY);
            this.Controls.Add(this.COURSE_NAME);
            this.Controls.Add(this.UPDATE_BUTTON);
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
            this.Controls.Add(this.UPDATE_COURSE);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.MY_COURSES_LISTVIEW);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button UPDATE_BUTTON;
        private System.Windows.Forms.Label START_DATE_LABEL;
        private System.Windows.Forms.DateTimePicker START_DATE_DP;
        private System.Windows.Forms.ComboBox SPECIALIZATION_CB;
        private System.Windows.Forms.Label SPECIALIZATION_LABEL;
        private System.Windows.Forms.Label DETAIL_LABEL;
        private System.Windows.Forms.RichTextBox DETAIL_VALUE;
        private System.Windows.Forms.Label CAPACITY_LABEL;
        private System.Windows.Forms.TextBox CAPACITY_VALUE;
        private System.Windows.Forms.Label NAME_LABEL;
        private System.Windows.Forms.TextBox NAME_VALUE;
        private System.Windows.Forms.Label UPDATE_COURSE;
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
        private System.Windows.Forms.Label COURSE_NAME;
        private System.Windows.Forms.Label COURSE_CAPACITY;
        private System.Windows.Forms.Label COURSE_SPECIALIZATION;
        private System.Windows.Forms.Label COURSE_DESC;
        private System.Windows.Forms.Label PAST_TESTS;
        private System.Windows.Forms.Label UPC_TESTS;
        private System.Windows.Forms.Label AVG_MARK;
        private System.Windows.Forms.ListView PAST_TESTS_LISTVIEW;
        private System.Windows.Forms.ColumnHeader IdPisemka;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader MarkColumn;
        private System.Windows.Forms.ListView UPCOMING_TESTS_LISTVIEW;
        private System.Windows.Forms.ColumnHeader IdCourse;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.Button END_COURSE_BUTTON;
        private System.Windows.Forms.Button CREATE_COURSE_BUTTON;
        private System.Windows.Forms.Label ENDED;
        private System.Windows.Forms.Button CREATE_TEST;
        private System.Windows.Forms.DateTimePicker TEST_DP;
        private System.Windows.Forms.Label TEST_DATE;
    }
}