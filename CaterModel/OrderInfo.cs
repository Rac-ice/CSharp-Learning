﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    public partial class OrderInfo
    {
        public int OId { get; set; }
        public int MemberId { get; set; }
        public DateTime ODate { get; set; }
        public decimal OMoney { get; set; }
        public bool IsPay { get; set; }
        public int TableId { get; set; }
        public decimal Discount { get; set; }
    }
}
