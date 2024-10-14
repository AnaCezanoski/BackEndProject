using BackEndProject.Domain.DTOs;
using BackEndProject.Domain.Model;

namespace BackEndProject.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<UserDTO> Get(int pageNumber, int pageQuant)
        {
            return _context.Users.Skip(pageNumber * pageQuant)
                .Take(pageQuant)
                .Select( b =>
                new UserDTO()
                {
                    Id = b.id,
                    Name = b.name,
                    Email = b.email,
                    Password = b.password
                }).ToList();
        }
    }
}
