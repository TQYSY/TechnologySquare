using System;
using System.Collections.Generic;

namespace TechnologySquare.Models
{
    public partial class Orders
    {
        public int ObjId { get; set; }
        public int? Customermessage { get; set; }
        public int? TheProduct { get; set; }
        public int? ThePayment { get; set; }
        public DateTime? OrderTime { get; set; }
        public int? OrderState { get; set; }

        public virtual Customer CustomermessageNavigation { get; set; }
        public virtual PaymentType ThePaymentNavigation { get; set; }

        public virtual Product TheProductNavigation { get; set; }
    }
}
