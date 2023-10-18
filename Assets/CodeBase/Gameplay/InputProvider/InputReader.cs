using System.Numerics;
using CodeBase.Gameplay.InputProvider.Common;
using CodeBase.Gameplay.InputProvider.Interfaces;
using MyInput;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace CodeBase.Gameplay.InputProvider
{
    public class InputReader : IInputSource
    {
        public int Priority => 0;
        
        private readonly InputActions _actions;

        public InputReader(InputActions actions)
        {
            _actions = actions;

        }

        public InputData ModifyInput(InputData input)
        {
            _actions.Enable();
            input.MovementDirection = _actions.Player.WASD.ReadValue<Vector2>();
            Debug.Log(input.MovementDirection);
            return input;
        }
    }
}