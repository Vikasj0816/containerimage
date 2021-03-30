using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleDockerProject.Models
{
    public interface IRepository<T>
    {
        public void AddItem(T t);
        public IEnumerable<T> GetItems();
        public T GetItemsById(int id);
    }
}
