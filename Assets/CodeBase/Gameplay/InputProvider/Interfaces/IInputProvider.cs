using CodeBase.Gameplay.InputProvider.Common;

namespace CodeBase.Gameplay.InputProvider.Interfaces
{
    public interface IInputProvider
    {
        public InputData GetInput();

        public void AddSource(IInputSource source);
        public void RemoveSource(IInputSource source);
    }
}