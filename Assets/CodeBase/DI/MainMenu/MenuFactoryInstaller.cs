using CodeBase.Factories;
using IFactories = CodeBase.Factories.Interfaces;
using CodeBase.UI.View;
using Zenject;

namespace CodeBase.DI.MainMenu
{
    public class MenuFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IFactories.IFactory<MainMenuView>>().To<MenuUIFactory>().AsSingle();
        }
    }
}