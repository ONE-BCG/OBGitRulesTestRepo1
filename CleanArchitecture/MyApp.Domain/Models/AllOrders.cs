using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MyApp.Domain.Models
{
    /// <summary>
    /// Represents an order entity with basic order information
    /// </summary>
    public class AllOrders
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order
        /// </summary>
        public int IOrderID { get; set; }
        
        /// <summary>
        /// Gets or sets the unique identifier for the patient associated with this order
        /// </summary>
        public int IPatientID { get; set; }
        
        /// <summary>
        /// Gets or sets the DME (Durable Medical Equipment) identifier
        /// </summary>
        public int IDMEID { get; set; } 
        
        /// <summary>
        /// Gets or sets the timestamp when the order was created or last modified
        /// Can be null if the timestamp is not available
        /// </summary>
        public DateTime? DtDateStamp { get; set; }        
        
    }
}