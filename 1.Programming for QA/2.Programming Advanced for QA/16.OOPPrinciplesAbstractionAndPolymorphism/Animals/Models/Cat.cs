using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Models
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) : base (name, favouriteFood)
        {

        }
        public override string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}{Environment.NewLine}MEEOW";
        }
    }
    
}
