using CDNFM.Dtos;
using CDNFM.Models;

namespace CDNFM.Services;

public interface IUserService
{
    Task<User> GetById(int id);
    Task<IEnumerable<User>> GetAll();
    Task<User> CreateUser(UserDto user);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(int id);
}