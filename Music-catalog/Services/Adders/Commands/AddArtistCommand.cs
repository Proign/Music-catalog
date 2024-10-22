using System.Windows.Forms;
using Music_catalog.Services;

namespace Music_catalog.Commands
{
    public class AddArtistCommand : ICommand
    {
        private readonly ArtistAdder _artistAdder;
        private readonly string _artistName;
        private readonly int _genreId;
        private readonly TextBox _artistTextBox;

        public AddArtistCommand(ArtistAdder artistAdder, string artistName, int genreId, TextBox artistTextBox)
        {
            _artistAdder = artistAdder;
            _artistName = artistName;
            _genreId = genreId;
            _artistTextBox = artistTextBox;
        }

        public void Execute()
        {
            _artistAdder.AddArtist(_artistName, _genreId, _artistTextBox);
        }
    }
}
