using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_Navigation.Interfaces
{
    public interface ILayout : INavigate
    {
        public INavigate? Content { get; set; }
    }
}
