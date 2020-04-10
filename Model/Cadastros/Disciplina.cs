using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Cadastros
{
    public class Disciplina
    {
        public long? CursoID { get; set; }
        public Curso Curso { get; set; }
        public virtual ICollection<CursoDisciplina> CursosDisciplinas { get; set; }

    }
}
