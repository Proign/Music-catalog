using System.Collections.Generic;
using System.Windows.Forms;
using Music_catalog.Models;
using Music_catalog.Repositories;

namespace Music_catalog.Services.Loaders
{
    public class CollectionLoader : IDataLoader
    {
        private readonly ICollectionRepository _collectionRepository;

        public CollectionLoader(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }

        public void LoadData(DataGridView collectionGridView, string searchTerm)
        {
            List<Collection> collectionData = _collectionRepository.GetCollections(searchTerm);
            collectionGridView.DataSource = collectionData;

            collectionGridView.Columns["Title"].HeaderText = "Название";

            collectionGridView.Columns["Id"].Visible = false;
        }
    }
}