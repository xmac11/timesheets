using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Timesheets.Models
{
    public class Kati
    {

        [DisplayName("To Noumero tou Kati")]
        public int number { get; set; }
        public string text { get; set; }

        public Kati(int number, string text)
        {
            this.number = number;
            this.text = text;
        }
    }
}
