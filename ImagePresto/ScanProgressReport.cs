using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePresto
{
    class ScanProgressReport
    {
        //current progress
        public int CurrentProgressAmount { get; set; }

        //total progress
        public int TotalProgressAmount { get; set; }

        //some message to pass to the UI of current progress
        public string CurrentProgressMessage { get; set; }
    }
}
