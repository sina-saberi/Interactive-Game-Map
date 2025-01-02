using Interactive_Map_WindowsApplication.ViewModels.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.Mock
{
    public class MapListViewModelMock : MapListViewModel
    {
        public MapListViewModelMock() : base("some slug")
        {
            Maps = [];
        }
    }
}
