using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClimbingRecords
{
    class Routines
    {
        public class GridExercise
        {
            public string leftHandHold = "None";
            public string rightHandHold = "None";
            public string duration = "0";
            public string rest = "60";
            public string description = "";
        }

        public class GridRoutine
        {
            public List<GridExercise> exercises;
            public string name;
            public int difficulty = 5;
            public string description;
        }

        static string xmlFilePath = "routines.xml";

        public static List<GridRoutine> LoadRoutines()
        {
            List<GridRoutine> routines = new List<GridRoutine>();

            if( !System.IO.File.Exists( xmlFilePath ) )
                return routines;

            var file = XElement.Load( xmlFilePath );

            if( file.IsEmpty )
                return routines;

            foreach( var routine in file.Elements() )
            {
                var newRoutine = new GridRoutine();
                newRoutine.exercises = new List<GridExercise>();

                foreach( var x in routine.Elements() )
                {
                    switch( x.Name.ToString() )
                    {
                        case "Name": newRoutine.name = x.Value; break;
                        case "Difficulty": newRoutine.difficulty = Convert.ToInt32( x.Value ); break;
                        case "Description": newRoutine.description = x.Value; break;
                        case "Exercises":
                            {
                                foreach( var y in x.Elements() )
                                {
                                    var newExercise = new GridExercise();

                                    foreach( var z in y.Elements() )
                                    {
                                        switch( z.Name.ToString() )
                                        {
                                            case "LeftHandHold": newExercise.leftHandHold = z.Value; break;
                                            case "RightHandHold": newExercise.rightHandHold = z.Value; break;
                                            case "Duration": newExercise.duration = z.Value; break;
                                            case "Rest": newExercise.rest = z.Value; break;
                                            case "Description": newExercise.description = z.Value; break;
                                        }
                                    }

                                    newRoutine.exercises.Add( newExercise );
                                }

                                break;
                            }
                    }
                }

                routines.Add( newRoutine );
            }

            return routines;
        }

        public static void SaveRoutines( List<GridRoutine> routines )
        {
            var root = new XElement( "Routines" );

            foreach( var x in routines )
            {
                var routine = new XElement( "Routine" );
                routine.Add( new XElement( "Name", x.name ) );
                routine.Add( new XElement( "Difficulty", x.difficulty.ToString() ) );
                routine.Add( new XElement( "Description", x.description ) );
                var exercises = new XElement( "Exercises" );

                foreach( var y in x.exercises )
                {
                    var exercise = new XElement( "Exercise" );
                    exercise.Add( new XElement( "LeftHandHold", y.leftHandHold ) );
                    exercise.Add( new XElement( "RightHandHold", y.rightHandHold ) );
                    exercise.Add( new XElement( "Duration", y.duration ) );
                    exercise.Add( new XElement( "Rest", y.rest ) );
                    exercise.Add( new XElement( "Description", y.description ) );
                    exercises.Add( exercise );
                }

                routine.Add( exercises );
                root.Add( routine );
            }

            XDocument doc = new XDocument( root );
            doc.Save( xmlFilePath );
        }
    }
}
