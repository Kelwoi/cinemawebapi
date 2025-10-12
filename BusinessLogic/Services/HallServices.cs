using AutoMapper;
using BusinessLogic.Dtos;
using CinemaAppDb.Data;
using CinemaAppDb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class HallServices
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public HallServices(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HallDTO>> GetAllHallsAsync()
        {
            var halls = await _context.Halls.ToListAsync();
            return _mapper.Map<IEnumerable<HallDTO>>(halls);
        }

        public async Task<HallDTO?> GetHallByIdAsync(int id)
        {
            var hall = await _context.Halls.FindAsync(id);
            return hall == null ? null : _mapper.Map<HallDTO>(hall);
        }

        public async Task<HallDTO> CreateHallAsync(CreateHallDTO dto)
        {
            var hall = _mapper.Map<Hall>(dto);
            _context.Halls.Add(hall);
            await _context.SaveChangesAsync();
            return _mapper.Map<HallDTO>(hall);
        }

        public async Task<HallDTO?> UpdateHallAsync(int id, CreateHallDTO dto)
        {
            var hall = await _context.Halls.FindAsync(id);
            if (hall == null)
                return null;

            hall.Name = dto.Name;
            hall.Capacity = dto.Capacity;

            await _context.SaveChangesAsync();
            return _mapper.Map<HallDTO>(hall);
        }

        public async Task<bool> DeleteHallAsync(int id)
        {
            var hall = await _context.Halls.FindAsync(id);
            if (hall == null)
                return false;

            _context.Halls.Remove(hall);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
