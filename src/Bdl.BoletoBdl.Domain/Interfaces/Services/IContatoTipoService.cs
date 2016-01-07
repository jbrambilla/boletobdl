using Bdl.BoletoBdl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Interfaces.Services
{
    public interface IContatoTipoService : IDisposable
    {
        ContatoTipo Add(ContatoTipo contatoTipo);
        ContatoTipo GetById(Guid id);
        IEnumerable<ContatoTipo> GetAll();
        ContatoTipo Update(ContatoTipo contatoTipo);
        void Remove(Guid id);
    }
}
