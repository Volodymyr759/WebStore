using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class DataEventArgs
    {
        private Dictionary<string, string> modelDictionary;

        public Dictionary<string, string> ModelDictionary
        {
            get
            {
                return modelDictionary;
            }
            set
            {
                modelDictionary = value;
            }
        }
    }
}
