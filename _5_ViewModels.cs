using System;
using Optional;
using System.Collections.Generic;
using System.ComponentModel;

/// <summary>
/// There are circumstances where we can avoid Flags and run-time exceptions by modeling the
/// state of our software.
/// 
/// Consider a Todo list view model that has an Add Todo button which should ONLY be enabled if the
/// user has entered a sufficient amount of text.
/// 
/// This would often me modeled as a void method on the controller or view model and an IsEnabled flag 
/// to which the UX would bind.
/// </summary>
namespace Talk.Options.ViewModel
{
    public class TodoListViewModel : INotifyPropertyChanged
    {
        private string _currentTodoText = string.Empty;
        private readonly List<string> _todos = new List<string>();

        public string CurrentTodoText {
            get { return _currentTodoText; }
            set
            {
                _currentTodoText = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(CurrentTodoText)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(AddTodo)));
            }
        }

        public Option<Action> AddTodo
        {
            get
            {
                var currentTextCopy = _currentTodoText;
                return (string.IsNullOrWhiteSpace(currentTextCopy))
                    ? Option.None<Action>()
                    : Option.Some<Action>(() =>
                    {
                        _todos.Add(currentTextCopy);
                    });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}
