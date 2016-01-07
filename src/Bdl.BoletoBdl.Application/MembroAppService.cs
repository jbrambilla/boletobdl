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
    public class MembroAppService : ApplicationService, IMembroAppService
    {
        private readonly IMembroService _membroService;

        public MembroAppService(IMembroService membroService, IUnitOfWork uow)
            : base(uow)
        {
            _membroService = membroService;
        }

        public MembroEnderecoViewModel Add(MembroEnderecoViewModel membroEnderecoViewModel)
        {
            var membro = Mapper.Map<MembroEnderecoViewModel, Membro>(membroEnderecoViewModel);
            var endereco = Mapper.Map<MembroEnderecoViewModel, Endereco>(membroEnderecoViewModel);
            var contato = Mapper.Map<MembroEnderecoViewModel, Contato>(membroEnderecoViewModel);

            membro.EnderecoList.Add(endereco);
            membro.ContatoList.Add(contato);

            BeginTransaction();
            var membroReturn = _membroService.Add(membro);
            var membroReturnViewModel = Mapper.Map<Membro, MembroEnderecoViewModel>(membroReturn);
            Commit();

            return membroReturnViewModel;
        }

        public MembroViewModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public MembroViewModel GetByCpf(string cpf)
        {
            throw new NotImplementedException();
        }

        public MembroViewModel GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MembroViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Membro>, IEnumerable<MembroViewModel>>(_membroService.GetAll());
        }

        public MembroViewModel Update(MembroViewModel membroViewModel)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel)
        {
            throw new NotImplementedException();
        }

        public EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel)
        {
            throw new NotImplementedException();
        }

        public EnderecoViewModel GetEnderecoById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveEndereco(Guid id)
        {
            throw new NotImplementedException();
        }

        public ContatoViewModel AddContato(ContatoViewModel contatoViewModel)
        {
            throw new NotImplementedException();
        }

        public ContatoViewModel UpdateContato(ContatoViewModel contatoViewModel)
        {
            throw new NotImplementedException();
        }

        public ContatoViewModel GetContatoById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveContato(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _membroService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
