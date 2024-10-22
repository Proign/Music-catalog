using System.Windows.Forms;
using Music_catalog.Services;

namespace Music_catalog.Commands
{
    public class AddTrackCommand : ICommand
    {
        private readonly TrackAdder _trackAdder;
        private readonly string _trackTitle;
        private readonly int _artistId;
        private readonly int _albumId;
        private readonly int _duration;
        private readonly TextBox _trackNameTextBox;
        private readonly TextBox _trackDurationTextBox;

        public AddTrackCommand(TrackAdder trackAdder, string trackTitle, int artistId, int albumId, int duration,
                               TextBox trackNameTextBox, TextBox trackDurationTextBox)
        {
            _trackAdder = trackAdder;
            _trackTitle = trackTitle;
            _artistId = artistId;
            _albumId = albumId;
            _duration = duration;
            _trackNameTextBox = trackNameTextBox;
            _trackDurationTextBox = trackDurationTextBox;
        }

        public void Execute()
        {
            _trackAdder.AddTrack(_trackTitle, _artistId, _albumId, _duration, _trackNameTextBox, _trackDurationTextBox, null);
        }
    }
}
