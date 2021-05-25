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
using System.Windows.Shapes;

namespace platformy_NET.MWM.View
{
    /// <summary>
    /// Logika interakcji dla klasy FeedView.xaml
    /// </summary>
    public partial class FeedView : UserControl
    {
        public FeedView()
        {
            InitializeComponent();
            statusList= service.GetStatus();
            this.DataListBox.ItemsSource = statusList;
            
            
            
                
        }
        private DataBaseService service = new DataBaseService();
        private List<SocialStatus> statusList;

        public void Update()
        {
            DataListBox.ItemsSource = service.GetStatus();
        }

        private void DataListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SocialStatus status = new SocialStatus();
            
            var index = DataListBox.SelectedIndex;
            SocialStatus statusToDelete = new SocialStatus();
            statusToDelete = statusList[index];
            DataBaseContext db = new DataBaseContext();
            if (MessageBox.Show("Czy chcesz usunąć wpis?","Question",MessageBoxButton.YesNoCancel)==MessageBoxResult.Yes)
            {
               
                db.SocialFeed.Attach(statusToDelete);
                db.SocialFeed.Remove(statusToDelete);
                db.SaveChanges();
               

            }

            Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AddYourStatus NewWindow = new AddYourStatus();
            NewWindow.Owner =Application.Current.MainWindow;
            NewWindow.Show();
            
            
        }

        
    }
}
