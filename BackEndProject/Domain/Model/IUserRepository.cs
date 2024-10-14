using BackEndProject.Domain.DTOs;

namespace BackEndProject.Domain.Model
{
    public interface IUserRepository
    {
        void Add(User user);

        List<UserDTO> Get(int pageNumber, int pageQuant);
    }
}
