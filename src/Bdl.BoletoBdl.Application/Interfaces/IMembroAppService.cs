using Bdl.BoletoBdl.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Application.Interfaces
{
    public interface IMembroAppService : IDisposable
    {
        MembroEnderecoViewModel Add(MembroEnderecoViewModel membroEnderecoViewModel);
        MembroViewModel GetById(Guid id);
        MembroViewModel GetByCpf(string cpf);
        MembroViewModel GetByEmail(string email);
        IEnumerable<MembroViewModel> GetAll();
        MembroViewModel Update(MembroViewModel membroViewModel);
        void Remove(Guid id);

        EnderecoViewModel AddEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel UpdateEndereco(EnderecoViewModel enderecoViewModel);
        EnderecoViewModel GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        ContatoViewModel AddContato(ContatoViewModel contatoViewModel);
        ContatoViewModel UpdateContato(ContatoViewModel contatoViewModel);
        ContatoViewModel GetContatoById(Guid id);
        void RemoveContato(Guid id);
    }
}
