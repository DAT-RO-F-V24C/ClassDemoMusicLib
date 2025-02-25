using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassDemoMusicLib.model
{
    public class Music
    {
        // instance fields
        private int _id;
        private string _title;
        private int _year;

        // properties
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (value is null || value.Length < 2)
                {
                    throw new ArgumentException("title must be at least 2 character");
                }
                _title = value;
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }
            set
            {
                if (value < 1900)
                {
                    throw new ArgumentException("only for music after 1900");
                }
                _year = value;
            }
        }

        // constructors
        public Music(int id, string title, int year)
        {
            Id = id;
            Title = title;
            Year = year;
            
        }

        public Music() : this(-1, "dummy", 1900)
        {
        }

        // To String
        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Title)}={Title}, {nameof(Year)}={Year.ToString()}}}";
        }

        

    }
}
