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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WinExp
{
    /// <summary>
    /// Interaction logic for FileItem.xaml
    /// </summary>
    public partial class FileItem : UserControl
    {
        public FileItem()
        {
            InitializeComponent();
        }

        
       

        private void MouseEnterColorChange(object sender, MouseEventArgs e)
        {
            BeginStoryboard(Resources["LightsUpBackgroundAnimation"] as Storyboard);
        }

        private void MouseLeaveColorChange(object sender, MouseEventArgs e)
        {
            BeginStoryboard(Resources["LightsDownBackgroundAnimation"] as Storyboard);
        }
    }
}
