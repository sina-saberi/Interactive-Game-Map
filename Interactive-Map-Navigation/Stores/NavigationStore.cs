using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_Navigation.Stores
{
    using Interactive_Map_Navigation.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NavigationStore
    {
        private readonly List<INavigate> _history = [];
        public event Action? CurrentViewModelChanged;

        public INavigate? CurrentViewModel
        {
            get => _history.LastOrDefault();
            set
            {
                if (_history.LastOrDefault() == value || value is null) return;
                _history.Add(value);

                OnCurrentViewModelChanged();
            }
        }
        public IReadOnlyList<INavigate> History => _history.AsReadOnly();
        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
        public void RemoveCurrentViewModel()
        {
            if (CurrentViewModel is null) return;
            _history.Remove(CurrentViewModel);
            OnCurrentViewModelChanged();
        }
    }
}
