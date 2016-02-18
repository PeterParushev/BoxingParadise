using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services
{
    public class BoxerService : IBoxerService
    {
        private readonly IBoxerRepository m_BoxerRepository;
        private readonly IAdministratorService m_AdministratorService;

        public BoxerService(IBoxerRepository boxerRepository, IAdministratorService administratorService)
        {
            m_BoxerRepository = boxerRepository;
            m_AdministratorService = administratorService;
        }

        public async Task<IList<BoxerDto>> GetBoxers()
        {
            return
                (await m_BoxerRepository.GetBoxers().ConfigureAwait(false)).Select(x => Mapper.Map<BoxerDto>(x))
                    .ToList();
        }

        public async Task CreateBoxer(BoxerDto boxer, string adminKey)
        {
            if (await m_AdministratorService.IsProvidedAdministratorKeyValid(adminKey))
            {
                await m_BoxerRepository.Persist(Mapper.Map<Boxer>(boxer));
            }
        }

        public async Task DeleteBoxer(int id, string adminKey)
        {
            if (await m_AdministratorService.IsProvidedAdministratorKeyValid(adminKey))
            {
                await m_BoxerRepository.Delete(id);
            }
        }
    }
}