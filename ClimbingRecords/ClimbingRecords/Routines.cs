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
            public string duration;
            public string rest;
            public string description;
        }

        public class GridRoutine
        {
            public List<GridExercise> exercises;
            public string name;
            public int difficulty;
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

               // foreach( var y in routine.Elements() )
               // {
               //     switch( y.Name.ToString() )
               //     {
               //         case "Category": newRecord.category = y.Value; break;
               //         case "LeftHandHold": newRecord.leftHandHold = y.Value; break;
               //         case "RightHandHold": newRecord.rightHandHold = y.Value; break;
               //         case "Person": newRecord.name = y.Value; break;
               //         case "Record": newRecord.record = y.Value; break;
               //         case "Units": newRecord.units = y.Value; break;
               //         case "Description": newRecord.description = y.Value; break;
               //     }
               // }

                routines.Add( newRoutine );
            }

            return routines;
        }

        public static void SaveRoutines( List<GridRoutine> records )
        {
            var root = new XElement( "Records" );

            foreach( var x in records )
            {
                var record = new XElement( "Record" );
                record.Add( new XElement( "Category", x.category ) );
                record.Add( new XElement( "LeftHandHold", x.leftHandHold ) );
                record.Add( new XElement( "RightHandHold", x.rightHandHold ) );
                record.Add( new XElement( "Person", x.name ) );
                record.Add( new XElement( "Record", x.record.ToString() ) );
                record.Add( new XElement( "Units", x.units ) );
                record.Add( new XElement( "Description", x.description ) );
                root.Add( record );
            }

            XDocument doc = new XDocument( root );
            doc.Save( xmlFilePath );
        }
    }
}
