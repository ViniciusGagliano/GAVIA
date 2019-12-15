using Entity.Importacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Acompanhamento
{
    public class SinistroEntity
    {
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public RegistroEntity Registro { get; set; }
        public SeguradoEntity Segurado { get; set; }
        public NotaDebitoEntity NotaDebito { get; set; }
        public PatrocinioEntity Patrocinio { get; set; }
        public TipoSinistroEntity TipoSinistro { get; set; }
    }
}
