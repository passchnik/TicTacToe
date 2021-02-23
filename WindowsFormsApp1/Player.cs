using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    abstract class Player
    {
        public abstract void drow();

        public abstract bool checkCell(int counter);

        public abstract bool checkEndGame();


    }
}
