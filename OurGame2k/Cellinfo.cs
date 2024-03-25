using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OurGame2k
{
    public class CellInfo(byte row, byte col) : Cell(row, col)
    {
        public int Left { get; set; }
        public int Top { get; set; }
        public int Size { get; set; }
        public Thickness Margin => new(Left, Top, 0, 0);
        public SolidColorBrush Color => Type switch
        {
            CellType.Mine => new SolidColorBrush(Colors.Red),
            _ => new(Colors.Lavender)
        };
    }

}
