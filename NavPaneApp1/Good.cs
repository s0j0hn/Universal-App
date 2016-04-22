using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupStore
{
    class Good
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
        public string location { get; set; }
        public float store_price { get; set; }
        public float global_price { get; set; }
    }
}
