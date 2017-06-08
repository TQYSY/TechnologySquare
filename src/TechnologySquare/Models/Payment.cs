using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class Payment
    {
        public int ObjId { get; set; }
        public double? Amount { get; set; }
        public int? ThePaymentType { get; set; }
        public string AccountNo { get; set; }
        public DateTime? TransTime { get; set; }
        public string TransNo { get; set; }
        public int? PaymentState { get; set; }
    }
}
