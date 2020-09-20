using Sapper_Soul.Classes;
using Sapper_Soul.Classes.Model;
using Sapper_Soul.Delegates;
using Sapper_Soul.Enumerlables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sapper_Soul.Controls
{
    public class GamePanel : Control
    {
        private Image CloseCell;
        private Image Flag;
        private Image MinesGray;
        private Image MinesRed;
        private Image NoMines;

        public event Action StartGame;
        public event EndGameDelegate EndGame;
        public event ChangeMines ChangeMines;

        public StatusGameOver GameOverStatus { get; set; } = StatusGameOver.Wait;

        public Color BorderColor { get; set; } = SapperStatic.BorderColor;

        public List<Cell> Cells { get; private set; } = new List<Cell>();

        public int CountMines { get; set; }

        private int[,] Maps { get; set; }

        private int CountRows { get; set; }

        private int CountColumn { get; set; }

        private int SizeCell { get; set; } = 35;

        public GamePanel()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            Size = new Size(300, 300);
            BackColor = SapperStatic.BackColor;
        }

        public void SetMaps(int[,] maps)
        {
            Maps = maps;
            CountRows = Maps.GetLength(0);
            CountColumn = Maps.GetLength(1);
            string str = Application.StartupPath + "\\Resources\\Images\\";
            if (File.Exists(str + "CloseFlag35.png") && File.Exists(str + "Flag35.png") && (File.Exists(str + "MinesGray35.png") && File.Exists(str + "MinesRed35.png")) && File.Exists(str + "NoMines35.png"))
            {
                CloseCell = Image.FromFile(str + "CloseFlag35.png");
                Flag = Image.FromFile(str + "Flag35.png");
                MinesGray = Image.FromFile(str + "MinesGray35.png");
                MinesRed = Image.FromFile(str + "MinesRed35.png");
                NoMines = Image.FromFile(str + "NoMines35.png");
            }
            else
            {
                int num = (int)MessageBox.Show("Не были найдены нужные ресурсные файлы, попробуйте переустановить приложение, а если ошибка повторится, то напишите в тех. поддержу", "Ошибка загрузки ресурсов", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Application.Exit();
            }
            Cells.Clear();
            for (int index1 = 0; index1 < Maps.GetLength(0); index1++)
            {
                for (int index2 = 0; index2 < Maps.GetLength(1); index2++)
                    Cells.Add(new Cell()
                    {
                        i = index1,
                        j = index2,
                        image = StatusImage.Close
                    });
            }
            Size = new Size(SizeCell * CountRows, SizeCell * CountColumn);
            GameOverStatus = StatusGameOver.Wait;
            Invalidate();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            Cell cellClickUser = Cells.Find(c =>
            {
                if (e.Location.X > c.i * SizeCell && e.Location.X < c.i * SizeCell + SizeCell && e.Location.Y > c.j * SizeCell)
                    return e.Location.Y < c.j * SizeCell + SizeCell;
                return false;
            });
            if (cellClickUser != null)
            {
                if (GameOverStatus == StatusGameOver.Wait)
                {
                    StartGame?.Invoke();
                }
                if (e.Button == MouseButtons.Left)
                {
                    if (cellClickUser.image == StatusImage.Flag)
                        return;
                    if (Maps[cellClickUser.i, cellClickUser.j] == -1)
                    {
                        GameOver(cellClickUser);
                    }
                    else
                    {
                        cellClickUser.image = StatusImage.None;
                        if (Maps[cellClickUser.i, cellClickUser.j] == 0)
                            CheckNeighboringCells(cellClickUser.i, cellClickUser.j);
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (cellClickUser.image == StatusImage.None)
                        return;
                    cellClickUser.image = cellClickUser.image == StatusImage.Flag ? StatusImage.Close : StatusImage.Flag;
                    Cell[] array = Cells.Where(c => c.image == StatusImage.Flag).ToArray();
                    ChangeMines?.Invoke(array.Length);
                    if (array.Length == CountMines && Cells.Where(c =>
                    {
                        if (Maps[c.i, c.j] == -1)
                            return c.image == StatusImage.Flag;
                        return false;
                    }).ToArray().Length == CountMines)
                    {
                        foreach (Cell cell in Cells)
                        {
                            if (cell.image == StatusImage.Close)
                                cell.image = StatusImage.None;
                        }
                        GameOverStatus = StatusGameOver.Win;
                        EndGame?.Invoke(GameOverStatus);
                        Invalidate();
                    }
                }
            }
            Invalidate();
        }

        private void CheckNeighboringCells(int StartI, int StartJ)
        {
            List<string> source = new List<string>();
            source.Add(string.Format("{0};{1}", (object)StartI, (object)StartJ));
            while (source.Count != 0)
            {
                int i = int.Parse(source[0].Split(';')[0]);
                int j = int.Parse(source[0].Split(';')[1]);
                this.SearchAndSetNoneImageTheCells(i, j);
                if (i == 0 && j == 0)
                {
                    if (this.Maps[i + 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j);
                    if (this.Maps[i + 1, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j + 1);
                    if (this.Maps[i, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j + 1);
                }
                else if (i == 0 && j == this.Maps.GetLength(1) - 1)
                {
                    if (this.Maps[i, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j - 1);
                    if (this.Maps[i + 1, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j - 1);
                    if (this.Maps[i + 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j);
                }
                else if (i == this.Maps.GetLength(0) - 1 && j == this.Maps.GetLength(1) - 1)
                {
                    if (this.Maps[i - 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j);
                    if (this.Maps[i - 1, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j - 1);
                    if (this.Maps[i, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j - 1);
                }
                else if (i == this.Maps.GetLength(0) - 1 && j == 0)
                {
                    if (this.Maps[i - 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j);
                    if (this.Maps[i - 1, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j + 1);
                    if (this.Maps[i, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j + 1);
                }
                else if (i == 0 && j > 0)
                {
                    if (this.Maps[i, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j - 1);
                    if (this.Maps[i + 1, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j - 1);
                    if (this.Maps[i + 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j);
                    if (this.Maps[i + 1, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j + 1);
                    if (this.Maps[i, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j + 1);
                }
                else if (i > 0 && j == this.Maps.GetLength(1) - 1)
                {
                    if (this.Maps[i - 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j);
                    if (this.Maps[i - 1, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j - 1);
                    if (this.Maps[i, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j - 1);
                    if (this.Maps[i + 1, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j - 1);
                    if (this.Maps[i + 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j);
                }
                else if (i == this.Maps.GetLength(0) - 1 && j > 0)
                {
                    if (this.Maps[i, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j - 1);
                    if (this.Maps[i - 1, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j - 1);
                    if (this.Maps[i - 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j);
                    if (this.Maps[i - 1, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j + 1);
                    if (this.Maps[i, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j + 1);
                }
                else if (i > 0 && j == 0)
                {
                    if (this.Maps[i - 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j);
                    if (this.Maps[i - 1, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j + 1);
                    if (this.Maps[i, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j + 1);
                    if (this.Maps[i + 1, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j + 1);
                    if (this.Maps[i + 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j);
                }
                else
                {
                    if (this.Maps[i - 1, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j - 1);
                    if (this.Maps[i - 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j);
                    if (this.Maps[i - 1, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i - 1)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i - 1), (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i - 1, j + 1);
                    if (this.Maps[i, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j + 1);
                    if (this.Maps[i + 1, j + 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j + 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)(j + 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j + 1);
                    if (this.Maps[i + 1, j] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)j));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j);
                    if (this.Maps[i + 1, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i + 1)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)(i + 1), (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i + 1, j - 1);
                    if (this.Maps[i, j - 1] == 0)
                    {
                        if (this.Cells.Find((Predicate<Cell>)(c =>
                        {
                            if (c.i == i)
                                return c.j == j - 1;
                            return false;
                        })).image == StatusImage.Close)
                            source.Add(string.Format("{0};{1}", (object)i, (object)(j - 1)));
                    }
                    else
                        this.SearchAndSetNoneImageTheCells(i, j - 1);
                }
                source.Remove(source.First<string>());
            }
        }

        private void SearchAndSetNoneImageTheCells(int i, int j)
        {
            this.Cells.Find((Predicate<Cell>)(c =>
            {
                if (c.i == i)
                    return c.j == j;
                return false;
            })).image = StatusImage.None;
        }

        private void GameOver(Cell cellClickUser)
        {
            cellClickUser.image = StatusImage.MinesRed;
            foreach (Cell cell in this.Cells)
            {
                switch (cell.image)
                {
                    case StatusImage.Close:
                        if (this.Maps[cell.i, cell.j] == -1)
                        {
                            cell.image = StatusImage.MinesGray;
                            continue;
                        }
                        continue;
                    case StatusImage.Flag:
                        if (this.Maps[cell.i, cell.j] != -1)
                        {
                            cell.image = StatusImage.NoMines;
                            continue;
                        }
                        continue;
                    default:
                        continue;
                }
            }
            Invalidate();
            GameOverStatus = StatusGameOver.Lose;
            EndGame?.Invoke(GameOverStatus);
            Enabled = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.Clear(this.Parent.BackColor);
            Rectangle rect1 = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            graphics.DrawRectangle(new Pen((Brush)new SolidBrush(this.BorderColor)), rect1);
            graphics.FillRectangle((Brush)new SolidBrush(this.BackColor), rect1);
            if (this.Cells.Count <= 0)
                return;
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            foreach (Cell cell in this.Cells)
            {
                Rectangle rect2 = new Rectangle(cell.i * this.SizeCell, cell.j * this.SizeCell, this.SizeCell, this.SizeCell);
                graphics.DrawRectangle(new Pen((Brush)new SolidBrush(this.BorderColor)), rect2);
                if (this.Maps[cell.i, cell.j] != 0)
                    graphics.DrawString(this.Maps[cell.i, cell.j].ToString(), this.Font, (Brush)new SolidBrush(Color.Black), (RectangleF)rect2, format);
                Rectangle rect3 = new Rectangle(rect2.X + 1, rect2.Y + 1, rect2.Width - 1, rect2.Height - 1);
                if (!SapperStatic.isPause)
                {
                    switch (cell.image)
                    {
                        case StatusImage.Close:
                            graphics.DrawImage(this.CloseCell, rect2);
                            continue;
                        case StatusImage.Flag:
                            graphics.DrawImage(this.Flag, rect2);
                            continue;
                        case StatusImage.MinesGray:
                            graphics.DrawImage(this.MinesGray, rect3);
                            continue;
                        case StatusImage.MinesRed:
                            graphics.DrawImage(this.MinesRed, rect3);
                            continue;
                        case StatusImage.NoMines:
                            graphics.DrawImage(this.NoMines, rect3);
                            continue;
                        default:
                            continue;
                    }
                }
                else
                    graphics.DrawImage(this.CloseCell, rect2);
            }
        }
    }
}
