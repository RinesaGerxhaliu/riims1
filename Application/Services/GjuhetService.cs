using AutoMapper;
using RIIMS.Application.DTOs.GjuhaDTOs;
using RIIMS.Application.DTOs.NiveliGjuhesorDTOs;
using RIIMS.Application.Interfaces;
using RIIMS.Domain.Entities;
using RIIMS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIIMS.Application.Services
{
    public class GjuhetService : IGjuhetService
    {
        private readonly IGjuhetRepository _gjuhetRepository;
        private readonly IMapper _mapper;

        public GjuhetService (IGjuhetRepository gjuhetRepository, IMapper mapper)
        {
            _gjuhetRepository = gjuhetRepository;
            _mapper = mapper;
        } 
        public async Task<GjuhetDto> CreateAsync(AddGjuhetDto add)
        {
            var gjuha = _mapper.Map<Gjuhet>(add);
            var createdGjuha = await _gjuhetRepository.CreateAsync(gjuha);

            return _mapper.Map<GjuhetDto>(createdGjuha);
        }

        public async Task<GjuhetDto?> DeleteAsync(Guid id)
        {
            var deletedGjuha = await _gjuhetRepository.DeleteAsync(id);
            return _mapper.Map<GjuhetDto>(deletedGjuha);
        }

        public async Task<List<GjuhetDto>> GetAllAsync()
        {
            var gjuhaList = await _gjuhetRepository.GetAllAsync();
            return _mapper.Map<List<GjuhetDto>>(gjuhaList);
        }

        public async Task<GjuhetDto?> GetByIdAsync(Guid id)
        {
            var gjuha = await _gjuhetRepository.GetByIdAsync(id);
            return _mapper.Map<GjuhetDto>(gjuha);
        }

        public async Task<GjuhetDto?> GetByNameAsync(string name)
        {
            var gjuhet = await _gjuhetRepository.GetByNameAsync(name);
            return _mapper.Map<GjuhetDto>(gjuhet);
        }

        public async Task<GjuhetDto?> UpdateAsync(Guid id, UpdateGjuhetDto update)
        {
            var gjuha = _mapper.Map<Gjuhet>(update);
            var updatedGjuha = await _gjuhetRepository.UpdateAsync(id, gjuha);

            return _mapper.Map<GjuhetDto>(updatedGjuha);
        }
    }
}
