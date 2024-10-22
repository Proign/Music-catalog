using System.Windows.Forms;
using Music_catalog.Services;

namespace Music_catalog.Commands
{
    public class AddAlbumCommand : ICommand
    {
        private readonly AlbumAdder _albumAdder;
        private readonly string _albumName;
        private readonly int _artistId;
        private readonly int _genreId;
        private readonly TextBox _albumTextBox;

        public AddAlbumCommand(AlbumAdder albumAdder, string albumName, int artistId, int genreId, TextBox albumTextBox)
        {
            _albumAdder = albumAdder;
            _albumName = albumName;
            _artistId = artistId;
            _genreId = genreId;
            _albumTextBox = albumTextBox;
        }

        public void Execute()
        {
            _albumAdder.AddAlbum(_albumName, _artistId, _genreId, _albumTextBox);
        }
    }
}
