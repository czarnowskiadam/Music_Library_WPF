using platformy_NET.Models;
using platformy_NET.Models.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace platformy_NET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Task.Run(async () => await SpotifySearch.GetTokenAsync());
        }
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        /*private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                //ListArtist.ItemsSource = null;
                //ListAlbums.ItemsSource = null;
                ListTracks.ItemsSource = null;
                return;
            }

            var result = SpotifySearch.SearchArtist(txtSearch.Text);

            if (result == null)
            {
                return;
            }
            var listArtist = new List<SpotifyArtist>();
            var listAlbums = new List<SpotifyAlbum>();
            var listTracks = new List<SpotifyTrack>();

            foreach (var item in result.artists.items)
            {
                listArtist.Add(new SpotifyArtist()
                {
                    ID = item.id,
                    Image = item.images.Any() ? item.images[0].url : "https://user-images.githubusercontent.com/24848110/33519396-7e56363c-d79d-11e7-969b-09782f5ccbab.png",
                    Name = item.name,
                    Popularity = $"{item.popularity}% popularność",
                    Followers = $"{item.followers.total.ToString("N")} obserwujących",
                    
                });
                    
            }

            foreach (var item in result.albums.items)
            {
                listAlbums.Add(new SpotifyAlbum()
                {
                    ID = item.id,
                    Image = item.images.Any() ? item.images[0].url : "https://user-images.githubusercontent.com/24848110/33519396-7e56363c-d79d-11e7-969b-09782f5ccbab.png",
                    Name = item.name,
                    Popularity = $"{item.popularity}% popularność",
                    release_date=item.release_date,
                    Artist = item.artists.name
                    

                });

            }

            foreach (var item in result.tracks.items)
            {
                listTracks.Add(new SpotifyTrack()
                {
                    ID = item.id,
                    Name = item.name,
                    Popularity = item.popularity,
                    Artist = item.artists,
                    Album = item.album.name,
                    Artist = item.artists.name
                    

                });

            }

            //ListArtist.ItemsSource = listArtist;
            //ListAlbums.ItemsSource = listAlbums;
            ListTracks.ItemsSource = listTracks;

        }*/
    }
}
