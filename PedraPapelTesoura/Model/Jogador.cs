using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedraPapelTesoura.Model
{
    public class Jogador
    {
        private bool _venceu;
        private string _nome;
        private string _letra;
        private bool _jogou;

        override public string ToString()
        {
            return "Nome:"+ Nome + ",  Letra:"+Letra;
        }
        public bool Venceu
        {
            get
            {
                return _venceu;
            }

            set
            {
                _venceu = value;
            }
        }

        public string Nome
        {
            get
            {
                return _nome;
            }

            set
            {
                _nome = value;
            }
        }
        public string Letra
        {
            get
            {
                return _letra;
            }

            set
            {
                _letra = value;
            }
        }

        public bool Jogou
        {
            get
            {
                return _jogou;
            }

            set
            {
                _jogou = value;
            }
        }
    }
}
