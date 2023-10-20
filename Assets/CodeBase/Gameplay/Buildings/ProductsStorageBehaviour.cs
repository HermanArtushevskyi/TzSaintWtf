using System;
using System.Collections.Generic;
using System.Linq;
using CodeBase.Gameplay.Buildings.Interfaces;
using CodeBase.Gameplay.Inventory.Interfaces;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Buildings
{
    [RequireComponent(typeof(Collider))]
    public class ProductsStorageBehaviour : MonoBehaviour, IStorage
    {
        [SerializeField] private TextMeshPro _text;
        [SerializeField] private int _capacity;

        public int Capacity => _capacity;

        private List<IItem> _inventory = new();
        private IInventory _playerInventory;

        [Inject]
        private void Construct(IInventory inventory)
        {
            _playerInventory = inventory;
        }

        private void FixedUpdate()
        {
            _text.text = $"{_inventory.Count}/{Capacity}";
        }

        public List<IItem> GetAllItems()
        {
            return _inventory;
        }

        public bool HasSpace()
        {
            return _inventory.Count < Capacity;
        }

        public void AddItem(IItem item)
        {
            _inventory.Add(item);
        }

        public bool HasNeededItems()
        {
            return true;
        }

        public void ProcessItems()
        {
            return;
        }

        public void RemoveItem(int tier)
        {
            _inventory.Remove(_inventory.First((i => i.Tier == tier)));
        }

        public void DeleteItem(int tier)
        {
            IItem item = _inventory.First(i => i.Tier == tier);
            _inventory.Remove(item);
            GameObject.Destroy(item.Prefab);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            if (_playerInventory.IsFull) return;

            List<IItem> deletedItems = new();
            
            foreach (IItem item in _inventory)
            {
                if (_playerInventory.IsFull) break;
                deletedItems.Add(item);
                _playerInventory.TransferObjectToInventory(item);
            }

            foreach (IItem item in deletedItems)
            {
                _inventory.Remove(item);
            }
        }
    }
}