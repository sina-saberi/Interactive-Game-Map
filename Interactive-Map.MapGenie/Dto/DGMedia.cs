using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.MapGenie.Dto
{
    public class DGMedia
    {
        public string FileName { get; set; } = null!;
        public string MimeType { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Type { get; set; } = null!;

        public DGMedia(string fileName, string mimeType, string title, string type)
        {
            FileName = fileName;
            MimeType = mimeType;
            Title = title;
            Type = type;
        }
    }
}
