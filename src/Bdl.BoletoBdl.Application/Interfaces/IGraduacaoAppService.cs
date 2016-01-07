using Bdl.BoletoBdl.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdl.BoletoBdl.Application.Interfaces
{
    public interface IGraduacaoAppService : IDisposable
    {
        GraduacaoViewModel Add(GraduacaoViewModel graduacaoViewModel);
        GraduacaoViewModel GetById(Guid id);
        IEnumerable<GraduacaoViewModel> GetAll();
        GraduacaoViewModel Update(GraduacaoViewModel graduacaoViewModel);
        void Remove(Guid id);
    }
}
