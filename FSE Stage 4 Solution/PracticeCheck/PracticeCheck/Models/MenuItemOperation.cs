using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeCheck.Models
{
    public class MenuItemOperation
    {
        private DataConnect op = new DataConnect();

        public IEnumerable<MenuItem> MenuFilter()
        {
            var items = from item in op.MenuItem select item;

            items = items.Where(item => item.Active.Equals("Yes")
                                        && item.DOL<=DateTime.Now);
            return items;
        }

        public IEnumerable<MenuItem> CartItemAccess(int id)
        {
            var food = from item in op.Cart where item.CartId == id select item.Item;

            var items = from i in op.MenuItem where food.Any(x => x.Equals(i.ItemId)) select i;

            return items;
        }

        public IEnumerable<Cart> CartAccess(int id)
        {
            var food = from item in op.Cart where item.CartId == id select item;
            return food;
        }


    }
}
