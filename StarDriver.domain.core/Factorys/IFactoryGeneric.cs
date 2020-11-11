namespace StarDriver.domain.core.Factorys
{
    public interface IFactoryGeneric<T>
    {
        
            T FactoryMethod(string type);
        
    }
}