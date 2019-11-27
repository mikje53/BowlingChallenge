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
        private BowlingGameManager gameManager;

        public MainWindow()
        {
            InitializeComponent();
            gameManager = new BowlingGameManager();

        }

        public void randomRoll(object sender, RoutedEventArgs e)
        {
            gameManager.rollBall(1);
            updateScoreboard();
            detectGameOver();
        }

        public void specificRoll(object sender, RoutedEventArgs e)
        {
            gameManager.rollBall(1);
            updateScoreboard();
            detectGameOver();
        }

        public void spareRoll(object sender, RoutedEventArgs e)
        {
            gameManager.rollBall(5);
            gameManager.rollBall(5);
            updateScoreboard();
            detectGameOver();
        }

        public void strikeRoll(object sender, RoutedEventArgs e)
        {
            gameManager.rollBall(10);
            updateScoreboard();
            detectGameOver();
        }

        public void gutterRoll(object sender, RoutedEventArgs e)
        {
            gameManager.rollBall(0);
            updateScoreboard();
            detectGameOver();
        }

        private void updateScoreboard()
        {
            Scoreboard.Content = gameManager.calculateScore();
        }

        private void detectGameOver()
        {
            if (gameManager.isGameOver)
            {
                GutterBtn.IsEnabled = false;
                RandomRollBtn.IsEnabled = false;
                SpecificRollBtn.IsEnabled = false;
                SpareBtn.IsEnabled = false;
                StrikeBtn.IsEnabled = false;

                Scoreboard.Content = "Game Over. Final score is: " + gameManager.calculateScore();
            }
        }
    }
}
