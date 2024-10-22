namespace Music_catalog.Services
{
    public interface IDataLoader
    {
        void LoadData(DataGridView gridView, string searchTerm);
    }
}