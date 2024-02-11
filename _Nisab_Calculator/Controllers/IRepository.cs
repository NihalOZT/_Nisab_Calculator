using _Nisab_Calculator.Models;
using static _Nisab_Calculator.Models.User;

namespace _Nisab_Calculator.Controllers
{
    public interface IRepository
    {
            User GetById(int id);
            Task<User> GetByUsername(string username);
            IEnumerable<User> GetAll();
            User Add(User entity);
            void Update(User entity);
            void Delete(User entity);
            Comment addComment(AddCommentDto addCommentDto);
    }
}
