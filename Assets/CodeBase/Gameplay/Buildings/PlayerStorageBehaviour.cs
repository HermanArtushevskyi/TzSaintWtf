using System;
using System.Collections.Generic;
using CodeBase.Gameplay.Buildings.Interfaces;
using CodeBase.Gameplay.Inventory.Interfaces;
using UnityEngine;

namespace CodeBase.Gameplay.Buildings
{
    [RequireComponent(typeof(Collider))]
    public class PlayerStorageBehaviour : MonoBehaviour, IStorage
    {
        public int Capacity => Int32.MaxValue;
        public int CurrentGlobalAmount => _hasPlayer ? 1 : 0;

        private bool _hasPlayer = false;

        private void OnTriggerEnter(Collider obj)
        {
            if (obj.CompareTag("Player"))
            {
                _hasPlayer = true;
            }
        }
        
        private void OnTriggerExit(Collider obj)
        {
            if (obj.CompareTag("Player"))
            {
                _hasPlayer = false;
            }
        }

        public bool NeedItem(IItem item)
        {
            return false;
        }


        public bool HasSpace()
        {
            return false;
        }

        public void AddItem(IItem item)
        {
            return;
        }

        public bool HasNeededItems()
        {
            return _hasPlayer;
        }

        public void ProcessItems()
        {
            return;
        }

        public IItem GetItem(string name)
        {
            return null;
        }

        public void RemoveItem(int tier)
        {
            return;
        }

        public void DeleteItem(int tier)
        {
            return;
        }

        public List<IItem> GetAllItems()
        {
            return null;
        }
    }
}