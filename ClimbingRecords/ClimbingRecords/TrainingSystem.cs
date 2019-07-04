using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Speech.Synthesis;

namespace ClimbingRecords
{
    public partial class HangboardForm : Form
    {
        private Timer updateTimer;
        private int exerciseIndex = 0;
        private int hangCounter = 0;
        private int restCounter = 0;
        private int startCounter = 0;
        private bool active = false;

        private bool _rest = false;
        private bool rest
        {
            get { return _rest; }
            set
            {
                if( value != _rest )
                {
                    _rest = value;
                    trainingGroupBox.Invalidate();

                    var font = trainingHangTimerLabel.Font;
                    trainingHangTimerLabel.Font = trainingRestTimerLabel.Font;
                    trainingRestTimerLabel.Font = font;
                }
            }
        }

        private System.Media.SoundPlayer beepPlayer = new System.Media.SoundPlayer( ClimbingRecords.Properties.Resources.beep );
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private Random rng = new Random();
        private bool abusePlayed = false;

        private String[] abuses = new String[]
        {
            "Keep going you bitch",
            "Try harder dickhead",
            "Put some effort in useless prick",
            "Fight the burn you wimp",
            "Stop being a bitch",
            "You suck, try harder!",
            "Garbage effort so far",
            "If you don't finish this, I will murder you",
            "One more you pussy",
            "Failing is for shit heads",
            "Lose some weight you fat fuck",
            "Stop complaining idiot",
            "Quit whinging you little bitch",
        };

        private void Start()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += new EventHandler( Tick );
            updateTimer.Start();
            active = true;
        }

        private void Stop()
        {
            if( updateTimer != null )
                updateTimer.Stop();

            active = false;
            trainingPauseButton.Text = "Start";
        }

        private void TogglePause()
        {
            updateTimer.Enabled = !updateTimer.Enabled;
        }

        private bool IsPaused()
        {
            return !updateTimer.Enabled;
        }

        private void LoadNextExercise( bool ignoreSwitch )
        {
            if( !rest && !ignoreSwitch )
            {
                SwitchToRest();

                if( CheckFinished() )
                    return;
            }

            synthesizer.SpeakAsyncCancelAll();
            var cells = exercisesGrid.Rows[exerciseIndex].Cells;
            rest = false;
            abusePlayed = false;

            // Current holds
            trainingLeftHandHold.Text = cells[0].Value.ToString();
            trainingRightHandHold.Text = cells[1].Value.ToString();

            // Next holds
            if( exerciseIndex + 1 == exercisesGrid.RowCount )
            {
                trainingNextLeftHandHold.Text = trainingNextRightHandHold.Text = "None";
                trainingNextInfoLabel.Text = "";
            }
            else
            {
                trainingNextLeftHandHold.Text = exercisesGrid.Rows[exerciseIndex + 1].Cells[0].Value.ToString();
                trainingNextRightHandHold.Text = exercisesGrid.Rows[exerciseIndex + 1].Cells[1].Value.ToString();
                trainingNextInfoLabel.Text = exercisesGrid.Rows[exerciseIndex + 1].Cells[4].Value.ToString();
            }

            // Durations
            hangCounter = Convert.ToInt32( cells[2].Value );
            restCounter = Convert.ToInt32( cells[3].Value );
            trainingHangTimerLabel.Text = String.Format( "Hang {0} seconds", hangCounter );
            trainingRestTimerLabel.Text = String.Format( "Rest {0} seconds", restCounter );

            // Description
            var description = cells[4].Value.ToString();
            trainingInfoLabel.Text = ( description.Length > 0 ? description : "" );

            ++exerciseIndex;

            // Exercises num
            trainingExerciseCountLabel.Text = String.Format( "Exercise {0} / {1}", exerciseIndex, exercisesGrid.RowCount );

            if( hangCounter == 0 )
                LoadNextExercise( false );
        }

        private void SwitchToRest()
        {
            trainingHangTimerLabel.Text = "Hang Complete";
            rest = true;

            if( exerciseIndex == exercisesGrid.RowCount )
            {
                LeftHandComboSelectedchanged( 18 );
                RightHandComboSelectedchanged( 18 );
            }
            else
            {
                ExercisesGridHandComboChanged( exerciseIndex, 0, false );
                ExercisesGridHandComboChanged( exerciseIndex, 1, true );

                if( restCounter > 0 )
                {
                    synthesizer.Volume = 100;  // 0...100
                    synthesizer.Rate = -1;     // -10...10
                    var leftHand = exercisesGrid.Rows[exerciseIndex].Cells[0].Value.ToString();
                    var rightHand = exercisesGrid.Rows[exerciseIndex].Cells[1].Value.ToString();
                    var formatText = ( leftHand == rightHand ? "One hand on each number {0}" : "Left hand hold on number {0}. Right hand hold on number {1}." );
                    synthesizer.SpeakAsync( String.Format( formatText, leftHand , rightHand ) );
                }
            }
        }

        private bool CheckFinished()
        {
            if( exerciseIndex == exercisesGrid.RowCount )
            {
                rest = false;
                trainingInfoLabel.Text = "";
                trainingSkipButton.Enabled = false;
                trainingHangTimerLabel.Text = "Finished";
                trainingRestTimerLabel.Text = "";
                Stop();
                trainingPauseButton.Text = "Finish";
            }

            return exerciseIndex == exercisesGrid.RowCount;
        }

        private void Tick( object sender, EventArgs e )
        {
            if( startCounter != 0 )
            {
                startCounter--;
                startingLabel.Text = String.Format( "Starting in {0}..", startCounter );

                if( startCounter == 0 )
                    startingLabel.Visible = false;
                else if( enableSoundsCheckbox.Checked && startCounter <= 3 )
                    beepPlayer.Play();

                return;
            }

            if( rest )
            {
                restCounter--;
                trainingRestTimerLabel.Text = String.Format( "Rest {0} seconds", restCounter );

                if( restCounter <= 0 )
                {
                    LoadNextExercise( false );
                }
                else if( restCounter <= 3 && enableSoundsCheckbox.Checked )
                    beepPlayer.Play();
            }
            else
            {
                hangCounter--;
                trainingHangTimerLabel.Text = String.Format( "Hang {0} seconds", hangCounter );

                if( hangCounter <= 0 )
                {
                    SwitchToRest();

                    if( !CheckFinished() && restCounter <= 0 )
                        LoadNextExercise( false );
                }
                else 
                {
                    if( enableSoundsCheckbox.Checked && hangCounter <= 3 )
                        beepPlayer.Play();

                    if( enableSoundsCheckbox.Checked && enableAbuseCheckbox.Checked && !abusePlayed && rng.Next( 1, 30 ) == 1 && hangCounter >= 6 )
                    {
                        abusePlayed = true;
                        synthesizer.SpeakAsync( abuses[rng.Next( 0, abuses.Length - 1 )].ToUpper() );
                    }
                }
            }
        }

        private void routinesGrid_CurrentCellDirtyStateChanged( object sender, EventArgs e )
        {
            if( exercisesGrid.IsCurrentCellDirty )
            {
                // This fires the cell value changed handler below
                exercisesGrid.CommitEdit( DataGridViewDataErrorContexts.Commit );
            }
        }

        private void routinesGrid_CellValueChanged( object sender, DataGridViewCellEventArgs e )
        {
            if( e.RowIndex < 0 || e.ColumnIndex > 1 || ignoreComboChange )
                return;

            ExercisesGridHandComboChanged( e.RowIndex, e.ColumnIndex, true );
        }

        private void routineDifficultyTrackbar_ValueChanged( object sender, EventArgs e )
        {
            label6.Text = "Difficulty: " + routineDifficultyTrackbar.Value.ToString();
        }

        private void trainingCancelButton_Click( object sender, EventArgs e )
        {
            CloseTraining();
        }

        private void CloseTraining()
        {
            recordsGroupBox.Visible = true;
            trainingGroupBox.Visible = false;
            mainTitle.Text = "Hangboard Records";
            exerciseIndex = 0;
            hangCounter = restCounter = 0;
            trainingSkipButton.Enabled = true;
            Stop();
            synthesizer.SpeakAsyncCancelAll();
            SetTrainingMode( false );
            startingLabel.Visible = false;

            LeftHandComboSelectedchanged( 18 );
            RightHandComboSelectedchanged( 18 );
        }

        private void trainingPauseButton_Click( object sender, EventArgs e )
        {
            if( exerciseIndex == exercisesGrid.RowCount )
            {
                CloseTraining();
                return;
            }

            if( !active )
            {
                Start();
                startCounter = 5;
                startingLabel.Visible = true;
                startingLabel.Text = "Starting in 5..";
                trainingPauseButton.Text = "Pause";
                return;
            }

            TogglePause();
            trainingPauseButton.Text = IsPaused() ? "Resume" : "Pause";
        }

        private void trainingSkipButton_Click( object sender, EventArgs e )
        {
            LoadNextExercise( false );
        }

        private void trainingCombo_SelectedValueChanged( object sender, EventArgs e )
        {
            editRoutineButton.Enabled = trainingCombo.SelectedValue != null;
        }

        private void trainingGroupBox_Paint( object sender, PaintEventArgs e )
        {
            DrawBorder( e, trainingLeftHandHold, 2, Color.Yellow );
            DrawBorder( e, trainingRightHandHold, 2, Color.LimeGreen );

            DrawBorder( e, trainingNextLeftHandHold, 2, Color.Yellow );
            DrawBorder( e, trainingNextRightHandHold, 2, Color.LimeGreen );

            if( exerciseIndex < exercisesGrid.RowCount )
            {
                trainingNextInfoLabel.Visible = trainingNextInfoLabel.Text != "";

                // Draw rectangle around current or next holds base on current stage
                var x = ( rest ? trainingNextLabel.Location.X : trainingCurrentLabel.Location.X );
                var height = rest && trainingNextInfoLabel.Text != "" ? 155 + trainingNextInfoLabel.Height : 150;
                var rect = new Rectangle( x - ( rest ? 135 : 100 ), trainingCurrentLabel.Location.Y - 10, 380, height );
                rect.Inflate( 2, 2 );
                ControlPaint.DrawBorder( e.Graphics, rect, Color.Aqua, ButtonBorderStyle.Solid );
            }
        }
    }
}
