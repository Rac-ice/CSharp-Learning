using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterModel
{
    public partial class TableInfo
    {
        public int TId { get; set; }
        public string TTitle { get; set; }
        public int THallId { get; set; }
        public bool TIsFree { get; set; }
    }
}
