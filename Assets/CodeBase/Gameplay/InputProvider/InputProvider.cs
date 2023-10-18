using System.Collections.Generic;
using CodeBase.Gameplay.InputProvider.Common;
using CodeBase.Gameplay.InputProvider.Interfaces;

namespace CodeBase.Gameplay.InputProvider
{
    public class InputProvider : IInputProvider
    {
        private List<IInputSource> _sources;

        public InputProvider()
        {
            _sources = new List<IInputSource>();
        }

        public InputData GetInput()
        {
            InputData data = default;
            
            foreach (IInputSource source in _sources)
            {
                data = source.ModifyInput(data);
            }
            
            return data;
        }

        public void AddSource(IInputSource source)
        {
            _sources.Add(source);
            _sources.Sort((a, b) => a.Priority.CompareTo(b.Priority));
        }

        public void RemoveSource(IInputSource source)
        {
            _sources.Remove(source);
        }
    }
}