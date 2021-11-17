using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Tron {
    public partial class Form1 : Form {
        Player player1;
        Player player2;
        List<Player> players1 = new List<Player>();
        List<Player> players2 = new List<Player>();
        Random rnd = new Random();

        enum Position {
            Left, Right, Up, Down, Null
        }

        enum Position1 {
            W, A, S, D, Null
        }

        private Position position;
        private Position1 position1;

        public Form1() {
            InitializeComponent();
            Init();

            position = Position.Null;
            position1 = Position1.Null;
            SetPlayer2();
            SetPlayer1();
            playSound();
        }

        public void Init() {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;

            this.pbCanvas.BackColor = Color.Black;
            this.pbCanvas.Size = this.Size;
        }

        private void playSound() {
            SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\baton\source\repos\Tron\Tron\Shawn Mendes - There's Nothing Holdin' Me Back[Acapella].wav");
        }

        public void SetPlayer1() {
            var size = new Size(13, 13);
            var location = new Point(pbCanvas.Width - pbCanvas.Width / 3, pbCanvas.Size.Height / 2);

            player1 = new Player(Brushes.Red, size, location, 3);
        }
        
        public void SetPlayer2() {
            var size = new Size(13, 13);
            var location = new Point(pbCanvas.Width / 3, pbCanvas.Size.Height / 2);

            player2 = new Player(Brushes.Blue, size, location, 3);
        }

        public void SetPlayer1Death() {
            var size = new Size(13, 13);
            var location = new Point(rnd.Next(0, pbCanvas.Width), rnd.Next(label1.Size.Height + 15, pbCanvas.Size.Height - 15));

            player1 = new Player(Brushes.Red, size, location, 3);
        }

        public void SetPlayer2Death() {
            var size = new Size(13, 13);
            var location = new Point(rnd.Next(0, pbCanvas.Width), rnd.Next(label1.Size.Height + 15, pbCanvas.Size.Height - 15));

            player2 = new Player(Brushes.Blue, size, location, 3);
        }

        public void SetPlayer1Tail() {
            var size = new Size(player1.Size.Width, player1.Size.Height);
            var location = new Point(player1.Location.X, player1.Location.Y);

            players1.Add(new Player(Brushes.Red, size, location, 3));
        }

        public void SetPlayer1TailUp() {
            var size = new Size(player1.Size.Width, player1.Size.Height);
            var location = new Point(player1.Location.X, player1.Location.Y + 10);

            players1.Add(new Player(Brushes.Red, size, location, 3));
        }

        public void SetPlayer1TailDown() {
            var size = new Size(player1.Size.Width, player1.Size.Height);
            var location = new Point(player1.Location.X, player1.Location.Y - 10);

            players1.Add(new Player(Brushes.Red, size, location, 3));
        }

        public void SetPlayer1TailLeft() {
            var size = new Size(player1.Size.Width, player1.Size.Height);
            var location = new Point(player1.Location.X + 10, player1.Location.Y);

            players1.Add(new Player(Brushes.Red, size, location, 3));
        }

        public void SetPlayer1TailRight() {
            var size = new Size(player1.Size.Width, player1.Size.Height);
            var location = new Point(player1.Location.X - 10, player1.Location.Y);

            players1.Add(new Player(Brushes.Red, size, location, 3));
        }

        public void SetPlayer2Tail() {
            var size = new Size(player2.Size.Width, player2.Size.Height);
            var location = new Point(player2.Location.X, player2.Location.Y);

            players2.Add(new Player(Brushes.Blue, size, location, 3));
        }

        public void SetPlayer2TailUp() {
            var size = new Size(player2.Size.Width, player2.Size.Height);
            var location = new Point(player2.Location.X, player2.Location.Y + 10);

            players2.Add(new Player(Brushes.Blue, size, location, 3));
        }

        public void SetPlayer2TailDown() {
            var size = new Size(player2.Size.Width, player2.Size.Height);
            var location = new Point(player2.Location.X, player2.Location.Y - 10);

            players2.Add(new Player(Brushes.Blue, size, location, 3));
        }

        public void SetPlayer2TailLeft() {
            var size = new Size(player2.Size.Width, player2.Size.Height);
            var location = new Point(player2.Location.X + 10, player2.Location.Y);

            players2.Add(new Player(Brushes.Blue, size, location, 3));
        }

        public void SetPlayer2TailRight() {
            var size = new Size(player2.Size.Width, player2.Size.Height);
            var location = new Point(player2.Location.X - 10, player2.Location.Y);

            players2.Add(new Player(Brushes.Blue, size, location, 3));
        }

        private void pbCanvas_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;

            foreach (var item in players1) {
                item.Draw(g);
            }

            foreach (var item in players2) {
                item.Draw(g);
            }

            player1.Draw(g);

            player2.Draw(g);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }

            if (Keys.Up == e.KeyCode) {
                if(position != Position.Down) {
                    position = Position.Up;
                }
            }
            if (Keys.Left == e.KeyCode) {
                if (position != Position.Right) {
                    position = Position.Left;
                }
            }
            if (Keys.Down == e.KeyCode) {
                if (position != Position.Up) {
                    position = Position.Down;
                }
            }
            if (Keys.Right == e.KeyCode) {
                if(position != Position.Left) {
                    position = Position.Right;
                }
            }

            if (Keys.W == e.KeyCode) {
                if (position1 != Position1.S) {
                    position1 = Position1.W;
                }
            }
            if (Keys.A == e.KeyCode) {
                if (position1 != Position1.D) {
                    position1 = Position1.A;
                }
            }
            if (Keys.S == e.KeyCode) {
                if(position1 != Position1.W) {
                    position1 = Position1.S;
                }
            }
            if (Keys.D == e.KeyCode) {
                if (position1 != Position1.A) {
                    position1 = Position1.D;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            
        }

        private void Timer_Tick(object sender, EventArgs e) {
            var direction = new Point();
            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, label1.Size.Height + player1.Size.Height, pbCanvas.Size.Height);

            if (position == Position.Up) {
                direction.Y--;
                SetPlayer1TailUp();
            }
            if (position == Position.Down) {
                direction.Y++;
                SetPlayer1TailDown();
            }
            if (position == Position.Left) {
                direction.X--;
                SetPlayer1TailLeft();
            }
            if (position == Position.Right) {
                direction.X++;
                SetPlayer1TailRight();
            }

            player1.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void Timer1_Tick(object sender, EventArgs e) {
            var direction = new Point();
            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, label1.Size.Height + player2.Size.Height, pbCanvas.Size.Height);

            if (position1 == Position1.W) {
                direction.Y--;
                SetPlayer2TailUp();
            }
            if (position1 == Position1.S) {
                direction.Y++;
                SetPlayer2TailDown();
            }
            if (position1 == Position1.A) {
                direction.X--;
                SetPlayer2TailLeft();
            }
            if (position1 == Position1.D) {
                direction.X++;
                SetPlayer2TailRight();
            }

            player2.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void Score1() {
            var displayScore = 0;

            displayScore++;
            label1.Text = "Red Score: " + displayScore;
        }

        private void Score2() {
            var displayScore = 0;

            displayScore++;
            label2.Text = "Blue Score: " + displayScore;
        }

        private void HandleCollision() {
            var players1Delete = new List<Player>();
            var players2Delete = new List<Player>();
            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, label1.Size.Height + player2.Size.Height, pbCanvas.Size.Height);

            foreach (var item in players1) {
                if (player2.Intersect(item.Rectangle)) {
                    players2Delete.Add(item);
                }
                if (player1.Intersect(item.Rectangle)) {
                    players1Delete.Add(item);
                }
                if (player1.Location.Y < boundary.Up) {
                    players1Delete.Add(item);
                }
                if (player1.Location.Y > (boundary.Down - player2.Size.Height)) {
                    players1Delete.Add(item);
                }
                if (player1.Location.X < boundary.Left) {
                    players1Delete.Add(item);
                }
                if (player1.Location.X > (boundary.Right - player1.Size.Width)) {
                    players1Delete.Add(item);
                }
            }

            foreach (var item in players2) {
                if (player1.Intersect(item.Rectangle)) {
                    players1Delete.Add(item);
                }
                if (player2.Intersect(item.Rectangle)) {
                    players2Delete.Add(item);
                }
                if (player2.Location.Y < boundary.Up) {
                    players2Delete.Add(item);
                }
                if (player2.Location.Y > (boundary.Down - player2.Size.Height)) {
                    players2Delete.Add(item);
                }
                if (player2.Location.X < boundary.Left) {
                    players2Delete.Add(item);
                }
                if (player2.Location.X > (boundary.Right - player2.Size.Width)) {
                    players2Delete.Add(item);
                }
            }

            foreach (var item in players1Delete) {
                if (item is Player) {
                    players1.Clear();
                    players2.Clear();
                    SetPlayer1();
                    SetPlayer2();
                    position = Position.Null;
                    position1 = Position1.Null;
                    Score2();
                }
            }

            foreach (var item in players2Delete) {
                if (item is Player) {
                    players2.Clear();
                    players1.Clear();
                    SetPlayer2();
                    SetPlayer1();
                    position1 = Position1.Null;
                    position = Position.Null;
                    Score1();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            label1.Location = new Point(pbCanvas.Width - 190, 10);
            label1.BackColor = Color.Black;
            label1.Font = new Font("Arial", 20);

            label2.Location = new Point(10, 10);
            label2.BackColor = Color.Black;
            label2.Font = new Font("Arial", 20);
        }
    }
}
