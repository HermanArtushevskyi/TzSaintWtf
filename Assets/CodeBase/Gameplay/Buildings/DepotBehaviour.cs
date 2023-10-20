using CodeBase.Gameplay.Buildings.Interfaces;
using UnityEngine;

namespace CodeBase.Gameplay.Buildings
{
    public class DepotBehaviour : MonoBehaviour, IBuilding
    {
        public IStorage Storage { get; }
        public IStorage ProductsStorage { get; }
    }
}