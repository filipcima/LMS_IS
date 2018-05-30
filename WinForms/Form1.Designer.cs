namespace LMS_IS_WF
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.studentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.courseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactTeacherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutLMSISToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.my_courses = new System.Windows.Forms.Label();
            this.MY_COURSES_LISTVIEW = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COURSE_NAME = new System.Windows.Forms.Label();
            this.COURSE_DESC = new System.Windows.Forms.Label();
            this.AVAIL_COURSES_CB = new System.Windows.Forms.ComboBox();
            this.SIGN_COURSE_BUTTON = new System.Windows.Forms.Button();
            this.UPCOMING_TESTS = new System.Windows.Forms.Label();
            this.PAST_TESTS = new System.Windows.Forms.Label();
            this.STATUS = new System.Windows.Forms.Label();
            this.LEARNING_MATERIALS = new System.Windows.Forms.Label();
            this.UPCOMING_TESTS_LISTVIEW = new System.Windows.Forms.ListView();
            this.IdCourse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LEARNING_MATERIALS_LISTVIEW = new System.Windows.Forms.ListView();
            this.PAST_TESTS_LISTVIEW = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MarkColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SIGN_OUT_BUTTON = new System.Windows.Forms.Button();
            this.AVERAGE_MARK = new System.Windows.Forms.Label();
            this.DATE_OF_SIGN = new System.Windows.Forms.Label();
            this.COMPLETED = new System.Windows.Forms.Label();
            this.IdPisemka = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.IDMaterial = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NameCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TextCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AuthorCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.switchToTeacherViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentToolStripMenuItem,
            this.courseToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.switchToTeacherViewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(967, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // studentToolStripMenuItem
            // 
            this.studentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.studentToolStripMenuItem.Name = "studentToolStripMenuItem";
            this.studentToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.studentToolStripMenuItem.Text = "Student";
            // 
            // accountToolStripMenuItem
            // 
            this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
            this.accountToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.accountToolStripMenuItem.Text = "Account";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // courseToolStripMenuItem
            // 
            this.courseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contactTeacherToolStripMenuItem,
            this.showStudentsToolStripMenuItem});
            this.courseToolStripMenuItem.Name = "courseToolStripMenuItem";
            this.courseToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.courseToolStripMenuItem.Text = "Course";
            // 
            // contactTeacherToolStripMenuItem
            // 
            this.contactTeacherToolStripMenuItem.Name = "contactTeacherToolStripMenuItem";
            this.contactTeacherToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.contactTeacherToolStripMenuItem.Text = "Contact teacher";
            // 
            // showStudentsToolStripMenuItem
            // 
            this.showStudentsToolStripMenuItem.Name = "showStudentsToolStripMenuItem";
            this.showStudentsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showStudentsToolStripMenuItem.Text = "Show students";
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
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // my_courses
            // 
            this.my_courses.AutoSize = true;
            this.my_courses.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.my_courses.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.my_courses.Location = new System.Drawing.Point(16, 42);
            this.my_courses.Name = "my_courses";
            this.my_courses.Size = new System.Drawing.Size(101, 22);
            this.my_courses.TabIndex = 1;
            this.my_courses.Text = "My courses";
            // 
            // MY_COURSES_LISTVIEW
            // 
            this.MY_COURSES_LISTVIEW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.NameColumn});
            this.MY_COURSES_LISTVIEW.FullRowSelect = true;
            this.MY_COURSES_LISTVIEW.Location = new System.Drawing.Point(12, 85);
            this.MY_COURSES_LISTVIEW.Name = "MY_COURSES_LISTVIEW";
            this.MY_COURSES_LISTVIEW.Size = new System.Drawing.Size(212, 337);
            this.MY_COURSES_LISTVIEW.TabIndex = 2;
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
            // COURSE_NAME
            // 
            this.COURSE_NAME.AutoSize = true;
            this.COURSE_NAME.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.COURSE_NAME.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.COURSE_NAME.Location = new System.Drawing.Point(269, 42);
            this.COURSE_NAME.Name = "COURSE_NAME";
            this.COURSE_NAME.Size = new System.Drawing.Size(148, 22);
            this.COURSE_NAME.TabIndex = 3;
            this.COURSE_NAME.Text = "COURSE_NAME";
            // 
            // COURSE_DESC
            // 
            this.COURSE_DESC.AutoSize = true;
            this.COURSE_DESC.Location = new System.Drawing.Point(273, 85);
            this.COURSE_DESC.Name = "COURSE_DESC";
            this.COURSE_DESC.Size = new System.Drawing.Size(87, 13);
            this.COURSE_DESC.TabIndex = 4;
            this.COURSE_DESC.Text = "COURSE_DESC";
            // 
            // AVAIL_COURSES_CB
            // 
            this.AVAIL_COURSES_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AVAIL_COURSES_CB.FormattingEnabled = true;
            this.AVAIL_COURSES_CB.Location = new System.Drawing.Point(12, 439);
            this.AVAIL_COURSES_CB.Name = "AVAIL_COURSES_CB";
            this.AVAIL_COURSES_CB.Size = new System.Drawing.Size(212, 21);
            this.AVAIL_COURSES_CB.TabIndex = 5;
            // 
            // SIGN_COURSE_BUTTON
            // 
            this.SIGN_COURSE_BUTTON.Location = new System.Drawing.Point(42, 466);
            this.SIGN_COURSE_BUTTON.Name = "SIGN_COURSE_BUTTON";
            this.SIGN_COURSE_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.SIGN_COURSE_BUTTON.TabIndex = 6;
            this.SIGN_COURSE_BUTTON.Text = "Sign this";
            this.SIGN_COURSE_BUTTON.UseVisualStyleBackColor = true;
            this.SIGN_COURSE_BUTTON.Click += new System.EventHandler(this.SIGN_COURSE_BUTTON_Click);
            // 
            // UPCOMING_TESTS
            // 
            this.UPCOMING_TESTS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UPCOMING_TESTS.AutoSize = true;
            this.UPCOMING_TESTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UPCOMING_TESTS.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.UPCOMING_TESTS.Location = new System.Drawing.Point(298, 146);
            this.UPCOMING_TESTS.Name = "UPCOMING_TESTS";
            this.UPCOMING_TESTS.Size = new System.Drawing.Size(133, 22);
            this.UPCOMING_TESTS.TabIndex = 7;
            this.UPCOMING_TESTS.Text = "Upcoming tests";
            this.UPCOMING_TESTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PAST_TESTS
            // 
            this.PAST_TESTS.AutoSize = true;
            this.PAST_TESTS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PAST_TESTS.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.PAST_TESTS.Location = new System.Drawing.Point(508, 146);
            this.PAST_TESTS.Name = "PAST_TESTS";
            this.PAST_TESTS.Size = new System.Drawing.Size(89, 22);
            this.PAST_TESTS.TabIndex = 8;
            this.PAST_TESTS.Text = "Past tests";
            this.PAST_TESTS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // STATUS
            // 
            this.STATUS.AutoSize = true;
            this.STATUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.STATUS.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.STATUS.Location = new System.Drawing.Point(725, 146);
            this.STATUS.Name = "STATUS";
            this.STATUS.Size = new System.Drawing.Size(61, 22);
            this.STATUS.TabIndex = 9;
            this.STATUS.Text = "Status";
            this.STATUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LEARNING_MATERIALS
            // 
            this.LEARNING_MATERIALS.AutoSize = true;
            this.LEARNING_MATERIALS.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LEARNING_MATERIALS.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LEARNING_MATERIALS.Location = new System.Drawing.Point(274, 330);
            this.LEARNING_MATERIALS.Name = "LEARNING_MATERIALS";
            this.LEARNING_MATERIALS.Size = new System.Drawing.Size(157, 22);
            this.LEARNING_MATERIALS.TabIndex = 10;
            this.LEARNING_MATERIALS.Text = "Learning materials";
            // 
            // UPCOMING_TESTS_LISTVIEW
            // 
            this.UPCOMING_TESTS_LISTVIEW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdCourse,
            this.DateColumn});
            this.UPCOMING_TESTS_LISTVIEW.FullRowSelect = true;
            this.UPCOMING_TESTS_LISTVIEW.Location = new System.Drawing.Point(302, 171);
            this.UPCOMING_TESTS_LISTVIEW.Name = "UPCOMING_TESTS_LISTVIEW";
            this.UPCOMING_TESTS_LISTVIEW.Size = new System.Drawing.Size(181, 113);
            this.UPCOMING_TESTS_LISTVIEW.TabIndex = 14;
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
            // LEARNING_MATERIALS_LISTVIEW
            // 
            this.LEARNING_MATERIALS_LISTVIEW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDMaterial,
            this.NameCol,
            this.TextCol,
            this.AuthorCol});
            this.LEARNING_MATERIALS_LISTVIEW.Location = new System.Drawing.Point(276, 355);
            this.LEARNING_MATERIALS_LISTVIEW.Name = "LEARNING_MATERIALS_LISTVIEW";
            this.LEARNING_MATERIALS_LISTVIEW.Size = new System.Drawing.Size(634, 160);
            this.LEARNING_MATERIALS_LISTVIEW.TabIndex = 15;
            this.LEARNING_MATERIALS_LISTVIEW.UseCompatibleStateImageBehavior = false;
            this.LEARNING_MATERIALS_LISTVIEW.View = System.Windows.Forms.View.Details;
            // 
            // PAST_TESTS_LISTVIEW
            // 
            this.PAST_TESTS_LISTVIEW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IdPisemka,
            this.columnHeader2,
            this.MarkColumn});
            this.PAST_TESTS_LISTVIEW.FullRowSelect = true;
            this.PAST_TESTS_LISTVIEW.Location = new System.Drawing.Point(512, 171);
            this.PAST_TESTS_LISTVIEW.Name = "PAST_TESTS_LISTVIEW";
            this.PAST_TESTS_LISTVIEW.Size = new System.Drawing.Size(181, 113);
            this.PAST_TESTS_LISTVIEW.TabIndex = 18;
            this.PAST_TESTS_LISTVIEW.UseCompatibleStateImageBehavior = false;
            this.PAST_TESTS_LISTVIEW.View = System.Windows.Forms.View.Details;
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
            // SIGN_OUT_BUTTON
            // 
            this.SIGN_OUT_BUTTON.Location = new System.Drawing.Point(123, 466);
            this.SIGN_OUT_BUTTON.Name = "SIGN_OUT_BUTTON";
            this.SIGN_OUT_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.SIGN_OUT_BUTTON.TabIndex = 19;
            this.SIGN_OUT_BUTTON.Text = "Sign out";
            this.SIGN_OUT_BUTTON.UseVisualStyleBackColor = true;
            this.SIGN_OUT_BUTTON.Click += new System.EventHandler(this.SIGN_OUT_BUTTON_Click);
            // 
            // AVERAGE_MARK
            // 
            this.AVERAGE_MARK.AutoSize = true;
            this.AVERAGE_MARK.Location = new System.Drawing.Point(726, 180);
            this.AVERAGE_MARK.Name = "AVERAGE_MARK";
            this.AVERAGE_MARK.Size = new System.Drawing.Size(76, 13);
            this.AVERAGE_MARK.TabIndex = 20;
            this.AVERAGE_MARK.Text = "Avg. mark: 1.0";
            // 
            // DATE_OF_SIGN
            // 
            this.DATE_OF_SIGN.AutoSize = true;
            this.DATE_OF_SIGN.Location = new System.Drawing.Point(726, 195);
            this.DATE_OF_SIGN.Name = "DATE_OF_SIGN";
            this.DATE_OF_SIGN.Size = new System.Drawing.Size(124, 13);
            this.DATE_OF_SIGN.TabIndex = 21;
            this.DATE_OF_SIGN.Text = "Date of sign: 21. 3. 2018";
            // 
            // COMPLETED
            // 
            this.COMPLETED.AutoSize = true;
            this.COMPLETED.Location = new System.Drawing.Point(726, 211);
            this.COMPLETED.Name = "COMPLETED";
            this.COMPLETED.Size = new System.Drawing.Size(79, 13);
            this.COMPLETED.TabIndex = 22;
            this.COMPLETED.Text = "Completed: yes";
            // 
            // IdPisemka
            // 
            this.IdPisemka.Text = "ID";
            this.IdPisemka.Width = 28;
            // 
            // IDMaterial
            // 
            this.IDMaterial.Text = "ID";
            this.IDMaterial.Width = 33;
            // 
            // NameCol
            // 
            this.NameCol.Text = "Name";
            this.NameCol.Width = 134;
            // 
            // TextCol
            // 
            this.TextCol.Text = "Text";
            this.TextCol.Width = 377;
            // 
            // AuthorCol
            // 
            this.AuthorCol.Text = "Author";
            this.AuthorCol.Width = 82;
            // 
            // switchToTeacherViewToolStripMenuItem
            // 
            this.switchToTeacherViewToolStripMenuItem.Name = "switchToTeacherViewToolStripMenuItem";
            this.switchToTeacherViewToolStripMenuItem.Size = new System.Drawing.Size(137, 20);
            this.switchToTeacherViewToolStripMenuItem.Text = "Switch to teacher view";
            this.switchToTeacherViewToolStripMenuItem.Click += new System.EventHandler(this.switchToTeacherViewToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 560);
            this.Controls.Add(this.COMPLETED);
            this.Controls.Add(this.DATE_OF_SIGN);
            this.Controls.Add(this.AVERAGE_MARK);
            this.Controls.Add(this.SIGN_OUT_BUTTON);
            this.Controls.Add(this.PAST_TESTS_LISTVIEW);
            this.Controls.Add(this.LEARNING_MATERIALS_LISTVIEW);
            this.Controls.Add(this.UPCOMING_TESTS_LISTVIEW);
            this.Controls.Add(this.LEARNING_MATERIALS);
            this.Controls.Add(this.STATUS);
            this.Controls.Add(this.PAST_TESTS);
            this.Controls.Add(this.UPCOMING_TESTS);
            this.Controls.Add(this.SIGN_COURSE_BUTTON);
            this.Controls.Add(this.AVAIL_COURSES_CB);
            this.Controls.Add(this.COURSE_DESC);
            this.Controls.Add(this.COURSE_NAME);
            this.Controls.Add(this.MY_COURSES_LISTVIEW);
            this.Controls.Add(this.my_courses);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "LMSIS";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem studentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem courseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactTeacherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutLMSISToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label my_courses;
        private System.Windows.Forms.ListView MY_COURSES_LISTVIEW;
        private System.Windows.Forms.Label COURSE_NAME;
        private System.Windows.Forms.Label COURSE_DESC;
        private System.Windows.Forms.ComboBox AVAIL_COURSES_CB;
        private System.Windows.Forms.Button SIGN_COURSE_BUTTON;
        private System.Windows.Forms.Label UPCOMING_TESTS;
        private System.Windows.Forms.Label PAST_TESTS;
        private System.Windows.Forms.Label STATUS;
        private System.Windows.Forms.Label LEARNING_MATERIALS;
        private System.Windows.Forms.ListView UPCOMING_TESTS_LISTVIEW;
        private System.Windows.Forms.ListView LEARNING_MATERIALS_LISTVIEW;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader IdCourse;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.ListView PAST_TESTS_LISTVIEW;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader MarkColumn;
        private System.Windows.Forms.Button SIGN_OUT_BUTTON;
        private System.Windows.Forms.Label AVERAGE_MARK;
        private System.Windows.Forms.Label DATE_OF_SIGN;
        private System.Windows.Forms.Label COMPLETED;
        private System.Windows.Forms.ColumnHeader IdPisemka;
        private System.Windows.Forms.ColumnHeader IDMaterial;
        private System.Windows.Forms.ColumnHeader NameCol;
        private System.Windows.Forms.ColumnHeader TextCol;
        private System.Windows.Forms.ColumnHeader AuthorCol;
        private System.Windows.Forms.ToolStripMenuItem switchToTeacherViewToolStripMenuItem;
    }
}