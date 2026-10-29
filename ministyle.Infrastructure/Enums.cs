using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure
{
    public class Enums
    {
        public enum Category
        {
            NewBorn = 1,
            Girls = 2,
            Boys = 3,
            Unisex = 4
        }

        public enum Fabric
        {
            Cotton = 1,
            Linen = 2,
            Muslin = 3
        }

        public enum Pattern
        {
            Top_Wear = 1,
            Bottom_Wear = 2,
        }

        public enum Style
        {
            Short_Set = 1,
            Skirts_Set = 2,
            Pants_Set = 3,
            Tees = 4,
            Skirt = 5,
            Frocks = 6,
            Leggings = 7,
            Pant = 8,
            Skirts = 9,
            Shorts = 10,
            Night_Wear = 11,
            Traditional_Wear = 12
        }


        public enum PaymentStatus
        {
            Pending = 1,
            Completed = 2,
            Failed = 3,
            Refunded = 4,
            Partially_Refunded = 5,
            Cancelled = 6,
            Authorized = 7,
            Captured = 8,
            Charge_back = 9,
            On_Hold = 10
        }
        public enum ShippingStatus
        {
            Not_Shipped = 1,
            Processing = 2,
            Shipped = 3,
            In_Transit = 4,
            Out_for_Delivery = 5,
            Delivered = 6,
            Returned = 7,
            Cancelled = 8,
            Failed_Delivery = 9,
            Awaiting_Pickup = 10
        }
    }
}
