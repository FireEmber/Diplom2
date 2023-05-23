using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Diplom.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected bool Set<T>(ref T field, T value, string propName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnProperyChanged(propName);
            return true;
        }
        protected virtual void OnProperyChanged(string propName)
        {
            PropertyChanged?.Invoke(PropertyChanged, new PropertyChangedEventArgs(propName));
        }
    }
}
