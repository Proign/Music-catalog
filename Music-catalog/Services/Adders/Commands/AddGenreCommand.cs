using System.Windows.Forms;
using Music_catalog.Services;

namespace Music_catalog.Commands
{
    public class AddGenreCommand : ICommand
    {
        private readonly GenreAdder _genreAdder;
        private readonly string _genreName;
        private readonly TextBox _genreTextBox;

        public AddGenreCommand(GenreAdder genreAdder, string genreName, TextBox genreTextBox)
        {
            _genreAdder = genreAdder;
            _genreName = genreName;
            _genreTextBox = genreTextBox;
        }

        public void Execute()
        {
            _genreAdder.AddGenre(_genreName, _genreTextBox);
        }
    }
}
