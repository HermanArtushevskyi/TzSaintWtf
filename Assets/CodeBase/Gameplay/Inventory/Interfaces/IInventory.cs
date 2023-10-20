using System;
using UnityEngine;

namespace CodeBase.Gameplay.Inventory.Interfaces
{
    public interface IInventory
    {
        public bool IsFull { get; }
        public void AddItem(IItem item);
        public IItem GetItem(string name);
        public IItem GetItem(int tier);
        public IItem GetItem(Predicate<IItem> predicate);
        public void RemoveItem(IItem item);
        public void TransferObjectFromInventory(Transform parent, IItem item);
        public void TransferObjectToInventory(IItem objectoToTransfer);
    }
}