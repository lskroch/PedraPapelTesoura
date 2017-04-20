using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedraPapelTesoura.Model
{
    public class Grupo
    {
        private List<SubGrupo> _listaSubGrupo;
        public Grupo()
        {
            _listaSubGrupo = new List<SubGrupo>();
        }

        public int Indice { get; internal set; }

        public List<SubGrupo> ListaSubGrupo
        {
            get
            {
                return _listaSubGrupo;
            }

            set
            {
                _listaSubGrupo = value;
            }
        }
    }
}
