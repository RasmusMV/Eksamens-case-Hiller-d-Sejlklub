using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub
{
    public class Boat
    {
        public Boat(string name, int sailNumber, string boatType, string model, int builtYear, double width, double height, double length)
        {
            Name = name;
            SailNumber = sailNumber;
            BoatType = boatType;
            Model = model;
            Width = width;
            Height = height;
            Length = length;
        }

        public Boat(string name, int sailNumber, string boatType, string model, int builtYear, double width, double height, double length, Engine engine)
        {
            Name = name;
            SailNumber = sailNumber;
            BoatType = boatType;
            Model = model;
            Width = width;
            Height = height;
            Length = length;
            Engine = engine;
        }


        public string Name { get; set; }
        public int SailNumber { get; set; }
        public string BoatType { get; set; }
        public string Model { get; set; }
        public int BuiltYear { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public Engine Engine { get; set; }
        public string ModelInformation { get; set; }
        public string MaintenanceLog { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Sailnumber {SailNumber}, Boattype: {BoatType}, Model: {Model}, Built in {BuiltYear}, " +
                $"Width: {Width}, Height: {Height}, Length: {Length}, Engine: {Engine}";
        }


    }
}
