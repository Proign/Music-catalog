using System;
using System.Windows.Forms;
using Music_catalog.UI;
using Music_catalog.Repositories;
using Music_catalog.Data;
using Music_catalog.Seeders;
using Music_catalog.Services;
using Music_catalog.Services.Loaders;

namespace Music_catalog
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Инициализируем DatabaseManager
            var databaseManager = new DatabaseManager("music_catalog.db");
            databaseManager.CreateDatabase();  // Убедимся, что БД создана

            // Создаем необходимые репозитории
            var genreRepository = new GenreRepository(databaseManager);
            var artistRepository = new ArtistRepository(databaseManager);
            var albumRepository = new AlbumRepository(databaseManager);
            var trackRepository = new TrackRepository(databaseManager);
            var collectionRepository = new CollectionRepository(databaseManager);

            var genreSeeder = new GenreSeeder();
            var artistsSeeder = new ArtistsSeeder();
            var albumSeeder = new AlbumSeeder();
            var trackSeeder = new TrackSeeder();
            var collectionSeeder = new CollectionSeeder();

            // Создаем валидаторы
            var genreValidator = new GenreValidator();
            var artistValidator = new ArtistValidator();
            var albumValidator = new AlbumValidator();
            var trackValidator = new TrackValidator();
            var collectionValidator = new CollectionValidator();

            var databaseSeeder = new DatabaseSeeder(
                genreRepository, genreSeeder,
                artistRepository, artistsSeeder,
                albumRepository, albumSeeder,
                trackRepository, trackSeeder,
                collectionRepository, collectionSeeder
            );

            // Если база данных пуста
            databaseSeeder.SeedDatabase(databaseManager);

            var catalogViewer = new CatalogViewer(databaseManager);

            var dataLoaderFactory = new DataLoaderFactory(
                genreRepository,
                artistRepository,
                albumRepository,
                trackRepository,
                collectionRepository,
                catalogViewer);

            Application.Run(new MainForm(
                catalogViewer,
                albumRepository,
                collectionRepository,
                artistRepository,
                genreRepository,
                trackRepository,
                genreValidator,
                artistValidator,
                albumValidator,
                trackValidator,
                collectionValidator,
                dataLoaderFactory
            ));
        }
    }
}