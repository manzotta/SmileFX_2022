using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmileFX_2022.Models
{

    public class OrderContent
    {
        public Order order { get; set; }
    }

    public class Order
    {
        // Name Violation?
        // Esetleg valami wrapper osztályt, ami jobban illeszkedik a logikához(?)?
        // Nálunk az Instrument egy osztály.. nála viszont következetesen egy stringet jelöl
        public string instrument { get; set; }

        public string units { get; set; }

        public string timeInForce { get; set; }

        public string type { get; set; }

        public string positionFill { get; set; }
    }


}
