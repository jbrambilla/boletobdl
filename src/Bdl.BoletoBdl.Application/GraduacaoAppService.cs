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
    public class GraduacaoAppService : ApplicationService, IGraduacaoAppService
    {
        private readonly IGraduacaoService _graduacaoService;

        public GraduacaoAppService(IGraduacaoService graduacaoService, IUnitOfWork uow)
            : base(uow)
        {
            _graduacaoService = graduacaoService;
        }

        public GraduacaoViewModel Add(GraduacaoViewModel graduacaoViewModel)
        {
            BeginTransaction();
            var graduacaoReturn = _graduacaoService.Add(Mapper.Map<GraduacaoViewModel, Graduacao>(graduacaoViewModel));
            graduacaoViewModel = Mapper.Map<Graduacao, GraduacaoViewModel>(graduacaoReturn);
            Commit();

            return graduacaoViewModel;
        }

        public GraduacaoViewModel GetById(Guid id)
        {
            return Mapper.Map<Graduacao, GraduacaoViewModel>(_graduacaoService.GetById(id));
        }

        public IEnumerable<GraduacaoViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Graduacao>, IEnumerable<GraduacaoViewModel>>(_graduacaoService.GetAll());
        }

        public GraduacaoViewModel Update(GraduacaoViewModel graduacaoViewModel)
        {
            BeginTransaction();
            _graduacaoService.Update(Mapper.Map<GraduacaoViewModel, Graduacao>(graduacaoViewModel));
            Commit();
            return graduacaoViewModel;
        }

        public void Remove(Guid id)
        {
            BeginTransaction();
            _graduacaoService.Remove(id);
            Commit();

        }

        public void Dispose()
        {
            _graduacaoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
