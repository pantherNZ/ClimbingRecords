namespace ClimbingRecords
{
    partial class HangboardForm
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
            this.leftHand_Combo = new System.Windows.Forms.ComboBox();
            this.rightHand_Combo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.searchTerm_Entry = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.recordsGroupBox = new System.Windows.Forms.GroupBox();
            this.editRoutineButton = new System.Windows.Forms.Button();
            this.customRoutineBtn = new System.Windows.Forms.Button();
            this.trainingCombo = new System.Windows.Forms.ComboBox();
            this.editBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.recordsGrid = new System.Windows.Forms.DataGridView();
            this.gridCategory = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridLeftHandHold = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridRightHandHold = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridRecord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gridUnits = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.gridDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addBtn = new System.Windows.Forms.Button();
            this.startTrainingBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.mainTitle = new System.Windows.Forms.Label();
            this.routinesGroupBox = new System.Windows.Forms.GroupBox();
            this.routineNameErrorLabel = new System.Windows.Forms.Label();
            this.saveRoutineButton = new System.Windows.Forms.Button();
            this.addExerciseButton = new System.Windows.Forms.Button();
            this.deleteExerciseButton = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.routineDescriptionText = new System.Windows.Forms.TextBox();
            this.backButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.routineDifficultyTrackbar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.routineNameText = new System.Windows.Forms.TextBox();
            this.createRoutineButton = new System.Windows.Forms.Button();
            this.exercisesGrid = new System.Windows.Forms.DataGridView();
            this.routinesLeftHandHold = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.routinesRightHandHold = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.routinesDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routinesDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainingGroupBox = new System.Windows.Forms.GroupBox();
            this.trainingSkipButton = new System.Windows.Forms.Button();
            this.trainingPauseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.trainingHangTimerLabel = new System.Windows.Forms.Label();
            this.trainingRestTimerLabel = new System.Windows.Forms.Label();
            this.trainingInfoLabel = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.trainingNextLeftHandHold = new System.Windows.Forms.TextBox();
            this.trainingNextRightHandHold = new System.Windows.Forms.TextBox();
            this.trainingNextLabel = new System.Windows.Forms.Label();
            this.trainingExerciseCountLabel = new System.Windows.Forms.Label();
            this.trainingCurrentLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trainingRightHandHold = new System.Windows.Forms.TextBox();
            this.trainingLeftHandHold = new System.Windows.Forms.TextBox();
            this.trainingCancelButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.recordsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordsGrid)).BeginInit();
            this.routinesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routineDifficultyTrackbar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exercisesGrid)).BeginInit();
            this.trainingGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // leftHand_Combo
            // 
            this.leftHand_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.leftHand_Combo.FormattingEnabled = true;
            this.leftHand_Combo.ItemHeight = 13;
            this.leftHand_Combo.Location = new System.Drawing.Point(117, 20);
            this.leftHand_Combo.Name = "leftHand_Combo";
            this.leftHand_Combo.Size = new System.Drawing.Size(232, 21);
            this.leftHand_Combo.TabIndex = 2;
            this.leftHand_Combo.SelectedIndexChanged += new System.EventHandler(this.leftHand_Combo_SelectedIndexChanged);
            // 
            // rightHand_Combo
            // 
            this.rightHand_Combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rightHand_Combo.FormattingEnabled = true;
            this.rightHand_Combo.ItemHeight = 13;
            this.rightHand_Combo.Location = new System.Drawing.Point(117, 46);
            this.rightHand_Combo.Name = "rightHand_Combo";
            this.rightHand_Combo.Size = new System.Drawing.Size(232, 21);
            this.rightHand_Combo.TabIndex = 4;
            this.rightHand_Combo.SelectedIndexChanged += new System.EventHandler(this.rightHand_Combo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Left Hand Hold";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(11, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "Right Hand Hold";
            // 
            // searchTerm_Entry
            // 
            this.searchTerm_Entry.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.searchTerm_Entry.Location = new System.Drawing.Point(584, 20);
            this.searchTerm_Entry.Name = "searchTerm_Entry";
            this.searchTerm_Entry.Size = new System.Drawing.Size(310, 20);
            this.searchTerm_Entry.TabIndex = 7;
            this.searchTerm_Entry.TextChanged += new System.EventHandler(this.searchTerm_Entry_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(501, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Search Term";
            // 
            // recordsGroupBox
            // 
            this.recordsGroupBox.Controls.Add(this.editRoutineButton);
            this.recordsGroupBox.Controls.Add(this.customRoutineBtn);
            this.recordsGroupBox.Controls.Add(this.trainingCombo);
            this.recordsGroupBox.Controls.Add(this.editBtn);
            this.recordsGroupBox.Controls.Add(this.cancelBtn);
            this.recordsGroupBox.Controls.Add(this.recordsGrid);
            this.recordsGroupBox.Controls.Add(this.addBtn);
            this.recordsGroupBox.Controls.Add(this.startTrainingBtn);
            this.recordsGroupBox.Controls.Add(this.saveBtn);
            this.recordsGroupBox.Controls.Add(this.label3);
            this.recordsGroupBox.Controls.Add(this.searchTerm_Entry);
            this.recordsGroupBox.Controls.Add(this.label2);
            this.recordsGroupBox.Controls.Add(this.label1);
            this.recordsGroupBox.Controls.Add(this.rightHand_Combo);
            this.recordsGroupBox.Controls.Add(this.leftHand_Combo);
            this.recordsGroupBox.Location = new System.Drawing.Point(20, 8);
            this.recordsGroupBox.Name = "recordsGroupBox";
            this.recordsGroupBox.Size = new System.Drawing.Size(1444, 381);
            this.recordsGroupBox.TabIndex = 7;
            this.recordsGroupBox.TabStop = false;
            this.recordsGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox2_Paint);
            // 
            // editRoutineButton
            // 
            this.editRoutineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editRoutineButton.Enabled = false;
            this.editRoutineButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editRoutineButton.Location = new System.Drawing.Point(1244, 46);
            this.editRoutineButton.Name = "editRoutineButton";
            this.editRoutineButton.Size = new System.Drawing.Size(90, 23);
            this.editRoutineButton.TabIndex = 26;
            this.editRoutineButton.Text = "Edit Routine";
            this.editRoutineButton.UseVisualStyleBackColor = true;
            this.editRoutineButton.Click += new System.EventHandler(this.editRoutineButton_Click);
            // 
            // customRoutineBtn
            // 
            this.customRoutineBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.customRoutineBtn.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customRoutineBtn.Location = new System.Drawing.Point(1147, 46);
            this.customRoutineBtn.Name = "customRoutineBtn";
            this.customRoutineBtn.Size = new System.Drawing.Size(90, 23);
            this.customRoutineBtn.TabIndex = 25;
            this.customRoutineBtn.Text = "Custom Routine";
            this.customRoutineBtn.UseVisualStyleBackColor = true;
            this.customRoutineBtn.Click += new System.EventHandler(this.customRoutineBtn_Click);
            // 
            // trainingCombo
            // 
            this.trainingCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.trainingCombo.FormattingEnabled = true;
            this.trainingCombo.ItemHeight = 13;
            this.trainingCombo.Location = new System.Drawing.Point(1147, 20);
            this.trainingCombo.Name = "trainingCombo";
            this.trainingCombo.Size = new System.Drawing.Size(284, 21);
            this.trainingCombo.TabIndex = 24;
            this.trainingCombo.SelectedValueChanged += new System.EventHandler(this.trainingCombo_SelectedValueChanged);
            // 
            // editBtn
            // 
            this.editBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.editBtn.Enabled = false;
            this.editBtn.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editBtn.Location = new System.Drawing.Point(611, 46);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(90, 23);
            this.editBtn.TabIndex = 13;
            this.editBtn.TabStop = false;
            this.editBtn.Text = "Edit Record";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.editBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cancelBtn.Enabled = false;
            this.cancelBtn.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(707, 46);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(90, 23);
            this.cancelBtn.TabIndex = 12;
            this.cancelBtn.TabStop = false;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // recordsGrid
            // 
            this.recordsGrid.AllowUserToAddRows = false;
            this.recordsGrid.AllowUserToDeleteRows = false;
            this.recordsGrid.AllowUserToResizeRows = false;
            this.recordsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.recordsGrid.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.recordsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.recordsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridCategory,
            this.gridLeftHandHold,
            this.gridRightHandHold,
            this.gridName,
            this.gridRecord,
            this.gridUnits,
            this.gridDescription});
            this.recordsGrid.Location = new System.Drawing.Point(12, 81);
            this.recordsGrid.Name = "recordsGrid";
            this.recordsGrid.ReadOnly = true;
            this.recordsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.recordsGrid.Size = new System.Drawing.Size(1420, 286);
            this.recordsGrid.TabIndex = 11;
            this.recordsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.recordsGrid_CellValueChanged);
            this.recordsGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.recordsGrid_CurrentCellDirtyStateChanged);
            this.recordsGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.recordsGrid_EditingControlShowing);
            this.recordsGrid.SelectionChanged += new System.EventHandler(this.recordsGrid_SelectionChanged);
            // 
            // gridCategory
            // 
            this.gridCategory.HeaderText = "Category";
            this.gridCategory.Items.AddRange(new object[] {
            "Hang",
            "Chinups",
            "Misc"});
            this.gridCategory.Name = "gridCategory";
            this.gridCategory.ReadOnly = true;
            this.gridCategory.Width = 150;
            // 
            // gridLeftHandHold
            // 
            this.gridLeftHandHold.HeaderText = "Left Hand Hold";
            this.gridLeftHandHold.Name = "gridLeftHandHold";
            this.gridLeftHandHold.ReadOnly = true;
            this.gridLeftHandHold.Width = 200;
            // 
            // gridRightHandHold
            // 
            this.gridRightHandHold.HeaderText = "Right Hand Hold";
            this.gridRightHandHold.Name = "gridRightHandHold";
            this.gridRightHandHold.ReadOnly = true;
            this.gridRightHandHold.Width = 200;
            // 
            // gridName
            // 
            this.gridName.HeaderText = "Name";
            this.gridName.Name = "gridName";
            this.gridName.ReadOnly = true;
            this.gridName.Width = 150;
            // 
            // gridRecord
            // 
            this.gridRecord.HeaderText = "Record";
            this.gridRecord.Name = "gridRecord";
            this.gridRecord.ReadOnly = true;
            this.gridRecord.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRecord.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gridUnits
            // 
            this.gridUnits.HeaderText = "Units";
            this.gridUnits.Items.AddRange(new object[] {
            "seconds",
            "minutes",
            "reps"});
            this.gridUnits.Name = "gridUnits";
            this.gridUnits.ReadOnly = true;
            // 
            // gridDescription
            // 
            this.gridDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.gridDescription.HeaderText = "Description";
            this.gridDescription.Name = "gridDescription";
            this.gridDescription.ReadOnly = true;
            // 
            // addBtn
            // 
            this.addBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addBtn.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addBtn.Location = new System.Drawing.Point(515, 46);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(90, 23);
            this.addBtn.TabIndex = 10;
            this.addBtn.TabStop = false;
            this.addBtn.Text = "Add Record";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // startTrainingBtn
            // 
            this.startTrainingBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startTrainingBtn.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startTrainingBtn.Location = new System.Drawing.Point(1341, 46);
            this.startTrainingBtn.Name = "startTrainingBtn";
            this.startTrainingBtn.Size = new System.Drawing.Size(90, 23);
            this.startTrainingBtn.TabIndex = 14;
            this.startTrainingBtn.Text = "Training";
            this.startTrainingBtn.UseVisualStyleBackColor = true;
            this.startTrainingBtn.Click += new System.EventHandler(this.startTrainingBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.saveBtn.Enabled = false;
            this.saveBtn.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.Location = new System.Drawing.Point(804, 46);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(90, 23);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.TabStop = false;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // mainTitle
            // 
            this.mainTitle.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.mainTitle.AutoSize = true;
            this.mainTitle.Font = new System.Drawing.Font("Georgia", 28F);
            this.mainTitle.ForeColor = System.Drawing.Color.White;
            this.mainTitle.Location = new System.Drawing.Point(535, 387);
            this.mainTitle.MinimumSize = new System.Drawing.Size(400, 0);
            this.mainTitle.Name = "mainTitle";
            this.mainTitle.Size = new System.Drawing.Size(400, 43);
            this.mainTitle.TabIndex = 39;
            this.mainTitle.Text = "Hangboard Records";
            this.mainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // routinesGroupBox
            // 
            this.routinesGroupBox.Controls.Add(this.routineNameErrorLabel);
            this.routinesGroupBox.Controls.Add(this.saveRoutineButton);
            this.routinesGroupBox.Controls.Add(this.addExerciseButton);
            this.routinesGroupBox.Controls.Add(this.deleteExerciseButton);
            this.routinesGroupBox.Controls.Add(this.label9);
            this.routinesGroupBox.Controls.Add(this.routineDescriptionText);
            this.routinesGroupBox.Controls.Add(this.backButton);
            this.routinesGroupBox.Controls.Add(this.label8);
            this.routinesGroupBox.Controls.Add(this.label7);
            this.routinesGroupBox.Controls.Add(this.label6);
            this.routinesGroupBox.Controls.Add(this.routineDifficultyTrackbar);
            this.routinesGroupBox.Controls.Add(this.label5);
            this.routinesGroupBox.Controls.Add(this.routineNameText);
            this.routinesGroupBox.Controls.Add(this.createRoutineButton);
            this.routinesGroupBox.Controls.Add(this.exercisesGrid);
            this.routinesGroupBox.Location = new System.Drawing.Point(41, 8);
            this.routinesGroupBox.Name = "routinesGroupBox";
            this.routinesGroupBox.Size = new System.Drawing.Size(1444, 381);
            this.routinesGroupBox.TabIndex = 26;
            this.routinesGroupBox.TabStop = false;
            this.routinesGroupBox.Visible = false;
            // 
            // routineNameErrorLabel
            // 
            this.routineNameErrorLabel.AutoSize = true;
            this.routineNameErrorLabel.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routineNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.routineNameErrorLabel.Location = new System.Drawing.Point(575, 24);
            this.routineNameErrorLabel.Name = "routineNameErrorLabel";
            this.routineNameErrorLabel.Size = new System.Drawing.Size(133, 14);
            this.routineNameErrorLabel.TabIndex = 41;
            this.routineNameErrorLabel.Text = "Name must be unique";
            this.routineNameErrorLabel.Visible = false;
            // 
            // saveRoutineButton
            // 
            this.saveRoutineButton.Enabled = false;
            this.saveRoutineButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveRoutineButton.Location = new System.Drawing.Point(1147, 46);
            this.saveRoutineButton.Name = "saveRoutineButton";
            this.saveRoutineButton.Size = new System.Drawing.Size(90, 23);
            this.saveRoutineButton.TabIndex = 40;
            this.saveRoutineButton.Text = "Save";
            this.saveRoutineButton.UseVisualStyleBackColor = true;
            this.saveRoutineButton.Click += new System.EventHandler(this.saveRoutineButton_Click);
            // 
            // addExerciseButton
            // 
            this.addExerciseButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addExerciseButton.Location = new System.Drawing.Point(752, 47);
            this.addExerciseButton.Name = "addExerciseButton";
            this.addExerciseButton.Size = new System.Drawing.Size(90, 23);
            this.addExerciseButton.TabIndex = 39;
            this.addExerciseButton.Text = "Add Row";
            this.addExerciseButton.UseVisualStyleBackColor = true;
            this.addExerciseButton.Click += new System.EventHandler(this.addExerciseButton_Click);
            // 
            // deleteExerciseButton
            // 
            this.deleteExerciseButton.Enabled = false;
            this.deleteExerciseButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteExerciseButton.Location = new System.Drawing.Point(848, 47);
            this.deleteExerciseButton.Name = "deleteExerciseButton";
            this.deleteExerciseButton.Size = new System.Drawing.Size(90, 23);
            this.deleteExerciseButton.TabIndex = 38;
            this.deleteExerciseButton.Text = "Delete Row";
            this.deleteExerciseButton.UseVisualStyleBackColor = true;
            this.deleteExerciseButton.Click += new System.EventHandler(this.deleteExerciseButton_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(237, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 14);
            this.label9.TabIndex = 37;
            this.label9.Text = "Info";
            // 
            // routineDescriptionText
            // 
            this.routineDescriptionText.Location = new System.Drawing.Point(268, 47);
            this.routineDescriptionText.Name = "routineDescriptionText";
            this.routineDescriptionText.Size = new System.Drawing.Size(403, 20);
            this.routineDescriptionText.TabIndex = 36;
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.Location = new System.Drawing.Point(1340, 46);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(90, 23);
            this.backButton.TabIndex = 35;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(190, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(22, 14);
            this.label8.TabIndex = 34;
            this.label8.Text = "10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(20, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 14);
            this.label7.TabIndex = 33;
            this.label7.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(83, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "Difficulty: 3";
            // 
            // routineDifficultyTrackbar
            // 
            this.routineDifficultyTrackbar.LargeChange = 1;
            this.routineDifficultyTrackbar.Location = new System.Drawing.Point(13, 18);
            this.routineDifficultyTrackbar.Name = "routineDifficultyTrackbar";
            this.routineDifficultyTrackbar.Size = new System.Drawing.Size(201, 45);
            this.routineDifficultyTrackbar.TabIndex = 31;
            this.routineDifficultyTrackbar.Value = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(226, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "Name";
            // 
            // routineNameText
            // 
            this.routineNameText.Location = new System.Drawing.Point(268, 21);
            this.routineNameText.Name = "routineNameText";
            this.routineNameText.Size = new System.Drawing.Size(300, 20);
            this.routineNameText.TabIndex = 29;
            // 
            // createRoutineButton
            // 
            this.createRoutineButton.Enabled = false;
            this.createRoutineButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createRoutineButton.Location = new System.Drawing.Point(1244, 46);
            this.createRoutineButton.Name = "createRoutineButton";
            this.createRoutineButton.Size = new System.Drawing.Size(90, 23);
            this.createRoutineButton.TabIndex = 27;
            this.createRoutineButton.Text = "Create";
            this.createRoutineButton.UseVisualStyleBackColor = true;
            this.createRoutineButton.Click += new System.EventHandler(this.createRoutineButton_Click);
            // 
            // exercisesGrid
            // 
            this.exercisesGrid.AllowUserToAddRows = false;
            this.exercisesGrid.AllowUserToDeleteRows = false;
            this.exercisesGrid.AllowUserToResizeRows = false;
            this.exercisesGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exercisesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.exercisesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.routinesLeftHandHold,
            this.routinesRightHandHold,
            this.routinesDuration,
            this.Rest,
            this.routinesDescription});
            this.exercisesGrid.Location = new System.Drawing.Point(12, 81);
            this.exercisesGrid.Name = "exercisesGrid";
            this.exercisesGrid.Size = new System.Drawing.Size(1418, 286);
            this.exercisesGrid.TabIndex = 28;
            this.exercisesGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.routinesGrid_CellValueChanged);
            this.exercisesGrid.CurrentCellChanged += new System.EventHandler(this.routinesGrid_CurrentCellChanged);
            this.exercisesGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.routinesGrid_CurrentCellDirtyStateChanged);
            this.exercisesGrid.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.routinesGrid_EditingControlShowing);
            // 
            // routinesLeftHandHold
            // 
            this.routinesLeftHandHold.HeaderText = "Left Hand Hold";
            this.routinesLeftHandHold.Name = "routinesLeftHandHold";
            this.routinesLeftHandHold.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.routinesLeftHandHold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.routinesLeftHandHold.Width = 200;
            // 
            // routinesRightHandHold
            // 
            this.routinesRightHandHold.HeaderText = "Right Hand Hold";
            this.routinesRightHandHold.Name = "routinesRightHandHold";
            this.routinesRightHandHold.Width = 200;
            // 
            // routinesDuration
            // 
            this.routinesDuration.HeaderText = "Duration";
            this.routinesDuration.Name = "routinesDuration";
            // 
            // Rest
            // 
            this.Rest.HeaderText = "Rest (seconds)";
            this.Rest.Name = "Rest";
            this.Rest.Width = 120;
            // 
            // routinesDescription
            // 
            this.routinesDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.routinesDescription.HeaderText = "Description";
            this.routinesDescription.Name = "routinesDescription";
            // 
            // trainingGroupBox
            // 
            this.trainingGroupBox.Controls.Add(this.trainingSkipButton);
            this.trainingGroupBox.Controls.Add(this.trainingPauseButton);
            this.trainingGroupBox.Controls.Add(this.groupBox1);
            this.trainingGroupBox.Controls.Add(this.trainingInfoLabel);
            this.trainingGroupBox.Controls.Add(this.label16);
            this.trainingGroupBox.Controls.Add(this.label17);
            this.trainingGroupBox.Controls.Add(this.trainingNextLeftHandHold);
            this.trainingGroupBox.Controls.Add(this.trainingNextRightHandHold);
            this.trainingGroupBox.Controls.Add(this.trainingNextLabel);
            this.trainingGroupBox.Controls.Add(this.trainingExerciseCountLabel);
            this.trainingGroupBox.Controls.Add(this.trainingCurrentLabel);
            this.trainingGroupBox.Controls.Add(this.label10);
            this.trainingGroupBox.Controls.Add(this.label4);
            this.trainingGroupBox.Controls.Add(this.trainingRightHandHold);
            this.trainingGroupBox.Controls.Add(this.trainingLeftHandHold);
            this.trainingGroupBox.Controls.Add(this.trainingCancelButton);
            this.trainingGroupBox.Location = new System.Drawing.Point(8, 29);
            this.trainingGroupBox.Name = "trainingGroupBox";
            this.trainingGroupBox.Size = new System.Drawing.Size(1444, 381);
            this.trainingGroupBox.TabIndex = 40;
            this.trainingGroupBox.TabStop = false;
            this.trainingGroupBox.Visible = false;
            this.trainingGroupBox.Paint += new System.Windows.Forms.PaintEventHandler(this.trainingGroupBox_Paint);
            // 
            // trainingSkipButton
            // 
            this.trainingSkipButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingSkipButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainingSkipButton.Location = new System.Drawing.Point(1173, 301);
            this.trainingSkipButton.Name = "trainingSkipButton";
            this.trainingSkipButton.Size = new System.Drawing.Size(100, 30);
            this.trainingSkipButton.TabIndex = 53;
            this.trainingSkipButton.Text = "Skip";
            this.trainingSkipButton.UseVisualStyleBackColor = true;
            this.trainingSkipButton.Click += new System.EventHandler(this.trainingSkipButton_Click);
            // 
            // trainingPauseButton
            // 
            this.trainingPauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingPauseButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainingPauseButton.Location = new System.Drawing.Point(577, 295);
            this.trainingPauseButton.Name = "trainingPauseButton";
            this.trainingPauseButton.Size = new System.Drawing.Size(342, 36);
            this.trainingPauseButton.TabIndex = 52;
            this.trainingPauseButton.Text = "Start";
            this.trainingPauseButton.UseVisualStyleBackColor = true;
            this.trainingPauseButton.Click += new System.EventHandler(this.trainingPauseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.trainingHangTimerLabel);
            this.groupBox1.Controls.Add(this.trainingRestTimerLabel);
            this.groupBox1.Location = new System.Drawing.Point(525, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(425, 135);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            // 
            // trainingHangTimerLabel
            // 
            this.trainingHangTimerLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.trainingHangTimerLabel.Font = new System.Drawing.Font("Georgia", 28F);
            this.trainingHangTimerLabel.ForeColor = System.Drawing.Color.White;
            this.trainingHangTimerLabel.Location = new System.Drawing.Point(13, 13);
            this.trainingHangTimerLabel.MinimumSize = new System.Drawing.Size(400, 0);
            this.trainingHangTimerLabel.Name = "trainingHangTimerLabel";
            this.trainingHangTimerLabel.Size = new System.Drawing.Size(400, 50);
            this.trainingHangTimerLabel.TabIndex = 42;
            this.trainingHangTimerLabel.Text = "Hang 45 seconds";
            this.trainingHangTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trainingRestTimerLabel
            // 
            this.trainingRestTimerLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.trainingRestTimerLabel.Font = new System.Drawing.Font("Georgia", 12F);
            this.trainingRestTimerLabel.ForeColor = System.Drawing.Color.White;
            this.trainingRestTimerLabel.Location = new System.Drawing.Point(13, 65);
            this.trainingRestTimerLabel.MinimumSize = new System.Drawing.Size(400, 0);
            this.trainingRestTimerLabel.Name = "trainingRestTimerLabel";
            this.trainingRestTimerLabel.Size = new System.Drawing.Size(400, 50);
            this.trainingRestTimerLabel.TabIndex = 43;
            this.trainingRestTimerLabel.Text = "Rest 45 seconds";
            this.trainingRestTimerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trainingInfoLabel
            // 
            this.trainingInfoLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.trainingInfoLabel.Font = new System.Drawing.Font("Georgia", 14F);
            this.trainingInfoLabel.ForeColor = System.Drawing.Color.White;
            this.trainingInfoLabel.Location = new System.Drawing.Point(525, 191);
            this.trainingInfoLabel.Name = "trainingInfoLabel";
            this.trainingInfoLabel.Size = new System.Drawing.Size(425, 100);
            this.trainingInfoLabel.TabIndex = 50;
            this.trainingInfoLabel.Text = "Info:  This is information for the current exercise";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(1033, 152);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(125, 18);
            this.label16.TabIndex = 48;
            this.label16.Text = "Right Hand Hold";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(1044, 115);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(116, 18);
            this.label17.TabIndex = 47;
            this.label17.Text = "Left Hand Hold";
            // 
            // trainingNextLeftHandHold
            // 
            this.trainingNextLeftHandHold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trainingNextLeftHandHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.trainingNextLeftHandHold.Location = new System.Drawing.Point(1164, 112);
            this.trainingNextLeftHandHold.Name = "trainingNextLeftHandHold";
            this.trainingNextLeftHandHold.ReadOnly = true;
            this.trainingNextLeftHandHold.Size = new System.Drawing.Size(230, 23);
            this.trainingNextLeftHandHold.TabIndex = 46;
            // 
            // trainingNextRightHandHold
            // 
            this.trainingNextRightHandHold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trainingNextRightHandHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.trainingNextRightHandHold.Location = new System.Drawing.Point(1164, 149);
            this.trainingNextRightHandHold.Name = "trainingNextRightHandHold";
            this.trainingNextRightHandHold.ReadOnly = true;
            this.trainingNextRightHandHold.Size = new System.Drawing.Size(230, 23);
            this.trainingNextRightHandHold.TabIndex = 45;
            // 
            // trainingNextLabel
            // 
            this.trainingNextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.trainingNextLabel.AutoSize = true;
            this.trainingNextLabel.Font = new System.Drawing.Font("Georgia", 28F);
            this.trainingNextLabel.ForeColor = System.Drawing.Color.White;
            this.trainingNextLabel.Location = new System.Drawing.Point(1161, 58);
            this.trainingNextLabel.Name = "trainingNextLabel";
            this.trainingNextLabel.Size = new System.Drawing.Size(98, 43);
            this.trainingNextLabel.TabIndex = 44;
            this.trainingNextLabel.Text = "Next";
            // 
            // trainingExerciseCountLabel
            // 
            this.trainingExerciseCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingExerciseCountLabel.Font = new System.Drawing.Font("Georgia", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainingExerciseCountLabel.ForeColor = System.Drawing.Color.White;
            this.trainingExerciseCountLabel.Location = new System.Drawing.Point(56, 288);
            this.trainingExerciseCountLabel.Name = "trainingExerciseCountLabel";
            this.trainingExerciseCountLabel.Size = new System.Drawing.Size(293, 43);
            this.trainingExerciseCountLabel.TabIndex = 41;
            this.trainingExerciseCountLabel.Text = "Exercise 1/4";
            this.trainingExerciseCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // trainingCurrentLabel
            // 
            this.trainingCurrentLabel.AutoSize = true;
            this.trainingCurrentLabel.Font = new System.Drawing.Font("Georgia", 28F);
            this.trainingCurrentLabel.ForeColor = System.Drawing.Color.White;
            this.trainingCurrentLabel.Location = new System.Drawing.Point(140, 58);
            this.trainingCurrentLabel.Name = "trainingCurrentLabel";
            this.trainingCurrentLabel.Size = new System.Drawing.Size(150, 43);
            this.trainingCurrentLabel.TabIndex = 40;
            this.trainingCurrentLabel.Text = "Current";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(46, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 18);
            this.label10.TabIndex = 39;
            this.label10.Text = "Right Hand Hold";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(56, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 18);
            this.label4.TabIndex = 38;
            this.label4.Text = "Left Hand Hold";
            // 
            // trainingRightHandHold
            // 
            this.trainingRightHandHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.trainingRightHandHold.Location = new System.Drawing.Point(174, 150);
            this.trainingRightHandHold.Name = "trainingRightHandHold";
            this.trainingRightHandHold.ReadOnly = true;
            this.trainingRightHandHold.Size = new System.Drawing.Size(230, 23);
            this.trainingRightHandHold.TabIndex = 37;
            // 
            // trainingLeftHandHold
            // 
            this.trainingLeftHandHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.trainingLeftHandHold.Location = new System.Drawing.Point(174, 112);
            this.trainingLeftHandHold.Name = "trainingLeftHandHold";
            this.trainingLeftHandHold.ReadOnly = true;
            this.trainingLeftHandHold.Size = new System.Drawing.Size(230, 23);
            this.trainingLeftHandHold.TabIndex = 36;
            // 
            // trainingCancelButton
            // 
            this.trainingCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trainingCancelButton.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainingCancelButton.Location = new System.Drawing.Point(1285, 301);
            this.trainingCancelButton.Name = "trainingCancelButton";
            this.trainingCancelButton.Size = new System.Drawing.Size(100, 30);
            this.trainingCancelButton.TabIndex = 35;
            this.trainingCancelButton.Text = "Cancel";
            this.trainingCancelButton.UseVisualStyleBackColor = true;
            this.trainingCancelButton.Click += new System.EventHandler(this.trainingCancelButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(26, 396);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.trainingGroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.routinesGroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.recordsGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(1406, 409);
            this.splitContainer1.SplitterDistance = 233;
            this.splitContainer1.TabIndex = 41;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1406, 233);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // HangboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1444, 834);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainTitle);
            this.Name = "HangboardForm";
            this.Text = "Hangboard Records";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.recordsGroupBox.ResumeLayout(false);
            this.recordsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.recordsGrid)).EndInit();
            this.routinesGroupBox.ResumeLayout(false);
            this.routinesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routineDifficultyTrackbar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exercisesGrid)).EndInit();
            this.trainingGroupBox.ResumeLayout(false);
            this.trainingGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox leftHand_Combo;
        private System.Windows.Forms.ComboBox rightHand_Combo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox searchTerm_Entry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox recordsGroupBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.DataGridView recordsGrid;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button startTrainingBtn;
        private System.Windows.Forms.Label mainTitle;
        private System.Windows.Forms.ComboBox trainingCombo;
        private System.Windows.Forms.Button customRoutineBtn;
        private System.Windows.Forms.GroupBox routinesGroupBox;
        private System.Windows.Forms.Button createRoutineButton;
        private System.Windows.Forms.DataGridView exercisesGrid;
        private System.Windows.Forms.TextBox routineNameText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar routineDifficultyTrackbar;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridCategory;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridLeftHandHold;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridRightHandHold;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridName;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridRecord;
        private System.Windows.Forms.DataGridViewComboBoxColumn gridUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn gridDescription;
        private System.Windows.Forms.DataGridViewComboBoxColumn routinesLeftHandHold;
        private System.Windows.Forms.DataGridViewComboBoxColumn routinesRightHandHold;
        private System.Windows.Forms.DataGridViewTextBoxColumn routinesDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rest;
        private System.Windows.Forms.DataGridViewTextBoxColumn routinesDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox routineDescriptionText;
        private System.Windows.Forms.Button addExerciseButton;
        private System.Windows.Forms.Button deleteExerciseButton;
        private System.Windows.Forms.Button editRoutineButton;
        private System.Windows.Forms.Button saveRoutineButton;
        private System.Windows.Forms.Label routineNameErrorLabel;
        private System.Windows.Forms.GroupBox trainingGroupBox;
        private System.Windows.Forms.Button trainingCancelButton;
        private System.Windows.Forms.TextBox trainingLeftHandHold;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox trainingRightHandHold;
        private System.Windows.Forms.Label trainingCurrentLabel;
        private System.Windows.Forms.Label trainingExerciseCountLabel;
        private System.Windows.Forms.Label trainingHangTimerLabel;
        private System.Windows.Forms.Label trainingRestTimerLabel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox trainingNextLeftHandHold;
        private System.Windows.Forms.TextBox trainingNextRightHandHold;
        private System.Windows.Forms.Label trainingNextLabel;
        private System.Windows.Forms.Label trainingInfoLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button trainingSkipButton;
        private System.Windows.Forms.Button trainingPauseButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

