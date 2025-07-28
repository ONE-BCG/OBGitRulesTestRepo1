using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Domain.Models
{
    /// <summary>
    /// Represents Order Information (OI) model containing order status and completion details
    /// </summary>
    public class OIModel
    {  
        /// <summary>
        /// Gets or sets a value indicating whether the order is currently on the way
        /// Default value is false
        /// </summary>
        public bool IsOnMyWay { get; set; } = false;
        
        /// <summary>
        /// Gets or sets the timestamp when the order was marked as "on my way"
        /// Can be null if the order is not on the way or timestamp is not available
        /// </summary>
        public DateTime? OnMyWayTime { get; set; }
        
        /// <summary>
        /// Gets or sets the unique identifier of the order
        /// </summary>
        public int OrderId { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether this is a back-dated order
        /// Default value is false
        /// </summary>
        public bool IsBackDatedOrder { get; set; } = false;
        
        /// <summary>
        /// Gets or sets the completion source identifier
        /// Default value is 1, indicating the standard completion method
        /// </summary>
        public int CompletedFrom { get; set; } = 1;
        
        /// <summary>
        /// Gets or sets a value indicating whether the order was originally mixed
        /// Default value is false
        /// </summary>
        public bool IsOriginallyMixed { get; set; } = false;
     
    }
}