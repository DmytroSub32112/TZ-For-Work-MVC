using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestForWork3.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string NameOfTheClient { get; set; }
        public int NumberForOrder { get; set; }
        public int Amount { get; set; }
        public List<OrderPosition> Positions { get; set; }
    }
}
