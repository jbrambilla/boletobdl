using AutoMapper;
using Bdl.BoletoBdl.Application.Interfaces;
using Bdl.BoletoBdl.Application.ViewModels;
using Bdl.BoletoBdl.Domain.Entities;
using Bdl.BoletoBdl.Domain.Interfaces.Services;
using Bdl.BoletoBdl.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Application
{
    public class ContatoTipoAppService : ApplicationService, IContatoTipoAppService
    {

        private readonly IContatoTipoService _contatoTipoService;

        public ContatoTipoAppService(IContatoTipoService contatoTipoService, IUnitOfWork uow)
            : base(uow)
        {
            _contatoTipoService = contatoTipoService;
        }

        public ContatoTipoViewModel Add(ContatoTipoViewModel contatoTipoViewModel)
        {
            BeginTransaction();
            var contatoTipoReturn = _contatoTipoService.Add(Mapper.Map<ContatoTipoViewModel, ContatoTipo>(contatoTipoViewModel));
            contatoTipoViewModel = Mapper.Map<ContatoTipo, ContatoTipoViewModel>(contatoTipoReturn);
            Commit();

            return contatoTipoViewModel;
        }

        public ContatoTipoViewModel GetById(Guid id)
        {
            return Mapper.Map<ContatoTipo, ContatoTipoViewModel>(_contatoTipoService.GetById(id));
        }

        public IEnumerable<ContatoTipoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<ContatoTipo>, IEnumerable<ContatoTipoViewModel>>(_contatoTipoService.GetAll());
        }

        public ContatoTipoViewModel Update(ContatoTipoViewModel contatoTipoViewModel)
        {
            BeginTransaction();
            _contatoTipoService.Update(Mapper.Map<ContatoTipoViewModel, ContatoTipo>(contatoTipoViewModel));
            Commit();

            return contatoTipoViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _contatoTipoService.Remove(id);
            Commit();
        }

        public void Dispose()
        {
            _contatoTipoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
