using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImagePresto
{
    class IPConfig
    {
        public string FileList = default;

        public static IPConfig GetConfig()
        {
            return JsonConvert.DeserializeObject<IPConfig>(File.ReadAllText("ipconfig.json"));
        }

        internal void Save()
        {
            string res = JsonConvert.SerializeObject(this);
        }
    }
}
