using CDNFM.Data.Repositories;
using CDNFM.Models;

namespace CDNFM.Services;

public class UserService : IUserService
{
    private readonly IRepository<User> userRepository;

    public UserService(IRepository<User> userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<User> GetById(int id)
    {
        return await userRepository.GetById(id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await userRepository.GetAll();
    }

    public async Task<bool> CreateUser(User user)
    {
        try
        {
            await userRepository.Add(user);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> UpdateUser(User user)
    {
        User userExists = await userRepository.GetById(user.Id);
        if (userExists == null)
        {
            return false;
        }

        try
        {
            await userRepository.Update(user);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> DeleteUser(int id)
    {
        try
        {
            User user = await userRepository.GetById(id);

            if (user == null)
            {
                return false;
            }

            await userRepository.Delete(user);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}