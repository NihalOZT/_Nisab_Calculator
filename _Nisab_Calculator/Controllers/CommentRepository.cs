namespace _Nisab_Calculator.Controllers
{
    using _Nisab_Calculator.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        public List<Comment> GetAllCommentsWithUsers()
        {
            return _context.Comments
                .Include(c => c.User)
                .ToList();
        }

        public Comment GetById(int id)
        {
            return _context.Comments.FirstOrDefault(c => c.CommentId == id);
        }

        public void Insert(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Comments.Add(comment);
        }

        public void Update(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Comments.Update(comment);
        }

        public void Delete(Comment comment)
        {
            if (comment == null)
                throw new ArgumentNullException(nameof(comment));

            _context.Comments.Remove(comment);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}
