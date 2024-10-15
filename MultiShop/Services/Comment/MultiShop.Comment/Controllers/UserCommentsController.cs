using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public UserCommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult UserCommentList()
        {
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateUserComment(UserComment userComment)
        {
            _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("The UserComment has been created successfully");
        }

        [HttpDelete]
        public IActionResult DeleteUserComment(int id)
        {
            var value = _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("The UserComment has been deleted successfully");
        }

        [HttpGet("{id}")]
        public IActionResult GetUserComment(int id)
        {
            var value= _commentContext.UserComments.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateUserComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("The UserComment has been updated successfully");
        }

        [HttpGet("CommentListByProductId")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentContext.UserComments.Where(x=>x.ProductId==id).ToList();
            return Ok(value);
        }


    }
}
