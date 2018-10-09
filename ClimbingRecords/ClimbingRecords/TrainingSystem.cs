﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ClimbingRecords
{
    public partial class HangboardForm : Form
    {
        private Timer updateTimer;
        private int exerciseIndex = 0;
        private int hangCounter = 0;
        private int restCounter = 0;
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

        private void Start()
        {
            updateTimer = new Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += new EventHandler( Tick );
            updateTimer.Start();
            exerciseIndex = 1;
            active = true;
        }

        private void Stop()
        {
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

        private void LoadNextExercise()
        {
            var cells = exercisesGrid.Rows[exerciseIndex].Cells;

            rest = false;

            // Current holds
            trainingLeftHandHold.Text = cells[0].Value.ToString();
            trainingRightHandHold.Text = cells[1].Value.ToString();

            // Next holds
            if( exerciseIndex + 1 == exercisesGrid.RowCount )
            {
                trainingNextLeftHandHold.Text = trainingNextRightHandHold.Text = "None";
            }
            else
            {
                trainingNextLeftHandHold.Text = exercisesGrid.Rows[exerciseIndex + 1].Cells[0].Value.ToString();
                trainingNextRightHandHold.Text = exercisesGrid.Rows[exerciseIndex + 1].Cells[1].Value.ToString();
            }

            // Durations
            hangCounter = Convert.ToInt32( cells[2].Value );
            restCounter = Convert.ToInt32( cells[3].Value );
            trainingHangTimerLabel.Text = String.Format( "Hang {0} seconds", hangCounter );
            trainingRestTimerLabel.Text = String.Format( "Rest {0} seconds", restCounter );

            // Description
            var description = cells[4].Value.ToString();
            trainingInfoLabel.Text = ( description.Length > 0 ? "Info:  " + description : "" );

            ++exerciseIndex;

            // Exercises num
            trainingExerciseCountLabel.Text = String.Format( "Exercise {0} / {1}", exerciseIndex, exercisesGrid.RowCount );
        }

        private void Tick( object sender, EventArgs e )
        {
            if( rest )
            {
                restCounter--;
                trainingRestTimerLabel.Text = String.Format( "Rest {0} seconds", restCounter );

                if( restCounter == 0 )
                {
                    LoadNextExercise();
                }
            }
            else
            {
                hangCounter--;
                trainingHangTimerLabel.Text = String.Format( "Hang {0} seconds", hangCounter );

                if( hangCounter == 0 )
                {
                    rest = true;
                    trainingInfoLabel.Text = "";

                    if( exerciseIndex == exercisesGrid.RowCount )
                    {
                        LeftHandComboSelectedchanged( 18 );
                        RightHandComboSelectedchanged( 18 );
                    }
                    else
                    {
                        ExercisesGridHandComboChanged( exerciseIndex, 0, false );
                        ExercisesGridHandComboChanged( exerciseIndex, 1, true );
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
            recordsGroupBox.Visible = true;
            trainingGroupBox.Visible = false;
            mainTitle.Text = "Hangboard Records";
        }

        private void trainingPauseButton_Click( object sender, EventArgs e )
        {
            if( !active )
            {
                Start();
                trainingPauseButton.Text = "Pause";
                return;
            }

            TogglePause();
            trainingPauseButton.Text = IsPaused() ? "Resume" : "Pause";
        }

        private void trainingSkipButton_Click( object sender, EventArgs e )
        {
            LoadNextExercise();
        }

        private void trainingCombo_SelectedValueChanged( object sender, EventArgs e )
        {
            editRoutineButton.Enabled = trainingCombo.SelectedValue != null;
        }

        private void deleteExerciseButton_Click( object sender, EventArgs e )
        {
            exercisesGrid.Rows.Remove( exercisesGrid.CurrentRow );
        }

        private void trainingGroupBox_Paint( object sender, PaintEventArgs e )
        {
            DrawBorder( e, trainingLeftHandHold, 2, Color.Yellow );
            DrawBorder( e, trainingRightHandHold, 2, Color.LimeGreen );

            DrawBorder( e, trainingNextLeftHandHold, 2, Color.Yellow );
            DrawBorder( e, trainingNextRightHandHold, 2, Color.LimeGreen );

            // Draw rectangle around current or next holds base on current stage
            var x = ( rest ? trainingNextLabel.Location.X : trainingCurrentLabel.Location.X );
            var rect = new Rectangle( x - ( rest ? 135 : 100 ), trainingCurrentLabel.Location.Y - 10, 380, 150 );
            rect.Inflate( 2, 2 );
            ControlPaint.DrawBorder( e.Graphics, rect, Color.Aqua, ButtonBorderStyle.Solid );
        }
    }
}