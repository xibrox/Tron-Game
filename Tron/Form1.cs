using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Tron {
    public partial class Tron : Form {
        Player player1;
        Player player2;
        List<Player> players1 = new List<Player>();
        List<Player> players2 = new List<Player>();
        List<Bonus> bonusSpeed = new List<Bonus>();
        List<Bonus> bonusSlow = new List<Bonus>();
        List<Bonus> bonusInvert = new List<Bonus>();
        List<Bonus> bonusIncrease = new List<Bonus>();
        Random rnd = new Random();
        int redScore = 0;
        int blueScore = 0;
        int redCount = 200;
        int blueCount = 200;
        int secSpeed1 = 5;
        int secSpeed2 = 5;
        int secSlow1 = 5;
        int secSlow2 = 5;
        int secInvert1 = 5;
        int secInvert2 = 5;
        int position1R = 0;

        //Epic Enums

        enum Position {
            Left, Right, Up, Down, Null
        }

        enum Position1 {
            W, A, S, D, Null
        }

        private Position position;

        public Tron() {
            InitializeComponent();
            Init();

            position = Position.Null;
            position1R = 0;

            SetPlayer2();
            SetPlayer1();
        }

        //Screen and Canvas Settings

        public void Init() {
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.WindowState = FormWindowState.Maximized;

            this.pbCanvas.Location = new Point(0, 0);
            this.pbCanvas.BackColor = Color.FromArgb(26, 26, 26);
            this.pbCanvas.Size = this.Size;
        }

        //Spawn Players, Players Tails and Bonuses

        //Player1

        public void SetPlayer1() {
            var size = new Size(13, 13);
            var location = new Point(pbCanvas.Width - pbCanvas.Width / 3, pbCanvas.Size.Height / 2);

            player1 = new Player(new SolidBrush(Color.FromArgb(230, 0, 0)), size, location, 3);
        }

        //Player2

        public void SetPlayer2() {
            var size = new Size(13, 13);
            var location = new Point(pbCanvas.Width / 3, pbCanvas.Size.Height / 2);

            player2 = new Player(new SolidBrush(Color.FromArgb(0, 0, 255)), size, location, 3);
        }

        //Spawning Tail for Player1

        public void SetPlayer1Tail() {
            var size = new Size(player1.Size.Width, player1.Size.Height);
            var location = new Point(player1.Location.X, player1.Location.Y);

            players1.Add(new Player(new SolidBrush(Color.FromArgb(230, 0, 0)), size, location, 3));
        }

        //Spawning Tail for Player1

        public void SetPlayer2Tail() {
            var size = new Size(player2.Size.Width, player2.Size.Height);
            var location = new Point(player2.Location.X, player2.Location.Y);

            players2.Add(new Player(new SolidBrush(Color.FromArgb(0, 0, 255)), size, location, 3));
        }

        //Spawn of Speed Bonus

        public void SetBonusSpeed() {
            var size = new Size(18, 18);
            var location = new Point(rnd.Next(0, pbCanvas.Width - size.Width), rnd.Next(50, pbCanvas.Height - 22));

            bonusSpeed.Add(new Bonus(Brushes.Green, size, location));
        }

        //Spawn of Slow Motion Bonus

        public void SetBonusSlow() {
            var size = new Size(18, 18);
            var location = new Point(rnd.Next(0, pbCanvas.Width - size.Width), rnd.Next(50, pbCanvas.Height - 22));

            bonusSlow.Add(new Bonus(Brushes.Gray, size, location));
        }

        //Spawn of Inverted Controls Bonus

        public void SetBonusInvert() {
            var size = new Size(18, 18);
            var location = new Point(rnd.Next(0, pbCanvas.Width - size.Width), rnd.Next(50, pbCanvas.Height - 22));

            bonusInvert.Add(new Bonus(Brushes.Aqua, size, location));
        }

        public void SetBonusIncrease() {
            var size = new Size(18, 18);
            var location = new Point(rnd.Next(0, pbCanvas.Width - size.Width), rnd.Next(50, pbCanvas.Height - 22));

            bonusIncrease.Add(new Bonus(Brushes.Coral, size, location));
        }

        //Starting Game

        private void StartGame() {
            if (Timer.Enabled == false && Timer1.Enabled == false) {
                SetPlayer1();
                SetPlayer2();

                Timer.Enabled = true;
                Timer1.Enabled = true;
                Timer2.Enabled = true;
                Timer3.Enabled = true;
                Timer4.Enabled = true;
                TimerBonus.Enabled = true;
                TimerP2Turn.Enabled = true;
                TimerSlowBonus.Enabled = true;
                TimerInvertBonus.Enabled = true;
                TimerIncreaseBonus.Enabled = true;
                GameOver.Visible = false;

                if (redScore == 5 && blueScore == 5) {
                    redScore = 0;
                    blueScore = 0;
                }

                if (redScore == 5 || blueScore == 5) {
                    redScore = 0;
                    blueScore = 0;
                }
            }
        }

        //Drawing on Canvas

        private void pbCanvas_Paint(object sender, PaintEventArgs e) {
            var g = e.Graphics;

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

            foreach (var item in bonusIncrease) {
                item.Draw(g);
            }

            player1.Draw(g);

            player2.Draw(g);

            g.DrawString("Red Score: " + redScore, new Font("Arial", 20), Brushes.Red, new Point(pbCanvas.Width - 190, 10));
            g.DrawString("Blue Score: " + blueScore, new Font("Arial", 20), Brushes.Blue, new Point(10, 10));
        }

        //Movement for Players

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Escape) {
                this.Close();
            }

            if (Keys.Space == e.KeyCode) {
                if (position == Position.Null && position1R == 0) {
                    position = Position.Left;
                    if (Form2.Bot == true) {
                        position1R = Form2.PositionD;
                    }

                    if (Form2.Bot == false) {
                        position1R = Form2.Position1D;
                    }
                }

                StartGame();
            }

            //Movement for Player1

            if (Keys.Up == e.KeyCode) {
                if (position == Position.Null) {
                    return;
                }

                if (position != Position.Down) {
                    position = Position.Up;
                }
            }

            if (Keys.Left == e.KeyCode) {
                if (position == Position.Null) {
                    return;
                }

                if (position != Position.Right) {
                    position = Position.Left;
                }
            }

            if (Keys.Down == e.KeyCode) {
                if (position == Position.Null) {
                    return;
                }

                if (position != Position.Up) {
                    position = Position.Down;
                }
            }

            if (Keys.Right == e.KeyCode) {
                if (position == Position.Null) {
                    return;
                }

                if (position != Position.Left) {
                    position = Position.Right;
                }
            }

            //Movement for Player2

            if (Form2.Bot == false && Keys.W == e.KeyCode) {
                if (position1R == 0) {
                    return;
                }

                if (position1R != Form2.Position1S) {
                    position1R = Form2.Position1W;
                }
            }

            if (Form2.Bot == false && Keys.A == e.KeyCode) {
                if (position1R == 0) {
                    return;
                }

                if (position1R != Form2.Position1D) {
                    position1R = Form2.Position1A;
                }
            }

            if (Form2.Bot == false && Keys.S == e.KeyCode) {
                if (position1R == 0) {
                    return;
                }

                if (position1R != Form2.Position1W) {
                    position1R = Form2.Position1S;
                }
            }

            if (Form2.Bot == false && Keys.D == e.KeyCode) {
                if (position1R == 0) {
                    return;
                }

                if (position1R != Form2.Position1A) {
                    position1R = Form2.Position1D;
                }
            }
        }

        //Spawning Tail for Player1
        //1 tick = 10 ms

        private void Timer_Tick(object sender, EventArgs e) {
            var direction = new Point();

            if (position == Position.Up) {
                direction.Y--;
            }
            if (position == Position.Down) {
                direction.Y++;
            }
            if (position == Position.Left) {
                direction.X--;
            }
            if (position == Position.Right) {
                direction.X++;
            }

            SetPlayer1Tail();

            player1.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Spawning Tail for Player2
        //1 tick = 10 ms

        private void Timer1_Tick(object sender, EventArgs e) {
            var direction = new Point();

            if (Form2.Bot == false && position1R == 0) {
                return;
            }

            if (Form2.Bot == false && position1R == Form2.Position1W) {
                direction.Y--;
            }

            if (Form2.Bot == false && position1R == Form2.Position1S) {
                direction.Y++;
            }

            if (Form2.Bot == false && position1R == Form2.Position1A) {
                direction.X--;
            }

            if (Form2.Bot == false && position1R == Form2.Position1D) {
                direction.X++;
            }

            SetPlayer2Tail();

            player2.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Bot

        private void Timer3_Tick(object sender, EventArgs e) {
            var direction = new Point();

            if (Form2.Bot == true && position1R == Form2.PositionW) {
                direction.Y--;
            }

            if (Form2.Bot == true && position1R == Form2.PositionS) {
                direction.Y++;
            }

            if (Form2.Bot == true && position1R == Form2.PositionA) {
                direction.X--;
            }

            if (Form2.Bot == true && position1R == Form2.PositionD) {
                direction.X++;
            }

            player2.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Bot Turn

        private void Timer4_Tick(object sender, EventArgs e) {
            var direction = new Point();

            Random rnd = new Random();
            var num = rnd.Next(0, 2);

            if (Form2.Bot == true && position1R == 0) {
                return;
            }

            if (Form2.Bot == true && position1R == Form2.PositionW) {
                foreach (var s in players1) {
                    if (player2.Location.Y <= s.Location.Y + player1.Size.Height * 5 && player2.Location.Y >= s.Size.Height) {
                        if (player2.Location.X <= s.Location.X + player1.Size.Width && player2.Location.X >= s.Location.X) {
                            if (num == 0) {
                                position1R = Form2.PositionA;
                            }

                            else if (num == 1) {
                                position1R = Form2.PositionD;
                            }
                        }
                    }
                }

                //foreach (var s in players2) {
                //    if (player2.Location.Y >= s.Location.Y - player1.Size.Height * 5 && player2.Location.Y <= s.Size.Height) {
                //        if (player2.Location.X <= s.Location.X + player1.Size.Width && player2.Location.X >= s.Location.X) {
                //            if (num == 0) {
                //                position1R = Form2.PositionA;
                //            }

                //            else if (num == 1) {
                //                position1R = Form2.PositionD;
                //            }
                //        }
                //    }
                //}

                if (player2.Location.Y <= player1.Location.Y + player2.Size.Height * 5 && player2.Location.Y >= player1.Size.Height) {
                    if (player2.Location.X <= player1.Location.X + player1.Size.Width && player2.Location.X >= player1.Location.X) {
                        if (num == 0) {
                            position1R = Form2.PositionA;
                        }

                        else if (num == 1) {
                            position1R = Form2.PositionD;
                        }
                    }
                }
            }

            if (Form2.Bot == true && position1R == Form2.PositionS) {
                foreach (var s in players1) {
                    if (player2.Location.Y >= s.Location.Y - player1.Size.Width * 5 && player2.Location.Y <= s.Location.Y) {
                        if (player2.Location.X <= s.Location.X + player1.Size.Width && player2.Location.X >= s.Location.X) {
                            if (num == 0) {
                                position1R = Form2.PositionA;
                            }

                            else if (num == 1) {
                                position1R = Form2.PositionD;
                            }
                        }
                    }
                }

                //foreach (var s in players2) {
                //    if (player2.Location.Y <= s.Location.Y + player1.Size.Width * 5 && player2.Location.Y >= s.Location.Y) {
                //        if (player2.Location.X <= s.Location.X + player1.Size.Width && player2.Location.X >= s.Location.X) {
                //            if (num == 0) {
                //                position1R = Form2.PositionA;
                //            }

                //            else if (num == 1) {
                //                position1R = Form2.PositionD;
                //            }
                //        }
                //    }
                //}

                if (player2.Location.Y >= player1.Location.Y - player1.Size.Width * 5 && player2.Location.Y <= player1.Location.Y) {
                    if (player2.Location.X <= player1.Location.X + player1.Size.Width && player2.Location.X >= player1.Location.X) {
                        if (num == 0) {
                            position1R = Form2.PositionA;
                        }

                        else if (num == 1) {
                            position1R = Form2.PositionD;
                        }
                    }
                }
            }

            if (Form2.Bot == true && position1R == Form2.PositionA) {
                foreach (var s in players1) {
                    if (player2.Location.X <= s.Location.X + player1.Size.Width * 5 && player2.Location.X >= s.Location.X) {
                        if (player2.Location.Y <= s.Location.Y + player1.Size.Height && player2.Location.Y >= s.Location.Y) {
                            if (num == 0) {
                                position1R = Form2.PositionW;
                            }

                            else if (num == 1) {
                                position1R = Form2.PositionS;
                            }
                        }
                    }
                }

                //foreach (var s in players2) {
                //    if (player2.Location.X >= s.Location.X - player1.Size.Width * 5 && player2.Location.X <= s.Location.X) {
                //        if (player2.Location.Y <= s.Location.Y + player1.Size.Height && player2.Location.Y >= s.Location.Y) {
                //            if (num == 0) {
                //                position1R = Form2.PositionW;
                //            }

                //            else if (num == 1) {
                //                position1R = Form2.PositionS;
                //            }
                //        }
                //    }
                //}

                if (player2.Location.X <= player1.Location.X + player1.Size.Width * 5 && player2.Location.X >= player1.Location.X) {
                    if (player2.Location.Y <= player1.Location.Y + player1.Size.Height && player2.Location.Y >= player1.Location.Y) {
                        if (num == 0) {
                            position1R = Form2.PositionW;
                        }

                        else if (num == 1) {
                            position1R = Form2.PositionS;
                        }
                    }
                }
            }

            if (Form2.Bot == true && position1R == Form2.PositionD) {
                foreach (var s in players1) {
                    if (player2.Location.X >= s.Location.X - player1.Size.Width * 5 && player2.Location.X <= s.Location.X) {
                        if (player2.Location.Y <= s.Location.Y + player1.Size.Height && player2.Location.Y >= s.Location.Y) {
                            if (num == 0) {
                                position1R = Form2.PositionW;
                            }

                            else if (num == 1) {
                                position1R = Form2.PositionS;
                            }
                        }
                    }
                }

                //foreach (var s in players2) {
                //    if (player2.Location.X <= s.Location.X + player1.Size.Width * 5 && player2.Location.X >= s.Location.X) {
                //        if (player2.Location.Y <= s.Location.Y + player1.Size.Height && player2.Location.Y >= s.Location.Y) {
                //            if (num == 0) {
                //                position1R = Form2.PositionW;
                //            }

                //            else if (num == 1) {
                //                position1R = Form2.PositionS;
                //            }
                //        }
                //    }
                //}

                if (player2.Location.X >= player1.Location.X - player1.Size.Width * 5 && player2.Location.X <= player1.Location.X) {
                    if (player2.Location.Y <= player1.Location.Y + player1.Size.Height && player2.Location.Y >= player1.Location.Y) {
                        if (num == 0) {
                            position1R = Form2.PositionW;
                        }

                        else if (num == 1) {
                            position1R = Form2.PositionS;
                        }
                    }
                }
            }

            player2.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        private void TimerP2Turn_Tick(object sender, EventArgs e) {
            foreach (var s in bonusSpeed) {
                if (player2.Location.Y <= s.Location.Y + s.Size.Height - 3 && player2.Location.Y >= s.Location.Y) {
                    if (player2.Location.X < s.Location.X) {
                        position1R = Form2.PositionD;
                    }

                    if (player2.Location.X > s.Location.X) {
                        position1R = Form2.PositionA;
                    }
                }

                if (player2.Location.X <= s.Location.X + s.Size.Width - 3 && player2.Location.X >= s.Location.X) {
                    if (player2.Location.Y < s.Location.Y) {
                        position1R = Form2.PositionS;
                    }

                    if (player2.Location.Y > s.Location.Y) {
                        position1R = Form2.PositionW;
                    }
                }
            }

            foreach (var s in bonusSlow) {
                if (player2.Location.Y <= s.Location.Y + s.Size.Height - 3 && player2.Location.Y >= s.Location.Y) {
                    if (player2.Location.X < s.Location.X) {
                        position1R = Form2.PositionD;
                    }

                    if (player2.Location.X > s.Location.X) {
                        position1R = Form2.PositionA;
                    }
                }

                if (player2.Location.X <= s.Location.X + s.Size.Width - 3 && player2.Location.X >= s.Location.X) {
                    if (player2.Location.Y < s.Location.Y) {
                        position1R = Form2.PositionS;
                    }

                    if (player2.Location.Y > s.Location.Y) {
                        position1R = Form2.PositionW;
                    }
                }
            }

            foreach (var s in bonusIncrease) {
                if (player2.Location.Y <= s.Location.Y + s.Size.Height - 3 && player2.Location.Y >= s.Location.Y) {
                    if (player2.Location.X < s.Location.X) {
                        position1R = Form2.PositionD;
                    }

                    if (player2.Location.X > s.Location.X) {
                        position1R = Form2.PositionA;
                    }
                }

                if (player2.Location.X <= s.Location.X + s.Size.Width - 3 && player2.Location.X >= s.Location.X) {
                    if (player2.Location.Y < s.Location.Y) {
                        position1R = Form2.PositionS;
                    }

                    if (player2.Location.Y > s.Location.Y) {
                        position1R = Form2.PositionW;
                    }
                }
            }

            foreach (var s in bonusInvert) {
                if (player2.Location.Y <= s.Location.Y + s.Size.Height - 3 && player2.Location.Y >= s.Location.Y) {
                    if (player2.Location.X < s.Location.X) {
                        position1R = Form2.PositionD;
                    }

                    if (player2.Location.X > s.Location.X) {
                        position1R = Form2.PositionA;
                    }
                }

                if (player2.Location.X <= s.Location.X + s.Size.Width - 3 && player2.Location.X >= s.Location.X) {
                    if (player2.Location.Y < s.Location.Y) {
                        position1R = Form2.PositionS;
                    }

                    if (player2.Location.Y > s.Location.Y) {
                        position1R = Form2.PositionW;
                    }
                }
            }
        }

        //Spawning Tail for Inverted Controls Bonus...Player1
        //1 tick = 10 ms

        private void TimerInverted_Tick(object sender, EventArgs e) {
            var direction = new Point();

            if (position == Position.Up) {
                direction.Y++;
            }

            if (position == Position.Down) {
                direction.Y--;
            }

            if (position == Position.Left) {
                direction.X++;
            }

            if (position == Position.Right) {
                direction.X--;
            }

            SetPlayer1Tail();

            player1.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //Spawning Tail for Inverted Controls Bonus...Player2
        //1 tick = 10 ms

        private void Timer1Inverted_Tick(object sender, EventArgs e) {
            var direction = new Point();

            if (Form2.Bot == false && position1R == Form2.Position1W) {
                direction.Y++;
            }

            if (Form2.Bot == false && position1R == Form2.Position1S) {
                direction.Y--;
            }

            if (Form2.Bot == false && position1R == Form2.Position1A) {
                direction.X++;
            }

            if (Form2.Bot == false && position1R == Form2.Position1D) {
                direction.X--;
            }

            SetPlayer2Tail();

            player2.Move(direction);

            HandleCollision();

            this.pbCanvas.Refresh();
        }


        //Limit of Tail
        //1 tick = 10 ms

        private void Timer2_Tick(object sender, EventArgs e) {
            if (players1.Count > redCount) {
                players1.RemoveRange(0, 1);
            }

            if (players2.Count > blueCount) {
                players2.RemoveRange(0, 1);
            }

            if (bonusSpeed.Count == 0 && Timer.Enabled == true) {
                TimerBonus.Enabled = true;
            }

            if (bonusSlow.Count == 0 && Timer.Enabled == true) {
                TimerSlowBonus.Enabled = true;
            }

            if (bonusInvert.Count == 0 && Timer.Enabled == true) {
                TimerInvertBonus.Enabled = true;
            }

            if (bonusIncrease.Count <= 1 && Timer.Enabled == true) {
                TimerIncreaseBonus.Enabled = true;
            }
        }

        //Spawn of Speed Bonus
        //1 tick = 10 000 ms (10 seconds)

        private void TimerBonus_Tick(object sender, EventArgs e) {
            if (bonusSpeed.Count == 1) {
                TimerBonus.Enabled = false;
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
                LengthSpeed1.Visible = false;
                TimerLabelSpeed1.Enabled = false;
            }

            if (player2.Speed > 0) {
                player2.Speed = 3;
                LengthSpeed2.Visible = false;
                TimerLabelSpeed2.Enabled = false;
            }

            secSpeed1 = 5;
            secSpeed2 = 5;

            TimerBonusLength.Enabled = false;

            this.pbCanvas.Refresh();
        }

        //Spawn of Slow Motion Bonus
        //1 tick = 12 000 ms (12 seconds)

        private void TimerSlowBonus_Tick(object sender, EventArgs e) {
            if (bonusSlow.Count == 1) {
                TimerSlowBonus.Enabled = false;
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

            secSlow1 = 5;
            secSlow2 = 5;

            LengthSlow1.Visible = false;
            LengthSlow2.Visible = false;
            TimerLabelSlow1.Enabled = false;
            TimerLabelSlow2.Enabled = false;
            TimerSlowBonusLength.Enabled = false;

            this.pbCanvas.Refresh();
        }

        //Spawn of Inverted Controls Bonus
        //1 tick = 15 000 ms (15 seconds)

        private void TimerInvertBonus_Tick(object sender, EventArgs e) {
            if (bonusInvert.Count == 1) {
                TimerInvertBonus.Enabled = false;
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
                    if (position == Position.Down) {
                        TimerInverted.Enabled = false;
                        Timer.Enabled = true;
                    }
                }

                else if (Position.Down == position) {
                    position = Position.Up;
                    if (position == Position.Up) {
                        TimerInverted.Enabled = false;
                        Timer.Enabled = true;
                    }
                }

                else if (Position.Left == position) {
                    position = Position.Right;
                    if (position == Position.Right) {
                        TimerInverted.Enabled = false;
                        Timer.Enabled = true;
                    }
                }

                else if (Position.Right == position) {
                    position = Position.Left;
                    if (position == Position.Left) {
                        TimerInverted.Enabled = false;
                        Timer.Enabled = true;
                    }
                }

                LengthInvert2.Visible = false;
            }

            if (Timer1Inverted.Enabled == true && Form2.Bot == false) {
                if (position1R == Form2.Position1W) {
                    position1R = Form2.Position1S;
                    if (position1R == Form2.Position1S) {
                        Timer1Inverted.Enabled = false;
                        Timer1.Enabled = true;
                    }
                }

                else if (position1R == Form2.Position1S) {
                    position1R = Form2.Position1W;
                    if (position1R == Form2.Position1W) {
                        Timer1Inverted.Enabled = false;
                        Timer1.Enabled = true;
                    }
                }

                else if (position1R == Form2.Position1A) {
                    position1R = Form2.Position1D;
                    if (position1R == Form2.Position1D) {
                        Timer1Inverted.Enabled = false;
                        Timer1.Enabled = true;
                    }
                }

                else if (position1R == Form2.Position1D) {
                    position1R = Form2.Position1A;
                    if (position1R == Form2.Position1A) {
                        Timer1Inverted.Enabled = false;
                        Timer1.Enabled = true;
                    }
                }

                LengthInvert1.Visible = false;
            }

            if (Timer1Inverted.Enabled == true && Form2.Bot == true) {
                if (position1R == Form2.PositionW) {
                    position1R = Form2.PositionS;
                    if (position1R == Form2.PositionS) {
                        Timer1Inverted.Enabled = false;
                        Timer1.Enabled = true;
                    }
                }

                else if (position1R == Form2.PositionS) {
                    position1R = Form2.PositionW;
                    if (position1R == Form2.PositionW) {
                        Timer1Inverted.Enabled = false;
                        Timer1.Enabled = true;
                    }
                }

                else if (position1R == Form2.PositionA) {
                    position1R = Form2.PositionD;
                    if (position1R == Form2.PositionD) {
                        Timer1Inverted.Enabled = false;
                        Timer1.Enabled = true;
                    }
                }

                else if (position1R == Form2.PositionD) {
                    position1R = Form2.PositionA;
                    if (position1R == Form2.PositionA) {
                        Timer1Inverted.Enabled = false;
                        Timer1.Enabled = true;
                    }
                }

                LengthInvert1.Visible = false;
            }

            secInvert1 = 5;
            secInvert2 = 5;

            TimerLabelInvert1.Enabled = false;
            TimerLabelInvert2.Enabled = false;
            TimerInvertBonusLength.Enabled = false;

            this.pbCanvas.Refresh();
        }

        private void TimerIncreaseBonus_Tick(object sender, EventArgs e) {
            if (bonusIncrease.Count == 2) {
                TimerIncreaseBonus.Enabled = false;
            }
            else {
                SetBonusIncrease();
            }

            HandleCollision();

            this.pbCanvas.Refresh();
        }

        //All Timers for Labels
        //1 tick = 1000 ms (1 second)

        private void TimerLabelSpeed1_Tick(object sender, EventArgs e) {
            secSpeed1--;

            LengthSpeed1.Text = "Red: " + secSpeed1;
        }

        private void TimerLabelSpeed2_Tick(object sender, EventArgs e) {
            secSpeed2--;

            LengthSpeed2.Text = "Blue: " + secSpeed2;
        }

        private void TimerLabelSlow1_Tick(object sender, EventArgs e) {
            secSlow1--;

            LengthSlow1.Text = "Red: " + secSlow1;
        }

        private void TimerLabelSlow2_Tick(object sender, EventArgs e) {
            secSlow2--;

            LengthSlow2.Text = "Blue: " + secSlow2;
        }

        private void TimerLabelInvert1_Tick(object sender, EventArgs e) {
            secInvert1--;

            LengthInvert1.Text = "Blue: " + secInvert1;
        }

        private void TimerLabelInvert2_Tick(object sender, EventArgs e) {
            secInvert2--;

            LengthInvert2.Text = "Red: " + secInvert2;
        }

        //If Someone Dies

        private void EndGameScore() {
            player1 = new Player(new SolidBrush(Color.FromArgb(26, 26, 26)), new Size(13, 13), player1.Location, 3);
            player2 = new Player(new SolidBrush(Color.FromArgb(26, 26, 26)), new Size(13, 13), player2.Location, 3);
            players1.Clear();
            players2.Clear();
            bonusSlow.Clear();
            bonusSpeed.Clear();
            bonusInvert.Clear();
            bonusIncrease.Clear();
            Timer.Enabled = false;
            Timer1.Enabled = false;
            Timer3.Enabled = false;
            Timer4.Enabled = false;
            TimerBonus.Enabled = false;
            TimerP2Turn.Enabled = false;
            TimerSlowBonus.Enabled = false;
            TimerInvertBonus.Enabled = false;
            TimerIncreaseBonus.Enabled = false;
            TimerInverted.Enabled = false;
            Timer1Inverted.Enabled = false;
            LengthSpeed1.Visible = false;
            LengthSpeed2.Visible = false;
            LengthSlow1.Visible = false;
            LengthSlow2.Visible = false;
            LengthInvert1.Visible = false;
            LengthInvert2.Visible = false;
            position = Position.Null;
            position1R = 0;

            redCount = 200;
            blueCount = 200;
        }

        //Score for Player1

        private void Score1() {
            if (redScore == 5) {
                position = Position.Null;
                position1R = 0;
            }

            if (redScore < 5) {
                redScore++;
            }

            EndGameScore();
        }

        //Score for Player2

        private void Score2() {
            if (blueScore == 5) {
                position = Position.Null;
                position1R = 0;
            }

            if (blueScore < 5) {
                blueScore++;
            }

            EndGameScore();
        }

        private void Tie() {
            if (redScore == 5 && blueScore == 5) {
                position = Position.Null;
                position1R = 0;
            }

            if (redScore == 4 && blueScore == 4) {
                GameOver.Visible = true;
                GameOver.Text = "                 Tie\nPress Space To Continue";
            }

            else if (blueScore == 4) {
                GameOver.Visible = true;
                GameOver.Text = "      Blue Player Won\nPress Space To Continue";
            }

            else if (redScore == 4) {
                GameOver.Visible = true;
                GameOver.Text = "      Red Player Won\nPress Space To Continue";
            }

            if (redScore <= 4) {
                Score1();
            }

            if (blueScore <= 4) {
                Score2();
            }

            EndGameScore();
        }

        private void HandleCollision() {
            var bonus1SpeedEffect = new List<Bonus>();
            var bonus2SpeedEffect = new List<Bonus>();

            var bonus1SlowEffect = new List<Bonus>();
            var bonus2SlowEffect = new List<Bonus>();

            var bonus1InvertEffect = new List<Bonus>();
            var bonus2InvertEffect = new List<Bonus>();

            var bonus1IncreaseEffect = new List<Bonus>();
            var bonus2IncreaseEffect = new List<Bonus>();

            Boundary boundary = new Boundary(0, pbCanvas.Size.Width, 0, pbCanvas.Size.Height);

            //Collision for Player1

            for (var i = 0; i < players2.Count; i++) {
                if (player1.Intersect(players2[i].Rectangle)) {
                    Score2();
                }

                if (player1.Intersect(player2.Rectangle)) {
                    Tie();
                }
            }

            for (var i = 0; i < players1.Count - 30; i++) {
                if (player1.Intersect(players1[i].Rectangle)) {
                    Score2();
                }
            }

            if (player1.Location.Y < boundary.Up - 7) {
                player1 = new Player(Brushes.Red, new Size(13, 13), new Point(player1.Location.X, pbCanvas.Height + 7 - player1.Size.Height), 3);
            }

            if (player1.Location.Y > (boundary.Down + 7 - player2.Size.Height)) {
                player1 = new Player(Brushes.Red, new Size(13, 13), new Point(player1.Location.X, -7), 3);
            }

            if (player1.Location.X < boundary.Left - 7) {
                player1 = new Player(Brushes.Red, new Size(13, 13), new Point(pbCanvas.Width + 7 - player1.Size.Width, player1.Location.Y), 3);
            }

            if (player1.Location.X > (boundary.Right + 7 - player1.Size.Width)) {
                player1 = new Player(Brushes.Red, new Size(13, 13), new Point(-7, player1.Location.Y), 3);
            }

            //Collision for Player2

            for (var i = 0; i < players1.Count; i++) {
                if (player2.Intersect(players1[i].Rectangle)) {
                    Score1();
                }

                if (player2.Intersect(player1.Rectangle)) {
                    Tie();
                }
            }

            for (var i = 0; i < players2.Count - 30; i++) {
                if (player2.Intersect(players2[i].Rectangle)) {
                    Score1();
                }
            }

            if (player2.Location.Y < boundary.Up - 7) {
                player2 = new Player(Brushes.Blue, new Size(13, 13), new Point(player2.Location.X, pbCanvas.Height + 7 - player2.Size.Height), 3);
            }

            if (player2.Location.Y > (boundary.Down + 7 - player2.Size.Height)) {
                player2 = new Player(Brushes.Blue, new Size(13, 13), new Point(player2.Location.X, -7), 3);
            }

            if (player2.Location.X < boundary.Left - 7) {
                player2 = new Player(Brushes.Blue, new Size(13, 13), new Point(pbCanvas.Width + 7 - player2.Size.Width, player2.Location.Y), 3);
            }

            if (player2.Location.X > (boundary.Right + 7 - player2.Size.Width)) {
                player2 = new Player(Brushes.Blue, new Size(13, 13), new Point(-7, player2.Location.Y), 3);
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
                    bonus1SlowEffect.Add(item);
                }

                if (player2.Intersect(item.Rectangle)) {
                    bonus2SlowEffect.Add(item);
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

            //Increase Tail Bonus

            foreach (var item in bonusIncrease) {
                if (player1.Intersect(item.Rectangle)) {
                    bonus1IncreaseEffect.Add(item);
                }

                if (player2.Intersect(item.Rectangle)) {
                    bonus2IncreaseEffect.Add(item);
                }
            }

            //Effect of Speed Bonus for Player1

            foreach (var item in bonus1SpeedEffect) {
                if (item is Bonus) {
                    TimerLabelSpeed1.Enabled = true;
                    LengthSpeed1.Visible = true;
                    LengthSpeed1.Text = "Red: " + secSpeed1;
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
                    TimerLabelSpeed2.Enabled = true;
                    LengthSpeed2.Visible = true;
                    LengthSpeed2.Text = "Blue: " + secSpeed2;
                    TimerBonusLength.Enabled = true;
                    if (player2.Speed <= 3) {
                        player2.Speed += 2;
                    }
                    bonusSpeed.Remove(item);
                }
            }

            //Effect of Slow Bonus for Player1

            foreach (var item in bonus1SlowEffect) {
                if (item is Bonus) {
                    TimerLabelSlow1.Enabled = true;
                    TimerLabelSlow2.Enabled = true;
                    LengthSlow1.Visible = true;
                    LengthSlow2.Visible = true;
                    LengthSlow1.Text = "Red: " + secSlow1;
                    LengthSlow2.Text = "Blue: " + secSlow2;
                    TimerSlowBonusLength.Enabled = true;
                    if (player1.Speed >= 3 && player2.Speed >= 3) {
                        player1.Speed -= 1;
                        player2.Speed -= 1;
                    }
                    bonusSlow.Remove(item);
                }
            }

            //Effect of Slow Bonus for Player1

            foreach (var item in bonus2SlowEffect) {
                if (item is Bonus) {
                    TimerLabelSlow1.Enabled = true;
                    TimerLabelSlow2.Enabled = true;
                    LengthSlow1.Visible = true;
                    LengthSlow2.Visible = true;
                    LengthSlow1.Text = "Red: " + secSlow1;
                    LengthSlow2.Text = "Blue: " + secSlow2;
                    TimerSlowBonusLength.Enabled = true;
                    if (player1.Speed >= 3 && player2.Speed >= 3) {
                        player1.Speed -= 1;
                        player2.Speed -= 1;
                    }
                    bonusSlow.Remove(item);
                }
            }

            //Inverted Controls Effect for Player2

            foreach (var item in bonus1InvertEffect) {
                if (item is Bonus) {
                    if (position1R == Form2.Position1W) {
                        position1R = Form2.Position1S;
                        if (position1R == Form2.Position1S) {
                            TimerInvertBonusLength.Enabled = true;
                            Timer1Inverted.Enabled = true;
                            Timer1.Enabled = false;
                        }
                    }

                    else if (position1R == Form2.Position1S) {
                        position1R = Form2.Position1W;
                        if (position1R == Form2.Position1W) {
                            TimerInvertBonusLength.Enabled = true;
                            Timer1Inverted.Enabled = true;
                            Timer1.Enabled = false;
                        }
                    }

                    else if (position1R == Form2.Position1A) {
                        position1R = Form2.Position1D;
                        if (position1R == Form2.Position1D) {
                            TimerInvertBonusLength.Enabled = true;
                            Timer1Inverted.Enabled = true;
                            Timer1.Enabled = false;
                        }
                    }

                    else if (position1R == Form2.Position1D) {
                        position1R = Form2.Position1A;
                        if (position1R == Form2.Position1A) {
                            TimerInvertBonusLength.Enabled = true;
                            Timer1Inverted.Enabled = true;
                            Timer1.Enabled = false;
                        }
                    }

                    TimerLabelInvert1.Enabled = true;
                    LengthInvert1.Visible = true;
                    LengthInvert1.Text = "Blue: " + secInvert1;

                    bonusInvert.Remove(item);
                }
            }

            //Inverted Controls Effect for Player1

            foreach (var item in bonus2InvertEffect) {
                if (item is Bonus) {
                    if (Position.Up == position) {
                        position = Position.Down;
                        if (position == Position.Down) {
                            TimerInvertBonusLength.Enabled = true;
                            TimerInverted.Enabled = true;
                            Timer.Enabled = false;
                        }
                    }

                    else if (Position.Down == position) {
                        position = Position.Up;
                        if (position == Position.Up) {
                            TimerInvertBonusLength.Enabled = true;
                            TimerInverted.Enabled = true;
                            Timer.Enabled = false;
                        }
                    }

                    else if (Position.Left == position) {
                        position = Position.Right;
                        if (position == Position.Right) {
                            TimerInvertBonusLength.Enabled = true;
                            TimerInverted.Enabled = true;
                            Timer.Enabled = false;
                        }
                    }

                    else if (Position.Right == position) {
                        position = Position.Left;
                        if (position == Position.Left) {
                            TimerInvertBonusLength.Enabled = true;
                            TimerInverted.Enabled = true;
                            Timer.Enabled = false;
                        }
                    }

                    TimerLabelInvert2.Enabled = true;
                    LengthInvert2.Visible = true;
                    LengthInvert2.Text = "Red: " + secInvert2;

                    bonusInvert.Remove(item);
                }
            }

            //Effect of Increase Tail Bonus for Player1 

            foreach (var item in bonus1IncreaseEffect) {
                if (item is Bonus) {
                    redCount += 100;

                    bonusIncrease.Remove(item);
                }
            }

            //Effect of Increase Tail Bonus for Player2

            foreach (var item in bonus2IncreaseEffect) {
                if (item is Bonus) {
                    blueCount += 100;

                    bonusIncrease.Remove(item);
                }
            }
        }

        //Score Labels and Length of Bonuses

        private void Form1_Load(object sender, EventArgs e) {
            GameOver.Visible = false;
            GameOver.Location = new Point(pbCanvas.Width / 2 - GameOver.Size.Width * 14 / 3, pbCanvas.Height / 2 - GameOver.Size.Height * 4);
            GameOver.BackColor = Color.FromArgb(26, 26, 26);
            GameOver.ForeColor = Color.White;
            GameOver.Font = new Font("Arial", 40);
            GameOver.Text = "                 Tie\nPress Space To Continue";

            LengthSpeed1.Visible = false;
            LengthSpeed1.Location = new Point(pbCanvas.Width - LengthSpeed1.Size.Width - 60, pbCanvas.Height - LengthSpeed1.Size.Height - 20);
            LengthSpeed1.BackColor = Color.FromArgb(26, 26, 26);
            LengthSpeed1.ForeColor = Color.Green;
            LengthSpeed1.Font = new Font("Arial", 20);

            LengthSpeed2.Visible = false;
            LengthSpeed2.Location = new Point(10, pbCanvas.Height - LengthSpeed2.Size.Height - 20);
            LengthSpeed2.BackColor = Color.FromArgb(26, 26, 26);
            LengthSpeed2.ForeColor = Color.Green;
            LengthSpeed2.Font = new Font("Arial", 20);

            LengthSlow1.Visible = false;
            LengthSlow1.Location = new Point(pbCanvas.Width / 2 - LengthSlow1.Size.Width * 3, pbCanvas.Height - LengthSlow1.Size.Height - 20);
            LengthSlow1.BackColor = Color.FromArgb(26, 26, 26);
            LengthSlow1.ForeColor = Color.Gray;
            LengthSlow1.Font = new Font("Arial", 20);

            LengthSlow2.Visible = false;
            LengthSlow2.Location = new Point(pbCanvas.Width / 2 + LengthSlow2.Size.Width / 2, pbCanvas.Height - LengthSlow2.Size.Height - 20);
            LengthSlow2.BackColor = Color.FromArgb(26, 26, 26);
            LengthSlow2.ForeColor = Color.Gray;
            LengthSlow2.Font = new Font("Arial", 20);

            LengthInvert1.Visible = false;
            LengthInvert1.Location = new Point(LengthSpeed1.Size.Width + 20, pbCanvas.Height - LengthInvert1.Size.Height - 20);
            LengthInvert1.BackColor = Color.FromArgb(26, 26, 26);
            LengthInvert1.ForeColor = Color.Aqua;
            LengthInvert1.Font = new Font("Arial", 20);

            LengthInvert2.Visible = false;
            LengthInvert2.Location = new Point(pbCanvas.Width - LengthSpeed2.Size.Width * 2, pbCanvas.Height - LengthInvert2.Size.Height - 20);
            LengthInvert2.BackColor = Color.FromArgb(26, 26, 26);
            LengthInvert2.ForeColor = Color.Aqua;
            LengthInvert2.Font = new Font("Arial", 20);

            if (this.Visible == false) {
                SetPlayer1();
                SetPlayer2();
                redScore = 0;
                blueScore = 0;
                redCount = 200;
                blueCount = 200;

                position = Position.Null;
                position1R = 0;

                players1.Clear();
                players2.Clear();
                bonusIncrease.Clear();
                bonusInvert.Clear();
                bonusSlow.Clear();
                bonusSpeed.Clear();

                Timer.Enabled = false;
                Timer1.Enabled = false;
                Timer2.Enabled = false;
                Timer3.Enabled = false;
                Timer4.Enabled = false;
                TimerBonus.Enabled = false;
                TimerP2Turn.Enabled = false;
                TimerSlowBonus.Enabled = false;
                TimerInvertBonus.Enabled = false;
                TimerIncreaseBonus.Enabled = false;
                GameOver.Visible = false;
            }
        }
    }
}
