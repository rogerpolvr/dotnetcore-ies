﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model.Cadastros
{
    public class Instituicao
    {
        public long? InstituicaoID { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }

        #region Relacionamento: Departamento
        public virtual ICollection<Departamento> Departamentos { get; set; }
        #endregion
    }
}
