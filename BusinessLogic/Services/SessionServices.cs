using AutoMapper;
using BusinessLogic.Dtos;
using BusinessLogic.Interfaces;
using CinemaAppDb.Data;
using CinemaAppDb.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class SessionServices : ISessionService
    {
        private readonly CinemaDbContext _context;
        private readonly IMapper _mapper;

        public SessionServices(CinemaDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // ✅ Створити нову сесію
        public async Task<SessionDTO> CreateSessionAsync(CreateSessionDTO dto)
        {
            // Перевірка, що фільм і зал існують
            var movie = await _context.Films.FindAsync(dto.MovieId);
            if (movie == null)
                throw new Exception($"Movie with id {dto.MovieId} not found.");

            var hall = await _context.Halls.FindAsync(dto.HallId);
            if (hall == null)
                throw new Exception($"Hall with id {dto.HallId} not found.");

            // Мапимо DTO у сутність
            var session = _mapper.Map<Session>(dto);

            // Присвоюємо навігаційні властивості
            session.Movie = movie;
            session.Hall = hall;

            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();

            // Повертаємо DTO
            return _mapper.Map<SessionDTO>(session);
        }

        // ✅ Отримати всі сесії
        public async Task<IEnumerable<SessionDTO>> GetAllSessionsAsync()
        {
            var sessions = await _context.Sessions
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .ToListAsync();

            return _mapper.Map<IEnumerable<SessionDTO>>(sessions);
        }

        // ✅ Отримати одну сесію по ID
        public async Task<SessionDTO?> GetSessionByIdAsync(int id)
        {
            var session = await _context.Sessions
                .Include(s => s.Movie)
                .Include(s => s.Hall)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (session == null)
                return null;

            return _mapper.Map<SessionDTO>(session);
        }

        // ✅ Видалити сесію
        public async Task<bool> DeleteSessionAsync(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
                return false;

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return true;
        }

        // ✅ Оновити сесію
        public async Task<SessionDTO?> UpdateSessionAsync(int id, CreateSessionDTO dto)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
                return null;

            session.StartTime = dto.StartTime;
            session.EndTime = dto.EndTime;
            session.MovieId = dto.MovieId;
            session.HallId = dto.HallId;

            await _context.SaveChangesAsync();

            return _mapper.Map<SessionDTO>(session);
        }
    }
}
