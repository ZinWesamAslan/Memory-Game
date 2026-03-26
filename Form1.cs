using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memory_Game
{
    public partial class Form1 : Form
    {
        public PictureBox[] pbMs;
        public Form1()
        {
            InitializeComponent();
            
            pbMs = new[] { pbM1, pbM2, pbM3, pbM4, pbM5,pbM6, pbM7, pbM8, pbM9, pbM10,pbM11, pbM12, pbM13, pbM14, pbM15,pbM16, pbM17, pbM18, pbM19, pbM20,pbM21, pbM22, pbM23, pbM24, pbM25 };
        }

        public string s;
        private void ChangeHomePictureBackColorWhenMouseClick(PictureBox p)
        {
            if (p.BackColor==Color.Black && Convert.ToInt32(p.Tag)== 1)
            {
                p.BackColor = MainPicBoxInTheSettings.BackColor;
                lblRemainingSquareValue.Text = (Convert.ToInt32(lblRemainingSquareValue.Text)-1).ToString();
            }
            else if(Convert.ToInt32(lblTimer.Text) <= 15 && Convert.ToInt32(p.Tag) != 1)
            {
                p.BackColor = Color.Red;
                timer1.Stop();
                MessageBox.Show("let's start again ...", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                DoRestart();
            }
            if(lblRemainingSquareValue.Text =="0")
            {
                
                lblCurrentScoreValue.Text = (Convert.ToInt32(lblCurrentScoreValue.Text) + 1).ToString();
                if(Convert.ToInt32(lblCurrentScoreValue.Text)> Convert.ToInt32(lblBestScoreValue.Text))
                {
                    lblBestScoreValue.Text = lblCurrentScoreValue.Text;
                }
                s = lblCurrentScoreValue.Text;
                DoRestart();
                lblCurrentScoreValue.Text = s;
            }
        }

        private void ChangeHomePictureBackColorWhenMouseEnter(PictureBox p)
        {
            if (p.BackColor == Color.Black)
            {
                p.BackColor = MainPicBoxInTheSettings.BackColor;
            }
            else
            {
                p.BackColor = Color.Black;
            }
        }

        private void ColoredPictureBox_MouseEnter(object sender, EventArgs e)
        {
            ChangeHomePictureBackColorWhenMouseEnter((PictureBox)sender);
        }

        private string CreatNewScore()
        {
            string s;
            s = lblNameValue.Text + "#//#" +  NuptodownTimer.Value + "#//#" + NuptodownTimeToTurnOffpbMs.Value + "#//#" + NuptodownNOfLSquare.Value + "#//#" + lblBestScoreValue.Text + Environment.NewLine;
            return s;
        }


        private void RecordTheScoreOnFile()
        {
            string filePath = @"C:\Users\USER\Documents\The developer ASLAN\14 C# level 1\Memory Game\Score.txt";
            string FileContent = File.ReadAllText(filePath);

            FileContent += CreatNewScore();
            File.WriteAllText(filePath, FileContent);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            RecordTheScoreOnFile();
            this.Close();
            
        }

        private void OpenLink(PictureBox PicBox)
        {
            System.Diagnostics.Process.Start(PicBox.Tag.ToString());
        }

        private void OpenLink(LinkLabel link)
        {
            System.Diagnostics.Process.Start(link.Tag.ToString());
        }

        private void ClickOpenLinkImageHome(object sender, EventArgs e)
        {
            OpenLink((PictureBox)sender);
        }

        private void linkLabelAslanMemoryGame_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenLink((LinkLabel)sender);
        }

        private void StartGame()
        {

            Random rnd = new Random();

            timer1.Start();
            int counter = 0;

            while(counter<=NuptodownNOfLSquare.Value-1)
            {
                int Index = rnd.Next(0, 25);
                if (pbMs[Index].BackColor != MainPicBoxInTheSettings.BackColor)
                {
                    pbMs[Index].BackColor = MainPicBoxInTheSettings.BackColor;
                    pbMs[Index].Tag = 1;
                    counter++;
                    
                }
            }
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = MemoryTab;
            btnRestart.Enabled = true;
            btnStop.Enabled = true;
            btnstart.Tag = 1;
            StartGame();
            btnstart.Enabled = false;
        }

        private void DisableAllpbMs()
        {
            foreach (PictureBox p in pbMs)
            {
                p.Enabled = false;
            }
        }

        private void EnableAllpbMs()
        {
            foreach (PictureBox p in pbMs)
            {
                p.Enabled = true;
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnStop.Tag) == 1)
            {
                timer1.Stop();
                btnStop.Tag = 0;
                btnStop.ImageIndex = 7;
                btnStop.Text = "";
                
                DisableAllpbMs();
            }
            else
            {
                ResetBtnStop();
            }
        }

        private void pbM_MouseClick(object sender, MouseEventArgs e)
        {
            ChangeHomePictureBackColorWhenMouseClick((PictureBox)sender);
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Counter = Convert.ToInt32(lblTimer.Text);
            if (Counter != 0)
            {
                lblTimer.Text = (Counter - 1).ToString();
                lblTimer.Refresh();
                if (Counter == NuptodownTimer.Value-NuptodownTimeToTurnOffpbMs.Value)
                {
                    TurnOffAllPbMs();
                }
            }
            else
            {
                timer1.Stop();
                MessageBox.Show("let's start again ...", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                lblCurrentScoreValue.Text = "0";
                DoRestart();
            }
        }

        private void TurnOffAllPbMs()
        {
            foreach (PictureBox pb in pbMs)
            {
                pb.BackColor = Color.Black;
            }
        }

        private void ResetAllPbM()
        {
            TurnOffAllPbMs();
            foreach(PictureBox pb in pbMs)
            {
                pb.Tag = 0;
            }

        }

        private void ResetBtnStop()
        {
            timer1.Start();
            btnStop.Tag = 1;
            btnStop.ImageIndex = 8;
            btnStop.Text = "Stop";
            EnableAllpbMs();
        }

        private void DoRestart()
        {
            lblTimer.Text = NuptodownTimer.Value.ToString();
            lblRemainingSquareValue.Text = NuptodownNOfLSquare.Value.ToString();
            lblCurrentScoreValue.Text = "0";
            ResetAllPbM();
            StartGame();

            ResetBtnStop();

        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            DoRestart();
            
        }

        private void SettingsTab_Click(object sender, EventArgs e)
        {

        }

        private void DoChangePicBoxBackColorFromSettings(PictureBox picBox)
        {
            MainPicBoxInTheSettings.BackColor = picBox.BackColor;
            pp0.BackColor = picBox.BackColor;
            pp1.BackColor = picBox.BackColor;
            pp2.BackColor = picBox.BackColor;
            pp3.BackColor = picBox.BackColor;
            lblGameName.ForeColor = picBox.BackColor;
            btnClose.FlatAppearance.MouseOverBackColor = picBox.BackColor;
            btnstart.FlatAppearance.MouseOverBackColor = picBox.BackColor;
            btnScore.FlatAppearance.MouseOverBackColor = picBox.BackColor;
            btnSettings.FlatAppearance.MouseOverBackColor = picBox.BackColor;
            btnStop.FlatAppearance.MouseOverBackColor = picBox.BackColor;
            btnRestart.FlatAppearance.MouseOverBackColor = picBox.BackColor;
            foreach(PictureBox p in pbMs)
            {
                if (Convert.ToInt32(p.Tag) == 1)
                {
                    p.BackColor = picBox.BackColor;
                }
            }
        }

        private void ChangePicBoxBackColorFromSettings(object sender, MouseEventArgs e)
        {
            DoChangePicBoxBackColorFromSettings((PictureBox)sender);


        }

        private void HomeTab_Enter(object sender, EventArgs e)
        {
            if (Convert.ToInt32(btnstart.Tag) == 1)
            {
                timer1.Stop();
                btnStop.Tag = 0;
                btnStop.ImageIndex = 7;
                btnStop.Text = "";

                DisableAllpbMs();
            } 
        }
        private void DoChangePersonalPicBoxFromSettings(PictureBox PicBox)
        {
            MainPicBoxForPersonalPicInSetting.Image = PicBox.Image;
            pbPersonalPicture.Image = PicBox.Image;
        }

        private void changePersonalPicBoxFromSettings(object sender, MouseEventArgs e)
        {
            DoChangePersonalPicBoxFromSettings((PictureBox)sender);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblNameValue.Text = tbName.Text;
            if(string.IsNullOrWhiteSpace(tbName.Text))
            {
                errorProvider1.SetError(tbName, "You should write a name.");
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            lblTimer.Text = NuptodownTimer.Value.ToString();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            lblRemainingSquareValue.Text = NuptodownNOfLSquare.Value.ToString();
        }

        private void SettingsTab_Enter(object sender, EventArgs e)
        {
            HomeTab_Enter(sender, e);
        }

        private void ScoreTab_Enter(object sender, EventArgs e)
        {
            HomeTab_Enter(sender, e);
            try
            {
                string filePath = @"C:\Users\USER\Documents\The developer ASLAN\14 C# level 1\Memory Game\Score.txt";
                string FileContent = File.ReadAllText(filePath);
                label4.Text = FileContent;
            }
            catch (Exception ex)
            {
                label4.Text = ex.Message;
            }


        }
    }
}
