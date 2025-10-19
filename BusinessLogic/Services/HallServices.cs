using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Repositories;
using CinemaAppDb.Data;
using CinemaAppDb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class HallServices
    {
        private readonly IGenericRepository<Hall> _hallRepo;
        private readonly IMapper _mapper;

        public HallServices(IGenericRepository<Hall> hallRepo, IMapper mapper)
        {
            _hallRepo = hallRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HallDTO>> GetAllHallsAsync()
        {
            var halls = await _hallRepo.GetAllAsync();
            return _mapper.Map<IEnumerable<HallDTO>>(halls);
        }

        public async Task<HallDTO?> GetHallByIdAsync(int id)
        {
            var hall = await _hallRepo.GetByIdAsync(id);
            return _mapper.Map<HallDTO>(hall);
        }

        public async Task<HallDTO> CreateHallAsync(CreateHallDTO dto)
        {
            var hall = _mapper.Map<Hall>(dto);
            await _hallRepo.AddAsync(hall);
            await _hallRepo.SaveChangesAsync();
            return _mapper.Map<HallDTO>(hall);
        }

        public async Task<bool> DeleteHallAsync(int id)
        {
            var hall = await _hallRepo.GetByIdAsync(id);
            if (hall == null) return false;
            _hallRepo.Delete(hall);
            await _hallRepo.SaveChangesAsync();
            return true;
        }
    }
}
