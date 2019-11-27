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

namespace Bowling_Challenge
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public void randomRoll(object sender, RoutedEventArgs e)
        {
            Scoreboard.Content = "Random Roll";
        }

        public void specificRoll(object sender, RoutedEventArgs e)
        {
            Scoreboard.Content = "Specific Roll";
        }

        public void spareRoll(object sender, RoutedEventArgs e)
        {
            Scoreboard.Content = "Spare Roll";
        }

        public void strikeRoll(object sender, RoutedEventArgs e)
        {
            Scoreboard.Content = "Strike Roll";
        }

        public void gutterRoll(object sender, RoutedEventArgs e)
        {
            Scoreboard.Content = "Gutter Roll";
        }
    }
}
