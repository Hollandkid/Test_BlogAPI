using BlogApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        private readonly IPostRepository _postRepository;

        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }


        //Get All Items from the Database... Get All the Post
        [HttpGet("getallPost")]
        public IActionResult GetAllPosts()
        {
            var posts = _postRepository.GetAllPost();

            return Ok(posts);
        }


        //Get A Single Item from the Database... Get Signle Post
        [HttpGet("{id}")]
        public IActionResult GetPostById([FromRoute] int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var post = _postRepository.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }



        //Post/Add an Item into the Database... Add a new book to the Database
        [HttpPost("")]
        public IActionResult PostBook([FromBody] PostModel postModel)
        {
            if (postModel == null )
            {
                return NotFound();
            }
            int response = _postRepository.AddPostAsync(postModel);

            return Ok(response);
            //return CreatedAtAction(nameof(GetPostById), new { Id = Id, Controller = "Book" }, Id);
        }


        //Post/Add an Item into the Database... Add a new book to the Database
        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdatePost([FromBody] PostModel postModel, [FromRoute] int Id)
        {
            await _postRepository.UpdatePostAsync(postModel,Id);

            return Ok();
        }



        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeletePost([FromRoute] int Id)
        {
            await _postRepository.RemovePostAsync(Id);
            return Ok();
        }
    }
}
