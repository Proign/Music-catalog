using System.Collections.Generic;
using Music_catalog.Models;

namespace Music_catalog.Repositories
{
    public interface ICollectionRepository
    {
        int AddCollection(string collectionTitle);
        List<Collection> GetCollections(string searchTerm = "");
        int GetCollectionIdByTitle(string collectionTitle);
        void UpdateTrackCollection(int trackId, int collectionId);
    }
}