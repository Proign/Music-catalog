using System.Collections.Generic;
using Music_catalog.Services;

namespace Music_catalog.Commands
{
    public class AddCollectionCommand : ICommand
    {
        private readonly CollectionAdder _collectionAdder;
        private readonly string _collectionTitle;
        private readonly List<int> _selectedTrackIds;

        public AddCollectionCommand(CollectionAdder collectionAdder, string collectionTitle, List<int> selectedTrackIds)
        {
            _collectionAdder = collectionAdder;
            _collectionTitle = collectionTitle;
            _selectedTrackIds = selectedTrackIds;
        }

        public void Execute()
        {
            _collectionAdder.AddCollection(_collectionTitle, _selectedTrackIds);
        }
    }
}
