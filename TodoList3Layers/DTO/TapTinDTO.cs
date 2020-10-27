using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TapTinDTO
    {
        public int matt { get; set; }
        public string taptin { get; set; }
        public int macv { get; set; }
        //public string path { get; set; }

        public TapTinDTO() { }
        public TapTinDTO(String taptin, int macv)
        {
            this.taptin = taptin;
            this.macv = macv;
            //this.path = path;
        }
    }
}
