using CodeBase.Gameplay.InputProvider.Common;

namespace CodeBase.Gameplay.InputProvider.Interfaces
{
    public interface IInputSource
    {
        public int Priority { get; }
        public InputData ModifyInput(InputData input);
    }
}