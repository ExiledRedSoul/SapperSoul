using Sapper_Soul.Classes;
using Sapper_Soul.Controls;
using Sapper_Soul.Enumerlables;
using Sapper_Soul.Forms;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sapper_Soul
{
    public partial class Form1 : Form
    {
        private string ResourcePath;
        private GamePanel gamePanel;
        public int TimeS;
        private Image NumberOff;
        private Image NumberNull;
        private Image NumberOne;
        private Image NumberTwo;
        private Image NumberThree;
        private Image NumberFour;
        private Image NumberFive;
        private Image NumberSix;
        private Image NumberSeven;
        private Image NumberEight;
        private Image NumberNine;
        private PauseForm pause;
        

        public Form OwnedForm { get; set; }

        private Game game { get; set; }

        private DifficultyLevels Level { get; set; }

        private Timer GameTime { get; set; } = new Timer();

        public Form1(DifficultyLevels statusGame)
        {
            Form1 form1 = this;
            InitializeComponent();
            ResourcePath = Application.StartupPath + "\\Resources\\";
            if (File.Exists(ResourcePath + "Images\\NumberOff.png"))
                NumberOff = Image.FromFile(ResourcePath + "Images\\NumberNull.png");
            if (File.Exists(ResourcePath + "Images\\NumberNull.png"))
                NumberNull = Image.FromFile(ResourcePath + "Images\\NumberNull.png");
            if (File.Exists(ResourcePath + "Images\\NumberOne.png"))
                NumberOne = Image.FromFile(ResourcePath + "Images\\NumberOne.png");
            if (File.Exists(ResourcePath + "Images\\NumberTwo.png"))
                NumberTwo = Image.FromFile(ResourcePath + "Images\\NumberTwo.png");
            if (File.Exists(ResourcePath + "Images\\NumberThree.png"))
                NumberThree = Image.FromFile(ResourcePath + "Images\\NumberThree.png");
            if (File.Exists(ResourcePath + "Images\\NumberFour.png"))
                NumberFour = Image.FromFile(ResourcePath + "Images\\NumberFour.png");
            if (File.Exists(ResourcePath + "Images\\NumberFive.png"))
                NumberFive = Image.FromFile(ResourcePath + "Images\\NumberFive.png");
            if (File.Exists(ResourcePath + "Images\\NumberSix.png"))
                NumberSix = Image.FromFile(ResourcePath + "Images\\NumberSix.png");
            if (File.Exists(ResourcePath + "Images\\NumberSeven.png"))
                NumberSeven = Image.FromFile(ResourcePath + "Images\\NumberSeven.png");
            if (File.Exists(ResourcePath + "Images\\NumberEight.png"))
                NumberEight = Image.FromFile(ResourcePath + "Images\\NumberEight.png");
            if (File.Exists(ResourcePath + "Images\\NumberEight.png"))
                NumberNine = Image.FromFile(ResourcePath + "Images\\NumberNine.png");
            Level = statusGame;
            KeyPress += (o, e) =>
            {
                if (e.KeyChar == (char)Keys.Escape && !SapperStatic.SettingsFormOpen)
                {
                    if (!SapperStatic.isPause)
                    {
                        SapperStatic.Pause();
                        form1.pause = new PauseForm(form1, form1.OwnedForm);
                        form1.pause.TopLevel = false;
                        form1.pause.Font = form1.Font;
                        form1.Controls.Add(form1.pause);
                        form1.pause.Location = new Point(form1.Width / 2 - form1.pause.Width / 2, form1.Height / 2 - form1.pause.Height / 2);
                        form1.pause.BringToFront();
                        form1.pause.Show();
                    }
                    else
                    {
                        SapperStatic.Resume();
                        form1.pause.Close();
                    }
                }
                form1.Focus();
            };
            Load += ((o, e) =>
            {
                form1.game = new Game(form1.Level);
                switch (statusGame)
                {
                    case DifficultyLevels.Easy:
                        form1.GameInterface.Size = new Size(375, 465);
                        form1.GameInterface.Load(Application.StartupPath + "\\Resources\\Images\\Interface9x9.png");
                        break;
                    case DifficultyLevels.Medium:
                        form1.GameInterface.Size = new Size(620, 710);
                        form1.GameInterface.Load(Application.StartupPath + "\\Resources\\Images\\Interface16x16.png");
                        break;
                    case DifficultyLevels.Hard:
                        form1.GameInterface.Size = new Size(1110, 710);
                        form1.GameInterface.Load(Application.StartupPath + "\\Resources\\Images\\Interface16x30.png");
                        break;
                }
                form1.SmileBox.Size = new Size(50, 50);
                form1.SmileBox.Load(Application.StartupPath + "\\Resources\\Images\\Smile50.png");
                form1.SmileBox.BringToFront();
                form1.GameInterface.Location = new Point(form1.Width / 2 - form1.GameInterface.Width / 2, form1.Height / 2 - form1.GameInterface.Height / 2);
                form1.SmileBox.Location = new Point(form1.GameInterface.Location.X + (form1.GameInterface.Width / 2 - form1.SmileBox.Width / 2), form1.GameInterface.Location.Y + 35);
                form1.gamePanel = new GamePanel();
                form1.gamePanel.Size = new Size(600, 600);
                form1.gamePanel.SetMaps(form1.game.maps);
                form1.gamePanel.CountMines = form1.game.Mines;
                form1.Controls.Add(form1.gamePanel);
                form1.gamePanel.BringToFront();
                form1.gamePanel.Location = new Point(form1.Width / 2 - form1.gamePanel.Width / 2, form1.GameInterface.Location.Y + 120);
                form1.gamePanel.MouseDown += ((oo, ee) =>
                {
                    if (form1.gamePanel.GameOverStatus != StatusGameOver.Wait || ee.Button != MouseButtons.Left)
                        return;
                    form1.SmileBox.Load(Application.StartupPath + "\\Resources\\Images\\Smile_CellClick50.png");
                });
                form1.gamePanel.MouseClick += ((oo, ee) => form1.Focus());
                form1.gamePanel.MouseUp += ((oo, ee) =>
                {
                    if (form1.gamePanel.GameOverStatus != StatusGameOver.Wait)
                        return;
                    form1.SmileBox.Load(Application.StartupPath + "\\Resources\\Images\\Smile50.png");
                });
                Size size = new Size(30, 46);
                form1.NumberOneCountMines.Size = size;
                form1.NumberTwoCountMines.Size = size;
                form1.NumberThreeCountMines.Size = size;
                form1.NumberOneCountMines.Location = new Point(form1.GameInterface.Location.X + 50, form1.GameInterface.Location.Y + 37);
                PictureBox numberTwoCountMines = form1.NumberTwoCountMines;
                int x1 = form1.NumberOneCountMines.Location.X + form1.NumberTwoCountMines.Width;
                Point location = form1.NumberOneCountMines.Location;
                int y1 = location.Y;
                Point point1 = new Point(x1, y1);
                numberTwoCountMines.Location = point1;
                PictureBox numberThreeCountMines = form1.NumberThreeCountMines;
                location = form1.NumberTwoCountMines.Location;
                int x2 = location.X + form1.NumberThreeCountMines.Width;
                location = form1.NumberTwoCountMines.Location;
                int y2 = location.Y;
                Point point2 = new Point(x2, y2);
                numberThreeCountMines.Location = point2;
                form1.NumberOneTimes.Size = size;
                form1.NumberTwoTimes.Size = size;
                form1.NumberThreeTimes.Size = size;
                PictureBox numberOneTimes = form1.NumberOneTimes;
                location = form1.GameInterface.Location;
                int x3 = location.X + form1.GameInterface.Width - 50 - form1.NumberOneTimes.Width * 3;
                location = form1.GameInterface.Location;
                int y3 = location.Y + 37;
                Point point3 = new Point(x3, y3);
                numberOneTimes.Location = point3;
                PictureBox numberTwoTimes = form1.NumberTwoTimes;
                location = form1.NumberOneTimes.Location;
                int x4 = location.X + form1.NumberTwoTimes.Width;
                location = form1.NumberOneTimes.Location;
                int y4 = location.Y;
                Point point4 = new Point(x4, y4);
                numberTwoTimes.Location = point4;
                PictureBox numberThreeTimes = form1.NumberThreeTimes;
                location = form1.NumberTwoTimes.Location;
                int x5 = location.X + form1.NumberThreeTimes.Width;
                location = form1.NumberTwoTimes.Location;
                int y5 = location.Y;
                Point point5 = new Point(x5, y5);
                numberThreeTimes.Location = point5;
                form1.NumberOneCountMines.Image = form1.NumberOff;
                form1.NumberTwoCountMines.Image = form1.NumberOff;
                form1.NumberThreeCountMines.Image = form1.NumberOff;
                form1.NumberOneTimes.Image = form1.NumberOff;
                form1.NumberTwoTimes.Image = form1.NumberOff;
                form1.NumberThreeTimes.Image = form1.NumberOff;
                form1.gamePanel.StartGame += () => form1.GameTime.Start();
                form1.gamePanel.EndGame += status =>
                {
                    form1.GameTime.Stop();
                    if (status == StatusGameOver.Win)
                        form1.SmileBox.Load(Application.StartupPath + "\\Resources\\Images\\Smile_Win50.png");
                    else
                    {
                        if (status != StatusGameOver.Lose)
                            return;
                        form1.SmileBox.Load(Application.StartupPath + "\\Resources\\Images\\Smile_Lose50.png");
                    }
                };
                form1.gamePanel.ChangeMines += c => form1.SetImageToNumberPicture(form1.game.Mines - c, form1.NumberOneCountMines, form1.NumberTwoCountMines, form1.NumberThreeCountMines);
                form1.SetImageToNumberPicture(form1.game.Mines, form1.NumberOneCountMines, form1.NumberTwoCountMines, form1.NumberThreeCountMines);
                form1.Focus();
            });
            FormClosed += (o, e) => (form1.OwnedForm as Main).SetEnableBtn(true);
            GameTime.Interval = 1000;
            GameTime.Tick += ((o, e) =>
            {
                form1.TimeS++;
                form1.SetImageToNumberPicture(form1.TimeS, form1.NumberOneTimes, form1.NumberTwoTimes, form1.NumberThreeTimes);
            });
            SmileBox.Click += (o, e) => form1.NewGame();
            SmileBox.MouseDown += ((o, e) => form1.SmileBox.Load(Application.StartupPath + "\\Resources\\Images\\SmileClick50.png"));
            SmileBox.MouseUp += ((o, e) => form1.SmileBox.Load(Application.StartupPath + "\\Resources\\Images\\Smile50.png"));
            SapperStatic.PauseGame += () =>
            {
                form1.GameTime.Stop();
                form1.gamePanel.Invalidate();
            };
            SapperStatic.ResumeGame += () =>
            {
                if (form1.game.statusGame == StatusGame.Play)
                    form1.GameTime.Start();
                form1.gamePanel.Invalidate();
            };
        }

        public void NewGame()
        {
            game = new Game(Level);
            gamePanel.SetMaps(game.maps);
            gamePanel.CountMines = game.Mines;
            gamePanel.Enabled = true;
            TimeS = 0;
            SetImageToNumberPicture(TimeS, NumberOneTimes, NumberTwoTimes, NumberThreeTimes);
            SetImageToNumberPicture(game.Mines, NumberOneCountMines, NumberTwoCountMines, NumberThreeCountMines);
            SmileBox.Load(Application.StartupPath + "\\Resources\\Images\\Smile50.png");
        }

        private void SetImageToNumberPicture(int num, PictureBox numberOne, PictureBox numberTwo, PictureBox numberThree)
        {
            numberOne.Image = NumberOff;
            numberTwo.Image = NumberOff;
            numberThree.Image = NumberOff;
            if (num.ToString().Length == 1)
            {
                switch (num)
                {
                    case 0:
                        numberThree.Image = NumberNull;
                        break;
                    case 1:
                        numberThree.Image = NumberOne;
                        break;
                    case 2:
                        numberThree.Image = NumberTwo;
                        break;
                    case 3:
                        numberThree.Image = NumberThree;
                        break;
                    case 4:
                        numberThree.Image = NumberFour;
                        break;
                    case 5:
                        numberThree.Image = NumberFive;
                        break;
                    case 6:
                        numberThree.Image = NumberSix;
                        break;
                    case 7:
                        numberThree.Image = NumberSeven;
                        break;
                    case 8:
                        numberThree.Image = NumberEight;
                        break;
                    case 9:
                        numberThree.Image = NumberNine;
                        break;
                }
            }
            else if (num.ToString().Length == 2)
            {
                switch (int.Parse(num.ToString()[0].ToString()))
                {
                    case 0:
                        numberTwo.Image = NumberNull;
                        break;
                    case 1:
                        numberTwo.Image = NumberOne;
                        break;
                    case 2:
                        numberTwo.Image = NumberTwo;
                        break;
                    case 3:
                        numberTwo.Image = NumberThree;
                        break;
                    case 4:
                        numberTwo.Image = NumberFour;
                        break;
                    case 5:
                        numberTwo.Image = NumberFive;
                        break;
                    case 6:
                        numberTwo.Image = NumberSix;
                        break;
                    case 7:
                        numberTwo.Image = NumberSeven;
                        break;
                    case 8:
                        numberTwo.Image = NumberEight;
                        break;
                    case 9:
                        numberTwo.Image = NumberNine;
                        break;
                }
                switch (int.Parse(num.ToString()[1].ToString()))
                {
                    case 0:
                        numberThree.Image = NumberNull;
                        break;
                    case 1:
                        numberThree.Image = NumberOne;
                        break;
                    case 2:
                        numberThree.Image = NumberTwo;
                        break;
                    case 3:
                        numberThree.Image = NumberThree;
                        break;
                    case 4:
                        numberThree.Image = NumberFour;
                        break;
                    case 5:
                        numberThree.Image = NumberFive;
                        break;
                    case 6:
                        numberThree.Image = NumberSix;
                        break;
                    case 7:
                        numberThree.Image = NumberSeven;
                        break;
                    case 8:
                        numberThree.Image = NumberEight;
                        break;
                    case 9:
                        numberThree.Image = NumberNine;
                        break;
                }
            }
            else
            {
                if (num.ToString().Length != 3)
                    return;
                switch (int.Parse(num.ToString()[0].ToString()))
                {
                    case 0:
                        numberOne.Image = NumberNull;
                        break;
                    case 1:
                        numberOne.Image = NumberOne;
                        break;
                    case 2:
                        numberOne.Image = NumberTwo;
                        break;
                    case 3:
                        numberOne.Image = NumberThree;
                        break;
                    case 4:
                        numberOne.Image = NumberFour;
                        break;
                    case 5:
                        numberOne.Image = NumberFive;
                        break;
                    case 6:
                        numberOne.Image = NumberSix;
                        break;
                    case 7:
                        numberOne.Image = NumberSeven;
                        break;
                    case 8:
                        numberOne.Image = NumberEight;
                        break;
                    case 9:
                        numberOne.Image = NumberNine;
                        break;
                }
                switch (int.Parse(num.ToString()[1].ToString()))
                {
                    case 0:
                        numberTwo.Image = NumberNull;
                        break;
                    case 1:
                        numberTwo.Image = NumberOne;
                        break;
                    case 2:
                        numberTwo.Image = NumberTwo;
                        break;
                    case 3:
                        numberTwo.Image = NumberThree;
                        break;
                    case 4:
                        numberTwo.Image = NumberFour;
                        break;
                    case 5:
                        numberTwo.Image = NumberFive;
                        break;
                    case 6:
                        numberTwo.Image = NumberSix;
                        break;
                    case 7:
                        numberTwo.Image = NumberSeven;
                        break;
                    case 8:
                        numberTwo.Image = NumberEight;
                        break;
                    case 9:
                        numberTwo.Image = NumberNine;
                        break;
                }
                switch (int.Parse(num.ToString()[2].ToString()))
                {
                    case 0:
                        numberThree.Image = NumberNull;
                        break;
                    case 1:
                        numberThree.Image = NumberOne;
                        break;
                    case 2:
                        numberThree.Image = NumberTwo;
                        break;
                    case 3:
                        numberThree.Image = NumberThree;
                        break;
                    case 4:
                        numberThree.Image = NumberFour;
                        break;
                    case 5:
                        numberThree.Image = NumberFive;
                        break;
                    case 6:
                        numberThree.Image = NumberSix;
                        break;
                    case 7:
                        numberThree.Image = NumberSeven;
                        break;
                    case 8:
                        numberThree.Image = NumberEight;
                        break;
                    case 9:
                        numberThree.Image = NumberNine;
                        break;
                }
            }
        }
    }
}
