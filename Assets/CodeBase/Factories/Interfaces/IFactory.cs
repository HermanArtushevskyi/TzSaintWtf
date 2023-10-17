namespace CodeBase.Factories.Interfaces
{
    public interface IFactory<TObject>
    {
        public TObject Create();
    }

    public interface IFactory<TObject, TArg>
    {
        public TObject Create(TArg arg);
    }
}