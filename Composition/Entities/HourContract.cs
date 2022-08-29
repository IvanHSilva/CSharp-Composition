using System;

namespace Composition.Entities {
    public class HourContract {
        //attributes
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        //constructors
        public HourContract() { }

        public HourContract(DateTime date, double valuePerHour, int hours) {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        //methods
        public double TotalValue() {
            return Hours * ValuePerHour;
        }
    }
}
