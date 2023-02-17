using Mately.Identity.API.Domain.User.Model;
using Mately.Identity.API.Repository.Base;

namespace Mately.Identity.API.Repository.User;

public interface IUserRepository : IRepository<ApplicationUser>
{
}