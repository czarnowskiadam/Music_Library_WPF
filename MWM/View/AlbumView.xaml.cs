using platformy_NET.Models.Helpers;
using platformy_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace platformy_NET.MWM.View
{
    /// <summary>
    /// Logika interakcji dla klasy AlbumView.xaml
    /// </summary>
    public partial class AlbumView : UserControl
    {
        public AlbumView()
        {
            InitializeComponent();
            Task.Run(async () => await SpotifySearch.GetTokenAsync());

        }

        private void TxtBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (TxtBox1.Text == string.Empty)
            {

                ListBoxAlbum.ItemsSource = null;
                return;
            }

            var result = SpotifySearch.SearchArtist(TxtBox1.Text);

            if (result == null)
            {
                return;
            }
            var listAlbums = new List<SpotifyAlbum>();


            foreach (var item in result.albums.items)
            {
                listAlbums.Add(new SpotifyAlbum()
                {
                    ID = item.id,
                    Image = item.images.Any() ? item.images[0].url : "https://user-images.githubusercontent.com/24848110/33519396-7e56363c-d79d-11e7-969b-09782f5ccbab.png",
                    Name = item.name,
                    Artist = item.GetArtists(),
                    Popularity = $"{item.popularity.ToString()}% popularność",
                    Release_date=$"Data wydania:{item.release_date}",

                });

            }


            ListBoxAlbum.ItemsSource = listAlbums;


        }
    }
}
