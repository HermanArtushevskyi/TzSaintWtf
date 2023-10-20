using CodeBase.Gameplay.Inventory.Interfaces;
using UnityEngine;

namespace CodeBase.Gameplay.Items
{
    public class ItemBehaviour : MonoBehaviour, IItem
    {
        public Transform topAnchor;
        public Transform bottomAnchor;
        
        public int tier;

        public GameObject Prefab => gameObject;
        public string Name => gameObject.name;
        public int Tier => tier;
    }
}