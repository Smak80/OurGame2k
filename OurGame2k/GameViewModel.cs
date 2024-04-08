using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OurGame2k
{
    public class GameViewModel
    {
        public MineField Field { get; } = new(15,15);

        private Command? _startCommand;
        public Command StartCommand => _startCommand ??= new Command(
            _ => { Field.InitializeMineField(); });

        public GameViewModel()
        {
            CellInfo.CellUpdateNeeded += Field.UpdateCells;
        }

    }
}
