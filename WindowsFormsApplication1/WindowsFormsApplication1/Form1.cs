using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public int itemCount = 5;
        public int seconds = 0;
        private ScoreManager _scoreManager;

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            _scoreManager = new ScoreManager();
        }

        public void OnFormLoad(object sender, EventArgs e) 
        {
            seconds = 0;
            itemCount = 5;

            foreach (PictureBox pictureBox in panel1.Controls)
            {
                pictureBox.BackColor = Color.Transparent;
                pictureBox.Visible = true;
                UpdateInfoLabel();
            }

            UpdateTimer(null, null);
            timer1.Start();
        }

        public void PictureBoxClick(object sender, EventArgs e) 
        {
            var pictureBox = sender as PictureBox;

            pictureBox.Visible = false;
            itemCount--;

            UpdateInfoLabel();

            if (itemCount <= 0)
                AnnounceWinner();
        }

        public void OnRestartButtonClick(object sender, EventArgs e)
        {
            timer1.Stop();
            OnFormLoad(null, null);
        }

        private void UpdateInfoLabel() 
        {
            label1.Text = "Вам необходимо найти предметы: " + itemCount.ToString() + " яблок";
        }

        private void UpdateTimer(object sender, EventArgs e) 
        {
            seconds++;
            timerLabel.Text = TimerStringConverter.GetStringFromSeconds(seconds);
        }

        private void AnnounceWinner()
        {
            timer1.Stop();
            _scoreManager.AddNewScore(nameTextBox.Text, seconds);
            MessageBox.Show("Поздравляю вы нашли все яблоки!\nСписок лидеров:\n" + _scoreManager.GetPlayerScoreList());
        }
    }
}
