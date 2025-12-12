using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hillerød_Sejlklub
{
    public class Boat : Engine
    {
        private Dictionary<string, Boat> _boat;

        public Boat(string name, string sailNumber, string boatType, string model, int builtYear, double width, double height, double length, string motorType, int hp, string brand) : base(motorType, hp, brand)
        {
            Name = name;
            SailNumber = sailNumber;
            BoatType = boatType;
            Model = model;
            Width = width;
            Height = height;
            Length = length;
            
        }

        public Boat(string name, string sailNumber, string boatType, string model, int builtYear, double width, double height, double length, Engine engine, string motorType, int hp, string brand) : base(motorType, hp, brand)
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
        public string SailNumber { get; set; }
        public string BoatType { get; set; }
        public string Model { get; set; }
        public int BuiltYear { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public Engine Engine { get; set; }
        public List<string> MaintenanceLog { get; set; }

        public void WriteMaintenanceLog(string text)
        {
            MaintenanceLog.Add(text);
        }

        

        public override string ToString()
        {
            return $"Name: {Name}, Sailnumber {SailNumber}, Boattype: {BoatType}, Model: {Model}, Built in {BuiltYear}, " +
                $"Width: {Width}, Height: {Height}, Length: {Length}, Engine: {Engine}";
        }


    }
}
