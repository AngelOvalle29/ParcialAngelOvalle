using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialAngelOvalle
{
    internal class Inscripciones
    {
        int dni;
        int code;
        DateTime fecha;

        public int Dni { get => dni; set => dni = value; }
        public int Code { get => code; set => code = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
