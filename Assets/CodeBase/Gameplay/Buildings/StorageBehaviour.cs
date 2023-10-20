using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Buildings.Interfaces;
using CodeBase.Gameplay.Inventory.Interfaces;
using CodeBase.Gameplay.Items;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Buildings
{
    [RequireComponent(typeof(Collider))]
    public class StorageBehaviour : MonoBehaviour, IStorage
    {
        [SerializeField] private TextMeshPro _text;
        
        [SerializeField] private Transform _itemsStack;
        [SerializeField] private int _capacity;
        
        public int[] neededTiers;

        public List<ItemBehaviour> _inventory;
        private IInventory _playerInventory;

        public int Capacity => _capacity;

        [Inject]
        private void Construct(IInventory inventory)
        {
            _playerInventory = inventory;
        }
        
        public List<IItem> GetAllItems()
        {
            return _inventory.ConvertAll(new Converter<ItemBehaviour, IItem>((i) => i));
        }

        private void FixedUpdate()
        {
            _text.text = $"{_inventory.Count}/{Capacity}";
        }

        public bool HasSpace() => _inventory.Count < Capacity;

        public void AddItem(IItem item)
        {
            _inventory.Add(item as ItemBehaviour);
        }

        public bool HasNeededItems()
        {
            foreach (int tier in neededTiers)
                if (_inventory.Find((i) => i.tier == tier) == null)
                    return false;

            return true;
        }

        public void ProcessItems()
        {
            int[] tiersToDelete = neededTiers;

            foreach (int tier in tiersToDelete)
            {
                ItemBehaviour item = null;
                
                item = _inventory.FindLast((i) => i.tier == tier);

                if (item == null) return;
                
                _inventory.Remove(item);
                GameObject.Destroy(item.gameObject);
            }
        }

        public void RemoveItem(int tier)
        {
            _inventory.Remove(_inventory.First((i) => i.tier == tier));
        }

        public void DeleteItem(int tier)
        {
            var item = _inventory.First((i) => i.tier == tier);
            _inventory.Remove(item);
            GameObject.Destroy(item.gameObject);
        }
        

        private void OnTriggerEnter(Collider obj)
        {
            if (!obj.CompareTag("Player")) return;
            if (_inventory.Count >= Capacity) return;
            foreach (int neededTier in neededTiers)
            {
                IItem item = _playerInventory.GetItem(neededTier);
                if (item == null) continue;
                _playerInventory.TransferObjectFromInventory(_itemsStack, item);
                AddItem(item);
                break;
            }
        }
    }
}