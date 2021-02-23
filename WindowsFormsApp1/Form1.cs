using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int step = 1;

        PlayerTicTacToe player ;
        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            //player = new PlayerTicTacToe(step, dg);
            //step++ ;
            //step += player.setStep;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dg.Rows.Add(2);
            for (int i=0; i<3; i++)
            {
                dg.Rows[i].Height = 193;
            }
            dg.ClearSelection();
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dg_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            player = new PlayerTicTacToe(step, dg);
            step++;
            step += player.setStep;
        }
    }
}
