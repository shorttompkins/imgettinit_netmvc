using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace App.Model
{
    public class Console
    {
        public int ConsoleId { get; set; }
        public string Title { get; set; }
        public string Abbrev { get; set; }

        [JsonIgnore]
        public virtual ICollection<Game> Games { get; set; }

    }
}
