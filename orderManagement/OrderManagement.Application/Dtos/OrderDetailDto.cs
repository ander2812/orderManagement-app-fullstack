using OrderManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Dtos
{
    public class OrderDetailDto
    {
        public int orderid { get; set; }

        public int productid { get; set; }

        public decimal unitprice { get; set; }

        public short qty { get; set; }

        public decimal discount { get; set; }


    }
}
