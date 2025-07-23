using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Domain.Models
{
    public class OIModel
    {  
    public bool IsOnMyWay { get; set; } = false;
    public DateTime? OnMyWayTime { get; set; }
    public int OrderId { get; set; }
    public bool IsBackDatedOrder { get; set; } = false;
    public int CompletedFrom { get; set; } = 1;
    public bool IsOriginallyMixed { get; set; } = false;
     
    }
}