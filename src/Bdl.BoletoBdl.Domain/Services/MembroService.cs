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
    public class MembroService : IMembroService
    {
        private readonly IMembroRepository _membroRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IContatoRepository _contatoRepository;
        private readonly IGraduacaoRepository _graduacaoRepository;
        private readonly IContatoTipoRepository _contatoTipoRepository;

        public MembroService(
            IMembroRepository membroRepository, 
            IEnderecoRepository enderecoRepository, 
            IContatoRepository contatoRepository, 
            IGraduacaoRepository graduacaoRepository, 
            IContatoTipoRepository contatoTipoRepository)
        {
            _membroRepository = membroRepository;
            _enderecoRepository = enderecoRepository;
            _contatoRepository = contatoRepository;
            _graduacaoRepository = graduacaoRepository;
            _contatoTipoRepository = contatoTipoRepository;
        }

        public Membro Add(Membro membro)
        {
            return _membroRepository.Add(membro);
        }

        public Membro GetById(Guid id)
        {
            return _membroRepository.GetById(id);
        }

        public Membro GetByCpf(string cpf)
        {
            return _membroRepository.GetByCpf(cpf);
        }

        public Membro GetByEmail(string email)
        {
            return _membroRepository.GetByEmail(email);
        }

        public IEnumerable<Membro> GetAll()
        {
            return _membroRepository.GetAll();
        }

        public Membro Update(Membro membro)
        {
            return _membroRepository.Update(membro);
        }

        public void Remove(Guid id)
        {
            _membroRepository.Remove(id);
        }

        public Endereco AddEndereco(Endereco endereco)
        {
            return _enderecoRepository.Add(endereco);
        }

        public Endereco UpdateEndereco(Endereco endereco)
        {
            return _enderecoRepository.Update(endereco);
        }

        public Endereco GetEnderecoById(Guid id)
        {
            return _enderecoRepository.GetById(id);
        }

        public void RemoveEndereco(Guid id)
        {
            _enderecoRepository.Remove(id);
        }

        public Contato AddContato(Contato contato)
        {
            return _contatoRepository.Add(contato);
        }

        public Contato UpdateContato(Contato contato)
        {
            return _contatoRepository.Update(contato);
        }

        public Contato GetContatoById(Guid id)
        {
            return _contatoRepository.GetById(id);
        }

        public void RemoveContato(Guid id)
        {
            _contatoRepository.Remove(id);
        }

        public IEnumerable<Graduacao> GetAllGraduacoes()
        {
            return _graduacaoRepository.GetAll();
        }


        public IEnumerable<ContatoTipo> GetAllContatoTipo()
        {
            return _contatoTipoRepository.GetAll();
        }

        public void Dispose()
        {
            _membroRepository.Dispose();
            GC.SuppressFinalize(this);
        }



    }
}
