using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace game_ping_pong
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;
        public int speed_top = 4;
        public int points = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            Rectangle screen = Screen.FromControl(this).Bounds;
            playground.Width = screen.Width;
            playground.Height = screen.Height;
            racket.Top = playground.Bottom - (playground.Bottom / 10);

            game_over_lbl.Left = (playground.Width / 2) - (game_over_lbl.Width / 2);
            game_over_lbl.Top = playground.Height / 2 - game_over_lbl.Height / 2;
            game_over_lbl.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);
            ball.Left += speed_left;
            ball.Top += speed_top;

            if(ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top = -speed_top;
                points += 1;
                points_lbl.Text = points.ToString();

                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 255), r.Next(150, 255), r.Next(150, 255));
                score_lbl.BackColor = playground.BackColor;
                points_lbl.BackColor = playground.BackColor;
                game_over_lbl.BackColor = playground.BackColor;
            }

            if(ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }
            if(ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }
            if(ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }
            if(ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                game_over_lbl.Visible = true;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if(e.KeyCode == Keys.F1)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                points = 0;
                points_lbl.Text = "0";
                timer1.Enabled = true;
                game_over_lbl.Visible = false;
                playground.BackColor = Color.White;
                score_lbl.BackColor = playground.BackColor;
                points_lbl.BackColor = playground.BackColor;
                game_over_lbl.BackColor = playground.BackColor;
            }
        }
    }
}
