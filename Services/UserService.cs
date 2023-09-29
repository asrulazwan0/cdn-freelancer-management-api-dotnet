using CDNFM.Data.Repositories;
using CDNFM.Dtos;
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

    public async Task<User> CreateUser(UserDto userDto)
    {
        var user = new User {
            Username = userDto.Username,
            Email = userDto.Email,
            PhoneNumber = userDto.PhoneNumber,
            Skillsets = userDto.Skillsets,
            Hobby = userDto.Hobby,
        };

        await userRepository.Add(user);

        return user;
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
            userExists.Username = user.Username;
            userExists.Email = user.Email;
            userExists.PhoneNumber = user.PhoneNumber;
            userExists.Skillsets = user.Skillsets;
            userExists.Hobby = user.Hobby;

            await userRepository.Update(userExists);
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