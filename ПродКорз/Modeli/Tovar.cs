using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПродКорз.Modeli
{
		public class Tovar: Tovary
		{
			string _kategoria, _name;
			int _tsena, _poleznost;
			public Tovar(string kategoria, string name, int tsena, int poleznost)
			{
				_kategoria = kategoria;
				_name = name;
				_tsena = tsena;
				_poleznost = poleznost;
			}
			public string Kategoria { get => _kategoria; set => _kategoria = value; }
			public string Name { get => _name; set => _name = value; }
			public int Tsena { get => _tsena; set => _tsena = value; }
			public int Poleznost { get => _poleznost; set => _poleznost = value; }
		}
}
