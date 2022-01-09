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
        List<Bonus> bonusSpeed = new List<Bonus>();
        List<Bonus> bonusSlow = new List<Bonus>();
        Random rnd = new Random();
        private int redScore = 0;
        private int blueScore = 0;

        //Epic Enums

        enum Position {
            Left, Right, Up, Down, Null
        }

        enum Position1 {
            W, A, S, D, Null
        }

        private Position position;
        private Position1 position1;

        //Some usefull staff 

        public Form1() {
            InitializeComponent();
            Init();

            position = Position.Null;
            position1 = Position1.Null;
            SetPlayer2();
            SetPlayer1();
        }
        
        //Canvas Settings

        public void Init() {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;

            this.pbCanvas.Location = new Point(0, 0);
            this.pbCanvas.BackColor = Color.FromArgb(0, 0, 0);
            this.pbCanvas.Size = this.Size;
        }

        //Spawn Players, Players Tails and Bonuses

        public void SetBonusSpeed() {
            var size = new Size(18, 18);
            var location = new Point(rnd.Next(0, pbCanvas.Width), rnd.Next(label1.Size.Height + 22, pbCanvas.Height - 22));

            bonusSpeed.Add(new Bonus(Brushes.Green, size, location));
        }

        public void SetBonusSlow() {
            var size = new Size(18, 18);
            var location = new Point(rnd.Next(0, pbCanvas.Width), rnd.Next(label1.Size.Height + 22, pbCanvas.Height - 22));

            bonusSlow.Add(new Bonus(Brushes.Gray, size, location));
        }

        public void SetPlayer1() {
            var size = new Size(15, 15);
            var location = new Point(pbCanvas.Width - pbCanvas.Width / 3, pbCanvas.Size.Height / 2);

            player1 = new Player(Brushes.Red, size, location, 3);
        }
        
        public void SetPlayer2() {
            var size = new Size(15, 15);
            var location = new Point(pbCanvas.Width / 3, pbCanvas.Size.Height / 2);

            player2 = new Player(Brushes.Blue, size, location, 3);
        }

        public void SetPlayer1Tail() {
            var size = new Size(player1.Size.Width, player1.Size.Height);
            var location = new Point(player1.Location.X, player1.Location.Y);

            players1.Add(new Player(Brushes.Red, size, location, 3));
        }
        public void SetPlayer2Tail() {
            var size = new Size(player2.Size.Width, player2.Size.Height);
            var location = new Point(player2.Location.X, player2.Location.Y);

            players2.Add(new Player(Brushes.Blue, size, location, 3));
        }

        //Drawing on Canvas

        private void pbCanvas_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;

            g.Clear(Color.Black);

            foreach (var item in players1) {
                item.Draw(g);
            }

            foreach (var item in players2) {
                item.Draw(g);
            }

            foreach (var item in bonusSpeed) {
                item.Draw(g);
            }

            foreach (var item in bonusSlow) {
                item.Draw(g);
            }

            player1.Draw(g);

            player2.Draw(g);
        }

        //Movement for Players

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }

            //Movement for Player2

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

            //Movement for Player1

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

        //1 tick = 10 ms

        private void Timer_Tick(object sender, EventArgs e) {
            var direction = new Point();

            //Spawning Tail for Player1

            if (position == Position.Up) {
                direction.Y--;
                SetPlayer1Tail();
            }
            if (position == Position.Down) {
                direction.Y++;
                SetPlayer1Tail();
            }
            if (position == Position.Left) {
                direction.X--;
                SetPlayer1Tail();
            }
            if (position == Position.Right) {
                direction.X++;
                SetPlayer1Tail();
            }

            player1.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //1 tick = 10 ms

        private void Timer1_Tick(object sender, EventArgs e) {
            var direction = new Point();

            //Spawning Tail for Player2

            if (position1 == Position1.W) {
                direction.Y--;
                SetPlayer2Tail();
            }
            if (position1 == Position1.S) {
                direction.Y++;
                SetPlayer2Tail();
            }
            if (position1 == Position1.A) {
                direction.X--;
                SetPlayer2Tail();
            }
            if (position1 == Position1.D) {
                direction.X++;
                SetPlayer2Tail();
            }

            player2.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //1 tick = 1 ms

        private void Timer2_Tick(object sender, EventArgs e) {
            if (players2.Count > 200) {
                SetPlayer2Tail();
                players2.RemoveRange(0, 2);
            }

            if (players1.Count > 200) {
                SetPlayer1Tail();
                players1.RemoveRange(0, 2);
            }
        }

        //1 tick = 10 000 ms (10 seconds)

        private void TimerBonus_Tick(object sender, EventArgs e) {
            if (bonusSpeed.Count == 2) {
                return;
            }
            else {
                SetBonusSpeed();
            }

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //1 tick = 12 000 ms (12 seconds)

        private void TimerSlowBonus_Tick(object sender, EventArgs e) {
            if (bonusSlow.Count == 2) {
                return;
            }
            else {
                SetBonusSlow();
            }

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //1 tick = 5 000 ms (5 seconds)

        private void TimerBonusLength_Tick(object sender, EventArgs e) {
            if (player1.Speed > 3) {
                player1.Speed = 3;
            }
            
            if (player2.Speed > 3) {
                player2.Speed = 3;
            }

            TimerBonusLength.Enabled = false;

            this.pbCanvas.Refresh();
        }

        //1 tick = 5 000 ms (5 seconds)

        private void TimerSlowBonusLength_Tick(object sender, EventArgs e) {
            if (player1.Speed == 1 && player2.Speed == 1) {
                player1.Speed = 3;
                player2.Speed = 3;
            }

            TimerSlowBonusLength.Enabled = false;

            this.pbCanvas.Refresh();
        }

        //not working score IDK why

        private void Score1() {
            redScore++;
            label1.Text = "Red Score: " + redScore;
        }

        private void Score2() {
            blueScore++;
            label2.Text = "Blue Score: " + blueScore;
        }

        private void HandleCollision() {
            var players1Delete = new List<Player>();
            var players2Delete = new List<Player>();

            var bonus1SpeedEffect = new List<Bonus>();
            var bonus2SpeedEffect = new List<Bonus>();

            var bonusSlowEffect = new List<Bonus>();

            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, 0, pbCanvas.Size.Height);

            //Collision for Player1

            foreach (var item in players1) {
                if (player2.Intersect(item.Rectangle)) {
                    players2Delete.Add(item);
                }

                for (var i = players1.Count - 20; i >= 0; i--) {
                    if (player1.Intersect(players1[i].Rectangle)) {
                        players1Delete.Add(item);
                    }
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

            //Collision for Player2

            foreach (var item in players2) {
                if (player1.Intersect(item.Rectangle)) {
                    players1Delete.Add(item);
                }
                
                for (var i = players2.Count - 20; i >= 0; i--) {
                    if (player2.Intersect(players2[i].Rectangle)) {
                        players2Delete.Add(item);
                    }
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

            //Speed Bonus

            foreach (var item in bonusSpeed) {
                if (player1.Intersect(item.Rectangle)) {
                    bonus1SpeedEffect.Add(item);
                }

                if (player2.Intersect(item.Rectangle)) {
                    bonus2SpeedEffect.Add(item);
                }
            }

            //Slow Motion Bonus

            foreach (var item in bonusSlow) {
                if (player1.Intersect(item.Rectangle)) {
                    bonusSlowEffect.Add(item);
                }

                if (player2.Intersect(item.Rectangle)) {
                    bonusSlowEffect.Add(item);
                }
            }

            //Effect of Speed Bonus for Player1

            foreach (var item in bonus1SpeedEffect) {
                if (item is Bonus) {
                    TimerBonusLength.Enabled = true;
                    if (player1.Speed == 3) {
                        player1.Speed += 2;
                    }
                    bonusSpeed.Remove(item);
                }
            }

            //Effect of Speed Bonus for Player2

            foreach (var item in bonus2SpeedEffect) {
                if (item is Bonus) {
                    TimerBonusLength.Enabled = true;
                    if (player2.Speed == 3) {
                        player2.Speed += 2;
                    }
                    bonusSpeed.Remove(item);
                }
            }

            //Effect of Slow Bonus

            foreach (var item in bonusSlowEffect) {
                if (item is Bonus) {
                    TimerSlowBonusLength.Enabled = true;
                    if (player1.Speed >= 3 && player2.Speed >= 3) {
                        player1.Speed -= 1;
                        player2.Speed -= 1;
                    }
                    bonusSlow.Remove(item);
                }
            }

            //Player1 Died

            foreach (var item in players1Delete) {
                if (item is Player) {
                    players1.Clear();
                    players2.Clear();
                    SetPlayer1();
                    SetPlayer2();
                    position = Position.Null;
                    position1 = Position1.Null;
                    Score2();
                    bonusSlow.Clear();
                    bonusSpeed.Clear();
                }
            }

            //Player2 Died

            foreach (var item in players2Delete) {
                if (item is Player) {
                    players2.Clear();
                    players1.Clear();
                    SetPlayer2();
                    SetPlayer1();
                    position1 = Position1.Null;
                    position = Position.Null;
                    Score1();
                    bonusSlow.Clear();
                    bonusSpeed.Clear();
                }
            }
        }

        //Score Labels

        private void Form1_Load(object sender, EventArgs e) {
            label1.Location = new Point(pbCanvas.Width - 190, 10);
            label1.BackColor = Color.Black;
            label1.ForeColor = Color.FromArgb(255, 0, 0);
            label1.Font = new Font("Arial", 20);

            label2.Location = new Point(10, 10);
            label2.BackColor = Color.Black;
            label2.ForeColor = Color.FromArgb(0, 0, 255);
            label2.Font = new Font("Arial", 20);
        }
    }
}
