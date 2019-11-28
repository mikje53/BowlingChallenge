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
            Random rand = new Random();
            int pinsHit = rand.Next(0, gameManager.pinsOnLane);
            this.rollBall(pinsHit);
        }

        public void spareRoll(object sender, RoutedEventArgs e)
        {
            this.rollBall(5);
            this.rollBall(5);
        }

        public void strikeRoll(object sender, RoutedEventArgs e)
        {
            this.rollBall(10);
        }

        public void gutterRoll(object sender, RoutedEventArgs e)
        {
            this.rollBall(0);
        }

        private void rollBall(int pinsHit)
        {
            gameManager.rollBall(pinsHit);
            updateScoreboard();
            detectGameOver();
        }

        private void updateScoreboard()
        {
            Scoreboard.Content = "Total score: " + gameManager.calculateTotalScore();
        }

        private void detectGameOver()
        {
            if (gameManager.isGameOver)
            {
                GutterBtn.IsEnabled = false;
                RandomRollBtn.IsEnabled = false;
                SpareBtn.IsEnabled = false;
                StrikeBtn.IsEnabled = false;

                string scoreboardContent = "Game Over. Final score is: " + gameManager.calculateTotalScore() + "\n\n" + createScoreBreakdownString();

                Scoreboard.Content = scoreboardContent;
            }
        }

        private string createScoreBreakdownString()
        {
            int[] scoreBreakdown = gameManager.getFrameScoreBreakDown();
            int frameCounter = 1;
            string scoreBreakdownString = "";
            foreach( int score in scoreBreakdown)
            {
                scoreBreakdownString += "Frame " + frameCounter + ": " + score + "\n";
                frameCounter++;
            }
            return scoreBreakdownString;
        }
    }
}
