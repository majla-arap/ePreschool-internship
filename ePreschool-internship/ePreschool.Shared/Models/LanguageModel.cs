using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Shared.Models
{
    public class LanguageModel
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool Default { get; set; }
        public CultureInfo CultureInfo { get; set; }
    }
}
