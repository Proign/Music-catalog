namespace Music_catalog.Services.Loaders
{
    public interface IDataLoaderFactory
    {
        IDataLoader CreateLoader(string loaderType);
    }
}