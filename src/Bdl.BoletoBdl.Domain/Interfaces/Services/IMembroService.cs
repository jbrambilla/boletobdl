using Bdl.BoletoBdl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Domain.Interfaces.Services
{
    public interface IMembroService : IDisposable
    {
        Membro Add(Membro membro);
        Membro GetById(Guid id);
        Membro GetByCpf(string cpf);
        Membro GetByEmail(string email);
        IEnumerable<Membro> GetAll();
        Membro Update(Membro membro);
        void Remove(Guid id);

        Endereco AddEndereco(Endereco endereco);
        Endereco UpdateEndereco(Endereco endereco);
        Endereco GetEnderecoById(Guid id);
        void RemoveEndereco(Guid id);

        Contato AddContato(Contato contato);
        Contato UpdateContato(Contato contato);
        Contato GetContatoById(Guid id);
        void RemoveContato(Guid id);
    }
}
