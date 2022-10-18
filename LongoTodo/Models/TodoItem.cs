using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LongoTodo.Models
{
    public class TodoItem: INotifyPropertyChanged
    {
        public string Id { get; set; }
        public string Name { get; set; }

        private bool _isCompleted;
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
