using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministyle.Infrastructure
{
    public class EnumHelper
    {
        //public static string GetEnumString(Enums.SubCategory subCategory)
        //{
        //    switch (subCategory)
        //    {
        //        case Enums.SubCategory.Boys:
        //            return nameof(Enums.SubCategory.Boys);
        //        case Enums.SubCategory.Girls:
        //            return nameof(Enums.SubCategory.Girls);
        //        case Enums.SubCategory.NewBorn:
        //            return nameof(Enums.SubCategory.NewBorn);
        //        case Enums.SubCategory.Unisex:
        //            return nameof(Enums.SubCategory.Unisex);
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(subCategory), subCategory, null);
        //    }
        //}

        public static int GetEnumIndex(Enums.Category category)
        {
            switch (category)
            {
                case Enums.Category.NewBorn:
                    return (int)Enums.Category.NewBorn;
                case Enums.Category.Girls:
                    return (int)Enums.Category.Girls;
                case Enums.Category.Boys:
                    return (int)Enums.Category.Boys;
                case Enums.Category.Unisex:
                    return (int)Enums.Category.Unisex;
                default:
                    throw new ArgumentOutOfRangeException(nameof(category), category, null);
            }
        }
    }
}
