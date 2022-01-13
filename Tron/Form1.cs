using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Tron {
    public partial class Tron : Form {
        Player player1;
        Player player2;
        List<Player> players1 = new List<Player>();
        List<Player> players2 = new List<Player>();
        List<Bonus> bonusSpeed = new List<Bonus>();
        List<Bonus> bonusSlow = new List<Bonus>();
        List<Bonus> bonusInvert = new List<Bonus>();
        Random rnd = new Random();
        int redScore = 0;
        int blueScore = 0;

        //Epic Enums

        enum Position {
            Left, Right, Up, Down, Null
        }

        enum Position1 {
            W, A, S, D, Null
        }

        private Position position;
        private Position1 position1;

        public Tron() {
            InitializeComponent();
            Init();

            position = Position.Null;
            position1 = Position1.Null;
            SetPlayer2();
            SetPlayer1();
        }
        
        //Screen and Canvas Settings

        public void Init() {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;

            this.pbCanvas.Location = new Point(0, 0);
            this.pbCanvas.BackColor = Color.FromArgb(0, 0, 0);
            this.pbCanvas.Size = this.Size;

            Cursor.Hide();
        }

        //Spawn Players, Players Tails and Bonuses

        //Spawn of Speed Bonus

        public void SetBonusSpeed() {
            var size = new Size(18, 18);
            var location = new Point(rnd.Next(0, pbCanvas.Width), rnd.Next(label1.Size.Height + 22, pbCanvas.Height - 22));

            bonusSpeed.Add(new Bonus(Brushes.Green, size, location));
        }

        //Spawn of Slow Motion Bonus

        public void SetBonusSlow() {
            var size = new Size(18, 18);
            var location = new Point(rnd.Next(0, pbCanvas.Width), rnd.Next(label1.Size.Height + 22, pbCanvas.Height - 22));

            bonusSlow.Add(new Bonus(Brushes.Gray, size, location));
        }

        //Spawn of Inverted Controls Bonus

        public void SetBonusInvert() {
            var size = new Size(18, 18);
            var location = new Point(rnd.Next(0, pbCanvas.Width), rnd.Next(label1.Size.Height + 22, pbCanvas.Height - 22));

            bonusInvert.Add(new Bonus(Brushes.Aqua, size, location));
        }

        //Player1

        public void SetPlayer1() {
            var size = new Size(13, 13);
            var location = new Point(pbCanvas.Width - pbCanvas.Width / 3, pbCanvas.Size.Height / 2);

            player1 = new Player(Brushes.Red, size, location, 3);
        }

        //Player2

        public void SetPlayer2() {
            var size = new Size(13, 13);
            var location = new Point(pbCanvas.Width / 3, pbCanvas.Size.Height / 2);

            player2 = new Player(Brushes.Blue, size, location, 3);
        }

        //Spawning Tail for Player1

        public void SetPlayer1Tail() {
            var size = new Size(player1.Size.Width, player1.Size.Height);
            var location = new Point(player1.Location.X, player1.Location.Y);

            players1.Add(new Player(Brushes.Red, size, location, 3));
        }

        //Spawning Tail for Player1

        public void SetPlayer2Tail() {
            var size = new Size(player2.Size.Width, player2.Size.Height);
            var location = new Point(player2.Location.X, player2.Location.Y);

            players2.Add(new Player(Brushes.Blue, size, location, 3));
        }

        //Starting Game

        private void StartGame() {
            if (Timer.Enabled == false && Timer1.Enabled == false) {
                Timer.Enabled = true;
                Timer1.Enabled = true;
                TimerBonus.Enabled = true;
                TimerSlowBonus.Enabled = true;
                Timer2.Enabled = true;
                TimerInvertBonus.Enabled = true;
            }
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
            
            foreach (var item in bonusInvert) {
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

            if (Keys.Space == e.KeyCode) {
                position = Position.Left;
                position1 = Position1.D;
                StartGame();
            }

            //Movement for Player1

            if (Keys.Up == e.KeyCode) {
                if (position != Position.Down) {
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
                if (position != Position.Left) {
                    position = Position.Right;
                }
            }

            //Movement for Player2

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
                if (position1 != Position1.W) {
                    position1 = Position1.S;
                }
            }

            if (Keys.D == e.KeyCode) {
                if (position1 != Position1.A) {
                    position1 = Position1.D;
                }
            }
        }

        //Spawning Tail for Player1
        //1 tick = 10 ms

        private void Timer_Tick(object sender, EventArgs e) {
            var direction = new Point();

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

        //Spawning Tail for Player2
        //1 tick = 10 ms

        private void Timer1_Tick(object sender, EventArgs e) {
            var direction = new Point();

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

        //Spawning Tail for Inverted Controls Bonus...Player1
        //1 tick = 10 ms

        private void TimerInverted_Tick(object sender, EventArgs e) {
            var direction = new Point();

            if (position == Position.Up) {
                direction.Y++;
                SetPlayer1Tail();
            }
            if (position == Position.Down) {
                direction.Y--;
                SetPlayer1Tail();
            }
            if (position == Position.Left) {
                direction.X++;
                SetPlayer1Tail();
            }
            if (position == Position.Right) {
                direction.X--;
                SetPlayer1Tail();
            }

            player1.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Spawning Tail for Inverted Controls Bonus...Player2
        //1 tick = 10 ms

        private void Timer1Inverted_Tick(object sender, EventArgs e) {
            var direction = new Point();

            if (position1 == Position1.W) {
                direction.Y++;
                SetPlayer2Tail();
            }
            if (position1 == Position1.S) {
                direction.Y--;
                SetPlayer2Tail();
            }
            if (position1 == Position1.A) {
                direction.X++;
                SetPlayer2Tail();
            }
            if (position1 == Position1.D) {
                direction.X--;
                SetPlayer2Tail();
            }

            player2.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }


        //Limit of Tail
        //1 tick = 10 ms

        private void Timer2_Tick(object sender, EventArgs e) {
            if (players1.Count > 302) {
                SetPlayer1Tail();
                players1.RemoveRange(0, 2);
            }

            if (players2.Count > 302) {
                SetPlayer2Tail();
                players2.RemoveRange(0, 2);
            }
        }

        //Spawn of Speed Bonus
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

        //Length of Speed Bonus
        //1 tick = 5 000 ms (5 seconds)

        private void TimerBonusLength_Tick(object sender, EventArgs e) {
            if (player1.Speed > 0) {
                player1.Speed = 3;
            }

            if (player2.Speed > 0) {
                player2.Speed = 3;
            }

            TimerBonusLength.Enabled = false;

            this.pbCanvas.Refresh();
        }

        //Spawn of Slow Motion Bonus
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

        //Length of Slow Motion Bonus
        //1 tick = 5 000 ms (5 seconds)

        private void TimerSlowBonusLength_Tick(object sender, EventArgs e) {
            if (player1.Speed < 3 && player2.Speed < 3) {
                player1.Speed = 3;
                player2.Speed = 3;
            }

            TimerSlowBonusLength.Enabled = false;

            this.pbCanvas.Refresh();
        }

        //Spawn of Inverted Controls Bonus
        //1 tick = 15 000 ms (15 seconds)

        private void TimerInvertBonus_Tick(object sender, EventArgs e) {
            if (bonusInvert.Count == 2) {
                return;
            }
            else {
                SetBonusInvert();
            }

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Length of Inverted Controls Bonus
        //1 tick = 5 000 ms (5 seconds)

        private void TimerInvertBonusLength_Tick(object sender, EventArgs e) {
            if (TimerInverted.Enabled == true) {
                if (Position.Up == position) {
                    position = Position.Down;
                    TimerInverted.Enabled = false;
                    Timer.Enabled = true;
                }

                if (Position.Down == position) {
                    position = Position.Up;
                    TimerInverted.Enabled = false;
                    Timer.Enabled = true;
                }

                if (Position.Left == position) {
                    position = Position.Right;
                    TimerInverted.Enabled = false;
                    Timer.Enabled = true;
                }

                if (Position.Right == position) {
                    position = Position.Left;
                    TimerInverted.Enabled = false;
                    Timer.Enabled = true;
                }
            }

            if (Timer1Inverted.Enabled == true) {
                if (Position1.W == position1) {
                    position1 = Position1.S;
                    Timer1Inverted.Enabled = false;
                    Timer1.Enabled = true;
                }

                if (Position1.S == position1) {
                    position1 = Position1.W;
                    Timer1Inverted.Enabled = false;
                    Timer1.Enabled = true;
                }

                if (Position1.A == position1) {
                    position1 = Position1.D;
                    Timer1Inverted.Enabled = false;
                    Timer1.Enabled = true;
                }

                if (Position1.D == position1) {
                    position1 = Position1.A;
                    Timer1Inverted.Enabled = false;
                    Timer1.Enabled = true;
                }
            }

            TimerInvertBonusLength.Enabled = false;

            this.pbCanvas.Refresh();
        }

        private void EndGameScore() {
            players1.Clear();
            players2.Clear();
            SetPlayer1();
            SetPlayer2();
            position = Position.Null;
            position1 = Position1.Null;
            bonusSlow.Clear();
            bonusSpeed.Clear();
            bonusInvert.Clear();
            Timer.Enabled = false;
            Timer1.Enabled = false;
            TimerBonus.Enabled = false;
            TimerSlowBonus.Enabled = false;
            TimerInvertBonus.Enabled = false;
            TimerInverted.Enabled = false;
            Timer1Inverted.Enabled = false;
        }

        //Score for Player1

        private void Score1() {
            redScore++;
            label1.Text = "Red Score: " + redScore;

            EndGameScore();
        }

        //Score for Player2

        private void Score2() {
            blueScore++;
            label2.Text = "Blue Score: " + blueScore;

            EndGameScore();
        }

        private void HandleCollision() {
            var bonus1SpeedEffect = new List<Bonus>();
            var bonus2SpeedEffect = new List<Bonus>();

            var bonusSlowEffect = new List<Bonus>();

            var bonus1InvertEffect = new List<Bonus>();
            var bonus2InvertEffect = new List<Bonus>();

            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, 0, pbCanvas.Size.Height);

            //Collision for Player1

            for (var i = 0; i < players2.Count; i++) {
                if (player1.Intersect(players2[i].Rectangle)) {
                    Score2();
                }

                if (player1.Intersect(player2.Rectangle)) {
                    Score1();
                    Score2();
                }
            }

            for (var i = 0; i < players1.Count - 30; i++) {
                if (player1.Intersect(players1[i].Rectangle)) {
                    Score2();
                }
            }

            if (player1.Location.Y < boundary.Up) {
                Score2();
            }

            if (player1.Location.Y > (boundary.Down - player2.Size.Height)) {
                Score2();
            }

            if (player1.Location.X < boundary.Left) {
                Score2();
            }

            if (player1.Location.X > (boundary.Right - player1.Size.Width)) {
                Score2();
            }

            //Collision for Player2

            for (var i = 0; i < players1.Count; i++) {
                if (player2.Intersect(players1[i].Rectangle)) {
                    Score1();
                }
            }

            for (var i = 0; i < players2.Count - 30; i++) {
                if (player2.Intersect(players2[i].Rectangle)) {
                    Score1();
                }
            }

            if (player2.Location.Y < boundary.Up) {
                Score1();
            }

            if (player2.Location.Y > (boundary.Down - player2.Size.Height)) {
                Score1();
            }

            if (player2.Location.X < boundary.Left) {
                Score1();
            }

            if (player2.Location.X > (boundary.Right - player2.Size.Width)) {
                Score1();
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

            //Inverted Controls Bonus

            foreach (var item in bonusInvert) {
                if (player1.Intersect(item.Rectangle)) {
                    bonus1InvertEffect.Add(item);
                }

                if (player2.Intersect(item.Rectangle)) {
                    bonus2InvertEffect.Add(item);
                }
            }

            //Effect of Speed Bonus for Player1

            foreach (var item in bonus1SpeedEffect) {
                if (item is Bonus) {
                    TimerBonusLength.Enabled = true;
                    if (player1.Speed <= 3) {
                        player1.Speed += 2;
                    }
                    bonusSpeed.Remove(item);
                }
            }

            //Effect of Speed Bonus for Player2

            foreach (var item in bonus2SpeedEffect) {
                if (item is Bonus) {
                    TimerBonusLength.Enabled = true;
                    if (player2.Speed <= 3) {
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

            //Inverted Controls Effect

            foreach (var item in bonus1InvertEffect) {
                if (item is Bonus) {
                    if (Position1.W == position1) {
                        position1 = Position1.S;
                        TimerInvertBonusLength.Enabled = true;
                        Timer1Inverted.Enabled = true;
                        Timer1.Enabled = false;
                    }

                    if (Position1.S == position1) {
                        position1 = Position1.W;
                        TimerInvertBonusLength.Enabled = true;
                        Timer1Inverted.Enabled = true;
                        Timer1.Enabled = false;
                    }

                    if (Position1.A == position1) {
                        position1 = Position1.D;
                        TimerInvertBonusLength.Enabled = true;
                        Timer1Inverted.Enabled = true;
                        Timer1.Enabled = false;
                    }

                    if (Position1.D == position1) {
                        position1 = Position1.A;
                        TimerInvertBonusLength.Enabled = true;
                        Timer1Inverted.Enabled = true;
                        Timer1.Enabled = false;
                    }

                    bonusInvert.Remove(item);
                }
            }

            foreach (var item in bonus2InvertEffect) {
                if (item is Bonus) {
                    if (Position.Up == position) {
                        position = Position.Down;
                        TimerInvertBonusLength.Enabled = true;
                        TimerInverted.Enabled = true;
                        Timer.Enabled = false;
                    }

                    if (Position.Down == position) {
                        position = Position.Up;
                        TimerInvertBonusLength.Enabled = true;
                        TimerInverted.Enabled = true;
                        Timer.Enabled = false;
                    }

                    if (Position.Left == position) {
                        position = Position.Right;
                        TimerInvertBonusLength.Enabled = true;
                        TimerInverted.Enabled = true;
                        Timer.Enabled = false;
                    }

                    if (Position.Right == position) {
                        position = Position.Left;
                        TimerInvertBonusLength.Enabled = true;
                        TimerInverted.Enabled = true;
                        Timer.Enabled = false;
                    }

                    bonusInvert.Remove(item);
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
