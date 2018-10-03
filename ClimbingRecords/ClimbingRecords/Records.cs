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
        public static string RemoveWhitespace( this string str )
        {
            return String.Join( "", str.Split( default( string[] ), StringSplitOptions.RemoveEmptyEntries ) );
        }

        public class GridRecord
        {
            public string category = "Hangboard";
            public string leftHandHold = "None";
            public string rightHandHold = "None";
            public string name;
            public string record;
            public string units = "seconds";
            public string description;

            // Used for searching
            public override string ToString()
            {
                return string.Join( " ", this.GetType().GetFields().Select( ( x ) => { return x.GetValue( this ); } ) );
            }

            public string[] GetAllColumns()
            {
                return this.GetType().GetFields().Select( ( x ) => { return x.Name; } ).ToArray();
            }

            public string GetColumnValueByIndex( int index )
            {
                var dataField = RemoveWhitespace( GetAllColumns()[index] );
                var field = this.GetType().GetField( dataField );
                return field.GetValue( this ) as string;
            }

            // Helper / boilerplate functionality
            public bool Equals( GridRecord other ) { return ToString() == other.ToString(); }
            public override bool Equals( object obj ) { return false; }
            public static bool operator ==( GridRecord left, GridRecord right ) { return left.Equals( right ); }
            public static bool operator !=( GridRecord left, GridRecord right ) { return !left.Equals( right ); }
            public override int GetHashCode() { return ToString().GetHashCode(); }
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
                        case "Category": newRecord.category = y.Value; break;
                        case "LeftHandHold": newRecord.leftHandHold = y.Value; break;
                        case "RightHandHold": newRecord.rightHandHold = y.Value; break;
                        case "Person": newRecord.name = y.Value; break;
                        case "Record": newRecord.record = y.Value; break;
                        case "Units": newRecord.units = y.Value; break;
                        case "Description": newRecord.description = y.Value; break;
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
                record.Add( new XElement( "Category", x.category ) );
                record.Add( new XElement( "LeftHandHold", x.leftHandHold ) );
                record.Add( new XElement( "RightHandHold", x.rightHandHold ) );
                record.Add( new XElement( "Person", x.name ) );
                record.Add( new XElement( "Record", x.record ) );
                record.Add( new XElement( "Units", x.units ) );
                record.Add( new XElement( "Description", x.description ) );
                root.Add( record );
            }

            XDocument doc = new XDocument( root );
            doc.Save( xmlFilePath );
        }
    }
}
