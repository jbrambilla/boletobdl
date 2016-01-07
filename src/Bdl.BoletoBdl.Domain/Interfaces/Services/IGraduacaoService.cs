using Bdl.BoletoBdl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Interfaces.Services
{
    public interface IGraduacaoService : IDisposable
    {
        Graduacao Add(Graduacao graduacao);
        Graduacao GetById(Guid id);
        IEnumerable<Graduacao> GetAll();
        Graduacao Update(Graduacao graduacao);
        void Remove(Guid id);
    }
}
