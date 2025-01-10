using Interactive_Map.Application.Services.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.ViewModels.Dtos
{
    public class GroupDtoViewModel
    {
        public string Title { get; set; } = null!;
        public IEnumerable<CategoryDtoViewModel> Categories { get; set; } = [];
    }
}
