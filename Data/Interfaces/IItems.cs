using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface IItems
    {
        IEnumerable<Items> AllItems { get; }
    }
}
