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
        public string Id => $"{Row},{Col}";
        public int Left { get; set; }
        public int Top { get; set; }
        public int Size { get; set; }
        public Thickness Margin => new(Left, Top, 0, 0);

        public static event Action? CellUpdateNeeded;

        public SolidColorBrush Color
        {
            get
            {
                if (IsMarked)
                {
                    return new SolidColorBrush(Colors.Aquamarine);
                }
                if (!IsOpen)
                {
                    return new SolidColorBrush(Colors.Bisque);
                }
                return Type switch
                {
                    CellType.Mine => new SolidColorBrush(Colors.Red),
                    _ => new(Colors.Lavender)
                };

            }
        }

        public string Text => Type switch
        {
            CellType.Number => IsOpen && MineCount > 0 ? MineCount.ToString() : "",
            _ => ""
        };

        private Command? _openCellCommand;
        public Command OpenCellCommand => _openCellCommand ??= new Command(_ =>
        {
            IsOpen = true;
            CellUpdateNeeded?.Invoke();
        });
        private Command? _markCellCommand;
        public Command MarkCellCommand => _markCellCommand ??= new Command(_ =>
        {
            IsMarked = true;
            CellUpdateNeeded?.Invoke();
        });
    }

}
