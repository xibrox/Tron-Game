
namespace Tron {
    partial class Tron {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.pbCanvas = new System.Windows.Forms.PictureBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TimerBonus = new System.Windows.Forms.Timer(this.components);
            this.TimerSlowBonus = new System.Windows.Forms.Timer(this.components);
            this.TimerSlowBonusLength = new System.Windows.Forms.Timer(this.components);
            this.TimerBonusLength = new System.Windows.Forms.Timer(this.components);
            this.Timer2 = new System.Windows.Forms.Timer(this.components);
            this.TimerInvertBonus = new System.Windows.Forms.Timer(this.components);
            this.TimerInvertBonusLength = new System.Windows.Forms.Timer(this.components);
            this.TimerInverted = new System.Windows.Forms.Timer(this.components);
            this.Timer1Inverted = new System.Windows.Forms.Timer(this.components);
            this.LengthSpeed1 = new System.Windows.Forms.Label();
            this.LengthSpeed2 = new System.Windows.Forms.Label();
            this.TimerLabelSpeed1 = new System.Windows.Forms.Timer(this.components);
            this.TimerLabelSpeed2 = new System.Windows.Forms.Timer(this.components);
            this.TimerLabelSlow1 = new System.Windows.Forms.Timer(this.components);
            this.TimerLabelSlow2 = new System.Windows.Forms.Timer(this.components);
            this.LengthSlow2 = new System.Windows.Forms.Label();
            this.LengthSlow1 = new System.Windows.Forms.Label();
            this.LengthInvert1 = new System.Windows.Forms.Label();
            this.LengthInvert2 = new System.Windows.Forms.Label();
            this.TimerLabelInvert1 = new System.Windows.Forms.Timer(this.components);
            this.TimerLabelInvert2 = new System.Windows.Forms.Timer(this.components);
            this.GameOver = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCanvas
            // 
            this.pbCanvas.Location = new System.Drawing.Point(12, 12);
            this.pbCanvas.Name = "pbCanvas";
            this.pbCanvas.Size = new System.Drawing.Size(100, 50);
            this.pbCanvas.TabIndex = 0;
            this.pbCanvas.TabStop = false;
            this.pbCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pbCanvas_Paint);
            // 
            // Timer
            // 
            this.Timer.Interval = 10;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // Timer1
            // 
            this.Timer1.Interval = 10;
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlText;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Red Score: 0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlText;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(12, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Blue Score: 0";
            // 
            // TimerBonus
            // 
            this.TimerBonus.Interval = 10000;
            this.TimerBonus.Tick += new System.EventHandler(this.TimerBonus_Tick);
            // 
            // TimerSlowBonus
            // 
            this.TimerSlowBonus.Interval = 12000;
            this.TimerSlowBonus.Tick += new System.EventHandler(this.TimerSlowBonus_Tick);
            // 
            // TimerSlowBonusLength
            // 
            this.TimerSlowBonusLength.Interval = 5000;
            this.TimerSlowBonusLength.Tick += new System.EventHandler(this.TimerSlowBonusLength_Tick);
            // 
            // TimerBonusLength
            // 
            this.TimerBonusLength.Interval = 5000;
            this.TimerBonusLength.Tick += new System.EventHandler(this.TimerBonusLength_Tick);
            // 
            // Timer2
            // 
            this.Timer2.Interval = 10;
            this.Timer2.Tick += new System.EventHandler(this.Timer2_Tick);
            // 
            // TimerInvertBonus
            // 
            this.TimerInvertBonus.Interval = 15000;
            this.TimerInvertBonus.Tick += new System.EventHandler(this.TimerInvertBonus_Tick);
            // 
            // TimerInvertBonusLength
            // 
            this.TimerInvertBonusLength.Interval = 5000;
            this.TimerInvertBonusLength.Tick += new System.EventHandler(this.TimerInvertBonusLength_Tick);
            // 
            // TimerInverted
            // 
            this.TimerInverted.Interval = 10;
            this.TimerInverted.Tick += new System.EventHandler(this.TimerInverted_Tick);
            // 
            // Timer1Inverted
            // 
            this.Timer1Inverted.Interval = 10;
            this.Timer1Inverted.Tick += new System.EventHandler(this.Timer1Inverted_Tick);
            // 
            // LengthSpeed1
            // 
            this.LengthSpeed1.AutoSize = true;
            this.LengthSpeed1.BackColor = System.Drawing.SystemColors.ControlText;
            this.LengthSpeed1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LengthSpeed1.Location = new System.Drawing.Point(12, 426);
            this.LengthSpeed1.Name = "LengthSpeed1";
            this.LengthSpeed1.Size = new System.Drawing.Size(39, 15);
            this.LengthSpeed1.TabIndex = 3;
            this.LengthSpeed1.Text = "Red: 5";
            // 
            // LengthSpeed2
            // 
            this.LengthSpeed2.AutoSize = true;
            this.LengthSpeed2.BackColor = System.Drawing.SystemColors.ControlText;
            this.LengthSpeed2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LengthSpeed2.Location = new System.Drawing.Point(746, 426);
            this.LengthSpeed2.Name = "LengthSpeed2";
            this.LengthSpeed2.Size = new System.Drawing.Size(42, 15);
            this.LengthSpeed2.TabIndex = 4;
            this.LengthSpeed2.Text = "Blue: 5";
            // 
            // TimerLabelSpeed1
            // 
            this.TimerLabelSpeed1.Interval = 1000;
            this.TimerLabelSpeed1.Tick += new System.EventHandler(this.TimerLabelSpeed1_Tick);
            // 
            // TimerLabelSpeed2
            // 
            this.TimerLabelSpeed2.Interval = 1000;
            this.TimerLabelSpeed2.Tick += new System.EventHandler(this.TimerLabelSpeed2_Tick);
            // 
            // TimerLabelSlow1
            // 
            this.TimerLabelSlow1.Interval = 1000;
            this.TimerLabelSlow1.Tick += new System.EventHandler(this.TimerLabelSlow1_Tick);
            // 
            // TimerLabelSlow2
            // 
            this.TimerLabelSlow2.Interval = 1000;
            this.TimerLabelSlow2.Tick += new System.EventHandler(this.TimerLabelSlow2_Tick);
            // 
            // LengthSlow2
            // 
            this.LengthSlow2.AutoSize = true;
            this.LengthSlow2.BackColor = System.Drawing.SystemColors.ControlText;
            this.LengthSlow2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LengthSlow2.Location = new System.Drawing.Point(698, 426);
            this.LengthSlow2.Name = "LengthSlow2";
            this.LengthSlow2.Size = new System.Drawing.Size(42, 15);
            this.LengthSlow2.TabIndex = 6;
            this.LengthSlow2.Text = "Blue: 5";
            // 
            // LengthSlow1
            // 
            this.LengthSlow1.AutoSize = true;
            this.LengthSlow1.BackColor = System.Drawing.SystemColors.ControlText;
            this.LengthSlow1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LengthSlow1.Location = new System.Drawing.Point(57, 426);
            this.LengthSlow1.Name = "LengthSlow1";
            this.LengthSlow1.Size = new System.Drawing.Size(39, 15);
            this.LengthSlow1.TabIndex = 7;
            this.LengthSlow1.Text = "Red: 5";
            // 
            // LengthInvert1
            // 
            this.LengthInvert1.AutoSize = true;
            this.LengthInvert1.BackColor = System.Drawing.SystemColors.ControlText;
            this.LengthInvert1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LengthInvert1.Location = new System.Drawing.Point(102, 426);
            this.LengthInvert1.Name = "LengthInvert1";
            this.LengthInvert1.Size = new System.Drawing.Size(42, 15);
            this.LengthInvert1.TabIndex = 8;
            this.LengthInvert1.Text = "Blue: 5";
            // 
            // LengthInvert2
            // 
            this.LengthInvert2.AutoSize = true;
            this.LengthInvert2.BackColor = System.Drawing.SystemColors.ControlText;
            this.LengthInvert2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LengthInvert2.Location = new System.Drawing.Point(653, 426);
            this.LengthInvert2.Name = "LengthInvert2";
            this.LengthInvert2.Size = new System.Drawing.Size(39, 15);
            this.LengthInvert2.TabIndex = 9;
            this.LengthInvert2.Text = "Red: 5";
            // 
            // TimerLabelInvert1
            // 
            this.TimerLabelInvert1.Interval = 1000;
            this.TimerLabelInvert1.Tick += new System.EventHandler(this.TimerLabelInvert1_Tick);
            // 
            // TimerLabelInvert2
            // 
            this.TimerLabelInvert2.Interval = 1000;
            this.TimerLabelInvert2.Tick += new System.EventHandler(this.TimerLabelInvert2_Tick);
            // 
            // GameOver
            // 
            this.GameOver.AutoSize = true;
            this.GameOver.BackColor = System.Drawing.SystemColors.ControlText;
            this.GameOver.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.GameOver.Location = new System.Drawing.Point(381, 218);
            this.GameOver.Name = "GameOver";
            this.GameOver.Size = new System.Drawing.Size(66, 15);
            this.GameOver.TabIndex = 10;
            this.GameOver.Text = "Game Over";
            // 
            // Tron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.GameOver);
            this.Controls.Add(this.LengthInvert2);
            this.Controls.Add(this.LengthInvert1);
            this.Controls.Add(this.LengthSlow1);
            this.Controls.Add(this.LengthSlow2);
            this.Controls.Add(this.LengthSpeed2);
            this.Controls.Add(this.LengthSpeed1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbCanvas);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tron";
            this.Text = "Tron";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCanvas;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Timer Timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer TimerBonus;
        private System.Windows.Forms.Timer TimerSlowBonus;
        private System.Windows.Forms.Timer TimerSlowBonusLength;
        private System.Windows.Forms.Timer TimerBonusLength;
        private System.Windows.Forms.Timer Timer2;
        private System.Windows.Forms.Timer TimerInvertBonus;
        private System.Windows.Forms.Timer TimerInvertBonusLength;
        private System.Windows.Forms.Timer TimerInverted;
        private System.Windows.Forms.Timer Timer1Inverted;
        private System.Windows.Forms.Label LengthSpeed1;
        private System.Windows.Forms.Label LengthSpeed2;
        private System.Windows.Forms.Timer TimerLabelSpeed1;
        private System.Windows.Forms.Timer TimerLabelSpeed2;
        private System.Windows.Forms.Timer TimerLabelSlow1;
        private System.Windows.Forms.Timer TimerLabelSlow2;
        private System.Windows.Forms.Label LengthSlow2;
        private System.Windows.Forms.Label LengthSlow1;
        private System.Windows.Forms.Label LengthInvert1;
        private System.Windows.Forms.Label LengthInvert2;
        private System.Windows.Forms.Timer TimerLabelInvert1;
        private System.Windows.Forms.Timer TimerLabelInvert2;
        private System.Windows.Forms.Label GameOver;
    }
}

