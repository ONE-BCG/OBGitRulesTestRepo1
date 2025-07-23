using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Application.Orders.Commands.AddOI
{
    /// <summary>
    /// Response DTO returned after successfully adding order information.
    /// Contains the identifier of the newly created order info entry.
    /// </summary>
    public class AddOIResponseDto
    {
        /// <summary>
        /// The unique identifier of the newly added order information record.
        /// </summary>
        public int OrderInformationId { get; set; }
    }
}