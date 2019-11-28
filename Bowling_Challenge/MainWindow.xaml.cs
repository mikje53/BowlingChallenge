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
            gameManager.rollBall(pinsHit);
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
                SpareBtn.IsEnabled = false;
                StrikeBtn.IsEnabled = false; 

                String scoreboardContent = "Game Over. Final score is: " + gameManager.calculateScore() + "\n\n" + createScoreBreakdownString();

                Scoreboard.Content = scoreboardContent;
            }
        }

        private String createScoreBreakdownString()
        {
            int[] scoreBreakdown = gameManager.getFrameScoreBreakDown();
            return "Frame 1: " + scoreBreakdown[0] + "\n" +
                "Frame 2: " + scoreBreakdown[1] + "\n" +
                "Frame 3: " + scoreBreakdown[2] + "\n" +
                "Frame 4: " + scoreBreakdown[3] + "\n" +
                "Frame 5: " + scoreBreakdown[4] + "\n" +
                "Frame 6: " + scoreBreakdown[5] + "\n" +
                "Frame 7: " + scoreBreakdown[6] + "\n" +
                "Frame 8: " + scoreBreakdown[7] + "\n" +
                "Frame 9: " + scoreBreakdown[8] + "\n" +
                "Frame 10: " + scoreBreakdown[9] + "\n";
        }
    }
}
