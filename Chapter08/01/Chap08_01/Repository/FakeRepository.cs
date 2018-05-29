using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chap08_01.Models;

namespace Chap08_01.Repository
{
    public class FakeRepository
    {
        public FakeRepository()
        {
            Comments = FakeComments();
        }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Comment> GetComments()
        {
            return Comments;
        }

        public void AddComment(Comment comment)
        {
            Comments.ToList().Add(comment);
        }
        private IEnumerable<Comment> FakeComments()
        {
            return new List<Comment>
            {
                new Comment
                {
                    UserName = "aroraG",
                    Description = "This is a first comment."
                },
                new Comment
                {
                    UserName = "aroraG",
                    Description = "This is a second comment."
                },
                new Comment
                {
                    UserName = "aroraG",
                    Description = "This is a third comment."
                },
                new Comment
                {
                    UserName = "aroraG",
                    Description = "<script>alert('hi!');</script>"
                }
            };
        }
    }
}
