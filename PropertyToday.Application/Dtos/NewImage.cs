using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyToday.Application.Dtos
{
    public class NewImage
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool IsUploaded { get; set; }
    }
}
