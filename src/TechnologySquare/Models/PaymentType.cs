using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class PaymentType
    {
        public int ObjId { get; set; }
        public string TypeName { get; set; }
        public string Url { get; set; }
        public string MethodName { get; set; }
    }
}
