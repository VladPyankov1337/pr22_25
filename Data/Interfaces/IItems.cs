using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IItems
    {
        IEnumerable<Items> AllItems { get; }
        int Add(Items newItems);
        bool Update(Items Item);
        bool Delete(int id);
        Items GetItemById(int id);
    }
}
