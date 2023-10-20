using UnityEngine;

namespace CodeBase.Gameplay.Inventory.Interfaces
{
    public interface IItem
    {
        public GameObject Prefab { get; }
        public string Name { get; }
        public int Tier { get; }
    }
}