using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPongProjektas
{
    public partial class PingPong : Form
    {
        #region variables
        bool playerGoup; // zaidejas kyla
        bool playerGodown; // zaidejas leidziasi
        int speed = 5; // kokiu greiciu juda platforma
        int xball = 8; // kamuolio greitis x asyje
        int yball = 8; // kamuolio greitis y asyje
        int playerPoints = 0;
        int npcPoints = 0;

        #endregion 

        public PingPong()
        {
            InitializeComponent();
            //playerScore.BackColor = System.Drawing.Color.Transparent;  //neveikia
            //npcScore.BackColor = System.Drawing.Color.Transparent; //neveikia irgi

        }

        private void keyDownn(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                playerGoup = true;
            }
            else if (e.KeyCode == Keys.Down)
            {
                playerGodown = true;
            }
        }

        private void keyUpp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                playerGoup = false;
            }
            else if (e.KeyCode == Keys.Down)
            {
                playerGodown = false;
            }
        }

        private void timerTick(object sender, EventArgs e)
        {
            playerScore.Text = "" + playerPoints;
            npcScore.Text = "" + npcPoints;

            Ball.Top -= yball;
            Ball.Left -= xball;

            npc.Top += speed;

            //kamuolys paliko ribas

            if (Ball.Left < 0)
            {
                Ball.Left = 434;
                xball = -xball;
                xball -= 2;
                npcPoints++;
            }

            if (Ball.Left + Ball.Width > ClientSize.Width)
            {
                Ball.Left = 434;
                xball = -xball;
                xball += 2;
                playerPoints++;
            }

            //tasku sistema
            if (playerPoints < 5)
            {
               if (npc.Top < 0 || npc.Top > 455)
                {
                    speed = -speed;
                }
            }
            else
            {
                npc.Top = Ball.Top + 30; 
            }


            //zaidejo controls
            if (playerGoup == true && Player.Top > 0)
            {
                Player.Top -= 8;
            }

            if (playerGodown == true && Player.Top < 455)
            {
                Player.Top += 8;
            }

            //kamuolio controls
            if (Ball.Top < 0 || Ball.Top + Ball.Height > ClientSize.Height)
            {
                yball = -yball;
            }

            if (Ball.Bounds.IntersectsWith(Player.Bounds) || Ball.Bounds.IntersectsWith(npc.Bounds))
            {
                xball = -xball;
            }

            //rezultatai
            if (playerPoints > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("You win.");
            }
            if (npcPoints > 10)
            {
                gameTimer.Stop();
                MessageBox.Show("You lose.");
            }
        }
    }
}
