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
    public partial class Form1 : Form
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
        List<Records.GridRecord> recordsData;

        public Form1()
        {
            InitializeComponent();

            hangboardOriginalRatio = hangboardImage.Image.Size.Width / Convert.ToDouble( hangboardImage.Image.Size.Height );
            InitialiseHighlightsArray();
            InitialiseDataSources();

            SetComboSelectedIndex( leftHand_Combo, 18 );
            SetComboSelectedIndex( rightHand_Combo, 18 );

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
        }

        private void InitialiseHighlightsArray()
        {
            highlights.Add( hangboardImage1 );
            highlights.Add( hangboardImage2 );
            highlights.Add( hangboardImage3 );
            highlights.Add( hangboardImage4 );
            highlights.Add( hangboardImage5 );
            highlights.Add( hangboardImage6 );
            highlights.Add( hangboardImage7 );
            highlights.Add( hangboardImage8 );
            highlights.Add( hangboardImage9 );
            highlights.Add( hangboardImage10 );
            highlights.Add( hangboardImage11 );
            highlights.Add( hangboardImage12 );
            highlights.Add( hangboardImage13 );
            highlights.Add( hangboardImage14 );
            highlights.Add( hangboardImage15 );
            highlights.Add( hangboardImage16 );
            highlights.Add( hangboardImage17 );
            highlights.Add( hangboardImage18 );
            highlights.Add( hangboardImage19 );
            highlights.Add( hangboardImage20 );
            highlights.Add( hangboardImage21 );
            highlights.Add( hangboardImage22 );
            highlights.Add( hangboardImage23 );
            highlights.Add( hangboardImage24 );
            highlights.Add( hangboardImage25 );
            highlights.Add( hangboardImage26 );
            highlights.Add( hangboardImage27 );
            highlights.Add( hangboardImage28 );
            highlights.Add( hangboardImage29 );
            highlights.Add( hangboardImage30 );
            highlights.Add( hangboardImage31 );
        }

        private void InitialiseDataSources()
        {
            foreach( var hold in Records.leftHoldNames )
                leftHand_Combo.Items.Add( hold );

            foreach( var hold in Records.rightHoldNames )
                rightHand_Combo.Items.Add( hold );

            recordsData = Records.LoadRecords();

            foreach( var x in recordsData )
                AddToRecordsTable( x );
        }

        private void AddToRecordsTable( Records.GridRecord record )
        {
            recordsGrid.Rows.Add();
            var cells = recordsGrid.Rows[recordsGrid.Rows.Count - 1].Cells;
            cells[0].Value = record.Category;
            cells[1].Value = record.LeftHandHold;
            cells[2].Value = record.RightHandHold;
            cells[3].Value = record.Person;
            cells[4].Value = record.Record;
            cells[5].Value = record.Units;
            cells[6].Value = record.Description;
        }

        private void ClearRecordsTable()
        {
            while( recordsGrid.Rows.Count > 0 )
                recordsGrid.Rows.RemoveAt( 0 );
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
            PictureBox highlight = sender as PictureBox;

            if( ( placingRightHand && highlight != rightHand ) || ( !placingRightHand && highlight != leftHand ) )
                SetHighlight( highlight, placingRightHand );
        }

        private void HighlightMouseLeave( object sender, EventArgs e )
        {
            PictureBox highlight = sender as PictureBox;

            if( highlight != leftHand && highlight != rightHand )
                highlight.Image = null;
            else
                SetHighlight( highlight, highlight == rightHand );
        }

        private void SetHighlight( PictureBox highlight, bool isRightHand )
        {
            var offset = ( highlight.Left + highlight.Width / 2.0f ) - ( hangboardImage.Left + hangboardImage.Width / 2.0f );
            highlight.Image = RotateImage( highlightImages[Convert.ToInt32( isRightHand )], offset / 40.0f );
        }

        private void SetComboSelectedIndex( ComboBox cb, int index )
        {
            ignoreComboChange = true;
            cb.SelectedIndex = index;
            ignoreComboChange = false;
        }

        private void HighlightMouseDown( object sender, MouseEventArgs e )
        {
            PictureBox highlight = sender as PictureBox;

            if( placingRightHand )
            {
                if( rightHand != null )
                    rightHand.Image = null;
                if( highlight == leftHand )
                {
                    leftHand = null;
                    SetComboSelectedIndex( leftHand_Combo, 18 );
                }

                rightHand = highlight;
                SetComboSelectedIndex( rightHand_Combo, highlights.FindIndex( ( PictureBox p ) => p == rightHand ) % 18 );
            }
            else
            {
                if( leftHand != null )
                    leftHand.Image = null;
                if( highlight == rightHand )
                {
                    rightHand = null;
                    SetComboSelectedIndex( rightHand_Combo, 18 );
                }

                leftHand = highlight;
                SetComboSelectedIndex( leftHand_Combo, highlights.FindIndex( ( PictureBox p ) => p == leftHand ) % 18 );
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
            if( ignoreComboChange )
                return;

            if( leftHand != null )
            {
                leftHand.Image = null;
                leftHand = null;
            }

            if( leftHand_Combo.SelectedIndex == 18 )
                return;

            leftHand = highlights[leftHand_Combo.SelectedIndex];
            SetHighlight( leftHand, false );

            if( leftHand == rightHand )
            {
                rightHand = null;
                SetComboSelectedIndex( rightHand_Combo, 18 );
            }
        }

        private void rightHand_Combo_SelectedIndexChanged( object sender, EventArgs e )
        {
            if( ignoreComboChange )
                return;

            if( rightHand != null )
            {
                rightHand.Image = null;
                rightHand = null;
            }

            if( rightHand_Combo.SelectedIndex == 18 )
                return;

            rightHand = highlights[rightHand_Combo.SelectedIndex + ( rightHand_Combo.SelectedIndex < 13 ? 18 : 0 )];
            SetHighlight( rightHand, true );

            if( rightHand == leftHand )
            {
                leftHand = null;
                SetComboSelectedIndex( leftHand_Combo, 18 );
            }
        }

        private void saveBtn_Click( object sender, EventArgs e )
        {
            var newRecord = new Records.GridRecord();
            var cells = recordsGrid.Rows[0].Cells;
            newRecord.Category = cells[0].Value.ToString();
            newRecord.LeftHandHold = cells[1].Value.ToString();
            newRecord.RightHandHold = cells[2].Value.ToString();
            newRecord.Person = cells[3].Value.ToString();
            newRecord.Record = cells[4].Value.ToString();
            newRecord.Units = cells[5].Value.ToString();
            newRecord.Description = cells[6].Value != null ? cells[6].Value.ToString() : "";
            recordsData.Add( newRecord );
            Records.SaveRecords( recordsData );
            addingRow = false;
            saveBtn.Enabled = false;
            recordsGrid.ReadOnly = true;
        }

        private void addBtn_Click( object sender, EventArgs e )
        {
            addingRow = true;
            recordsGrid.ReadOnly = false;
            ClearRecordsTable();
            var newRecord = new Records.GridRecord();
            newRecord.LeftHandHold = leftHand_Combo.SelectedItem.ToString();
            newRecord.RightHandHold = rightHand_Combo.SelectedItem.ToString();
            AddToRecordsTable( newRecord );
        }

        private void recordsGrid_CellValueChanged( object sender, DataGridViewCellEventArgs e )
        {
            if( addingRow )
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
            e.Control.KeyPress -= new KeyPressEventHandler( RecordKeyPress );

            if( recordsGrid.CurrentCell.ColumnIndex == 4 )
            {
                TextBox tb = e.Control as TextBox;
                if( tb != null )
                {
                    tb.KeyPress += new KeyPressEventHandler( RecordKeyPress );
                }
            }
        }

        private void RecordKeyPress( object sender, KeyPressEventArgs e )
        {
            if( !char.IsControl( e.KeyChar ) && !char.IsDigit( e.KeyChar ) && e.KeyChar != '.' && e.KeyChar != ':' )
            {
                e.Handled = true;
            }
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
    }
}
