using Music_catalog.Models;
using System.Collections.Generic;

namespace Music_catalog.Repositories
{
    public interface ITrackRepository
    {
        void AddTrack(string title, int artistId, int albumId, int duration, int? collectionId = null);
        List<Track> GetAllTracks();
    }
}