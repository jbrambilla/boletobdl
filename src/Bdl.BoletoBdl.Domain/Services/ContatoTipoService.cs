using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Interfaces.Repository;
using Bdl.BoletoBdl.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Services
{
    public class ContatoTipoService : IContatoTipoService
    {
        private readonly IContatoTipoRepository _contatoTipoRepository;

        public ContatoTipoService(IContatoTipoRepository contatoTipoRepository)
        {
            _contatoTipoRepository = contatoTipoRepository;
        }

        public ContatoTipo Add(ContatoTipo contatoTipo)
        {
            return _contatoTipoRepository.Add(contatoTipo);
        }

        public ContatoTipo GetById(Guid id)
        {
            return _contatoTipoRepository.GetById(id);
        }

        public IEnumerable<ContatoTipo> GetAll()
        {
            return _contatoTipoRepository.GetAll();
        }

        public ContatoTipo Update(ContatoTipo contatoTipo)
        {
            return _contatoTipoRepository.Update(contatoTipo);
        }

        public void Remove(Guid id)
        {
            _contatoTipoRepository.Remove(id);
        }

        public void Dispose()
        {
            _contatoTipoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
