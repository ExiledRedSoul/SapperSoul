using Sapper_Soul.Enumerlables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapper_Soul.Classes
{
    public class Game
    {
        public DifficultyLevels levels { get; private set; }

        public int[,] maps { get; private set; }

        public int Mines { get; private set; }

        public StatusGame statusGame { get; private set; }

        public Game(DifficultyLevels levels)
        {
            this.levels = levels;
            GenerateMaps();
            statusGame = StatusGame.Wait;
        }

        private void GenerateMaps()
        {
            switch (levels)
            {
                case DifficultyLevels.Easy:
                    this.maps = new int[9, 9];
                    this.Mines = 10;
                    break;
                case DifficultyLevels.Medium:
                    this.maps = new int[16, 16];
                    this.Mines = 40;
                    break;
                case DifficultyLevels.Hard:
                    this.maps = new int[30, 16];
                    this.Mines = 99;
                    break;
            }
            Random random = new Random();
            int num1 = 0;
            int mines = this.Mines;
            for (int index1 = 0; index1 < mines; ++index1)
            {
                int index2 = random.Next(0, this.maps.GetLength(0));
                int index3 = random.Next(0, this.maps.GetLength(1));
                if (this.maps[index2, index3] == 0)
                {
                    if (index2 == 0 && index3 == 0)
                    {
                        int num2 = 0;
                        if (this.maps[index2 + 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 + 1] == -1)
                            ++num2;
                        if (num2 < 3)
                        {
                            this.maps[index2, index3] = -1;
                            ++num1;
                        }
                        else
                            ++mines;
                    }
                    else if (index2 == 0 && index3 == this.maps.GetLength(1) - 1)
                    {
                        int num2 = 0;
                        if (this.maps[index2 + 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 - 1] == -1)
                            ++num2;
                        if (num2 < 3)
                        {
                            this.maps[index2, index3] = -1;
                            ++num1;
                        }
                        else
                            ++mines;
                    }
                    else if (index2 == this.maps.GetLength(0) - 1 && index3 == this.maps.GetLength(1) - 1)
                    {
                        int num2 = 0;
                        if (this.maps[index2 - 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 - 1, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 - 1] == -1)
                            ++num2;
                        if (num2 < 3)
                        {
                            this.maps[index2, index3] = -1;
                            ++num1;
                        }
                        else
                            ++mines;
                    }
                    else if (index2 == this.maps.GetLength(0) - 1 && index3 == 0)
                    {
                        int num2 = 0;
                        if (this.maps[index2 - 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 - 1, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 + 1] == -1)
                            ++num2;
                        if (num2 < 3)
                        {
                            this.maps[index2, index3] = -1;
                            ++num1;
                        }
                        else
                            ++mines;
                    }
                    else if (index2 == 0 && index3 > 0)
                    {
                        int num2 = 0;
                        if (this.maps[index2, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 + 1] == -1)
                            ++num2;
                        if (num2 < 3)
                        {
                            this.maps[index2, index3] = -1;
                            ++num1;
                        }
                        else
                            ++mines;
                    }
                    else if (index2 > 0 && index3 == this.maps.GetLength(1) - 1)
                    {
                        int num2 = 0;
                        if (this.maps[index2 - 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 - 1, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3] == -1)
                            ++num2;
                        if (num2 < 3)
                        {
                            this.maps[index2, index3] = -1;
                            ++num1;
                        }
                        else
                            ++mines;
                    }
                    else if (index2 == this.maps.GetLength(0) - 1 && index3 > 0)
                    {
                        int num2 = 0;
                        if (this.maps[index2, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2 - 1, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2 - 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 - 1, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 + 1] == -1)
                            ++num2;
                        if (num2 < 3)
                        {
                            this.maps[index2, index3] = -1;
                            ++num1;
                        }
                        else
                            ++mines;
                    }
                    else if (index2 > 0 && index3 == 0)
                    {
                        int num2 = 0;
                        if (this.maps[index2 - 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 - 1, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3] == -1)
                            ++num2;
                        if (num2 < 3)
                        {
                            this.maps[index2, index3] = -1;
                            ++num1;
                        }
                        else
                            ++mines;
                    }
                    else
                    {
                        int num2 = 0;
                        if (this.maps[index2 - 1, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2 - 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 - 1, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3 + 1] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3] == -1)
                            ++num2;
                        if (this.maps[index2 + 1, index3 - 1] == -1)
                            ++num2;
                        if (this.maps[index2, index3 - 1] == -1)
                            ++num2;
                        if (num2 < 3)
                        {
                            this.maps[index2, index3] = -1;
                            ++num1;
                        }
                        else
                            ++mines;
                    }
                }
                else if (this.maps[index2, index3] == -1)
                    ++mines;
            }
            for (int index1 = 0; index1 < this.maps.GetLength(0); ++index1)
            {
                for (int index2 = 0; index2 < this.maps.GetLength(1); ++index2)
                {
                    if (this.maps[index1, index2] != -1)
                    {
                        if (index1 == 0 && index2 == 0)
                        {
                            int num2 = 0;
                            if (this.maps[index1 + 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 + 1] == -1)
                                ++num2;
                            this.maps[index1, index2] = num2;
                        }
                        else if (index1 == 0 && index2 == this.maps.GetLength(1) - 1)
                        {
                            int num2 = 0;
                            if (this.maps[index1 + 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 - 1] == -1)
                                ++num2;
                            this.maps[index1, index2] = num2;
                        }
                        else if (index1 == this.maps.GetLength(0) - 1 && index2 == this.maps.GetLength(1) - 1)
                        {
                            int num2 = 0;
                            if (this.maps[index1 - 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 - 1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 - 1] == -1)
                                ++num2;
                            this.maps[index1, index2] = num2;
                        }
                        else if (index1 == this.maps.GetLength(0) - 1 && index2 == 0)
                        {
                            int num2 = 0;
                            if (this.maps[index1 - 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 - 1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 + 1] == -1)
                                ++num2;
                            this.maps[index1, index2] = num2;
                        }
                        else if (index1 == 0 && index2 > 0)
                        {
                            int num2 = 0;
                            if (this.maps[index1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 + 1] == -1)
                                ++num2;
                            this.maps[index1, index2] = num2;
                        }
                        else if (index1 > 0 && index2 == this.maps.GetLength(1) - 1)
                        {
                            int num2 = 0;
                            if (this.maps[index1 - 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 - 1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2] == -1)
                                ++num2;
                            this.maps[index1, index2] = num2;
                        }
                        else if (index1 == this.maps.GetLength(0) - 1 && index2 > 0)
                        {
                            int num2 = 0;
                            if (this.maps[index1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1 - 1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1 - 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 - 1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 + 1] == -1)
                                ++num2;
                            this.maps[index1, index2] = num2;
                        }
                        else if (index1 > 0 && index2 == 0)
                        {
                            int num2 = 0;
                            if (this.maps[index1 - 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 - 1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2] == -1)
                                ++num2;
                            this.maps[index1, index2] = num2;
                        }
                        else
                        {
                            int num2 = 0;
                            if (this.maps[index1 - 1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1 - 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 - 1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2 + 1] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2] == -1)
                                ++num2;
                            if (this.maps[index1 + 1, index2 - 1] == -1)
                                ++num2;
                            if (this.maps[index1, index2 - 1] == -1)
                                ++num2;
                            this.maps[index1, index2] = num2;
                        }
                    }
                }
            }
        }

        public bool StartGame()
        {
            if (this.statusGame != StatusGame.Wait)
                return false;
            this.statusGame = StatusGame.Play;
            return true;
        }

        public void EndGame()
        {
            if (this.statusGame != StatusGame.Play)
                return;
            this.statusGame = StatusGame.End;
        }
    }
}
