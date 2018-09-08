using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Diagnostics;
using Microsoft.DirectX.AudioVideoPlayback;

namespace Suudoku
{
    public class Sudoku
    {
        int doo = -101;

        String selectedNumber = "0";

        Random r = new Random();

        int randomValue = 0;

        int[,] s = new int[9, 9];

        int[,] sh = new int[9, 9];

        int[,] shh = new int[9, 9];

        List<int> p = new List<int>();

        Form f = new Form();

        Panel ppp = new Panel();

        Panel pp = new Panel();

        Panel pppp = new Panel();

        Panel[,] sq = new Panel[9, 9];

        Graphics g = null;
        
        ComboBox[,] c = new ComboBox[9, 9];

        Image logo = null;

        Button newGame = new Button();

        Button newGame2 = new Button();

        Button checkSolution = new Button();

        Button clear = new Button();

        Button exit = new Button();

        Bitmap bm = null;

        bool hard = false;

        bool plays = true;

        bool won = false;

        private FormWindowState winState;
        private FormBorderStyle brdStyle;
        private bool topMost;
        private Rectangle bounds;

        private bool IsMaximized = false;

        Label gameDiff = new Label();

        Label duration = new Label();
        int elaspHour = 0;
        int elaspMin = 0;
        int elaspSec = 0;
        int elasp_Sec = 0;

        Timer playTimer = new Timer();

        Image bg = null;

        Button hint = new Button();

        int hintValue = -1;

        int hintPositionX = -1;

        int hintPositionY = -1;

        bool btnPress = false;

        Label htp = new Label();

        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Label lbl4 = new Label();

        Button v1 = new Button();
        Button v2 = new Button();
        Button v3 = new Button();
        Button v4 = new Button();

        Button b1 = new Button();
        Button b2 = new Button();
        Button b3 = new Button();
        Button b4 = new Button();

        Panel ppppp1 = new Panel();
        Panel ppppp2 = new Panel();
        Panel ppppp3 = new Panel();
        Panel ppppp4 = new Panel();

        Button howToPlay = new Button();

        Video myvideo1 = null;

        Video myvideo2 = null;

        Video myvideo3 = null;

        Video myvideo4 = null;

        Button playme1 = new Button();

        Button pauseme1 = new Button();

        Button stopme1 = new Button();

        Button playme2 = new Button();

        Button pauseme2 = new Button();

        Button stopme2 = new Button();

        Button playme3 = new Button();

        Button pauseme3 = new Button();

        Button stopme3 = new Button();

        Button playme4 = new Button();

        Button pauseme4 = new Button();

        Button stopme4 = new Button();

        Sudoku()
        {
            if (!IsMaximized)
            {
                IsMaximized = true;
                winState = f.WindowState;
                brdStyle = f.FormBorderStyle;
                topMost = f.TopMost;
                bounds = f.Bounds;
                f.WindowState = FormWindowState.Maximized;
                f.FormBorderStyle = FormBorderStyle.None;
                f.TopMost = false;
            }

            f.ControlBox = false;

            f.SetBounds(0, 0, SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height);
            
            pppp.SetBounds(0, 0, 640 + 1 + 100 + 80, 80 + 640 + 1);

            pppp.Location = new Point(
                f.ClientSize.Width / 2 - pppp.Size.Width / 2,
                f.ClientSize.Height / 2 - pppp.Size.Height / 2);
            pppp.Anchor = AnchorStyles.None;

            ppp.SetBounds(0, 0, 100, 640 + 80);

            ppp.Paint += new PaintEventHandler(DrawLogo);

            ppp.MouseEnter += new EventHandler(MouseLeaveLogic);

            pp.SetBounds(100, 0, 640, 640);

            logo = Image.FromFile(Environment.CurrentDirectory + "/logo.png");
            bm = new Bitmap(logo, new Size(100, 40));

            ppp.BackColor = Color.White;
            pp.BackColor = Color.White;
            pppp.BackColor = Color.White;

            newGame2.SetBounds(10, 50, 80, 25);
            newGame2.Text = "Tough >";
            newGame2.BackColor = Color.LightGray;
            newGame2.MouseHover += new EventHandler(ChangeBgColor);
            newGame2.MouseLeave += new EventHandler(OrigBgColor);

            ppp.Controls.Add(newGame2);

            newGame2.Click += new EventHandler(New_Game2);

            newGame.SetBounds(10, 80, 80, 25);
            newGame.Text = "Easy >";
            newGame.BackColor = Color.LightGray;
            newGame.MouseHover += new EventHandler(ChangeBgColor);
            newGame.MouseLeave += new EventHandler(OrigBgColor);

            ppp.Controls.Add(newGame);
            
            newGame.Click += new EventHandler(Easy_Game);

            checkSolution.SetBounds(10, 110, 80, 25);
            checkSolution.Text = "Submit";
            checkSolution.BackColor = Color.LightGray;
            checkSolution.MouseHover += new EventHandler(ChangeBgColor);
            checkSolution.MouseLeave += new EventHandler(OrigBgColor);

            ppp.Controls.Add(checkSolution);

            checkSolution.Click += new EventHandler(CheckSolution);

            hint.SetBounds(10, 140, 80, 25);
            hint.Text = "Hint";
            hint.BackColor = Color.LightGray;
            hint.MouseHover += new EventHandler(ChangeBgColor);
            hint.MouseLeave += new EventHandler(OrigBgColor);

            ppp.Controls.Add(hint);

            hint.Click += new EventHandler(GiveHint);

            clear.SetBounds(10, 170, 80, 25);
            clear.Text = "Clear";
            clear.BackColor = Color.LightGray;
            clear.MouseHover += new EventHandler(ChangeBgColor);
            clear.MouseLeave += new EventHandler(OrigBgColor);

            ppp.Controls.Add(clear);

            clear.Click += new EventHandler(Clear);

            howToPlay.SetBounds(10, 200, 80, 25);
            howToPlay.Text = "Videos";
            howToPlay.BackColor = Color.LightGray;
            howToPlay.MouseHover += new EventHandler(ChangeBgColor);
            howToPlay.MouseLeave += new EventHandler(OrigBgColor);

            ppp.Controls.Add(howToPlay);

            howToPlay.Click += new EventHandler(HowToPlay);

            exit.SetBounds(10, 230, 80, 25);
            exit.Text = "Quit";
            exit.BackColor = Color.LightGray;
            exit.MouseHover += new EventHandler(ChangeBgColor);
            exit.MouseLeave += new EventHandler(OrigBgColor);

            ppp.Controls.Add(exit);

            pppp.Controls.Add(pp);
            pppp.Controls.Add(ppp);

            exit.Click += new EventHandler(ExitGame);

            f.FormBorderStyle = FormBorderStyle.FixedDialog;
            f.MaximizeBox = false;

            f.StartPosition = FormStartPosition.CenterScreen;

            bg = Image.FromFile(Environment.CurrentDirectory + "//bamboo.jpg");

            Bitmap bmp = new Bitmap(bg, new Size(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height));

            f.BackgroundImage = bmp;

            ppp.BackColor = Color.YellowGreen;

            gameDiff.ForeColor = Color.Azure;

            gameDiff.Font = new Font("Helvetica", 12);

            gameDiff.BackColor = Color.Transparent;

            gameDiff.SetBounds(f.ClientSize.Width / 2, 0, 80, 20);

            duration.Font = new Font("Helvetica", 12);

            duration.ForeColor = Color.White;

            duration.BackColor = Color.Transparent;

            duration.SetBounds(f.ClientSize.Width / 2 + 100, 0, 500, 20);

            f.Controls.Add(duration);

            f.Controls.Add(gameDiff);

            f.Controls.Add(pppp);

            Label lbl = new Label();
            lbl.Text = "Please select a menu item";
            lbl.SetBounds(0, 0, 650, 50);
            lbl.Font = new Font("Tahoma", 20);
            lbl.ForeColor = Color.SeaGreen;

            pp.Controls.Add(lbl);

            Application.Run(f);
        }

        private void ChangeBgColor(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.SeaGreen;
        }

        private void OrigBgColor(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.LightGray;
        }

        private void GiveHint(object sender, EventArgs e)
        {
            if (myvideo1 != null)
            {
                myvideo1.Stop();
            }

            if (myvideo2 != null)
            {
                myvideo2.Stop();
            }

            if (myvideo3 != null)
            {
                myvideo3.Stop();
            }

            if (myvideo4 != null)
            {
                myvideo4.Stop();
            }

            if (!btnPress)
            {
                return;
            }

            int fill = 0;

            for(int i=0; i<9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(sh[i, j] == 0)
                    {
                        fill++;
                    }
                }
            }

            if(fill == 0)
            {
                return;
            }

            int mains = -1;
            int square = -1;

            while(true)
            {
                mains = r.Next(9);
                square = r.Next(9);
                if (sh[mains, square] != 0)
                {
                    continue;
                }
                else
                {
                    break;
                }
            }

            hintPositionY = mains;
            hintPositionX = square;

            hintValue = s[hintPositionY, hintPositionX];

            sh[hintPositionY, hintPositionX] = hintValue;

            DrawCanvas(null, null);

            DrawSheet(null, null);
        }

        private void HowToPlay(object sender, EventArgs e)
        {
            pppp.Controls.Remove(pp);

            if (myvideo1 != null)
            {
                myvideo1.Stop();
            }

            if (myvideo2 != null)
            {
                myvideo2.Stop();
            }

            if (myvideo3 != null)
            {
                myvideo3.Stop();
            }

            if (myvideo4 != null)
            {
                myvideo4.Stop();
            }

            htp.Text = "Videos";
            htp.Font = new Font("arial", 11);
            htp.SetBounds(f.ClientSize.Width / 2 - 130, 10 - 5, 260, 15);
            htp.ForeColor = Color.White;
            htp.BackColor = Color.Transparent;

            b1.Text = "Close";
            b2.Text = "Close";
            b3.Text = "Close";
            b4.Text = "Close";

            b1.SetBounds(f.ClientSize.Width / 2 - 80, f.ClientSize.Height - 15 - 5, 160, 19);
            b2.SetBounds(f.ClientSize.Width / 2 - 80, f.ClientSize.Height - 15 - 5, 160, 19);
            b3.SetBounds(f.ClientSize.Width / 2 - 80, f.ClientSize.Height - 15 - 5, 160, 19);
            b4.SetBounds(f.ClientSize.Width / 2 - 80, f.ClientSize.Height - 15 - 5, 160, 19);

            b1.Font = new Font("arial", 9);
            b2.Font = new Font("arial", 9);
            b3.Font = new Font("arial", 9);
            b4.Font = new Font("arial", 9);

            pppp.Location = new Point(
                f.ClientSize.Width / 2 - pppp.Size.Width / 2,
                f.ClientSize.Height / 2 - pppp.Size.Height / 2);

            pppp.SetBounds(0, 0, 640 + 1 + 100 + 80, 80 + 640 + 1);

            pppp.Location = new Point(
                f.ClientSize.Width / 2 - pppp.Size.Width / 2,
                f.ClientSize.Height / 2 - pppp.Size.Height / 2);
            pppp.Anchor = AnchorStyles.None;

            ppppp1.Dispose();
            ppppp1 = new Panel();
            myvideo1 = new Video("t.avi");
            myvideo1.Owner = ppppp1;
            ppppp1.BackColor = Color.Black;
            ppppp1.Size = new Size(300, 260);
            ppppp1.Location = new Point(100, 20);
            
            lbl1.Text = "How to Solve a Sudoku Game";
            lbl1.SetBounds(100, 0, 300, 20);
            pppp.Controls.Add(lbl1);
            myvideo1.Size = new Size(300, 260);

            pppp.Controls.Add(ppppp1);

            playme1.SetBounds(100, 280, 90, 20);
            playme1.Text = "Play";
            playme1.Click -= new EventHandler(PlayMe1);
            playme1.Click += new EventHandler(PlayMe1);

            pauseme1.SetBounds(191, 280, 90, 20);
            pauseme1.Text = "Pause";
            pauseme1.Click -= new EventHandler(PauseMe1);
            pauseme1.Click += new EventHandler(PauseMe1);

            stopme1.SetBounds(282, 280, 90, 20);
            stopme1.Text = "Stop";
            stopme1.Click -= new EventHandler(StopMe1);
            stopme1.Click += new EventHandler(StopMe1);

            v1.SetBounds(373, 280, 25, 20);
            v1.Text = "[]";
            v1.Click -= new EventHandler(FullScreen1);
            v1.Click += new EventHandler(FullScreen1);

            b1.Click -= new EventHandler(Escape1);
            b1.Click += new EventHandler(Escape1);

            pppp.Controls.Add(playme1);
            pppp.Controls.Add(pauseme1);
            pppp.Controls.Add(stopme1);
            pppp.Controls.Add(v1);

            ppppp2.Dispose();
            ppppp2 = new Panel();
            myvideo2 = new Video("t2.avi");
            myvideo2.Owner = ppppp2;
            ppppp2.BackColor = Color.Black;
            ppppp2.Size = new Size(320, 260);
            ppppp2.Location = new Point(417, 20);
            lbl2.Text = "Sudoku Tutorial 1 - Basic Strategies";
            lbl2.SetBounds(417, 0, 200, 20);
            pppp.Controls.Add(lbl2);
            myvideo2.Size = new Size(320, 280);

            pppp.Controls.Add(ppppp2);

            playme2.SetBounds(425, 280, 90, 20);
            playme2.Text = "Play";
            playme2.Click -= new EventHandler(PlayMe2);
            playme2.Click += new EventHandler(PlayMe2);

            pauseme2.SetBounds(516, 280, 90, 20);
            pauseme2.Text = "Pause";
            pauseme2.Click -= new EventHandler(PauseMe2);
            pauseme2.Click += new EventHandler(PauseMe2);

            stopme2.SetBounds(607, 280, 90, 20);
            stopme2.Text = "Stop";
            stopme2.Click -= new EventHandler(StopMe2);
            stopme2.Click += new EventHandler(StopMe2);

            v2.SetBounds(698, 280, 25, 20);
            v2.Text = "[]";
            v2.Click -= new EventHandler(FullScreen2);
            v2.Click += new EventHandler(FullScreen2);

            b2.Click -= new EventHandler(Escape2);
            b2.Click += new EventHandler(Escape2);

            pppp.Controls.Add(playme2);
            pppp.Controls.Add(pauseme2);
            pppp.Controls.Add(stopme2);
            pppp.Controls.Add(v2);

            ppppp3.Dispose();
            ppppp3 = new Panel();
            myvideo3 = new Video("t3.avi");
            myvideo3.Owner = ppppp3;
            ppppp3.BackColor = Color.Black;
            ppppp3.Size = new Size(300, 260);
            ppppp3.Location = new Point(100, 320);
            lbl3.Text = "Sudoku Rules for Beginners";
            lbl3.SetBounds(100, 300, 200, 20);
            pppp.Controls.Add(lbl3);
            myvideo3.Size = new Size(300, 260);

            pppp.Controls.Add(ppppp3);

            playme3.SetBounds(100, 580, 90, 20);
            playme3.Text = "Play";
            playme3.Click -= new EventHandler(PlayMe3);
            playme3.Click += new EventHandler(PlayMe3);

            pauseme3.SetBounds(191, 580, 90, 20);
            pauseme3.Text = "Pause";
            pauseme3.Click -= new EventHandler(PauseMe3);
            pauseme3.Click += new EventHandler(PauseMe3);

            stopme3.SetBounds(282, 580, 90, 20);
            stopme3.Text = "Stop";
            stopme3.Click -= new EventHandler(StopMe3);
            stopme3.Click += new EventHandler(StopMe3);

            v3.SetBounds(373, 580, 25, 20);
            v3.Text = "[]";
            v3.Click -= new EventHandler(FullScreen3);
            v3.Click += new EventHandler(FullScreen3);

            b3.Click -= new EventHandler(Escape3);
            b3.Click += new EventHandler(Escape3);

            pppp.Controls.Add(playme3);
            pppp.Controls.Add(pauseme3);
            pppp.Controls.Add(stopme3);
            pppp.Controls.Add(v3);

            ppppp4.Dispose();
            ppppp4 = new Panel();
            myvideo4 = new Video("t4.avi");
            myvideo4.Owner = ppppp4;
            ppppp4.BackColor = Color.Black;
            ppppp4.Size = new Size(320, 260);
            ppppp4.Location = new Point(417, 320);
            lbl4.Text = "Sudoku Solving Tip";
            lbl4.SetBounds(417, 300, 300, 20);
            pppp.Controls.Add(lbl4);
            myvideo4.Size = new Size(320, 260);

            pppp.Controls.Add(ppppp4);

            playme4.SetBounds(425, 580, 90, 20);
            playme4.Text = "Play";
            playme4.Click -= new EventHandler(PlayMe4);
            playme4.Click += new EventHandler(PlayMe4);

            pauseme4.SetBounds(516, 580, 90, 20);
            pauseme4.Text = "Pause";
            pauseme4.Click -= new EventHandler(PauseMe4);
            pauseme4.Click += new EventHandler(PauseMe4);

            stopme4.SetBounds(607, 580, 90, 20);
            stopme4.Text = "Stop";
            stopme4.Click -= new EventHandler(StopMe4);
            stopme4.Click += new EventHandler(StopMe4);

            v4.SetBounds(698, 580, 25, 20);
            v4.Text = "[]";
            v4.Click -= new EventHandler(FullScreen4);
            v4.Click += new EventHandler(FullScreen4);

            b4.Click -= new EventHandler(Escape4);
            b4.Click += new EventHandler(Escape4);

            pppp.Controls.Add(playme4);
            pppp.Controls.Add(pauseme4);
            pppp.Controls.Add(stopme4);
            pppp.Controls.Add(v4);

            pppp.BackColor = Color.SeaGreen;
        }

        private void FullScreen1(object sender, EventArgs e)
        {
            f.Controls.Clear();

            ppppp1.SetBounds(0, 0, 640 + 1 + 100 + 80, 80 + 640 + 1);
            ppppp1.Location = new Point(
                f.ClientSize.Width / 2 - pppp.Size.Width / 2,
                f.ClientSize.Height / 2 - pppp.Size.Height / 2);
            ppppp1.Size = new Size(640 + 1 + 100 + 80, 80 + 640 + 1);

            myvideo1.Stop();
            myvideo2.Stop();
            myvideo3.Stop();
            myvideo4.Stop();
            myvideo1.Play();

            ppppp1.BackColor = Color.SeaGreen;

            f.Controls.Add(ppppp1);
            f.Controls.Add(htp);
            f.Controls.Add(b1);
        }

        private void Escape1(object sender, EventArgs e)
        {
            f.Controls.Remove(ppppp1);
            f.Controls.Remove(htp);
            f.Controls.Remove(b1);
            f.Controls.Add(duration);
            f.Controls.Add(gameDiff);
            f.Controls.Add(pppp);
            HowToPlay(null, null);
        }

        private void FullScreen2(object sender, EventArgs e)
        {
            f.Controls.Clear();

            ppppp2.SetBounds(0, 0, 640 + 1 + 100 + 80, 80 + 640 + 1);
            ppppp2.Location = new Point(
                f.ClientSize.Width / 2 - pppp.Size.Width / 2,
                f.ClientSize.Height / 2 - pppp.Size.Height / 2);
            ppppp2.Size = new Size(640 + 1 + 100 + 80, 80 + 640 + 1);

            myvideo1.Stop();
            myvideo2.Stop();
            myvideo3.Stop();
            myvideo4.Stop();
            myvideo2.Play();

            ppppp2.BackColor = Color.SeaGreen;

            f.Controls.Add(ppppp2);
            f.Controls.Add(htp);
            f.Controls.Add(b2);
        }

        private void Escape2(object sender, EventArgs e)
        {
            f.Controls.Remove(ppppp2);
            f.Controls.Remove(htp);
            f.Controls.Remove(b2);
            f.Controls.Add(duration);
            f.Controls.Add(gameDiff);
            f.Controls.Add(pppp);
            HowToPlay(null, null);
        }

        private void FullScreen3(object sender, EventArgs e)
        {
            f.Controls.Clear();

            ppppp3.SetBounds(0, 0, 640 + 1 + 100 + 80, 80 + 640 + 1);
            ppppp3.Location = new Point(
                f.ClientSize.Width / 2 - pppp.Size.Width / 2,
                f.ClientSize.Height / 2 - pppp.Size.Height / 2);
            ppppp3.Size = new Size(640 + 1 + 100 + 80, 80 + 640 + 1);

            myvideo1.Stop();
            myvideo2.Stop();
            myvideo3.Stop();
            myvideo4.Stop();
            myvideo3.Play();

            ppppp3.BackColor = Color.SeaGreen;

            f.Controls.Add(ppppp3);
            f.Controls.Add(htp);
            f.Controls.Add(b3);
        }

        private void Escape3(object sender, EventArgs e)
        {
            f.Controls.Remove(ppppp3);
            f.Controls.Remove(htp);
            f.Controls.Remove(b3);
            f.Controls.Add(duration);
            f.Controls.Add(gameDiff);
            f.Controls.Add(pppp);
            HowToPlay(null, null);
        }

        private void FullScreen4(object sender, EventArgs e)
        {
            f.Controls.Clear();

            ppppp4.SetBounds(0, 0, 640 + 1 + 100 + 80, 80 + 640 + 1);
            ppppp4.Location = new Point(
                f.ClientSize.Width / 2 - pppp.Size.Width / 2,
                f.ClientSize.Height / 2 - pppp.Size.Height / 2);
            ppppp4.Size = new Size(640 + 1 + 100 + 80, 80 + 640 + 1);

            myvideo1.Stop();
            myvideo2.Stop();
            myvideo3.Stop();
            myvideo4.Stop();
            myvideo4.Play();

            ppppp4.BackColor = Color.SeaGreen;

            f.Controls.Add(ppppp4);
            f.Controls.Add(htp);
            f.Controls.Add(b4);
        }

        private void Escape4(object sender, EventArgs e)
        {
            f.Controls.Remove(ppppp4);
            f.Controls.Remove(htp);
            f.Controls.Remove(b4);
            f.Controls.Add(duration);
            f.Controls.Add(gameDiff);
            f.Controls.Add(pppp);
            HowToPlay(null, null);
        }

        private void PlayMe1(object sender, EventArgs e)
        {
            if(myvideo1 != null)
            {
                myvideo1.Play();
            }
        }

        private void PauseMe1(object sender, EventArgs e)
        {
            if (myvideo1 != null)
            {
                myvideo1.Pause();
            }
        }

        private void StopMe1(object sender, EventArgs e)
        {
            if (myvideo1 != null)
            {
                myvideo1.Stop();
            }
        }

        private void PlayMe2(object sender, EventArgs e)
        {
            if (myvideo2 != null)
            {
                myvideo2.Play();
            }
        }

        private void PauseMe2(object sender, EventArgs e)
        {
            if (myvideo2 != null)
            {
                myvideo2.Pause();
            }
        }

        private void StopMe2(object sender, EventArgs e)
        {
            if (myvideo2 != null)
            {
                myvideo2.Stop();
            }
        }

        private void PlayMe3(object sender, EventArgs e)
        {
            if (myvideo3 != null)
            {
                myvideo3.Play();
            }
        }

        private void PauseMe3(object sender, EventArgs e)
        {
            if (myvideo3 != null)
            {
                myvideo3.Pause();
            }
        }

        private void StopMe3(object sender, EventArgs e)
        {
            if (myvideo3 != null)
            {
                myvideo3.Stop();
            }
        }

        private void PlayMe4(object sender, EventArgs e)
        {
            if (myvideo4 != null)
            {
                myvideo4.Play();
            }
        }

        private void PauseMe4(object sender, EventArgs e)
        {
            if (myvideo4 != null)
            {
                myvideo4.Pause();
            }
        }

        private void StopMe4(object sender, EventArgs e)
        {
            if (myvideo4 != null)
            {
                myvideo4.Stop();
            }
        }

        private void MouseLogic(object sender, EventArgs e)
        {
            Panel a = (Panel)sender;
            if (a.Name != null)
            {
                int v = (int)Int64.Parse(a.Name);
                int v2 = (int)a.Tag;
                c[v, v2].DroppedDown = true;
            }
        }

        private void MouseLeaveLogic(object sender, EventArgs e)
        {
            Panel a = (Panel)sender;
            if (a.Name != null && !a.Name.Equals(""))
            {
                int v = (int)Int64.Parse(a.Name);
                int v2 = (int)a.Tag;
                int v_ = (int)Int64.Parse(a.AccessibleName);
                int v_2 = (int)Int64.Parse(a.AccessibleDescription);
                a.Refresh();
                a.Update();
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        sq[v, v2].BackColor = Color.LightSkyBlue;
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                    }
                    else
                    {
                        break;
                    }
                    --v2;
                }
                v2 = (int)a.Tag;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        sq[v, v2].BackColor = Color.LightSkyBlue;
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                    }
                    else
                    {
                        break;
                    }
                    ++v2;
                }
                v = (int)Int64.Parse(a.Name);
                v2 = (int)a.Tag;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        sq[v, v2].BackColor = Color.LightSkyBlue;
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                        --v2;
                        if (v2 == -1 ||
                            v2 == 2 ||
                            v2 == 5)
                        {
                            --v;
                            if (v == 2 ||
                                v == 5 ||
                                v == 8)
                            {
                                break;
                            }
                            if (v2 == -1)
                            {
                                v2 = 2;
                            }
                            else if (v2 == 2)
                            {
                                v2 = 5;
                            }
                            else if (v2 == 5)
                            {
                                v2 = 8;
                            }
                        }
                    }
                    else
                    {
                    }
                    if (v2 < 0)
                    {
                        break;
                    }
                    if (v < 0)
                    {
                        break;
                    }
                }
                v = (int)Int64.Parse(a.Name);
                v2 = (int)a.Tag;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        sq[v, v2].BackColor = Color.LightSkyBlue;
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                        ++v2;
                        if (v2 == 3 ||
                            v2 == 6 ||
                            v2 == 9)
                        {
                            ++v;
                            if (v2 == 3)
                            {
                                v2 = 0;
                            }
                            else if (v2 == 6)
                            {
                                v2 = 3;
                            }
                            else if (v2 == 9)
                            {
                                v2 = 6;
                            }
                            if (v == 3 ||
                                v == 6 ||
                                v == 9)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (v2 == 9)
                        {
                            break;
                        }
                    }
                    if (v2 < 0)
                    {
                        break;
                    }
                    if (v < 0)
                    {
                        break;
                    }
                }

                v = (int)Int64.Parse(a.Name);
                v2 = (int)a.Tag;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        sq[v, v2].BackColor = Color.LightSkyBlue;
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                        v2 -= 3;
                        if (v2 == -3 ||
                            v2 == -2 ||
                            v2 == -1)
                        {
                            v -= 3;
                            if (v == -3 ||
                                v == -2 ||
                                v == -1)
                            {
                                break;
                            }
                            if (v2 == -3)
                            {
                                v2 = 6;
                            }
                            else if (v2 == -2)
                            {
                                v2 = 7;
                            }
                            else if (v2 == -1)
                            {
                                v2 = 8;
                            }
                        }
                    }
                    else
                    {
                    }
                    if (v2 < 0)
                    {
                        break;
                    }
                    if (v < 0)
                    {
                        break;
                    }
                }
                v = (int)Int64.Parse(a.Name);
                v2 = (int)a.Tag;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        sq[v, v2].BackColor = Color.LightSkyBlue;
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                        v2 += 3;
                        if (v2 == 9 ||
                            v2 == 10 ||
                            v2 == 11)
                        {
                            v += 3;
                            if (v == 9 ||
                                v == 10 ||
                                v == 11)
                            {
                                break;
                            }
                            if (v2 == 9)
                            {
                                v2 = 0;
                            }
                            else if (v2 == 10)
                            {
                                v2 = 1;
                            }
                            else if (v2 == 11)
                            {
                                v2 = 2;
                            }
                        }
                    }
                    else
                    {
                        if (v2 == 9)
                        {
                            break;
                        }
                    }
                    if (v2 < 0)
                    {
                        break;
                    }
                    if (v < 0)
                    {
                        break;
                    }
                }
            }

            try
            {
                int val = 0;
                int valy = 0;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Graphics gg = sq[i, j].CreateGraphics();
                        if ((i == 0 || i == 1) && j == 2)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        if ((i == 1 || i == 2) && j == 2)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        val++;
                    }
                }

                val = 0;
                valy++;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Graphics gg = sq[i, j].CreateGraphics();
                        if ((i == 0 || i == 1) && j == 5)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        if ((i == 1 || i == 2) && j == 5)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        val++;
                    }
                }

                val = 0;
                valy++;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Graphics gg = sq[i, j].CreateGraphics();
                        if ((i == 0 || i == 1) && j == 8)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        if ((i == 1 || i == 2) && j == 8)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        val++;
                    }
                }

                val = 0;
                valy++;

                for (int i = 3; i < 6; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Graphics gg = sq[i, j].CreateGraphics();
                        if ((i == 3 || i == 4) && j == 2)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        if ((i == 4 || i == 5) && j == 2)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        val++;
                    }
                }

                val = 0;
                valy++;

                for (int i = 3; i < 6; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Graphics gg = sq[i, j].CreateGraphics();
                        if ((i == 3 || i == 4) && j == 5)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        if ((i == 4 || i == 5) && j == 5)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        val++;
                    }
                }

                val = 0;
                valy++;

                for (int i = 3; i < 6; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Graphics gg = sq[i, j].CreateGraphics();
                        if ((i == 3 || i == 4) && j == 8)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        if ((i == 4 || i == 5) && j == 8)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        val++;
                    }
                }

                val = 0;
                valy++;

                for (int i = 6; i < 9; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Graphics gg = sq[i, j].CreateGraphics();
                        if ((i == 6 || i == 7) && j == 2)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        if ((i == 7 || i == 8) && j == 2)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        val++;
                    }
                }

                val = 0;
                valy++;

                for (int i = 6; i < 9; i++)
                {
                    for (int j = 3; j < 6; j++)
                    {
                        Graphics gg = sq[i, j].CreateGraphics();
                        gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        if ((i == 6 || i == 7) && j == 5)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        if ((i == 7 || i == 8) && j == 5)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        val++;
                    }
                }

                val = 0;
                valy++;

                for (int i = 6; i < 9; i++)
                {
                    for (int j = 6; j < 9; j++)
                    {
                        Graphics gg = sq[i, j].CreateGraphics();
                        if ((i == 6 || i == 7) && j == 8)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        if ((i == 6 || i == 8) && j == 8)
                        {
                            gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                        }
                        val++;
                    }
                }
            } catch(Exception ex)
            {
                string aa = ex.Message;
            }
        }

        private void MouseEnterLogic(object sender, EventArgs e)
        {
            bool firstTime = true;
            Panel a = (Panel)sender;
            if (a.Name != null)
            {
                int v = (int)Int64.Parse(a.Name);
                int v2 = (int)a.Tag;
                int v_ = (int)Int64.Parse(a.AccessibleName);
                int v_2 = (int)Int64.Parse(a.AccessibleDescription);
                a.Refresh();
                a.Update();
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        if (firstTime)
                        {
                            sq[v, v2].BackColor = Color.SeaGreen;
                            firstTime = false;
                        }
                        else
                        {
                            sq[v, v2].BackColor = Color.LightBlue;
                        }
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if(v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                    }
                    else
                    {
                        break;
                    }
                    --v2;
                }
                v = (int)Int64.Parse(a.Name);
                v2 = (int)a.Tag;
                firstTime = true;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        if (firstTime)
                        {
                            sq[v, v2].BackColor = Color.SeaGreen;
                            firstTime = false;
                        }
                        else
                        {
                            sq[v, v2].BackColor = Color.LightBlue;
                        }
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                    }
                    else
                    {
                        break;
                    }
                    ++v2;
                }
                v = (int)Int64.Parse(a.Name);
                v2 = (int)a.Tag;
                firstTime = true;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        if (firstTime)
                        {
                            sq[v, v2].BackColor = Color.SeaGreen;
                            firstTime = false;
                        }
                        else
                        {
                            sq[v, v2].BackColor = Color.LightBlue;
                        }
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                        --v2;
                        if (v2 == -1 ||
                            v2 == 2 ||
                            v2 == 5)
                        {
                            --v;
                            if (v == 2 ||
                                v == 5 ||
                                v == 8)
                            {
                                break;
                            }
                            if (v2 == -1)
                            {
                                v2 = 2;
                            }
                            else if (v2 == 2)
                            {
                                v2 = 5;
                            }
                            else if (v2 == 5)
                            {
                                v2 = 8;
                            }
                        }
                    }
                    else
                    {
                    }
                    if (v2 < 0)
                    {
                        break;
                    }
                    if (v < 0)
                    {
                        break;
                    }
                }
                v = (int)Int64.Parse(a.Name);
                v2 = (int)a.Tag;
                firstTime = true;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        if (firstTime)
                        {
                            sq[v, v2].BackColor = Color.SeaGreen;
                            firstTime = false;
                        }
                        else
                        {
                            sq[v, v2].BackColor = Color.LightBlue;
                        }
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                        ++v2;
                        if (v2 == 3 ||
                            v2 == 6 ||
                            v2 == 9)
                        {
                            ++v;
                            if (v2 == 3)
                            {
                                v2 = 0;
                            }
                            else if (v2 == 6)
                            {
                                v2 = 3;
                            }
                            else if (v2 == 9)
                            {
                                v2 = 6;
                            }
                            if (v == 3 ||
                                v == 6 ||
                                v == 9)
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (v2 == 9)
                        {
                            break;
                        }
                    }
                    if (v2 < 0)
                    {
                        break;
                    }
                    if (v < 0)
                    {
                        break;
                    }
                }

                v = (int)Int64.Parse(a.Name);
                v2 = (int)a.Tag;
                firstTime = true;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        if (firstTime)
                        {
                            sq[v, v2].BackColor = Color.SeaGreen;
                            firstTime = false;
                        }
                        else
                        {
                            sq[v, v2].BackColor = Color.LightBlue;
                        }
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                        v2 -= 3;
                        if (v2 == -3 ||
                            v2 == -2 ||
                            v2 == -1)
                        {
                            v -= 3;
                            if (v == -3 ||
                                v == -2 ||
                                v == -1)
                            {
                                break;
                            }
                            if (v2 == -3)
                            {
                                v2 = 6;
                            }
                            else if (v2 == -2)
                            {
                                v2 = 7;
                            }
                            else if (v2 == -1)
                            {
                                v2 = 8;
                            }
                        }
                    }
                    else
                    {
                    }
                    if (v2 < 0)
                    {
                        break;
                    }
                    if (v < 0)
                    {
                        break;
                    }
                }
                v = (int)Int64.Parse(a.Name);
                v2 = (int)a.Tag;
                firstTime = true;
                while (true)
                {
                    if ((v2 >= 0 && v2 < 3) ||
                        (v2 >= 3 && v2 < 6) ||
                        (v2 >= 6 && v2 < 9))
                    {
                        if (firstTime)
                        {
                            sq[v, v2].BackColor = Color.SeaGreen;
                            firstTime = false;
                        }
                        else
                        {
                            sq[v, v2].BackColor = Color.LightBlue;
                        }
                        sq[v, v2].Refresh();
                        sq[v, v2].Update();
                        if (v2 < 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                        }
                        else if (v2 >= 6)
                        {
                            sq[v, v2].CreateGraphics().DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                        }
                        Draw_Sheet(v_, v_2, v, v2);
                        v2 += 3;
                        if (v2 == 9 ||
                            v2 == 10 ||
                            v2 == 11)
                        {
                            v += 3;
                            if (v == 9 ||
                                v == 10 ||
                                v == 11)
                            {
                                break;
                            }
                            if (v2 == 9)
                            {
                                v2 = 0;
                            }
                            else if (v2 == 10)
                            {
                                v2 = 1;
                            }
                            else if (v2 == 11)
                            {
                                v2 = 2;
                            }
                        }
                    }
                    else
                    {
                        if (v2 == 9)
                        {
                            break;
                        }
                    }
                    if (v2 < 0)
                    {
                        break;
                    }
                    if (v < 0)
                    {
                        break;
                    }
                }
            }

            int val = 0;
            int valy = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Graphics gg = sq[i, j].CreateGraphics();
                    if ((i == 0 || i == 1) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 1 || i == 2) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    Graphics gg = sq[i, j].CreateGraphics();
                    if ((i == 0 || i == 1) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 1 || i == 2) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    Graphics gg = sq[i, j].CreateGraphics();
                    if ((i == 0 || i == 1) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 1 || i == 2) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Graphics gg = sq[i, j].CreateGraphics();
                    if ((i == 3 || i == 4) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 4 || i == 5) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    Graphics gg = sq[i, j].CreateGraphics();
                    if ((i == 3 || i == 4) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 4 || i == 5) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    Graphics gg = sq[i, j].CreateGraphics();
                    if ((i == 3 || i == 4) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 4 || i == 5) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Graphics gg = sq[i, j].CreateGraphics();
                    if ((i == 6 || i == 7) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 7 || i == 8) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    Graphics gg = sq[i, j].CreateGraphics();
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                    if ((i == 6 || i == 7) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 7 || i == 8) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    Graphics gg = sq[i, j].CreateGraphics();
                    if ((i == 6 || i == 7) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 6 || i == 8) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }
        }
        
        private void ExitGame(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void New_Game2(object sender, EventArgs e)
        {
            if (myvideo1 != null)
            {
                myvideo1.Stop();
            }

            if (myvideo2 != null)
            {
                myvideo2.Stop();
            }

            if (myvideo3 != null)
            {
                myvideo3.Stop();
            }

            if (myvideo4 != null)
            {
                myvideo4.Stop();
            }
            pppp.Controls.Remove(ppppp1);
            pppp.Controls.Remove(ppppp2);
            pppp.Controls.Remove(ppppp3);
            pppp.Controls.Remove(ppppp4);
            pppp.Controls.Remove(playme1);
            pppp.Controls.Remove(playme2);
            pppp.Controls.Remove(playme3);
            pppp.Controls.Remove(playme4);
            pppp.Controls.Remove(pauseme1);
            pppp.Controls.Remove(pauseme2);
            pppp.Controls.Remove(pauseme3);
            pppp.Controls.Remove(pauseme4);
            pppp.Controls.Remove(stopme1);
            pppp.Controls.Remove(stopme2);
            pppp.Controls.Remove(stopme3);
            pppp.Controls.Remove(stopme4);
            pppp.Controls.Remove(lbl1);
            pppp.Controls.Remove(lbl2);
            pppp.Controls.Remove(lbl3);
            pppp.Controls.Remove(lbl4);
            pppp.Controls.Remove(v1);
            pppp.Controls.Remove(v2);
            pppp.Controls.Remove(v3);
            pppp.Controls.Remove(v4);
            hard = true;
            gameDiff.Text = "Tough";
            New_Game(null, null);
            btnPress = true;
        }

        public void Easy_Game(object sender, EventArgs e)
        {
            if (myvideo1 != null)
            {
                myvideo1.Stop();
            }

            if (myvideo2 != null)
            {
                myvideo2.Stop();
            }

            if (myvideo3 != null)
            {
                myvideo3.Stop();
            }

            if (myvideo4 != null)
            {
                myvideo4.Stop();
            }
            pppp.Controls.Remove(ppppp1);
            pppp.Controls.Remove(ppppp2);
            pppp.Controls.Remove(ppppp3);
            pppp.Controls.Remove(ppppp4);
            pppp.Controls.Remove(playme1);
            pppp.Controls.Remove(playme2);
            pppp.Controls.Remove(playme3);
            pppp.Controls.Remove(playme4);
            pppp.Controls.Remove(pauseme1);
            pppp.Controls.Remove(pauseme2);
            pppp.Controls.Remove(pauseme3);
            pppp.Controls.Remove(pauseme4);
            pppp.Controls.Remove(stopme1);
            pppp.Controls.Remove(stopme2);
            pppp.Controls.Remove(stopme3);
            pppp.Controls.Remove(stopme4);
            pppp.Controls.Remove(lbl1);
            pppp.Controls.Remove(lbl2);
            pppp.Controls.Remove(lbl3);
            pppp.Controls.Remove(lbl4);
            pppp.Controls.Remove(v1);
            pppp.Controls.Remove(v2);
            pppp.Controls.Remove(v3);
            pppp.Controls.Remove(v4);
            hard = false;
            gameDiff.Text = "Easy";
            New_Game(null, null);
            btnPress = true;
        }

        public void New_Game(object sender, EventArgs e)
        {
            while (doo > 11 || doo == -101)
            {
                if (!hard)
                {
                    MakeSudoku();
                }
                else
                {
                    MakeSudoku2();
                }
            }

            doo = -101;

            this.selectedNumber = "0";

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    shh[i, j] = 0;
                }
            }

            int amount = 70;

            if(hard)
            {
                amount = 50;
            }
            else if(!hard)
            {
                amount = 70;
            }

            for (int i = 0; i < amount; i++)
            {
                int sqh = r.Next(9);
                int sqv = r.Next(9);
                sh[sqh, sqv] = s[sqh, sqv];
                shh[sqh, sqv] = sh[sqh, sqv];
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    c[i, j] = new ComboBox();
                }
            }

            this.plays = true;

            pppp.Controls.Remove(pp);

            pp = new Panel();

            pp.SetBounds(100, 0, 810, 810);

            pp.BackColor = Color.LightSkyBlue;

            g = pp.CreateGraphics();

            pppp.Controls.Add(pp);

            pp.Refresh();

            pppp.Refresh();

            f.Refresh();

            f.Update();

            DrawCanvas(null, null);

            DrawSheet(null, null);

            playTimer.Interval = 1000;

            playTimer.Tick -= new EventHandler(TimePlay);
            
            playTimer.Tick += new EventHandler(TimePlay);

            playTimer.Start();

            elasp_Sec = 0;
        }

        private void TimePlay(object sender, EventArgs e)
        {
            elasp_Sec++;
            elaspMin = elasp_Sec / 60;
            elaspSec = elasp_Sec % 60;
            elaspHour = elaspMin / 60;
            elaspMin = elaspMin % 60;
            duration.Text = elaspHour + " hours " + elaspMin + " minutes and " + elaspSec + " seconds... ";
        }

        private void DrawLogo(object sender, PaintEventArgs e)
        {
            Graphics g = ppp.CreateGraphics();

            for (int i = 0; i < 1; i++)
            {
                g.DrawImage(bm, 0, i * 31);
            }
        }

        public void DrawCanvas(object sender, PaintEventArgs e)
        {
            pp.Controls.Clear();

            int val = 0;
            int valy = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sq[i, j] = new GradientPanelMouseOver();
                    sq[i, j].Name = i + "";
                    sq[i, j].Tag = j;
                    sq[i, j].AccessibleName = val + "";
                    sq[i, j].AccessibleDescription = valy + "";
                    sq[i, j].MouseEnter += new EventHandler(MouseEnterLogic);
                    sq[i, j].MouseLeave += new EventHandler(MouseLeaveLogic);
                    sq[i, j].Click += new EventHandler(MouseLogic);
                    sq[i, j].SetBounds(val * 80, valy * 80, 80, 80);
                    Graphics gg = sq[i, j].CreateGraphics();
                    pp.Controls.Add(sq[i, j]);
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                    if ((i == 0 || i == 1) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 1 || i == 2) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    sq[i, j] = new GradientPanelMouseOver();
                    sq[i, j].Name = i + "";
                    sq[i, j].Tag = j;
                    sq[i, j].AccessibleName = val + "";
                    sq[i, j].AccessibleDescription = valy + "";
                    sq[i, j].MouseEnter += new EventHandler(MouseEnterLogic);
                    sq[i, j].MouseLeave += new EventHandler(MouseLeaveLogic);
                    sq[i, j].Click += new EventHandler(MouseLogic);
                    sq[i, j].SetBounds(val * 80, valy * 80, 80, 80);
                    Graphics gg = sq[i, j].CreateGraphics();
                    pp.Controls.Add(sq[i, j]);
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                    if ((i == 0 || i == 1) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 1 || i == 2) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    sq[i, j] = new GradientPanelMouseOver();
                    sq[i, j].Name = i + "";
                    sq[i, j].Tag = j;
                    sq[i, j].AccessibleName = val + "";
                    sq[i, j].AccessibleDescription = valy + "";
                    sq[i, j].MouseEnter += new EventHandler(MouseEnterLogic);
                    sq[i, j].MouseLeave += new EventHandler(MouseLeaveLogic);
                    sq[i, j].Click += new EventHandler(MouseLogic);
                    sq[i, j].SetBounds(val * 80, valy * 80, 80, 80);
                    Graphics gg = sq[i, j].CreateGraphics();
                    pp.Controls.Add(sq[i, j]);
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                    if ((i == 0 || i == 1) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 1 || i == 2) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sq[i, j] = new GradientPanelMouseOver();
                    sq[i, j].Name = i + "";
                    sq[i, j].Tag = j;
                    sq[i, j].AccessibleName = val + "";
                    sq[i, j].AccessibleDescription = valy + "";
                    sq[i, j].MouseEnter += new EventHandler(MouseEnterLogic);
                    sq[i, j].MouseLeave += new EventHandler(MouseLeaveLogic);
                    sq[i, j].Click += new EventHandler(MouseLogic);
                    sq[i, j].SetBounds(val * 80, valy * 80, 80, 80);
                    Graphics gg = sq[i, j].CreateGraphics();
                    pp.Controls.Add(sq[i, j]);
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                    if ((i == 3 || i == 4) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 4 || i == 5) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    sq[i, j] = new GradientPanelMouseOver();
                    sq[i, j].Name = i + "";
                    sq[i, j].Tag = j;
                    sq[i, j].AccessibleName = val + "";
                    sq[i, j].AccessibleDescription = valy + "";
                    sq[i, j].MouseEnter += new EventHandler(MouseEnterLogic);
                    sq[i, j].MouseLeave += new EventHandler(MouseLeaveLogic);
                    sq[i, j].Click += new EventHandler(MouseLogic);
                    sq[i, j].SetBounds(val * 80, valy * 80, 80, 80);
                    Graphics gg = sq[i, j].CreateGraphics();
                    pp.Controls.Add(sq[i, j]);
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                    if ((i == 3 || i == 4) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 4 || i == 5) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    sq[i, j] = new GradientPanelMouseOver();
                    sq[i, j].Name = i + "";
                    sq[i, j].Tag = j;
                    sq[i, j].AccessibleName = val + "";
                    sq[i, j].AccessibleDescription = valy + "";
                    sq[i, j].MouseEnter += new EventHandler(MouseEnterLogic);
                    sq[i, j].MouseLeave += new EventHandler(MouseLeaveLogic);
                    sq[i, j].Click += new EventHandler(MouseLogic);
                    sq[i, j].SetBounds(val * 80, valy * 80, 80, 80);
                    Graphics gg = sq[i, j].CreateGraphics();
                    pp.Controls.Add(sq[i, j]);
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 78));
                    if ((i == 3 || i == 4) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 4 || i == 5) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sq[i, j] = new GradientPanelMouseOver();
                    sq[i, j].Name = i + "";
                    sq[i, j].Tag = j;
                    sq[i, j].AccessibleName = val + "";
                    sq[i, j].AccessibleDescription = valy + "";
                    sq[i, j].MouseEnter += new EventHandler(MouseEnterLogic);
                    sq[i, j].MouseLeave += new EventHandler(MouseLeaveLogic);
                    sq[i, j].Click += new EventHandler(MouseLogic);
                    sq[i, j].SetBounds(val * 80, valy * 80, 80, 80);
                    Graphics gg = sq[i, j].CreateGraphics();
                    pp.Controls.Add(sq[i, j]);
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                    if ((i == 6 || i == 7) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 7 || i == 8) && j == 2)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    sq[i, j] = new GradientPanelMouseOver();
                    sq[i, j].Name = i + "";
                    sq[i, j].Tag = j;
                    sq[i, j].AccessibleName = val + "";
                    sq[i, j].AccessibleDescription = valy + "";
                    sq[i, j].MouseEnter += new EventHandler(MouseEnterLogic);
                    sq[i, j].MouseLeave += new EventHandler(MouseLeaveLogic);
                    sq[i, j].Click += new EventHandler(MouseLogic);
                    sq[i, j].SetBounds(val * 80, valy * 80, 80, 80);
                    Graphics gg = sq[i, j].CreateGraphics();
                    pp.Controls.Add(sq[i, j]);
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                    if ((i == 6 || i == 7) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 7 || i == 8) && j == 5)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    sq[i, j] = new GradientPanelMouseOver();
                    sq[i, j].Name = i + "";
                    sq[i, j].Tag = j;
                    sq[i, j].AccessibleName = val + "";
                    sq[i, j].AccessibleDescription = valy + "";
                    sq[i, j].MouseEnter += new EventHandler(MouseEnterLogic);
                    sq[i, j].MouseLeave += new EventHandler(MouseLeaveLogic);
                    sq[i, j].Click += new EventHandler(MouseLogic);
                    sq[i, j].SetBounds(val * 80, valy * 80, 80, 80);
                    Graphics gg = sq[i, j].CreateGraphics();
                    pp.Controls.Add(sq[i, j]);
                    gg.DrawRectangle(new Pen(Color.Gray), new Rectangle(1, 1, 79, 79));
                    if ((i == 6 || i == 7) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    if ((i == 6 || i == 8) && j == 8)
                    {
                        gg.DrawLine(new Pen(Color.Gray), 79, 1, 79, 79);
                    }
                    val++;
                }
            }
        }

        private void Draw_Sheet(int val, int valy, int i, int j)
        {
            Graphics ggg = sq[i, j].CreateGraphics();
            
            if (shh[i, j] == 0 && sh[i, j] != 0)
            {
                if (sh[i, j] == Int64.Parse(selectedNumber))
                {
                    ggg.DrawString(sh[i, j] + "", new Font("helvetica", 32, FontStyle.Bold), new SolidBrush(Color.Green), 25, 24, new StringFormat());
                }
                else
                {
                    ggg.DrawString(sh[i, j] + "", new Font("helvetica", 32, FontStyle.Bold), new SolidBrush(Color.Green), 25, 24, new StringFormat());
                }
                sq[i, j].Controls.Remove(c[i, j]);
                c[i, j] = new ComboBox();
                c[i, j].SetBounds(23, 0, 45, 20);
                c[i, j].Font = new Font(c[i, j].Font.Name, 20);
                c[i, j].BackColor = Color.SeaGreen;
                c[i, j].Visible = false;
                sq[i, j].Controls.Add(c[i, j]);
                c[i, j].SelectedIndexChanged += new EventHandler(CB);
                c[i, j].MaxDropDownItems = 10;
                c[i, j].MaxLength = 0;
                c[i, j].Items.Add(" " + "            (" + i + "," + j + ")");
                for (int k = 1; k < 10; k++)
                {
                    c[i, j].Items.Add(k + "            (" + i + "," + j + ")");
                }
            }
            else
            {
                if (sh[i, j] != 0)
                {
                    if (sh[i, j] == Int64.Parse(selectedNumber))
                    {
                        ggg.DrawString(sh[i, j] + "", new Font("helvetica", 32, FontStyle.Bold), new SolidBrush(Color.Green), 25, 24, new StringFormat());
                    }
                    else
                    {
                        ggg.DrawString(sh[i, j] + "", new Font("helvetica", 32, FontStyle.Bold), new SolidBrush(Color.White), 25, 24, new StringFormat());
                    }
                }
                else
                {
                    sq[i, j].Controls.Remove(c[i, j]);
                    c[i, j] = new ComboBox();
                    c[i, j].SetBounds(23, 0, 45, 20);
                    c[i, j].Font = new Font(c[i, j].Font.Name, 20);
                    c[i, j].BackColor = Color.SeaGreen;
                    c[i, j].Visible = false;
                    sq[i, j].Controls.Add(c[i, j]);
                    c[i, j].SelectedIndexChanged += new EventHandler(CB);
                    c[i, j].MaxDropDownItems = 10;
                    c[i, j].MaxLength = 0;
                    c[i, j].Items.Add(" " + "            (" + i + "," + j + ")");
                    for (int k = 1; k < 10; k++)
                    {
                        c[i, j].Items.Add(k + "            (" + i + "," + j + ")");
                    }
                }
            }
        }

        public void DrawSheet(object sender, PaintEventArgs e)
        {
            int val = 0;
            int valy = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Draw_Sheet(val, valy, i, j);
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    Draw_Sheet(val, valy, i, j);
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    Draw_Sheet(val, valy, i, j);
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Draw_Sheet(val, valy, i, j);
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    Draw_Sheet(val, valy, i, j);
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    Draw_Sheet(val, valy, i, j);
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Draw_Sheet(val, valy, i, j);
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    Draw_Sheet(val, valy, i, j);
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    Draw_Sheet(val, valy, i, j);
                    val++;
                }
            }
        }

        public void DrawSudoku(object sender, EventArgs e)
        {
            g = pp.CreateGraphics();

            int val = 0;
            int valy = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (s[i, j] != 0)
                    {
                        g.DrawString(s[i, j] + "", new Font("helvetica", 22,FontStyle.Bold), new SolidBrush(Color.White), val * 90 + 55, valy * 90 + 54, new StringFormat());
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (s[i, j] != 0)
                    {
                        g.DrawString(s[i, j] + "", new Font("helvetica", 22, FontStyle.Bold), new SolidBrush(Color.White), val * 90 + 55, valy * 90 + 54, new StringFormat());
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    if (s[i, j] != 0)
                    {
                        g.DrawString(s[i, j] + "", new Font("helvetica", 22, FontStyle.Bold), new SolidBrush(Color.White), val * 90 + 55, valy * 90 + 54, new StringFormat());
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (s[i, j] != 0)
                    {
                        g.DrawString(s[i, j] + "", new Font("helvetica", 22, FontStyle.Bold), new SolidBrush(Color.White), val * 90 + 55, valy * 90 + 54, new StringFormat());
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (s[i, j] != 0)
                    {
                        g.DrawString(s[i, j] + "", new Font("helvetica", 22, FontStyle.Bold), new SolidBrush(Color.White), val * 90 + 55, valy * 90 + 54, new StringFormat());
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 3; i < 6; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    if (s[i, j] != 0)
                    {
                        g.DrawString(s[i, j] + "", new Font("helvetica", 22, FontStyle.Bold), new SolidBrush(Color.White), val * 90 + 55, valy * 90 + 54, new StringFormat());
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (s[i, j] != 0)
                    {
                        g.DrawString(s[i, j] + "", new Font("helvetica", 22, FontStyle.Bold), new SolidBrush(Color.White), val * 90 + 55, valy * 90 + 54, new StringFormat());
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 3; j < 6; j++)
                {
                    if (s[i, j] != 0)
                    {
                        g.DrawString(s[i, j] + "", new Font("helvetica", 22, FontStyle.Bold), new SolidBrush(Color.White), val * 90 + 55, valy * 90 + 54, new StringFormat());
                    }
                    val++;
                }
            }

            val = 0;
            valy++;

            for (int i = 6; i < 9; i++)
            {
                for (int j = 6; j < 9; j++)
                {
                    if (s[i, j] != 0)
                    {
                        g.DrawString(s[i, j] + "", new Font("helvetica", 22, FontStyle.Bold), new SolidBrush(Color.White), val * 90 + 55, valy * 90 + 54, new StringFormat());
                    }
                    val++;
                }
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            if (myvideo1 != null)
            {
                myvideo1.Stop();
            }

            if (myvideo2 != null)
            {
                myvideo2.Stop();
            }

            if (myvideo3 != null)
            {
                myvideo3.Stop();
            }

            if (myvideo4 != null)
            {
                myvideo4.Stop();
            }

            if (!btnPress)
            {
                return;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sh[i, j] = shh[i, j];
                }
            }

            this.selectedNumber = "0";

            this.plays = true;

            DrawCanvas(null, null);

            DrawSheet(null, null);
        }

        public void CB(object sender, EventArgs e)
        {
            ComboBox s = sender as ComboBox;
            this.selectedNumber = s.SelectedItem.ToString().Substring(0, s.SelectedItem.ToString().IndexOf("("));
            g.FillRectangle(new SolidBrush(Color.LightSkyBlue), new Rectangle(s.Bounds.X + 24, s.Bounds.Y + 25, 60, 60));
            g.DrawString(this.selectedNumber, new Font("arial", 32), new SolidBrush(Color.SeaGreen), new RectangleF(new PointF(s.Bounds.X + 24, s.Bounds.Y+25), new SizeF(80, 80)));

            if(this.selectedNumber.Substring(0, 1).Equals(" "))
            {
                this.selectedNumber = "0";
            }

            String ii = s.SelectedItem.ToString().Substring(s.SelectedItem.ToString().IndexOf("(") + 1, s.SelectedItem.ToString().IndexOf(",") - s.SelectedItem.ToString().IndexOf("(") - 1);
            String jj = s.SelectedItem.ToString().Substring(s.SelectedItem.ToString().IndexOf(",") + 1, s.SelectedItem.ToString().IndexOf(")") - s.SelectedItem.ToString().IndexOf(",") - 1);

            int iii = (int) Int64.Parse(ii);
            int jjj = (int) Int64.Parse(jj);

            try
            {
                sh[iii, jjj] = (int)Int64.Parse(s.SelectedItem.ToString().Substring(0, s.SelectedItem.ToString().IndexOf(" ")));
            } catch(Exception ex)
            {
                string a = ex.Message;
                sh[iii, jjj] = 0;
            }

            pp.Refresh();

            pp.Update();

            DrawCanvas(null, null);

            DrawSheet(null, null);
        }

        private void CheckSolution(object sender, EventArgs e)
        {
            if (myvideo1 != null)
            {
                myvideo1.Stop();
            }

            if (myvideo2 != null)
            {
                myvideo2.Stop();
            }

            if (myvideo3 != null)
            {
                myvideo3.Stop();
            }

            if (myvideo4 != null)
            {
                myvideo4.Stop();
            }

            if (!btnPress)
            {
                return;
            }

            if(!this.plays)
            {
                return;
            }

            DrawCanvas(null, null);

            DrawSheet(null, null);

            this.plays = true;

            int fill = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (sh[i, j] == 0)
                    {
                        fill++;
                    }
                }
            }

            won = false;
            int woncheck = 0;

            if (fill != 81)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (sh[i, j] == this.s[i, j])
                        {
                            woncheck++;
                        }
                    }
                }

                DrawSudoku(null, null);

                if (woncheck == 81)
                {
                    won = true;
                }
                else
                {
                    won = false;
                }

                if (won)
                {
                    playTimer.Stop();
                    duration.Text += "Done";
                    MessageBox.Show("You won!  You completed the sudoku");
                }
                else
                {
                    MessageBox.Show("You didn't win!  Please retry or start a new game");
                }
            }
        }

        public void MakeSudoku()
        {
            doo = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    s[i, j] = 0;
                    sh[i, j] = 0;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                p.Clear();
                for (int k = 1; k < 10; k++)
                {
                    p.Add(k);
                }

                if (i == 0)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        randomValue = p[r.Next(p.Count)];
                        s[i, j] = randomValue;
                        p.Remove(randomValue);
                    }
                }

                if (i == 1)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j >= 0 && j <= 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 0] != s[i, j] && s[0, 1] != s[i, j] && s[0, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j >= 3 && j <= 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 3] != s[i, j] && s[0, 4] != s[i, j] && s[0, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j >= 6 && j <= 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 6] != s[i, j] && s[0, 7] != s[i, j] && s[0, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 2)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j >= 0 && j <= 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 0] != s[i, j] && s[0, 1] != s[i, j] && s[0, 2] != s[i, j] &&
                                    s[1, 0] != s[i, j] && s[1, 1] != s[i, j] && s[1, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j >= 3 && j <= 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 3] != s[i, j] && s[0, 4] != s[i, j] && s[0, 5] != s[i, j] &&
                                    s[1, 3] != s[i, j] && s[1, 4] != s[i, j] && s[1, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j >= 6 && j <= 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 6] != s[i, j] && s[0, 7] != s[i, j] && s[0, 8] != s[i, j] &&
                                    s[1, 6] != s[i, j] && s[1, 7] != s[i, j] && s[1, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 3)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0 || j == 3 || j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 0] != s[i, j] && s[0, 3] != s[i, j] && s[0, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1 || j == 4 || j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 1] != s[i, j] && s[0, 4] != s[i, j] && s[0, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2 || j == 5 || j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 2] != s[i, j] && s[0, 5] != s[i, j] && s[0, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 4)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                        }

                        if (j == 3)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 4)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 5)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 1] != s[i, j] && s[4, 2] != s[i, j] &&
                                    s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 1] != s[i, j] && s[4, 2] != s[i, j] &&
                                    s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 1] != s[i, j] && s[4, 2] != s[i, j] &&
                                    s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 3)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[4, 3] != s[i, j] && s[4, 4] != s[i, j] && s[4, 5] != s[i, j] &&
                                    s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 4)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[4, 3] != s[i, j] && s[4, 4] != s[i, j] && s[4, 5] != s[i, j] &&
                                    s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[4, 3] != s[i, j] && s[4, 4] != s[i, j] && s[4, 5] != s[i, j] &&
                                    s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[4, 6] != s[i, j] && s[4, 7] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[4, 6] != s[i, j] && s[4, 7] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[4, 6] != s[i, j] && s[4, 7] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 6)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0 || j == 3 || j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 0] != s[i, j] && s[0, 3] != s[i, j] && s[0, 6] != s[i, j] &&
                                    s[3, 0] != s[i, j] && s[3, 3] != s[i, j] && s[3, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1 || j == 4 || j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 1] != s[i, j] && s[0, 4] != s[i, j] && s[0, 7] != s[i, j] &&
                                    s[3, 1] != s[i, j] && s[3, 4] != s[i, j] && s[3, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2 || j == 5 || j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 2] != s[i, j] && s[0, 5] != s[i, j] && s[0, 8] != s[i, j] &&
                                    s[3, 2] != s[i, j] && s[3, 5] != s[i, j] && s[3, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 7)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 3] != s[i, j] && s[4, 6] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j] &&
                                    s[4, 1] != s[i, j] && s[4, 4] != s[i, j] && s[4, 7] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j] &&
                                    s[4, 2] != s[i, j] && s[4, 5] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 3)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 3] != s[i, j] && s[4, 6] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 4)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j] &&
                                    s[4, 1] != s[i, j] && s[4, 4] != s[i, j] && s[4, 7] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j] &&
                                    s[4, 2] != s[i, j] && s[4, 5] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 3] != s[i, j] && s[4, 6] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j] &&
                                    s[4, 1] != s[i, j] && s[4, 4] != s[i, j] && s[4, 7] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j] &&
                                    s[4, 2] != s[i, j] && s[4, 5] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 8)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j] &&
                                    s[5, 0] != s[i, j] && s[5, 3] != s[i, j] && s[5, 6] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j] &&
                                    s[7, 0] != s[i, j] && s[7, 1] != s[i, j] && s[7, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j] &&
                                    s[5, 1] != s[i, j] && s[5, 4] != s[i, j] && s[5, 7] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j] &&
                                    s[7, 0] != s[i, j] && s[7, 1] != s[i, j] && s[7, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j] &&
                                    s[5, 2] != s[i, j] && s[5, 5] != s[i, j] && s[5, 8] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j] &&
                                    s[7, 0] != s[i, j] && s[7, 1] != s[i, j] && s[7, 2] != s[i, j])
                                {

                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 3)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j] &&
                                    s[5, 0] != s[i, j] && s[5, 3] != s[i, j] && s[5, 6] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j] &&
                                    s[7, 3] != s[i, j] && s[7, 4] != s[i, j] && s[7, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 4)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j] &&
                                    s[5, 1] != s[i, j] && s[5, 4] != s[i, j] && s[5, 7] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j] &&
                                    s[7, 3] != s[i, j] && s[7, 4] != s[i, j] && s[7, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j] &&
                                    s[5, 2] != s[i, j] && s[5, 5] != s[i, j] && s[5, 8] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j] &&
                                    s[7, 3] != s[i, j] && s[7, 4] != s[i, j] && s[7, 5] != s[i, j])
                                {

                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j] &&
                                    s[5, 0] != s[i, j] && s[5, 3] != s[i, j] && s[5, 6] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j] &&
                                    s[7, 6] != s[i, j] && s[7, 7] != s[i, j] && s[7, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j] &&
                                    s[5, 1] != s[i, j] && s[5, 4] != s[i, j] && s[5, 7] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j] &&
                                    s[7, 6] != s[i, j] && s[7, 7] != s[i, j] && s[7, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j] &&
                                    s[5, 2] != s[i, j] && s[5, 5] != s[i, j] && s[5, 8] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j] &&
                                    s[7, 6] != s[i, j] && s[7, 7] != s[i, j] && s[7, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }
            }
        }

        public void MakeSudoku2()
        {
            doo = 0;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    s[i, j] = 0;
                    sh[i, j] = 0;
                }
            }

            for (int i = 0; i < 9; i++)
            {
                p.Clear();
                for (int k = 1; k < 10; k++)
                {
                    p.Add(k);
                }

                if (i == 0)
                {
                    p.Clear();

                    p.Add(1);
                    p.Add(2);
                    p.Add(3);

                    for (int j = 0; j < 3; j++)
                    {
                        randomValue = p[r.Next(p.Count)];
                        s[i, j] = randomValue;
                        p.Remove(randomValue);
                    }

                    p.Clear();

                    p.Add(4);
                    p.Add(5);
                    p.Add(6);

                    p.Add(7);
                    p.Add(8);
                    p.Add(9);

                    for (int j = 3; j < 9; j++)
                    {
                        randomValue = p[r.Next(p.Count)];
                        s[i, j] = randomValue;
                        p.Remove(randomValue);
                    }
                }

                if (i == 1)
                {
                    p.Clear();

                    p.Add(4);
                    p.Add(5);
                    p.Add(6);

                    for (int j = 3; j < 6; j++)
                    {
                        randomValue = p[r.Next(p.Count)];
                        s[i, j] = randomValue;
                        p.Remove(randomValue);
                    }

                    p.Clear();

                    p.Add(1);
                    p.Add(2);
                    p.Add(3);

                    p.Add(7);
                    p.Add(8);
                    p.Add(9);

                    for (int j = 0; (j >= 0 && j <= 2); j++)
                    {
                        if (j >= 0 && j <= 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 0] != s[i, j] && s[0, 1] != s[i, j] && s[0, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }

                    for (int j = 6; (j >= 6 && j <= 8); j++)
                    {
                        if (j >= 6 && j <= 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 6] != s[i, j] && s[0, 7] != s[i, j] && s[0, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 2)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j >= 0 && j <= 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 0] != s[i, j] && s[0, 1] != s[i, j] && s[0, 2] != s[i, j] &&
                                    s[1, 0] != s[i, j] && s[1, 1] != s[i, j] && s[1, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j >= 3 && j <= 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 3] != s[i, j] && s[0, 4] != s[i, j] && s[0, 5] != s[i, j] &&
                                    s[1, 3] != s[i, j] && s[1, 4] != s[i, j] && s[1, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j >= 6 && j <= 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 6] != s[i, j] && s[0, 7] != s[i, j] && s[0, 8] != s[i, j] &&
                                    s[1, 6] != s[i, j] && s[1, 7] != s[i, j] && s[1, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 3)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0 || j == 3 || j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 0] != s[i, j] && s[0, 3] != s[i, j] && s[0, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1 || j == 4 || j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 1] != s[i, j] && s[0, 4] != s[i, j] && s[0, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2 || j == 5 || j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 2] != s[i, j] && s[0, 5] != s[i, j] && s[0, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 4)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                        }

                        if (j == 3)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 4)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 5)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 1] != s[i, j] && s[4, 2] != s[i, j] &&
                                    s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 1] != s[i, j] && s[4, 2] != s[i, j] &&
                                    s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 0] != s[i, j] && s[3, 1] != s[i, j] && s[3, 2] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 1] != s[i, j] && s[4, 2] != s[i, j] &&
                                    s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 3)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[4, 3] != s[i, j] && s[4, 4] != s[i, j] && s[4, 5] != s[i, j] &&
                                    s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 4)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[4, 3] != s[i, j] && s[4, 4] != s[i, j] && s[4, 5] != s[i, j] &&
                                    s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 3] != s[i, j] && s[3, 4] != s[i, j] && s[3, 5] != s[i, j] &&
                                    s[4, 3] != s[i, j] && s[4, 4] != s[i, j] && s[4, 5] != s[i, j] &&
                                    s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[4, 6] != s[i, j] && s[4, 7] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[4, 6] != s[i, j] && s[4, 7] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[3, 6] != s[i, j] && s[3, 7] != s[i, j] && s[3, 8] != s[i, j] &&
                                    s[4, 6] != s[i, j] && s[4, 7] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 6)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0 || j == 3 || j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 0] != s[i, j] && s[0, 3] != s[i, j] && s[0, 6] != s[i, j] &&
                                    s[3, 0] != s[i, j] && s[3, 3] != s[i, j] && s[3, 6] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1 || j == 4 || j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 1] != s[i, j] && s[0, 4] != s[i, j] && s[0, 7] != s[i, j] &&
                                    s[3, 1] != s[i, j] && s[3, 4] != s[i, j] && s[3, 7] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2 || j == 5 || j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[0, 2] != s[i, j] && s[0, 5] != s[i, j] && s[0, 8] != s[i, j] &&
                                    s[3, 2] != s[i, j] && s[3, 5] != s[i, j] && s[3, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 7)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 3] != s[i, j] && s[4, 6] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j] &&
                                    s[4, 1] != s[i, j] && s[4, 4] != s[i, j] && s[4, 7] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j] &&
                                    s[4, 2] != s[i, j] && s[4, 5] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 3)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 3] != s[i, j] && s[4, 6] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 4)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j] &&
                                    s[4, 1] != s[i, j] && s[4, 4] != s[i, j] && s[4, 7] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j] &&
                                    s[4, 2] != s[i, j] && s[4, 5] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 0] != s[i, j] && s[1, 3] != s[i, j] && s[1, 6] != s[i, j] &&
                                    s[4, 0] != s[i, j] && s[4, 3] != s[i, j] && s[4, 6] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 1] != s[i, j] && s[1, 4] != s[i, j] && s[1, 7] != s[i, j] &&
                                    s[4, 1] != s[i, j] && s[4, 4] != s[i, j] && s[4, 7] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[1, 2] != s[i, j] && s[1, 5] != s[i, j] && s[1, 8] != s[i, j] &&
                                    s[4, 2] != s[i, j] && s[4, 5] != s[i, j] && s[4, 8] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }

                if (i == 8)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (j == 0)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j] &&
                                    s[5, 0] != s[i, j] && s[5, 3] != s[i, j] && s[5, 6] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j] &&
                                    s[7, 0] != s[i, j] && s[7, 1] != s[i, j] && s[7, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 1)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j] &&
                                    s[5, 1] != s[i, j] && s[5, 4] != s[i, j] && s[5, 7] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j] &&
                                    s[7, 0] != s[i, j] && s[7, 1] != s[i, j] && s[7, 2] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 2)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j] &&
                                    s[5, 2] != s[i, j] && s[5, 5] != s[i, j] && s[5, 8] != s[i, j] &&
                                    s[6, 0] != s[i, j] && s[6, 1] != s[i, j] && s[6, 2] != s[i, j] &&
                                    s[7, 0] != s[i, j] && s[7, 1] != s[i, j] && s[7, 2] != s[i, j])
                                {

                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 3)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j] &&
                                    s[5, 0] != s[i, j] && s[5, 3] != s[i, j] && s[5, 6] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j] &&
                                    s[7, 3] != s[i, j] && s[7, 4] != s[i, j] && s[7, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 4)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j] &&
                                    s[5, 1] != s[i, j] && s[5, 4] != s[i, j] && s[5, 7] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j] &&
                                    s[7, 3] != s[i, j] && s[7, 4] != s[i, j] && s[7, 5] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 5)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j] &&
                                    s[5, 2] != s[i, j] && s[5, 5] != s[i, j] && s[5, 8] != s[i, j] &&
                                    s[6, 3] != s[i, j] && s[6, 4] != s[i, j] && s[6, 5] != s[i, j] &&
                                    s[7, 3] != s[i, j] && s[7, 4] != s[i, j] && s[7, 5] != s[i, j])
                                {

                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 6)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 0] != s[i, j] && s[2, 3] != s[i, j] && s[2, 6] != s[i, j] &&
                                    s[5, 0] != s[i, j] && s[5, 3] != s[i, j] && s[5, 6] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j] &&
                                    s[7, 6] != s[i, j] && s[7, 7] != s[i, j] && s[7, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 7)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 1] != s[i, j] && s[2, 4] != s[i, j] && s[2, 7] != s[i, j] &&
                                    s[5, 1] != s[i, j] && s[5, 4] != s[i, j] && s[5, 7] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j] &&
                                    s[7, 6] != s[i, j] && s[7, 7] != s[i, j] && s[7, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }

                        if (j == 8)
                        {
                            while (true)
                            {
                                randomValue = p[r.Next(p.Count)];
                                s[i, j] = randomValue;
                                if (s[2, 2] != s[i, j] && s[2, 5] != s[i, j] && s[2, 8] != s[i, j] &&
                                    s[5, 2] != s[i, j] && s[5, 5] != s[i, j] && s[5, 8] != s[i, j] &&
                                    s[6, 6] != s[i, j] && s[6, 7] != s[i, j] && s[6, 8] != s[i, j] &&
                                    s[7, 6] != s[i, j] && s[7, 7] != s[i, j] && s[7, 8] != s[i, j])
                                {
                                    break;
                                }
                                else
                                {
                                    doo++;
                                }
                                if (doo > 11)
                                {
                                    return;
                                }
                            }
                            p.Remove(randomValue);
                            doo = 0;
                        }
                    }
                }
            }
        }

        static void Main(String[] args)
        {
            Sudoku s = new Sudoku();
        }
    }
}