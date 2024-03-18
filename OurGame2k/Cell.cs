using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurGame2k
{
    public class Cell(byte row, byte col)
    {
        public byte Row { get => row; set => row = value; }
        public byte Col { get => col; set => col = value; }
    }
}
