
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Numbers

        /// <summary>
        /// holds the current results of cells in the active game
        /// </summary>
        private TypeOfMark[] cellResults;

        /// <summary>
        /// True if it is player 1's turn (x), but false if it is player 2 turn's (0)
        /// </summary>
        private bool Player1;

        /// <summary>
        /// True if the game has ended
        /// </summary>
        private bool GameEnded;
        

        #endregion


        #region Constructor

        /// <summary>
        /// default constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            StartNewGame();
        }


        #endregion

        /// <summary>
        /// Starts a new game and clears all values back to the start
        /// </summary>
        private void StartNewGame()
        {
            //Create a new blank array of free cells
            cellResults = new TypeOfMark[9];

            for (var i = 0; i < cellResults.Length; i++)
                cellResults[1] = TypeOfMark.Free;

            //Make sure Player 1 starts the game
            Player1 = true;

            //Loop through every button on the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;

            });

            //Make sure the game hasn't finished
            GameEnded = false;
        }

        /// <summary>
        /// Handles a button click event
        /// </summary>
        /// <param name="sender"> The button that was clicked </param>
        /// <param name="e"> The events of the click </param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //starts a new game after it finished by click on a random field
            if (GameEnded)
            {
                StartNewGame();
                return;
            }

            var button = (Button)sender;

            //Find the buttons position in the array
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            var index = column + (row * 3);

            //Don't do anything if the cell already has a value in it
            if (cellResults[index] != TypeOfMark.Free)
                return;

            //Set the cell value, if it is Player1's turn (x) or Player2's turn (0)
            cellResults[index] = Player1 ? TypeOfMark.Cross : TypeOfMark.Nought;

            //set button text to result
            button.Content = Player1 ? "X" : "0";

            //change noughts to green
            if (!Player1)
                button.Foreground = Brushes.Red;

            //toggle the players turn
            if (Player1)
                Player1 = false;
            else
                Player1 = true;

            //check for a winner
            CheckForaWinner();
        }

        /// <summary>
        /// checks if there is a winner of a 3 line straight
        /// </summary>
        private void CheckForaWinner()
        {
            #region Horizontal wins
            //check for horizontal wins
            //check row 0 to see if there is a winner
            if (cellResults[0] != TypeOfMark.Free && (cellResults[0] & cellResults[1] & cellResults[2]) == cellResults[0])
            {
                
                GameEnded = true;

                //highlight winning cells in green
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            //check row 1 to see if there is a winner
            if (cellResults[3] != TypeOfMark.Free && (cellResults[3] & cellResults[4] & cellResults[5]) == cellResults[3])
            {
                
                GameEnded = true;

                //highlight winning cells in green
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }

            //check row 2 if there is a winner
            if (cellResults[6] != TypeOfMark.Free && (cellResults[6] & cellResults[7] & cellResults[8]) == cellResults[6])
            {
                
                GameEnded = true;

                //highlight winning cells in green
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region Vertical Wins
            //check for vertical wins
            //check column 0 if there is a winner
            if (cellResults[0] != TypeOfMark.Free && (cellResults[0] & cellResults[3] & cellResults[6]) == cellResults[0])
            {
                //Game ends
                GameEnded = true;

                //highlight winning cells in green
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }

            //check column 1 if there is a winner
            if (cellResults[1] != TypeOfMark.Free && (cellResults[1] & cellResults[4] & cellResults[7]) == cellResults[1])
            {
               
                GameEnded = true;

                //highlight winning cells in green
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }

            //check column 2 if there is a winner
            if (cellResults[2] != TypeOfMark.Free && (cellResults[2] & cellResults[5] & cellResults[8]) == cellResults[2])
            {
                //Game ends
                GameEnded = true;

                //highlight winning cells in green
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }

            #endregion

            #region Diagonal Wins

            //Check for diagonal wins
            //
            //go from top left cell to the bottom right cell
        
            if (cellResults[0] != TypeOfMark.Free && (cellResults[0] & cellResults[4] & cellResults[8]) == cellResults[0])
            {
                //Game ends
                GameEnded = true;

                //highlight winning cells in green
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            //go from the top right cell to the bottom left
            if (cellResults[2] != TypeOfMark.Free && (cellResults[2] & cellResults[4] & cellResults[6]) == cellResults[2])
            {
                //Game ends
                GameEnded = true;

                //highlight winning cells in green
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }

            #endregion

            #region NO winners
            //check for no winner and full board
            if (!cellResults.Any(result => result == TypeOfMark.Free))
                {
                //game ended
                GameEnded = true;

                    //turns all cells orange if there is no winner 
                   
                    Container.Children.Cast<Button>().ToList().ForEach(button =>
                    {
                       
                        button.Background = Brushes.Orange;
             
                    });
                }

            #endregion

        }
    }
    }

