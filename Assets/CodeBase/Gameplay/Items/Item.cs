using CodeBase.Gameplay.Inventory.Interfaces;
using UnityEngine;

namespace CodeBase.Gameplay.Items
{
    [CreateAssetMenu(fileName = "Item", menuName = "Items/Item")]
    public class Item : ScriptableObject, IItem
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private string _name;
        [SerializeField] private int _tier;

        public GameObject Prefab => _prefab;
        public string Name => _name;
        public int Tier => _tier;
    }
}