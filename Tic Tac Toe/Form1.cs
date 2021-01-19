using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        bool turn = true; // true = X köre, false = O köre
        int turnCount = 0;
        private static String player1, player2;
        public Form1()
        {
            InitializeComponent();
        }

        public static void SetPlayerNames(String n1, String n2)
        {
            player1 = n1;
            player2 = n2;
        }
        // A játékról
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            MessageBox.Show("Készítette: Törköly Csaba", "Tic Tac Toe");
        }

        // Kilépés
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn) 
                b.Text = "X";
            else 
                b.Text = "O";
               
            turn = !turn;
            b.Enabled = false;

            turnCount++;

            winnerCheck();
        }
        private void winnerCheck()
        {
            bool isWinner = false;

            // vízszintesen
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                isWinner = true;
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                isWinner = true;

            // függőlegesen
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                isWinner = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                isWinner = true;

            // átlósan
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                isWinner = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!C1.Enabled))
                isWinner = true;

            if (isWinner)
            {
                buttonDisable();

                String winner = "";
                if (turn) // Ha true, O nyer, mivel ő fejezte be az előző kört
                {
                    winner = player2;
                    oCount.Text = (Int32.Parse(oCount.Text) + 1).ToString();
                } 

                else // Ha false, X nyer, mivel ő fejezte be az előző kört
                {
                    winner = player1;
                    xCount.Text = (Int32.Parse(xCount.Text) + 1).ToString();
                }

                MessageBox.Show(winner + " Győzött!", "Játék vége");
            }
            else
            {
                if (turnCount == 9)
                {
                    drawCount.Text = (Int32.Parse(drawCount.Text) + 1).ToString();
                     MessageBox.Show("Döntetlen!", "Játék vége");
                }
            }

        }

        private void buttonDisable()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
                
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turnCount = 0;

            foreach (Control c in Controls)
            {
                try
                {
                    Button b = (Button) c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }
        }

        private void buttonEnter(object sender, EventArgs e) // kinek a köre
        {
            Button b = (Button)sender;
            if (b.Enabled) 
            {
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            }
        }

        private void buttonLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
            label1.Text = player1;
            label3.Text = player2;
        }
    }
}
