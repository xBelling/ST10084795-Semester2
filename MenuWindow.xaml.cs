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

namespace POE_PartOne_ST10084795
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }
        private void MouseClick(Object sender, MouseButtonEventArgs e)
        {
            //To handle mouse click events
        }

        //Method to display the ASemMod window where the user will enter information regarding their current semester and modules
        private void SemMod(Object sender, RoutedEventArgs e)
        {
            ASemModWindow asmw = new ASemModWindow();
            asmw.Show();
            this.Close();
        }
    }
}
