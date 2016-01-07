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
    public class GraduacaoService : IGraduacaoService
    {
        private readonly IGraduacaoRepository _graduacaoRepository;

        public GraduacaoService(IGraduacaoRepository graduacaoRepository)
        {
            _graduacaoRepository = graduacaoRepository;
        }


        public Graduacao Add(Graduacao graduacao)
        {
            return _graduacaoRepository.Add(graduacao);
        }

        public Graduacao GetById(Guid id)
        {
            return _graduacaoRepository.GetById(id);
        }

        public IEnumerable<Graduacao> GetAll()
        {
            return _graduacaoRepository.GetAll();
        }

        public Graduacao Update(Graduacao graduacao)
        {
            return _graduacaoRepository.Update(graduacao);
        }

        public void Remove(Guid id)
        {
            _graduacaoRepository.Remove(id);
        }

        public void Dispose()
        {
            _graduacaoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
