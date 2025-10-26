using GymManagementBLL.ViewModels.SessionViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementBLL.Services.Interfaces
{
    internal interface ISessionService
    {
        IEnumerable<SessionViewModel> GetAllSessions();
        bool CreateSession(CreateSessionViewModel createSession);
        SessionViewModel? GetSessionById(int sessionId);
        UpdateSessionViewModel? GetSessionToUpdate(int sessionId);
        bool UpdateSessionDatails(int sessionId, UpdateSessionViewModel sessionToUpdate);
        bool RemoveSession(int sessionId);
    }
}
