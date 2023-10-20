using System;
using System.Collections.Generic;
using CodeBase.Common;
using CodeBase.Gameplay.Buildings.Interfaces;
using CodeBase.Gameplay.Inventory.Interfaces;
using CodeBase.Gameplay.Items;
using CodeBase.StateMachine.Interfaces;
using CodeBase.StateMachine.States.GameStateMachine;
using CodeBase.StateMachine.States.PlayerStateMachine;
using TMPro;
using UnityEngine;
using Zenject;

namespace CodeBase.Gameplay.Buildings
{
    public class DepotStorageBehaviour : MonoBehaviour, IStorage
    {
        [SerializeField] private TextMeshPro _text;
        [SerializeField] private Transform _itemsStack;
        [SerializeField] private int _capacity;
        
        public int[] neededTiers;
        public List<ItemBehaviour> _inventory;
        
        private IInventory _playerInventory;
        private IStateMachine _gameStateMachine;
        private IStateMachine _playerStateMachine;

        public int Capacity => _capacity;

        [Inject]
        private void Construct(
            IInventory inventory,
            [InjectOptional(Id = GameStateMachineID.Game)] IStateMachine gameStateMachine,
            [InjectOptional(Id = GameStateMachineID.Player)] IStateMachine playerStateMachine)
        {
            _playerInventory = inventory;
            _gameStateMachine = gameStateMachine;
            _playerStateMachine = playerStateMachine;
        }

        private void FixedUpdate()
        {
            CheckWinCondition();
            _text.text = $"{_inventory.Count}/{Capacity}";
        }

        private void CheckWinCondition()
        {
            if (_inventory.Count >= Capacity)
            {
                _playerStateMachine.EnterState<PlayerWonState>();
                _gameStateMachine.EnterState<GameWinState>();
            }
        }

        public List<IItem> GetAllItems()
        {
            return _inventory.ConvertAll(new Converter<ItemBehaviour, IItem>((i) => i));
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
            return;
        }

        public void RemoveItem(int tier)
        {
            return;
        }

        public void DeleteItem(int tier)
        {
            return;
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