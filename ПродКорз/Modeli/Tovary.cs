using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПродКорз.Modeli
{
    public interface Tovary
    {
        string Kategoria { get; set; }
        string Name { get; set; }
        int Tsena { get; set; }
        int Poleznost { get; set; }
    }
}
