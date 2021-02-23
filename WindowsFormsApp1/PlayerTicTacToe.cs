using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class PlayerTicTacToe : Player
    {
        private int step;
        private DataGridView dg;
        public int setStep = 0;
        
        public PlayerTicTacToe(int step, DataGridView dg)
        {
            this.step=step;
            this.dg = dg;
            drow();
            
        }

        
        public override bool checkCell(int i)
        {
            if (Convert.ToString(dg.SelectedCells[i].Value) == "")
            {
                return false;
            }
            else
            {
                if (checkEndGame() == false)
                {
                    MessageBox.Show("Selected cell is busy", "Error", MessageBoxButtons.OK);
                    setStep = -1;
                    return true;
                }
                else
                {
                    return true;
                }
            }

        }

        public bool checkeWinOrLose()
        {
            char[,] array = new char[3, 3]; // mirror array from field in dg
            int someNum = 1;
            for (int i = 0; i < dg.ColumnCount; i++)// filling array 
            {
                for (int j = 0; j < dg.RowCount; j++)
                {
                    if (dg.Rows[j].Cells[i].Value=="X")
                    {
                        array[i, j] = 'X';
                    }
                    else
                    {
                        if(dg.Rows[j].Cells[i].Value == "O")
                        {
                            array[i, j] = 'O';
                        }
                        else
                        {
                            array[i, j] = Convert.ToChar(i+j+someNum);
                            someNum++;
                        }
                    }
                }
            }
            bool count=false;       //checking on full field for drawing result
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                for (int j = 0; j < dg.RowCount; j++)
                {
                    if(dg.Rows[j].Cells[i].Value != "O" 
                        || dg.Rows[j].Cells[i].Value != "X")
                    {
                        count = true;
                    }
                }

            }

            if (count==true 
                && step%10==0)      // draw result           
            {
                MessageBox.Show("Draw", "End Game", MessageBoxButtons.OK);
                Application.Restart();
            }
            else
            {
                for (int i = 0; i < 3; i++) // checking on all win combination
                {
                    if (array[0, i] == array[1, i]
                        && array[0, i] == array[2, i])
                    {
                        return true;
                    }
                    else
                    {
                        if (array[i, 0] == array[i, 1]
                            && array[i, 0] == array[i, 2])
                        {
                            return true;
                        }
                    }
                }

                if (array[0, 0] == array[1, 1]
                    && array[0, 0] == array[2, 2])
                {
                    return true;
                }
                else
                {
                    if (array[2, 0] == array[1, 1]
                        && array[2, 0] == array[0, 2])
                    {
                        return true;
                    }
                }

            }


            return false;

        }//end this big method (sorry for this crutches)




        private string findPlayer()
        {
            if (step%2==0)
            {
                return "O";
            }
            else
            {
                return "x";
            }
        }


        public override bool checkEndGame()
        {
            if (checkeWinOrLose()==false)
            return false;
            else
            {
                MessageBox.Show("Congratulations! Player "+findPlayer()+" win", "End Game", MessageBoxButtons.OK);
                Application.Restart();
                return true;
            }
        }
        public override void drow()
        {
            for (int i = 0; i < dg.SelectedCells.Count; i++)
            {
                
                if (checkCell(i) == false 
                    && checkEndGame() == false)
                {
                    if (step%2==0)
                    {
                        dg.SelectedCells[i].Value = "O";
                    }
                    else
                    {
                        dg.SelectedCells[i].Value = "X";
                    }
                }
                
            }
            checkEndGame();
        }

    }
}
