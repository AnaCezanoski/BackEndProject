using BackEndProject.Domain.DTOs;

namespace BackEndProject.Domain.Model.Users
{
    public interface IUserRepository
    {
        void Add(User user);

        List<UserDTO> Get(int pageNumber, int pageQuantity);

        User? GetById(int id);

        void Update(User user);

        void Delete(User user);
    }
}
