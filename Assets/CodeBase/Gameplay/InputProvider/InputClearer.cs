using System;
using CodeBase.Gameplay.InputProvider.Common;
using CodeBase.Gameplay.InputProvider.Interfaces;

namespace CodeBase.Gameplay.InputProvider
{
    public class InputClearer : IInputSource
    {
        public int Priority => Int32.MinValue;

        public InputData ModifyInput(InputData input) => InputData.Empty;
    }
}