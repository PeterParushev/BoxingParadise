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

        public BoxerService(IBoxerRepository boxerRepository)
        {
            m_BoxerRepository = boxerRepository;
        }

        public async Task<IList<BoxerDto>> GetBoxers()
        {
            return
                (await m_BoxerRepository.GetBoxers().ConfigureAwait(false)).Select(x => Mapper.Map<BoxerDto>(x))
                    .ToList();
        }

        public Task CreateBoxer(BoxerDto boxer)
        {
            return m_BoxerRepository.Persist(Mapper.Map<Boxer>(boxer));
        }

        public Task DeleteBoxer(int id)
        {
            return m_BoxerRepository.Delete(id);
        }
    }
}