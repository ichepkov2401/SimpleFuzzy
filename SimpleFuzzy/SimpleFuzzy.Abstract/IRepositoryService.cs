using SimpleFuzzy.Abstract;
using System.Runtime.Loader;

public interface IRepositoryService
{
    public void AddAssemblyElements(AssemblyLoadContext assembly);
    List<T> GetCollection<T>();
}