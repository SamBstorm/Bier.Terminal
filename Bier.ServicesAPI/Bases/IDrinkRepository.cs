using Bier.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bier.ServicesAPI.Bases
{
    public interface IDrinkRepository
    {
        public IEnumerable<Drink> Get();
        public Drink Get(int id);
        public Drink Insert(Drink entity);
        public Drink Update(int id, Drink entity);
        public Drink Delete(int id);
    }
}
