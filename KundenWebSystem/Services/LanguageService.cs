using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using KundenWebSystem.Translations;
using System.Text.Json;

namespace KundenWebSystem.Services
{
    public class LanguageService
    {
        public Language SelectedLanguage { get; set; }

        public LanguageService()
        {
            SelectedLanguage = LoadLanguage("de").Result;
        }

        public async Task<Language> LoadLanguage(string language)
        {
            String languageFileName = @"Translations\" + language.ToLower() + ".json";
            using (FileStream stream = File.OpenRead(languageFileName)) {
                return await JsonSerializer.DeserializeAsync<Language>(stream);
            }
        }

        public async void SaveLanguage(Language language)
        {
            using (FileStream stream = File.OpenWrite(@"Translations\" + language.ShortName + ".json"))
            {
                await JsonSerializer.SerializeAsync<Language>(stream, language);
            }
        }

        public string Get(string key, params string[] parameters)
        {
            return String.Format(SelectedLanguage.Translations.GetValueOrDefault(key, "n/a @ " + key), parameters);
        }

    }
}
