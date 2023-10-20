using System;
using System.Collections.Generic;
using CodeBase.Gameplay.Inventory.Interfaces;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CodeBase.Gameplay.Inventory
{
    public class Inventory : MonoBehaviour, IInventory
    {
        public bool IsFull => _inventory.Count >= _capacity;
        
        [SerializeField] private int _capacity;
        private List<IItem> _inventory = new();
        private Dictionary<IItem, LinkedListNode<GameObject>> _itemToNode = new();
        private ItemsStack _itemsStack;


        private void Awake()
        {
            _itemsStack = GetComponent<ItemsStack>();
        }

        public void AddItem(IItem item)
        {
            _inventory.Add(item);
        }

        public IItem GetItem(string name)
        {
            for (int i = _inventory.Count-1; i >= 0; i--)
            {
                if (_inventory[i].Name == name)
                {
                    return _inventory[i];
                }
            }

            return null;
        }

        public IItem GetItem(int tier)
        {
            for (int i = _inventory.Count-1; i >= 0; i--)
            {
                if (_inventory[i].Tier == tier)
                {
                    return _inventory[i];
                }
            }

            return null;
        }

        public IItem GetItem(Predicate<IItem> predicate)
        {
            for (int i = _inventory.Count-1; i >= 0; i--)
            {
                if (predicate(_inventory[i]))
                {
                    return _inventory[i];
                }
            }

            return null;
        }

        public void RemoveItem(IItem item)
        {
            _inventory.Remove(item);
        }

        public void TransferObjectFromInventory(Transform parent, IItem item)
        {
            RemoveItem(item);
            _itemsStack.Remove(_itemToNode[item]);

            item.Prefab.transform.parent = parent;
            item.Prefab.transform.DOLocalMove(Vector3.zero + Vector3.right * Random.Range(-0.5f, 0.5f), 1f);
        }

        public void TransferObjectToInventory(IItem objectoToTransfer)
        {
            AddItem(objectoToTransfer);
            _itemToNode.Add(objectoToTransfer, _itemsStack.Add(objectoToTransfer.Prefab));
            objectoToTransfer.Prefab.transform.DOLocalMove(Vector3.zero, 1f);
        }
    }
}