using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Security.Cryptography;
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

namespace Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool turn = true; // true = X turn, false = O turn
        int turn_count = 0;

        public MainWindow()
        {
            initialize();
            
        }

        public void initialize()
        {
            InitializeComponent();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 

                Button btn = (Button)sender;
                if (turn)
                {
                    btn.Content = "X";
                    btn.Foreground = Brushes.Blue;
                    label3.Content = "Player2 turns";
                }
                else
                {
                    btn.Content = "O";
                    btn.Foreground = Brushes.Red;
                    label3.Content = "Player1 turns";
                }

                btn.IsEnabled = false;

                turn_count++;

                check_Winner();
                turn = !turn;


                //if (turn == false)
                //{
                //    bool check = true;
                //    while (check)
                //    {
                //        Random r = new Random();
                //        int cell = r.Next(1, 9);

                //        foreach(Button b in mainFrame.Children)
                //        {
                //            if (b.Content.ToString() == cell.ToString())
                //            {
                //                btn = b;
                //                btn.Content = "O";
                //                btn.Foreground = Brushes.Red;
                //                check = false;
                //                break;
                //            }
                //        }
                //    }
                //    btn.IsEnabled = false;
                //    turn_count++;
                //    check_Winner();
                //    turn = true;
                //}
            }
            catch{ }
        }

        private void check_Winner()
        {
            bool winner = false;
            try 
            { 

                //horizontal checks
                if ((btn1.Content == btn2.Content) && (btn2.Content == btn3.Content) && (!btn1.IsEnabled))
                {
                    displayEffects(btn1, btn2, btn3);
                    winner = true;
                }
                else if ((btn4.Content == btn5.Content) && (btn5.Content == btn6.Content) && (!btn4.IsEnabled))
                {
                    displayEffects(btn4, btn5, btn6);
                    winner = true;
                }
                else if ((btn7.Content == btn8.Content) && (btn8.Content == btn9.Content) && (!btn7.IsEnabled))
                {
                    displayEffects(btn7, btn8, btn9);
                    winner = true;
                }
                //vertical checks
                else if ((btn1.Content == btn4.Content) && (btn4.Content == btn7.Content) && (!btn1.IsEnabled))
                {
                    displayEffects(btn1, btn4, btn7);
                    winner = true;
                }
                else if ((btn2.Content == btn5.Content) && (btn5.Content == btn8.Content) && (!btn2.IsEnabled))
                {
                    displayEffects(btn2, btn5, btn8);
                    winner = true;
                }
                else if ((btn3.Content == btn6.Content) && (btn6.Content == btn9.Content) && (!btn3.IsEnabled))
                {
                    displayEffects(btn3, btn6, btn9);
                    winner = true;
                }
                //primary diagonal check
                else if ((btn1.Content == btn5.Content) && (btn5.Content == btn9.Content) && (!btn1.IsEnabled))
                {
                    displayEffects(btn1, btn5, btn9);
                    winner = true;
                }
                //secondary diagonal check
                else if ((btn3.Content == btn5.Content) && (btn5.Content == btn7.Content) && (!btn3.IsEnabled))
                {
                    displayEffects(btn3, btn5, btn7);
                    winner = true;
                }
                displayWinner(winner);
            }
            catch{}
        }
        public void disableButtons()
        {
            try
            {
                foreach(Button b in mainFrame.Children)
                {
                    b.IsEnabled = false;
                }
            }
            catch { }
        }

        public void displayWinner(bool flag)
        {
            if (flag)
            {
                disableButtons();
                if (turn)
                {
                    label3.Content = "Player1 won";
                }
                else
                {
                    label3.Content = "Player2 won";
                }
                label3.Foreground = Brushes.Green;
            }
            else
            {
                if (turn_count == 9)
                {
                    label3.Content = "Game Draw";
                }
            }
        }

        public void displayEffects(Button b1, Button b2, Button b3)
        {
            try
            {
                b1.Foreground = Brushes.Green;
                b2.Foreground = Brushes.Green;
                b3.Foreground = Brushes.Green;
            }
            catch { }
            
        
        }

        private void newGame_Click(object sender, RoutedEventArgs e)
        {
            turn = true;
            turn_count = 0;
            label3.Content = "Player1 turns";
            label3.Foreground = Brushes.Red;
            try
            {
                int i = 0;
                foreach(Button b in mainFrame.Children) 
                {
                    b.Foreground = Brushes.Black;
                    b.IsEnabled = true;
                    b.Content = (++i).ToString();
                };
            }
            catch
            { }
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Game Developed by Ali Khan.");
        }

        
    }
}
