using Bdl.BoletoBdl.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Application.Interfaces
{
    public interface IContatoTipoAppService : IDisposable
    {
        ContatoTipoViewModel Add(ContatoTipoViewModel contatoTipoViewModel);
        ContatoTipoViewModel GetById(Guid id);
        IEnumerable<ContatoTipoViewModel> GetAll();
        ContatoTipoViewModel Update(ContatoTipoViewModel contatoTipoViewModel);
        void Remove(Guid id);
    }
}
