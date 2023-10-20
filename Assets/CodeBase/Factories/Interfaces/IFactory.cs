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

    public interface IFactory<TObject, TArg1, TArg2>
    {
        public TObject Create(TArg1 arg1, TArg2 arg2);
    }
}