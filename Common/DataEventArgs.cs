using System.Collections.Generic;

namespace Common
{
    /// <summary>
    /// Клас для передачі повідомлень у подіях між рівнями
    /// </summary>
    public class DataEventArgs
    {
        private Dictionary<string, string> modelDictionary;

        /// <summary>
        /// Словник для передачі повідомлень
        /// </summary>
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
