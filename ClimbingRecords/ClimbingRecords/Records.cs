using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClimbingRecords
{
    static class Records
    {
        public class GridRecord
        {
            public string Category { get; set; } = "Hangboard";
            public string LeftHandHold { get; set; } = "None";
            public string RightHandHold { get; set; } = "None";
            public string Person { get; set; }
            public string Record { get; set; }
            public string Units { get; set; } = "seconds";
            public string Description { get; set; }
        }

        static string xmlFilePath = "records.xml";

        public static String[] leftHoldNames = new String[]
        {
            "1: Top Left Jug",
            "2: Outside Sloper (Square)",
            "3: Inside Sloper (Round)",
            "4: Top Deep Pocket (3 Finger)",
            "5: Medium Edge (4 Finger)",
            "6: Shallow Edge (4 Finger)",
            "7: Deep Flat Edge (4 Finger)",
            "8: Extra Shallow Edge (3 Finger)",
            "9: Deep Flat Pocket (3 Finger)",
            "10: Medium Edge (4 Finger)",
            "11: Extra Shallow Edge (4 Finger)",
            "12: Deep Flat Pocket (2 Finger)",
            "13: Extra Shallow Pocket (2 Finger)",
            "14: Top Centre Jug",
            "15: Top Centre Pocket (4 Finger)",
            "16: Top Centre Pocket (3 Finger)",
            "17: Bottom Centre Pocket (3 Finger)",
            "18: Bottom Centre Pocket (2 Finger)",
            "None",
        };

        public static String[] rightHoldNames = leftHoldNames.Select( ( name ) => name.Replace( "Left", "Right" ) ).ToArray();

        public static List<GridRecord> LoadRecords()
        {
            List<GridRecord> records = new List<GridRecord>();

            if( !System.IO.File.Exists( xmlFilePath ) )
                return records;

            var file = XElement.Load( xmlFilePath );

            if( file.IsEmpty )
                return records;

            foreach( var record in file.Elements() )
            {
                var newRecord = new GridRecord();
            
                foreach( var y in record.Elements() )
                {
                    switch( y.Name.ToString() )
                    {
                        case "Category": newRecord.Category = y.Value; break;
                        case "LeftHandHold": newRecord.LeftHandHold = y.Value; break;
                        case "RightHandHold": newRecord.RightHandHold = y.Value; break;
                        case "Person": newRecord.Person = y.Value; break;
                        case "Record": newRecord.Record = y.Value; break;
                        case "Units": newRecord.Units = y.Value; break;
                        case "Description": newRecord.Description = y.Value; break;
                    }
                }
            
                records.Add( newRecord );
            }

            return records;
        }

        public static void SaveRecords( List<GridRecord> records )
        {
            var root = new XElement( "Records" );

            foreach( var x in records )
            {
                var record = new XElement( "Record" );
                record.Add( new XElement( "Category", x.Category ) );
                record.Add( new XElement( "LeftHandHold", x.LeftHandHold ) );
                record.Add( new XElement( "RightHandHold", x.RightHandHold ) );
                record.Add( new XElement( "Person", x.Person ) );
                record.Add( new XElement( "Record", x.Record.ToString() ) );
                record.Add( new XElement( "Units", x.Units ) );
                record.Add( new XElement( "Description", x.Description ) );
                root.Add( record );
            }

            XDocument doc = new XDocument( root );
            doc.Save( xmlFilePath );
        }
    }
}
