using CodeBase.Gameplay.InputProvider;
using CodeBase.Gameplay.InputProvider.Interfaces;
using MyInput;
using Zenject;

namespace CodeBase.Factories
{
    public class InputFactory : Interfaces.IFactory<IInputProvider>
    {
        private readonly DiContainer _container;
        private readonly InputActions _inputActions;

        public InputFactory(DiContainer container, InputActions inputActions)
        {
            _container = container;
            _inputActions = inputActions;
        }

        public IInputProvider Create()
        {
            IInputProvider inputProvider = new InputProvider();
                
            inputProvider.AddSource(new InputClearer());
            inputProvider.AddSource(new InputReader(_inputActions));

            _container.Bind<IInputProvider>().FromInstance(inputProvider).AsSingle().NonLazy();
            return inputProvider;
        }
    }
}