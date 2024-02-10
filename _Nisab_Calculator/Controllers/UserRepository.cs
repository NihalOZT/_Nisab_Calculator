using _Nisab_Calculator.Models;
using _Nisab_Calculator.Controllers;
using Microsoft.EntityFrameworkCore;

namespace _Nisab_Calculator.Controllers
{
    public class UserRepository:IRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<User> GetByUsername(string username)
        {
            Task<User> user = _dbContext.GetByUsername(username);
            return user;
        }

        public User GetById(int id)
        {
            return _dbContext.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public User Add(User entity)
        {
            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public Comment addComment(int userId, Comment entity)
        {
            userId = GetById(userId).id;
            entity.User = GetById(userId);
            entity.UserId = userId;
            entity.User.comments.Add(entity);
            _dbContext.Comments.Add(entity);
            entity.User = _dbContext.GetByUserId(entity.UserId).Result;
            _dbContext.Update(GetById(userId));
            _dbContext.SaveChanges();
            return entity;
        }

        public void Update(User entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.Users.Remove(entity);
            _dbContext.SaveChanges();
        }
    }

}

