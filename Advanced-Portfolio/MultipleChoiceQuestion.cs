using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Portfolio
{
    public enum CorrectChoise { A = 1, B, C, D }

    public class MultipleChoiceQuestion
    {
        public string Question { get; set; }

        public string Choise1 { get; set; }

        public string Choise2 { get; set; }

        public string Choise3 { get; set; }

        public string Choise4 { get; set; }

        public CorrectChoise CorrectChoise { get; set; }

    }
}
