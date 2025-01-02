using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Map.Application.Interfaces
{
    public interface ITileRepository
    {
        public Task<byte[]?> GetBytesAsync(string pattern);
    }
}
