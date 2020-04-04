using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IES.Models
{
    public class Departamento
    {
        public long? DepartamentoID { get; set; }
        public string Nome { get; set; }

        #region Relacionamento: Instituição
        public long? InstituicaoID { get; set; }
        public Instituicao Instituicao { get; set; }
        #endregion
    }
}
