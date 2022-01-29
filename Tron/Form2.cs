using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace Tron {
    public partial class Form2 : Form {
        Tron tr = new Tron();
        public static int PositionW;
        public static int PositionA;
        public static int PositionS;
        public static int PositionD;
        public static int Position1W;
        public static int Position1A;
        public static int Position1S;
        public static int Position1D;
        public static bool Bot;

        public Form2() {
            InitializeComponent();
            Init();
        }

        public void Init() {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;

            BackColor = Color.Black;
        }

        private void Player1_Click(object sender, EventArgs e) {
            this.Hide();

            PositionW = 5;
            PositionA = 6;
            PositionS = 7;
            PositionD = 8;
            Bot = true;

            tr.ShowDialog();

            this.Show();
        }

        private void Player2_Click(object sender, EventArgs e) {
            this.Hide();

            Position1W = 1;
            Position1A = 2;
            Position1S = 3;
            Position1D = 4;
            Bot = false;

            tr.ShowDialog();

            this.Show();
        }

        private void Form2_Load(object sender, EventArgs e) {
            TronLabel.ForeColor = Color.White;
            TronLabel.Font = new Font("Ariel", 80);
            TronLabel.Location = new Point(Size.Width / 2 - TronLabel.Width / 2, Size.Height / 2 - TronLabel.Width - 50);

            Player1.ForeColor = Color.White;
            Player1.Location = new Point(Size.Width / 2 - Player1.Width / 2 - 40, Size.Height / 2 - Player1.Width * 2);
            Player1.Size = new Size(150, 75);
            Player1.Font = new Font("Ariel", 20);

            Player2.ForeColor = Color.White;
            Player2.Location = new Point(Size.Width / 2 - Player2.Width / 2 - 40, Size.Height / 2);
            Player2.Size = new Size(150, 75);
            Player2.Font = new Font("Ariel", 20);

            Bitmap bmp = new Bitmap(Player1.Width, Player1.Height);
            using (Graphics g = Graphics.FromImage(bmp)) {
                Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    Color.DarkGray,
                                                    Color.Black,
                                                    LinearGradientMode.Vertical)) {
                    g.FillRectangle(br, r);
                }
            }

            Bitmap bmp1 = new Bitmap(TronLabel.Width, TronLabel.Height);
            using (Graphics g = Graphics.FromImage(bmp1)) {
                Rectangle r = new Rectangle(0, 0, bmp1.Width, bmp1.Height);
                using (LinearGradientBrush br = new LinearGradientBrush(
                                                    r,
                                                    Color.DarkGray,
                                                    Color.Black,
                                                    LinearGradientMode.Vertical)) {
                    g.FillRectangle(br, r);
                }
            }

            Player1.BackgroundImage = bmp;
            Player2.BackgroundImage = bmp;
            TronLabel.BackgroundImage = bmp1;
        }
    }
}
