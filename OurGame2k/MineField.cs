using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace OurGame2k
{
    public class MineField : List<CellInfo>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        private int _width;
        private int _height;

        private readonly byte _rows;
        private readonly byte _cols;
        public byte Rows
        {
            get => _rows;
            init => _rows = byte.Min(byte.Max(value, 6), 50);
        }

        public byte Cols
        {
            get => _cols;
            init => _cols = byte.Min(byte.Max(value, 6), 50);
        }

        public int Width
        {
            get => _width;
            set
            {
                SetField(ref _width, value);
                UpdateCells();
            }
        }

        public int Height
        {
            get => _height;
            set
            {
                SetField(ref _height, value);
                UpdateCells();
            }
        }
        private int CellSize => int.Min(Height / Rows, Width / Cols);
        private int LShift => (Width - CellSize * Cols) / 2;
        private int TShift => (Height - CellSize * Rows) / 2;
        private CellInfo this[int row, int col] => this[row * Cols + col];
        public MineField(byte rows = 30, byte cols = 15)
        {
            Rows = rows;
            Cols = cols;
            for (byte i = 0; i < Rows; i++)
            {
                for (byte j = 0; j < Cols; j++)
                {
                    Add(new CellInfo(i, j));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void UpdateCells()
        {
            if (Height > 0 && Width > 0)
            {
                foreach (var cell in this)
                {
                    cell.Left = CellSize * cell.Col + LShift;
                    cell.Top = CellSize * cell.Row + TShift;
                    cell.Size = CellSize;
                }
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

    }
}
