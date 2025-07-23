using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MyApp.Domain.Models
{
    public class AllOrders
    {
        public int IOrderID { get; set; }
        public int IPatientID { get; set; }
        public int IDMEID { get; set; } 
        public DateTime? DtDateStamp { get; set; }        
        
    }
}