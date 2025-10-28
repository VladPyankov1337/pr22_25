using Shop.Data.Models;
using System.Collections.Generic;

namespace Shop.Data.Interfaces
{
    public interface ICategorys
    {
        IEnumerable<Categorys> AllCategorys { get; }
    }
}
