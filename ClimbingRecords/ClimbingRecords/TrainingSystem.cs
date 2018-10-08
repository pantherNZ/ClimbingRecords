using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClimbingRecords
{
    class TrainingSystem
    {
        private Timer updateTimer;
        private int index = 0;
        private int hangCounter = 0;
        private int restCounter = 0;
        private DataGridView exercisesGrid;
        private Label[] timerLabels;
        private Label exerciseNumLabel;
        private Label trainingInfoLabel;
        private TextBox[] holdTextBoxes;
        private bool rest = false;
        private bool active = false;

        public TrainingSystem( DataGridView exercisesGrid, Label hangLabel, Label restLabel, Label exerciseLabel, Label infoLabel, TextBox currentLeftHold, TextBox currentRightHold, TextBox nextLeftHold, TextBox nextRightHold )
        {
            this.exercisesGrid = exercisesGrid;
            timerLabels = new Label[] { hangLabel, restLabel };
            exerciseNumLabel = exerciseLabel;
            trainingInfoLabel = infoLabel;
            holdTextBoxes = new TextBox[] { currentLeftHold, currentRightHold, nextLeftHold, nextRightHold };
        }

        public void Start()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += new EventHandler( Tick );
            updateTimer.Start();
            index = 0;
            active = true;
        }

        public void Stop()
        {
            updateTimer.Stop();
        }

        public void TogglePause()
        {
            updateTimer.Enabled = !updateTimer.Enabled;
        }

        public bool IsPaused()
        {
            return !updateTimer.Enabled;
        }

        public bool IsActive()
        {
            return active;
        }

        public void LoadNextExercise()
        {
            var cells = exercisesGrid.Rows[index].Cells;

            // Current holds
            holdTextBoxes[0].Text = cells[0].Value.ToString();
            holdTextBoxes[1].Text = cells[1].Value.ToString();

            // Next holds
            if( index + 1 == exercisesGrid.RowCount )
            {
                holdTextBoxes[0].Text = holdTextBoxes[1].Text = "None";
            }
            else
            {
                holdTextBoxes[0].Text = exercisesGrid.Rows[index + 1].Cells[0].Value.ToString();
                holdTextBoxes[1].Text = exercisesGrid.Rows[index + 1].Cells[1].Value.ToString();
            }

            // Durations
            hangCounter = Convert.ToInt32( cells[2].Value );
            restCounter = Convert.ToInt32( cells[3].Value );
            timerLabels[0].Text = String.Format( "Hang {0} seconds", hangCounter );
            timerLabels[1].Text = String.Format( "Rest {0} seconds", restCounter );

            // Description
            trainingInfoLabel.Text = cells[4].Value.ToString();

            ++index;

            // Exercises num
            exerciseNumLabel.Text = String.Format( "{0} / {1}", index, exercisesGrid.RowCount );
        }

        private void Tick( object sender, EventArgs e )
        {
            if( rest )
            {
                restCounter--;
                timerLabels[1].Text = String.Format( "Rest {0} seconds", restCounter );

                if( restCounter == 0 )
                {
                    var defaultScale = new System.Drawing.SizeF( 1.0f, 1.0f );
                    //timerLabels[0].Scale( defaultScale );
                    //timerLabels[1].Scale( defaultScale );
                    LoadNextExercise();
                }
            }
            else
            {
                hangCounter--;
                timerLabels[0].Text = String.Format( "Hang {0} seconds", hangCounter );

                if( hangCounter == 0 )
                {
                    rest = true;
                    //timerLabels[0].Scale( new System.Drawing.SizeF( 0.5f, 0.5f ) );
                    //timerLabels[1].Scale( new System.Drawing.SizeF( 2.0f, 2.0f ) );
                }
            }
        }
    }
}
