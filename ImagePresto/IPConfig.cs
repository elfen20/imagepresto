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
        private const string CONFIGFILE = "config.json";
        public string FileList = default;


        public static IPConfig GetDefault()
        {
            IPConfig conf = new IPConfig();
            conf.FileList = "images.json";
            return conf;
        }
        public static IPConfig GetConfig()
        {
            if (!File.Exists(CONFIGFILE))
            {
                IPConfig conf = IPConfig.GetDefault();
                conf.Save();
                return conf;
            } 
            return JsonConvert.DeserializeObject<IPConfig>(File.ReadAllText(CONFIGFILE));
        }

        internal void Save()
        {
            File.WriteAllText(CONFIGFILE, JsonConvert.SerializeObject(this));
        }
    }
}
