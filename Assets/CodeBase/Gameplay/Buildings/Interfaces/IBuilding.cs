namespace CodeBase.Gameplay.Buildings.Interfaces
{
    public interface IBuilding
    {
        public IStorage Storage { get; }
        public IStorage ProductsStorage { get; }
    }
}