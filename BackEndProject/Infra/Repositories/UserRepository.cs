using BackEndProject.Domain.DTOs;
using BackEndProject.Domain.Model.Users;

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

        public List<UserDTO> Get(int pageNumber, int pageQuantity)
        {
            return _context.Users.Skip(pageNumber * pageQuantity)
                .Take(pageQuantity)
                .Select(b =>
                new UserDTO()
                {
                    Id = b.id,
                    Name = b.name,
                    Email = b.email,
                    Password = b.password
                }).ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(b => b.id == id);
        }

        public void Update(User user)
        {
            var existingUser = _context.Users.Find(user.id);
            if(existingUser == null)
            {
                throw new ArgumentNullException(nameof(user), "User not found.");
            }

            existingUser.name = user.name;
            existingUser.email = user.email;
            existingUser.password = user.password;

            _context.Users.Update(existingUser); // Atualiza o usuário no contexto
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }


        public void Delete(User user)
        {
            var existingUser = _context.Users.Find(user.id);
            if(existingUser != null)
            {
                _context.Users.Remove(existingUser);
                _context.SaveChanges();
            }
        }

        public User? Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
