using IFactories = CodeBase.Factories.Interfaces;
using UnityEngine;

namespace CodeBase.Factories
{
    public class GameCameraFactory : IFactories.IFactory<Camera>
    {
        public Camera Create()
        {
            return null;
        }
    }
}