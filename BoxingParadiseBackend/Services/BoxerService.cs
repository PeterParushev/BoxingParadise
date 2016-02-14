using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxingParadiseBackend.Services
{
    public class BoxerService : IBoxerService
    {
        private readonly IBoxerRepository m_BoxerRepository;

        public BoxerService(IBoxerRepository boxerRepository)
        {
            m_BoxerRepository = boxerRepository;
        }

        public IList<BoxerDto> GetBoxers()
        {
            return m_BoxerRepository.GetBoxers().Select(x => Mapper.Map<BoxerDto>(x)).ToList();
        }

        public void CreateBoxer(BoxerDto boxer)
        {
            m_BoxerRepository.Persist(Mapper.Map<Boxer>(boxer));
        }

        public void DeleteBoxer(int id)
        {
            m_BoxerRepository.Delete(id);
        }
    }
}