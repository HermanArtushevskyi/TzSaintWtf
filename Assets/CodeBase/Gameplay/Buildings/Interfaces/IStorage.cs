using System.Collections.Generic;
using CodeBase.Gameplay.Inventory.Interfaces;

namespace CodeBase.Gameplay.Buildings.Interfaces
{
    public interface IStorage
    {
        public int Capacity { get; }
        public List<IItem> GetAllItems();
        public bool HasSpace();
        public void AddItem(IItem item);
        public bool HasNeededItems();
        public void ProcessItems();
        public void RemoveItem(int tier);
        public void DeleteItem(int tier);
    }
}