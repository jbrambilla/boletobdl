using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Validations.Datas
{
    public class MaioridadeValidation
    {
        public static bool Validar(DateTime dataNascimento)
        {
            int anos = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.Month < dataNascimento.Month || (DateTime.Now.Month == dataNascimento.Month && DateTime.Now.Day < dataNascimento.Day))
                anos--;
            return anos >= 18;
        }
    }
}
