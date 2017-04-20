using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedraPapelTesoura.Model
{
    public class SubGrupo
    {
        private List<Jogador> _listaJogadores;
        public SubGrupo()
        {
            _listaJogadores = new List<Jogador>();
        }

        public int Indice { get; internal set; }

        public List<Jogador> ListaJogadores
        {
            get
            {
                return _listaJogadores;
            }

            set
            {
                _listaJogadores = value;
            }
        }
    }
}
