using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadComPort
{
    public class DComPort
    {
        private string? date;
        private string? comdata;
        private string? comname;
        public DComPort(string date, string data, string? comname)
        {
            this.date = date;
            this.comdata = data;
            this.comname = comname;
        }
    }
}
