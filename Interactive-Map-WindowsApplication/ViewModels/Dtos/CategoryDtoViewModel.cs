using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map_WindowsApplication.ViewModels.Dtos
{
    public class CategoryDtoViewModel
    {
        public Guid GroupId { get; set; }
        public string Title { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
