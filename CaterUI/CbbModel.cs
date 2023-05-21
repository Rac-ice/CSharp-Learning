using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterUI
{
    public partial class CbbModel
    {
        public CbbModel(string id,string title) 
        {
            this.Id = id;
            this.Title = title;
        }
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
