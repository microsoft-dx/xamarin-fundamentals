using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDemo.Helpers
{
    public static class Mappers
    {
        public static MobileDemo.Models.ShoppingItem ToModel(this MobileDemo.DataAccess.Entities.ShoppingItem data)
        {
            return new Models.ShoppingItem
            {
                ItemId = data.Id,
                ItemName = data.Name
            };
        }
    }
}
