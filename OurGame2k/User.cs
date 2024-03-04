using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OurGame2k
{
    public class User : INotifyPropertyChanged
    {
        private string _nick = "";
        private string _name = "";
        private DateTime _birth = DateTime.Now.Date.AddYears(-6);
        private static readonly List<User> _users = new List<User>();

        public string Nick
        {
            get => _nick;
            set => SetField(ref _nick, value);
        }

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        public DateTime Birth
        {
            get => _birth;
            set => SetField(ref _birth, value);
        }

        public bool IsValid =>
            !Nick.Trim().Equals("") 
            && !Name.Trim().Equals("") 
            && Birth <= DateTime.Now.Date.AddYears(-6) 
            && Birth >= DateTime.Now.Date.AddYears(-120);

        public event PropertyChangedEventHandler? PropertyChanged;

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

        public void SaveOrUpdateUser(object? p)
        {

        }

        public void DeleteUser()
        {

        }
    }
}
