using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TUI.Gasoline.Source
{
    public class Gas
    {
        public String Name { get; }
        public Double GasolinePower { get; }
        public Double Price { get; set; }

        public Gas(String name, Double gasolinePower, Double price)
        {
            this.Name = name;
            this.GasolinePower = gasolinePower;
            this.Price = price;
        }

        public Double GetLiterByKm(Double weight, Double speedAverage)
        {
            return (weight * speedAverage) / GasolinePower;
        }

        public Double GetPrice(Double literByKm, Double distance)
        {
            return distance * literByKm * Price;
        }
    }
}
