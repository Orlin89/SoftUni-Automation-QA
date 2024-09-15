using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        private string model;
        private string color;
        private int battery;

        public string Model { get; set; }
        public string Color { get; set; }
        public int Battery { get; set; }

        public Tesla(string model, string color,int battery)
        {
            Model = model;
            Color = color;
            Battery = battery;
        }

        public string Start()
        {
            return "Engine start";
        }
        public string Stop()
        {
            return "Break!";
        }
        public override string ToString()
        {
            return $"{this.Color} {GetType().Name} {this.Model} with {this.Battery} Batteries";
        }
    }
}
