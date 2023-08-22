namespace Solution
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            panel1 = new DoubleBufferedPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            button2 = new Button();
            colorDialog1 = new ColorDialog();
            trackBar1 = new TrackBar();
            panel2 = new Panel();
            rectRadioBtn = new RadioButton();
            circleRadioBtn = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(824, 12);
            button1.Name = "button1";
            button1.Size = new Size(250, 100);
            button1.TabIndex = 1;
            button1.Text = "Начать анимацию";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ScrollBar;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 600);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            panel1.MouseClick += panel1_MouseClick;
            // 
            // timer1
            // 
            timer1.Interval = 30;
            timer1.Tick += Update;
            // 
            // button2
            // 
            button2.Location = new Point(824, 124);
            button2.Name = "button2";
            button2.Size = new Size(250, 100);
            button2.TabIndex = 3;
            button2.Text = "Остановить анимацию";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(824, 265);
            trackBar1.Maximum = 30;
            trackBar1.Minimum = 1;
            trackBar1.Name = "trackBar1";
            trackBar1.RightToLeft = RightToLeft.Yes;
            trackBar1.Size = new Size(246, 90);
            trackBar1.TabIndex = 4;
            trackBar1.Value = 30;
            trackBar1.ValueChanged += trackBar1_ValueChanged;
            // 
            // panel2
            // 
            panel2.Controls.Add(rectRadioBtn);
            panel2.Controls.Add(circleRadioBtn);
            panel2.Location = new Point(824, 375);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 136);
            panel2.TabIndex = 5;
            // 
            // rectRadioBtn
            // 
            rectRadioBtn.AutoSize = true;
            rectRadioBtn.Location = new Point(34, 78);
            rectRadioBtn.Name = "rectRadioBtn";
            rectRadioBtn.Size = new Size(133, 36);
            rectRadioBtn.TabIndex = 1;
            rectRadioBtn.Text = "Квадрат";
            rectRadioBtn.UseVisualStyleBackColor = true;
            rectRadioBtn.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // circleRadioBtn
            // 
            circleRadioBtn.AutoSize = true;
            circleRadioBtn.Checked = true;
            circleRadioBtn.Location = new Point(34, 20);
            circleRadioBtn.Name = "circleRadioBtn";
            circleRadioBtn.Size = new Size(94, 36);
            circleRadioBtn.TabIndex = 0;
            circleRadioBtn.TabStop = true;
            circleRadioBtn.Text = "Круг";
            circleRadioBtn.UseVisualStyleBackColor = true;
            circleRadioBtn.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(836, 230);
            label1.Name = "label1";
            label1.Size = new Size(234, 32);
            label1.TabIndex = 6;
            label1.Text = "Скорость анимации";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(858, 327);
            label2.Name = "label2";
            label2.Size = new Size(144, 32);
            label2.TabIndex = 7;
            label2.Text = "Тип фигуры";
            // 
            // button3
            // 
            button3.Location = new Point(824, 512);
            button3.Name = "button3";
            button3.Size = new Size(250, 100);
            button3.TabIndex = 8;
            button3.Text = "Инструкция";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 624);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(trackBar1);
            Controls.Add(panel1);
            Controls.Add(button1);
            DoubleBuffered = true;
            MaximumSize = new Size(1117, 695);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private DoubleBufferedPanel panel1;
        private System.Windows.Forms.Timer timer1;
        private Button button2;
        private ColorDialog colorDialog1;
        private TrackBar trackBar1;
        private Panel panel2;
        private RadioButton rectRadioBtn;
        private RadioButton circleRadioBtn;
        private Label label1;
        private Label label2;
        private Button button3;
    }
}