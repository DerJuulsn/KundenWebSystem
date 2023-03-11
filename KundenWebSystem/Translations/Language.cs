using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KundenWebSystem.Translations
{
    public class Language
    {
        public string Name { get; set; } = "Deutsch";

        public string ShortName { get; set; } = "de";

        public Dictionary<String, String> Translations { get; set; } = new Dictionary<string, string>();
    }
}
