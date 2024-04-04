using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialAngelOvalle
{
    internal class Talleres
    {
        int codigo;
        string nombreTaller;
        decimal costo;

        public int Codigo { get => codigo; set => codigo = value; }
        public string NombreTaller { get => nombreTaller; set => nombreTaller = value; }
        public decimal Costo { get => costo; set => costo = value; }
    }
}
