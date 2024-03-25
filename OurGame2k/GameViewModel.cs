using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurGame2k
{
    public class GameViewModel
    {
        public MineField Field { get; } = new();

        private Command _startCommand;
        public Command StartCommand => _startCommand ??= new Command(
            _ => { Field.InitializeMineField(); });
    }
}
