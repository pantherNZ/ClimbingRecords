using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClimbingRecords
{
    public partial class Hangboard : Form
    {
        // Ratios
        struct Ratio
        {
            public double locX, locY, sizeX, sizeY;
        };

        public List<String> leftHandHoldsDataSource = new List<string>();

        Dictionary< Control, Ratio > highlightRatios = new Dictionary< Control, Ratio >();
        double hangboardOriginalRatio = 0.0;
        List<PictureBox> highlights = new List<PictureBox>();
        Bitmap[] highlightImages = new Bitmap[2] { ClimbingRecords.Properties.Resources.Highlight, ClimbingRecords.Properties.Resources.Highlight2 };
        PictureBox leftHand = null, rightHand = null;
        bool placingRightHand = false;
        bool ignoreComboChange = false;
        bool addingRow = false;
        int editRowIndex = -1;
        List<Records.GridRecord> recordsData;
        List<Records.GridRecord> filteredData;
        List<Routines.GridRoutine> routinesData;
        string searchTerm;
        bool trainingMode = false;

        public Hangboard()
        {
            InitializeComponent();

            hangboardOriginalRatio = hangboardImage.Image.Size.Width / Convert.ToDouble( hangboardImage.Image.Size.Height );
            InitialiseHighlightsArray();

            hangboardImage.Controls.Add( mainTitle );
            mainTitle.BackColor = Color.Transparent;

            // Add highlights as children to the hangboard
            foreach( var highlight in highlights )
            {
                hangboardImage.Controls.Add( highlight );
                highlight.BackColor = Color.Transparent;
                highlight.Image = null;
                highlight.MouseEnter += this.HighlightMouseEnter;
                highlight.MouseLeave += this.HighlightMouseLeave;
                highlight.MouseDown += this.HighlightMouseDown;
            }

            hangboardImage.SendToBack();

            var hangboardTrueSize = GetHangboardTrueSize();
            var hangboardCentre = new Point( hangboardImage.Left + hangboardImage.Width / 2, hangboardImage.Top + hangboardImage.Height / 2 );

            foreach( var highlight in highlights )
            {
                // Ratios
                Ratio ratio = new Ratio();
                ratio.locX = ( highlight.Left - hangboardCentre.X ) / Convert.ToDouble( hangboardTrueSize.Width );
                ratio.locY = ( highlight.Top - hangboardCentre.Y ) / Convert.ToDouble( hangboardTrueSize.Height );
                ratio.sizeX = highlight.Width / Convert.ToDouble( hangboardTrueSize.Width );
                ratio.sizeY = highlight.Height / Convert.ToDouble( hangboardTrueSize.Height );
                highlightRatios.Add( highlight, ratio );
            }

            routineNameText.TextChanged += this.ValidateCreateButton;
            routinesGrid.RowsRemoved += this.ValidateCreateButton;
            routinesGrid.RowsAdded += this.ValidateCreateButton;
        }


        private void Form1_Load( object sender, EventArgs e )
        {
            InitialiseDataSources();

            SetComboSelectedIndex( leftHand_Combo, 18 );
            SetComboSelectedIndex( rightHand_Combo, 18 );

            recordsGrid.ClearSelection();

            if( recordsGrid.CurrentRow != null )
                recordsGrid.CurrentRow.Selected = false;

            editBtn.Enabled = false;
        }

        private void InitialiseHighlightsArray()
        {
            for( int i = 1; i <= 31; ++i )
            {
                var fieldName = "hangboardImage" + i;
                var field = this.GetType().GetField( fieldName, System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance );
                highlights.Add( field.GetValue( this ) as PictureBox );
            }
        }

        private void InitialiseDataSources()
        {
            foreach( var hold in Records.leftHoldNames )
                leftHand_Combo.Items.Add( hold );

            foreach( var hold in Records.rightHoldNames )
                rightHand_Combo.Items.Add( hold );

            ( recordsGrid.Columns["gridLeftHandHold"] as DataGridViewComboBoxColumn ).DataSource = Records.leftHoldNames;
            ( recordsGrid.Columns["gridRightHandHold"] as DataGridViewComboBoxColumn ).DataSource = Records.rightHoldNames;
            ( routinesGrid.Columns["routinesLeftHandHold"] as DataGridViewComboBoxColumn ).DataSource = Records.leftHoldNames;
            ( routinesGrid.Columns["routinesRightHandHold"] as DataGridViewComboBoxColumn ).DataSource = Records.rightHoldNames;

            recordsData = Records.LoadRecords();
            filteredData = recordsData;
            RefreshRecordsTable();

            routinesData = Routines.LoadRoutines();

            var routines = new List<String>();

            foreach( var routine in routinesData )
                routines.Add( routine.name );

            trainingCombo.DataSource = routines;
        }

        private void AddToRecordsTable( Records.GridRecord record )
        {
            recordsGrid.Rows.Add();
            var cells = recordsGrid.Rows[recordsGrid.Rows.Count - 1].Cells;
            cells[0].Value = record.category;
            cells[1].Value = record.leftHandHold;
            cells[2].Value = record.rightHandHold;
            cells[3].Value = record.name;
            cells[4].Value = record.record;
            cells[5].Value = record.units;
            cells[6].Value = record.description;

            recordsGrid.ClearSelection();
        }

        private void AddToExercisesTable( Routines.GridExercise exercise )
        {
            routinesGrid.Rows.Add();
            var cells = routinesGrid.Rows[routinesGrid.Rows.Count - 1].Cells;
            cells[0].Value = exercise.leftHandHold;
            cells[1].Value = exercise.rightHandHold;
            cells[2].Value = exercise.duration;
            cells[3].Value = exercise.rest;
            cells[4].Value = exercise.description;
            routinesGrid.ClearSelection();
            createRoutineButton.Enabled = routinesGrid.RowCount > 0 && routineNameText.Text.Length > 0;
        }

        private void RefreshRecordsTable()
        {
            ClearRecordsTable();

            foreach( var x in filteredData )
                AddToRecordsTable( x );
        }

        private void ClearRecordsTable()
        {
            editBtn.Enabled = false;

            while( recordsGrid.Rows.Count > 0 )
                recordsGrid.Rows.RemoveAt( 0 );
        }

        private void ClearExercisesTable()
        {
            while( routinesGrid.Rows.Count > 0 )
                routinesGrid.Rows.RemoveAt( 0 );
        }

        private Bitmap RotateImage( Bitmap image, float angle )
        {
            if( Math.Abs( angle ) <= 2.0f )
                return image;

            int l = image.Width;
            int h = image.Height;
            double an = angle * Math.PI / 180.0;
            double cos = Math.Abs( Math.Cos( an ) );
            double sin = Math.Abs( Math.Sin( an ) );
            int nl = ( int )( l * cos + h * sin );
            int nh = ( int )( l * sin + h * cos );
            Bitmap returnBitmap = new Bitmap( nl, nh );
            Graphics g = Graphics.FromImage( returnBitmap );
            g.TranslateTransform( ( float )( nl - l ) / 2, ( float )( nh - h ) / 2 );
            g.TranslateTransform( ( float )image.Width / 2, ( float )image.Height / 2 );
            g.RotateTransform( angle );
            g.TranslateTransform( -( float )image.Width / 2, -( float )image.Height / 2 );
            g.DrawImage( image, new Point( 0, 0 ) );
            return returnBitmap;
        }

        private void HighlightMouseEnter( object sender, EventArgs e )
        {
            if( trainingMode )
                return;

            PictureBox highlight = sender as PictureBox;

            if( ( placingRightHand && highlight != rightHand ) || ( !placingRightHand && highlight != leftHand ) )
                SetHighlight( highlight, placingRightHand );
        }

        private void HighlightMouseLeave( object sender, EventArgs e )
        {
            if( trainingMode )
                return;

            PictureBox highlight = sender as PictureBox;

            if( highlight != leftHand && highlight != rightHand )
                highlight.Image = null;
            else
                SetHighlight( highlight, highlight == rightHand );
        }

        private void SetHighlight( PictureBox highlight, bool isRightHand )
        {
            var offset = ( highlight.Left + highlight.Width / 2.0f ) - ( hangboardImage.Left + hangboardImage.Width / 2.0f );
            highlight.Image = RotateImage( highlightImages[Convert.ToInt32( isRightHand )], offset / ( offset > 0 ? 40.0f : 28.0f ) );
        }

        private void hangboardImage_MouseClick( object sender, MouseEventArgs e )
        {
            if( trainingMode )
                return;

            if( rightHand != null )
            {
                rightHand.Image = null;
                rightHand = null;
            }

            if( leftHand != null )
            {
                leftHand.Image = null;
                leftHand = null;
            }

            SetComboSelectedIndex( leftHand_Combo, 18 );
            SetComboSelectedIndex( rightHand_Combo, 18 );
            placingRightHand = false;
        }

        private void SetComboSelectedIndex( ComboBox cb, int index )
        {
            ignoreComboChange = true;
            cb.SelectedIndex = index;
            ignoreComboChange = false;
        }

        private void SetComboSelectedIndex( DataGridViewCell cell, int index )
        {
            ignoreComboChange = true;
            var combo = cell as DataGridViewComboBoxCell;
            combo.Value = combo.Items[index];
            ignoreComboChange = false;
        }

        private void HighlightMouseDown( object sender, MouseEventArgs e )
        {
            if( trainingMode )
                return;

            PictureBox highlight = sender as PictureBox;
            bool modifyRoutinesTable = routinesGroupBox.Visible && routinesGrid.CurrentRow != null;

            if( placingRightHand )
            {
                if( rightHand != null && highlight != rightHand )
                    rightHand.Image = null;
                if( highlight == leftHand )
                {
                    leftHand = null;
                    SetComboSelectedIndex( leftHand_Combo, 18 );

                    if( modifyRoutinesTable )
                        SetComboSelectedIndex( routinesGrid.CurrentRow.Cells[0], 18 );
                }

                rightHand = highlight;
                var index = highlights.FindIndex( ( PictureBox p ) => p == rightHand ) % 18;
                SetComboSelectedIndex( rightHand_Combo, index );

                if( modifyRoutinesTable )
                    SetComboSelectedIndex( routinesGrid.CurrentRow.Cells[1], index );
            }
            else
            {
                if( leftHand != null && highlight != leftHand )
                    leftHand.Image = null;
                if( highlight == rightHand )
                {
                    rightHand = null;
                    SetComboSelectedIndex( rightHand_Combo, 18 );

                    if( modifyRoutinesTable )
                        SetComboSelectedIndex( routinesGrid.CurrentRow.Cells[1], 18 );
                }

                leftHand = highlight;
                var index = highlights.FindIndex( ( PictureBox p ) => p == leftHand ) % 18;
                SetComboSelectedIndex( leftHand_Combo, index );

                if( modifyRoutinesTable )
                    SetComboSelectedIndex( routinesGrid.CurrentRow.Cells[0], index );
            }

            placingRightHand = !placingRightHand;
        }

        private void hangboardImage_SizeChanged( object sender, EventArgs e )
        {
            var hangboardTrueSize = GetHangboardTrueSize();
            var hangboardCentre = new Point( hangboardImage.Left + hangboardImage.Width / 2, hangboardImage.Top + hangboardImage.Height / 2 );

            foreach( var highlight in highlights )
            {
                // Calculate the new Location by using the ratios
                var ratios = highlightRatios[highlight];
                
                Size newLoc = new Size( Convert.ToInt32( hangboardTrueSize.Width * ratios.locX ), Convert.ToInt32( hangboardTrueSize.Height * ratios.locY ) );
                highlight.Location = new Point( hangboardCentre.X + newLoc.Width, hangboardCentre.Y + newLoc.Height );
                highlight.Size = new Size( Convert.ToInt32( hangboardTrueSize.Width * ratios.sizeX ), Convert.ToInt32( hangboardTrueSize.Height * ratios.sizeY ) );
            }
        }

        private void leftHand_Combo_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( LeftHandComboSelectedchanged( leftHand_Combo.SelectedIndex ) )
                SetComboSelectedIndex( rightHand_Combo, 18 );
        }

        private bool LeftHandComboSelectedchanged( int selectedIndex )
        {
            if( ignoreComboChange )
                return false;

            if( leftHand != null )
            {
                leftHand.Image = null;
                leftHand = null;
            }

            if( selectedIndex == 18 )
                return false;

            leftHand = highlights[selectedIndex];
            SetHighlight( leftHand, false );

            if( leftHand == rightHand )
            {
                rightHand = null;
                return true;
            }

            return false;
        }

        private void rightHand_Combo_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( RightHandComboSelectedchanged( rightHand_Combo.SelectedIndex ) )
                SetComboSelectedIndex( leftHand_Combo, 18 );
        }

        private bool RightHandComboSelectedchanged( int selectedIndex )
        {
            if( ignoreComboChange )
                return false;

            if( rightHand != null )
            {
                rightHand.Image = null;
                rightHand = null;
            }

            if( selectedIndex == 18 )
                return false;

            rightHand = highlights[selectedIndex + ( selectedIndex < 13 ? 18 : 0 )];
            SetHighlight( rightHand, true );

            if( rightHand == leftHand )
            {
                leftHand = null;
                return true;
            }

            return false;
        }

        private void saveBtn_Click( object sender, EventArgs e )
        {
            var newRecord = GetRecordFromGrid( recordsGrid.Rows[0].Cells );

            if( addingRow )
                recordsData.Add( newRecord );
            else
                recordsData[editRowIndex] = newRecord;

            Records.SaveRecords( recordsData );

            filteredData = new List<Records.GridRecord>( recordsData );
            CancelEditingMode();
        }

        private Records.GridRecord GetRecordFromGrid( DataGridViewCellCollection cells )
        {
            var newRecord = new Records.GridRecord();
            newRecord.category = cells[0].Value.ToString();
            newRecord.leftHandHold = cells[1].Value.ToString();
            newRecord.rightHandHold = cells[2].Value.ToString();
            newRecord.name = cells[3].Value.ToString();
            newRecord.record = cells[4].Value.ToString();
            newRecord.units = cells[5].Value.ToString();
            newRecord.description = cells[6].Value != null ? cells[6].Value.ToString() : "";
            return newRecord;
        }

        private void addBtn_Click( object sender, EventArgs e )
        {
            cancelBtn.Enabled = true;
            addingRow = true;
            ClearRecordsTable();
            SetGridEditMode( true );

            var newRecord = new Records.GridRecord();
            newRecord.leftHandHold = leftHand_Combo.SelectedItem.ToString();
            newRecord.rightHandHold = rightHand_Combo.SelectedItem.ToString();
            AddToRecordsTable( newRecord );
        }

        private void editBtn_Click( object sender, EventArgs e )
        {
            saveBtn.Enabled = true;
            cancelBtn.Enabled = true;
            var record = GetRecordFromGrid( recordsGrid.CurrentRow.Cells );
            editRowIndex = recordsData.FindIndex( ( x ) => { return x == record; } );
            SetGridEditMode( true );
            ClearRecordsTable();
            AddToRecordsTable( record );
        }

        private void cancelBtn_Click( object sender, EventArgs e )
        {
            CancelEditingMode();
        }

        private void CancelEditingMode()
        {
            cancelBtn.Enabled = false;
            saveBtn.Enabled = false;
            editBtn.Enabled = false;
            addingRow = false;
            editRowIndex = -1;
            RefreshRecordsTable();
            SetGridEditMode( false );
        }

        private void SetGridEditMode( bool edit )
        {
            recordsGrid.ReadOnly = !edit;
            recordsGrid.SelectionMode = edit ? System.Windows.Forms.DataGridViewSelectionMode.CellSelect : System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }

        private void recordsGrid_CellValueChanged( object sender, DataGridViewCellEventArgs e )
        {
            if( addingRow || editRowIndex != -1 )
            {
                var name = recordsGrid.Rows[0].Cells[3];
                var record = recordsGrid.Rows[0].Cells[4];

                saveBtn.Enabled = name.Value != null && 
                    name.Value.ToString().Length > 0 &&
                    record.Value != null && 
                    name.Value.ToString().Length > 0 && 
                    name.Value.ToString() != "0";
            }
        }

        private void recordsGrid_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( addingRow && recordsGrid.IsCurrentCellDirty )
            {
                recordsGrid.CommitEdit( DataGridViewDataErrorContexts.Commit );
            }
        }

        private void recordsGrid_EditingControlShowing( object sender, DataGridViewEditingControlShowingEventArgs e )
        {
            TextBox tb = e.Control as TextBox;

            if( tb == null )
                return;

            tb.KeyPress -= new KeyPressEventHandler( RecordKeyPress );

            if( recordsGrid.CurrentCell.ColumnIndex == 4 )
                tb.KeyPress += new KeyPressEventHandler( RecordKeyPress );
        }

        private void routinesGrid_EditingControlShowing( object sender, DataGridViewEditingControlShowingEventArgs e )
        {   
            TextBox tb = e.Control as TextBox;

            if( tb == null )
                return;

            tb.KeyPress -= new KeyPressEventHandler( RecordKeyPressDigits );
            tb.KeyPress -= new KeyPressEventHandler( RecordKeyPress );

            if( routinesGrid.CurrentCell.ColumnIndex == 2 )
                tb.KeyPress += new KeyPressEventHandler( RecordKeyPressDigits );

            else if( routinesGrid.CurrentCell.ColumnIndex == 3 )
                tb.KeyPress += new KeyPressEventHandler( RecordKeyPress );
        }

        private void RecordKeyPress( object sender, KeyPressEventArgs e )
        {
            if( !char.IsControl( e.KeyChar ) && !char.IsDigit( e.KeyChar ) && e.KeyChar != '.' && e.KeyChar != ':' )
                e.Handled = true;
        }

        private void RecordKeyPressDigits( object sender, KeyPressEventArgs e )
        {
            if( !char.IsControl( e.KeyChar ) && !char.IsDigit( e.KeyChar ) )
                e.Handled = true;
        }

        private void searchTerm_Entry_TextChanged( object sender, EventArgs e )
        {
            var text = ( sender as TextBox ).Text;

            // Add to our current search term
            if( searchTerm == null ||
                searchTerm.Length == 0 ||
                text.Length <= searchTerm.Length ||
                text.Substring( 0, searchTerm.Length ) != searchTerm ||
                text.Contains( "=" ) )
            {
                filteredData = new List<Records.GridRecord>( recordsData );
            }

            filteredData.RemoveAll( ( Records.GridRecord record ) => !RecordContains( record, text ) );
            searchTerm = text;

            ClearRecordsTable();

            foreach( var x in filteredData )
                AddToRecordsTable( x );
        }

        private bool RecordContains( Records.GridRecord record, string search )
        {
            search = search.ToLower();

            if( record.ToString().ToLower().Contains( search ) )
                return true;

            // Add specific searching
            var columns = record.GetAllColumns();
            var searchTerms = search.Split( ',' );
            var valid = false;

            foreach( var x in searchTerms )
            {
                var split = x.Split( '=' );

                if( split.Length != 2 )
                    continue;

                var index = Array.IndexOf( columns.Select( ( y ) => {  return y.ToLower(); } ).ToArray(), ClimbingRecords.Records.RemoveWhitespace( split[0] ) );

                if( index != -1 )
                {
                    valid = record.GetColumnValueByIndex( index ).ToLower().Contains( split[1].Trim() );
                    
                    if( !valid )
                        return false;
                }
            }

            return valid;
        }

        private void recordsGrid_SelectionChanged( object sender, EventArgs e )
        {
            if( recordsGrid.SelectedRows.Count > 0 ) 
                editBtn.Enabled = !addingRow;
        }

        private void groupBox2_Paint( object sender, PaintEventArgs e )
        {
            var size = 2;
            System.Drawing.Rectangle rect = new Rectangle( leftHand_Combo.Location.X, leftHand_Combo.Location.Y, leftHand_Combo.ClientSize.Width, leftHand_Combo.ClientSize.Height );
            rect.Inflate( size, size );
            System.Windows.Forms.ControlPaint.DrawBorder( e.Graphics, rect, Color.Yellow, ButtonBorderStyle.Solid );

            rect = new Rectangle( rightHand_Combo.Location.X, rightHand_Combo.Location.Y, rightHand_Combo.ClientSize.Width, rightHand_Combo.ClientSize.Height );
            rect.Inflate( size, size );
            System.Windows.Forms.ControlPaint.DrawBorder( e.Graphics, rect, Color.LimeGreen, ButtonBorderStyle.Solid );
        }

        private void showHoldNumbersCheckBox_CheckedChanged( object sender, EventArgs e )
        {
            hangboardImage.Image = ( sender as CheckBox ).Checked ? ClimbingRecords.Properties.Resources.BoardWithNumbers : ClimbingRecords.Properties.Resources.Board;
        }

        private void startTrainingBtn_Click( object sender, EventArgs e )
        {
            mainTitle.Text = trainingCombo.Text;
            recordsGroupBox.Visible = false;
            routinesGroupBox.Visible = true;
            CancelEditingMode();

            editRowIndex = trainingCombo.SelectedIndex;

            // Load routine into table
            var routine = routinesData[editRowIndex];
            LoadRoutine( routine );

            SetTrainingMode( true );
        }

        private void SetTrainingMode( bool training )
        {
            routineNameText.ReadOnly = training;
            routineDifficultyTrackbar.Enabled = !training;
            routineDescriptionText.ReadOnly = training;
            addExerciseButton.Visible = !training;
            deleteExerciseButton.Visible = !training;
            saveRoutineButton.Visible = !training;
            createRoutineButton.Text = "Begin";
            routinesGrid.ReadOnly = training;
            trainingMode = training;
        }

        private void customRoutineBtn_Click( object sender, EventArgs e )
        {
            mainTitle.Text = "Custom Routine";
            saveRoutineButton.Enabled = false;
            recordsGroupBox.Visible = false;
            routinesGroupBox.Visible = true;
            CancelEditingMode();

            var emptyRoutine = new Routines.GridRoutine();
            emptyRoutine.exercises = new List<Routines.GridExercise>();
            emptyRoutine.exercises.Add( new Routines.GridExercise() );
            LoadRoutine( emptyRoutine );
        }

        private void backButton_Click( object sender, EventArgs e )
        {
            mainTitle.Text = "Hangboard Records";
            routineNameErrorLabel.Visible = false;
            recordsGroupBox.Visible = true;
            routinesGroupBox.Visible = false;
            editRowIndex = -1;

            if( trainingMode )
                SetTrainingMode( false );
        }

        private void ValidateCreateButton( object sender, EventArgs e )
        {
            createRoutineButton.Enabled = routinesGrid.RowCount > 0 && routineNameText.Text.Length > 0;
        }

        private void createRoutineButton_Click( object sender, EventArgs e )
        {
            if( trainingMode )
            {
                trainingGroupBox.Visible = true;
                routinesGroupBox.Visible = false;
            }
            else
            {
                foreach( var routine in routinesData )
                {
                    if( routine.name == routineNameText.Text )
                    {
                        routineNameErrorLabel.Visible = true;
                        return;
                    }
                }

                SaveRoutine();
            }
        }

        private void saveRoutineButton_Click( object sender, EventArgs e )
        {
            SaveRoutine();
        }

        private void SaveRoutine()
        {
            routineNameErrorLabel.Visible = false;

            // Read from grid
            var newRoutine = new Routines.GridRoutine();
            newRoutine.description = routineDescriptionText.Text;
            newRoutine.name = routineNameText.Text;
            newRoutine.difficulty = routineDifficultyTrackbar.Value;
            newRoutine.exercises = new List<Routines.GridExercise>();

            foreach( var row in routinesGrid.Rows )
            {
                var cells = ( row as DataGridViewRow ).Cells;

                if( cells[0].Value == null )
                    continue;

                var newExercise = new Routines.GridExercise();
                newExercise.leftHandHold = cells[0].Value.ToString();
                newExercise.rightHandHold = cells[1].Value.ToString();
                newExercise.duration = cells[2].Value.ToString();
                newExercise.rest = cells[3].Value.ToString();
                newExercise.description = cells[4].Value == null ? "" : cells[4].Value.ToString();
                newRoutine.exercises.Add( newExercise );
            }

            if( editRowIndex != -1 )
                routinesData[editRowIndex] = newRoutine;
            else
                routinesData.Add( newRoutine );

            Routines.SaveRoutines( routinesData );

            mainTitle.Text = "Hangboard Records";
            recordsGroupBox.Visible = true;
            routinesGroupBox.Visible = false;
            editRowIndex = -1;

            var routines = new List<String>();

            foreach( var routine in routinesData )
                routines.Add( routine.name );

            trainingCombo.DataSource = routines;
        }

        private void addExerciseButton_Click( object sender, EventArgs e )
        {
            var exercise = new Routines.GridExercise();
            exercise.leftHandHold = leftHand_Combo.SelectedItem.ToString();
            exercise.rightHandHold = rightHand_Combo.SelectedItem.ToString();
            AddToExercisesTable( exercise );
        }

        private void routinesGrid_CurrentCellChanged( object sender, EventArgs e )
        {
            deleteExerciseButton.Enabled = routinesGrid.CurrentRow != null && routinesGrid.Rows.Count > 1;

            if( routinesGrid.CurrentRow != null )
            {
                RoutinesGridHandComboChanged( routinesGrid.CurrentRow.Index, 0, false );
                RoutinesGridHandComboChanged( routinesGrid.CurrentRow.Index, 1, true );
            }
        }

        private void deleteExerciseButton_Click( object sender, EventArgs e )
        {
            routinesGrid.Rows.Remove( routinesGrid.CurrentRow );
        }

        private void editRoutineButton_Click( object sender, EventArgs e )
        {
            saveRoutineButton.Enabled = true;
            mainTitle.Text = "Edit Routine";
            recordsGroupBox.Visible = false;
            routinesGroupBox.Visible = true;
            CancelEditingMode();
            editRowIndex = trainingCombo.SelectedIndex;

            // Load routine into table
            var routine = routinesData[editRowIndex];
            LoadRoutine( routine );

            // Load highlights from first row
            if( routinesGrid.RowCount > 0 )
            {
                RoutinesGridHandComboChanged( 0, 0, false );
                RoutinesGridHandComboChanged( 0, 1, true );
            }
        }

        private void LoadRoutine( Routines.GridRoutine routine )
        {
            routineDescriptionText.Text = routine.description;
            routineNameText.Text = routine.name;
            routineDifficultyTrackbar.Value = routine.difficulty;
            ClearExercisesTable();

            foreach( var exercise in routine.exercises )
                AddToExercisesTable( exercise );
        }

        private void trainingCombo_SelectedValueChanged( object sender, EventArgs e )
        {
            editRoutineButton.Enabled = trainingCombo.SelectedValue != null;
        }

        private Size GetHangboardTrueSize()
        {
            var hangboardTrueSize = hangboardImage.Size; 
            var parentAspectRatio = hangboardTrueSize.Width / Convert.ToDouble( hangboardTrueSize.Height );

            // More square (lower aspect ratio than the image) means we are limiting by width
            if( parentAspectRatio < hangboardOriginalRatio )
                hangboardTrueSize.Height = Convert.ToInt32( hangboardTrueSize.Width / hangboardOriginalRatio );
            // Else we are limiting by height (higher aspect ratio than the image)
            else
                hangboardTrueSize.Width = Convert.ToInt32( hangboardTrueSize.Height * hangboardOriginalRatio );

            return hangboardTrueSize;
        }

        private void routinesGrid_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( routinesGrid.IsCurrentCellDirty )
            {
                // This fires the cell value changed handler below
                routinesGrid.CommitEdit( DataGridViewDataErrorContexts.Commit );
            }
        }

        private void routinesGrid_CellValueChanged( object sender, DataGridViewCellEventArgs e )
        {
            if( e.RowIndex < 0 || e.ColumnIndex > 1 || ignoreComboChange )
                return;

            RoutinesGridHandComboChanged( e.RowIndex, e.ColumnIndex, true );
        }

        private void routineDifficultyTrackbar_ValueChanged( object sender, EventArgs e )
        {
            label6.Text = "Difficulty: " + routineDifficultyTrackbar.Value.ToString();
        }

        private void trainingCancelButton_Click( object sender, EventArgs e )
        {
            recordsGroupBox.Visible = true;
            trainingGroupBox.Visible = false;
            mainTitle.Text = "Hangboard Records";
        }

        private void RoutinesGridHandComboChanged( int rowIndex, int columnIndex, bool canSwap )
        {
            var combo = routinesGrid.Rows[rowIndex].Cells[columnIndex] as DataGridViewComboBoxCell;

            if( combo.Value == null )
                return;

            var otherCombo = routinesGrid.Rows[rowIndex].Cells[1 - columnIndex] as DataGridViewComboBoxCell;
            bool swap = false;

            if( columnIndex == 0 )
                swap = LeftHandComboSelectedchanged( combo.Items.IndexOf( combo.Value ) );
            else if( columnIndex == 1 )
                swap = RightHandComboSelectedchanged( combo.Items.IndexOf( combo.Value ) );

            if( swap && canSwap )
                SetComboSelectedIndex( otherCombo, 18 );

            routinesGrid.Invalidate();
        }
    }
}
