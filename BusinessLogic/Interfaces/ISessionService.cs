using BusinessLogic.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ISessionService
    {
        Task<SessionDTO> CreateSessionAsync(CreateSessionDTO dto);
        Task<IEnumerable<SessionDTO>> GetAllSessionsAsync();
        Task<SessionDTO?> GetSessionByIdAsync(int id);
        Task<SessionDTO?> UpdateSessionAsync(int id, CreateSessionDTO dto);
        Task<bool> DeleteSessionAsync(int id);
        Task<IEnumerable<SessionDTO>> GetFilteredSessionsAsync(SessionFilterDTO filter);
    }
}
