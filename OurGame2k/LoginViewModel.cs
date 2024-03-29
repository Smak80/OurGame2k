﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OurGame2k
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private User _user = new ();
        private GameWindow _game = new();
        public User CurrentUser
        {
            get => _user;
            private set => SetField(ref _user, value);
        }
        
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

        private Command _loginCommand;
        public Command LoginCommand => _loginCommand;
        private Command _removeCommand;
        public Command RemoveCommand => _removeCommand ??= new Command(
            CurrentUser.DeleteUser, _ => CurrentUser.IsExists);

        public LoginViewModel()
        {
            User.LoadUsers();
            _loginCommand = new(
                p=>
                {
                    CurrentUser.SaveOrUpdateUser(p);
                    _game.Show();
                }, 
                _ => CurrentUser.IsValid
            );
        }
    }
}
