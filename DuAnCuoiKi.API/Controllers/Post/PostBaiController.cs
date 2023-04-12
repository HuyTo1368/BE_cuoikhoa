using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DuAnCuoiKi.Common.Entities;
using DuAnCuoiKi.BL.APosts;

namespace DuAnCuoiKi.API.Controllers.Post
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostBaiController : ControllerBase
    {
        private IPostBL _postBL;
        public PostBaiController(IPostBL postBL)
        {
            _postBL = postBL;
        }


        [HttpGet]
        [Route("Get")]
        public IActionResult GetPost([FromQuery] Guid _userID, [FromQuery] int start) {
            try
            {
                var result = _postBL.getPost(_userID, start);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet]
        [Route("GetInfor")]
        public IActionResult GetInforPost([FromQuery] Guid _postID)
        {
            try
            {
                var result = _postBL.getInforPost(_postID);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        [Route("UpdatePost")]
        public IActionResult GetPost([FromBody] APost _post)
        {
            try
            {
                var result = _postBL.updatePost(_post);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete]
        [Route("DeletePost")]
        public IActionResult DeletePost([FromQuery] Guid postID)
        {
            try
            {
                var result = _postBL.deletePost(postID);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
