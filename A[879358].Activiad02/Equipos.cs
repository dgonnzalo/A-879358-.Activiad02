using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_879358_.Activiad02
{
    class Equipos
    {
        private string _nombreEquipo;
        private int _puntaje;
        private int _numeroDeInscripcion;
        static int contadorDeInscripcion = 0;

        public Equipos ( string nombreDelEquipo)
        {
            this._nombreEquipo = nombreDelEquipo;
            
            this._puntaje = 0;

        }
       

        public string ReflejarNombre
        {
            get { return this._nombreEquipo; }
        }

        public int ReflejarInscripcion
        {
            get { return _numeroDeInscripcion; }
        }

        public int ReflejarPuntaje
        {
            get { return this._puntaje; }

        }

        public void SumarPuntajeporGanar ()
        {
            this._puntaje = this._puntaje + 3;

        }

        public void SumarPuntajeporEmpatar()
        {
            this._puntaje = this._puntaje + 1;

        }

        public void SumarPuntajeporPerder()
        {
            this._puntaje = this._puntaje + 0;

        }

        
    }
}
