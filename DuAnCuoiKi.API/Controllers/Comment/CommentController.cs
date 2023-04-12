using DuAnCuoiKi.BL.Comment;
using DuAnCuoiKi.Common.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnCuoiKi.API.Controllers.Comment
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentBL _commentBL;
        public CommentController(ICommentBL commentBL)
        {
            _commentBL = commentBL;
        }

        [HttpGet]
        [Route("GetAllComment")]
        public IActionResult GetAllComment([FromQuery] Guid _postID)
        {
            try
            {
                var result = _commentBL.getAllComment(_postID);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("UpdateComment")]
        public IActionResult GetPost([FromQuery] Guid _commentID, [FromQuery] Guid _postID, [FromBody] string content)
        {
            try
            {
                var result = _commentBL.updateComment(_commentID, _postID, content);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("DeleteComment")]
        public IActionResult DeletePost([FromQuery] Guid _commentID)
        {
            try
            {
                var result = _commentBL.deleteComment(_commentID);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
