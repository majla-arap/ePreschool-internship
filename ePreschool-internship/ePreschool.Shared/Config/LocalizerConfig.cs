using ePreschool.Shared.Models;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Shared.Config
{
    public static class LocalizerConfig
    {
        public static readonly List<LanguageModel> SupportedLanguages = new List<LanguageModel>
        {
            new LanguageModel
            {
                Default = true,
                Title = "Bosnian",
                CultureInfo = new CultureInfo("bs-Latn-BA"),
                Icon = "assets/media/flags/bosnia-and-herzegovina.svg"
            },
            new LanguageModel
            {
                Default = false,
                Title = "English",
                CultureInfo = new CultureInfo("en-US"),
                Icon = "assets/media/flags/united-kingdom.svg"
            }
        };

        public const string TranslationsRelativePath = "Resources/Translations";
        public static readonly LanguageModel DefaultLanguage = SupportedLanguages.Single(sl => sl.Default);
    }
}
