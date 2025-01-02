using Interactive_Map_Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.ViewModels
{
    public class LayoutBase : ViewModelBase, ILayout
    {
        public INavigate? Content { get; set; }
        public ILayout? Layout { get; set; }

        public virtual void OnReady()
        {
           
        }
    }
}
