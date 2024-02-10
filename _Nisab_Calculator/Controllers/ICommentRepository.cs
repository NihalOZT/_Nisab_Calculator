namespace _Nisab_Calculator.Controllers
{
    using _Nisab_Calculator.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface ICommentRepository
    {
        IEnumerable<Comment> GetAll();
        List<Comment> GetAllCommentsWithUsers();
        Comment GetById(int id);
        void Insert(Comment comment);
        void Update(Comment comment);
        void Delete(Comment comment);
        void SaveChanges();
    }

}
