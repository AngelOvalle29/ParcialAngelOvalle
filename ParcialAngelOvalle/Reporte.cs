using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialAngelOvalle
{
    internal class Reporte
    {
        string name;
        string workshop;
        DateTime date;

        public string Name { get => name; set => name = value; }
        public string Workshop { get => workshop; set => workshop = value; }
        public DateTime Date { get => date; set => date = value; }
    }
}
