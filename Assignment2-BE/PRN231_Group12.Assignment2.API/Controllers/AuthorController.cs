using Microsoft.AspNetCore.Mvc;
using PRN231_Group12.Assignment2.Service.Interfaces;
using PRN231_Group12.Assignment2.Service.Models;
using PRN231_Group12.Assignment2.Service.Models.Models;
using PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Author;
using Service.Models;
using Service.Models.Payload.Responses;

namespace PRN231_Group12.Assignment2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Result<PaginatedList<AuthorModel>>>> GetAuthors([FromQuery] GetAuthorsRequest request)
        {
            var authors = await _service.GetAuthors(request);
            return Ok(Result<PaginatedList<AuthorModel>>.Succeed(authors));
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Result<AuthorModel>>> GetAuthorById([FromRoute]int id)
        {
            var author = await _service.GetAuthorById(id);
            return Ok(Result<AuthorModel>.Succeed(author));
        }

        [HttpPost]
        public async Task<ActionResult<Result<AuthorModel>>> CreateMember([FromBody]CreateAuthorRequest request)
        {
            var author = await _service.CreateAuthor(request);
            return Ok(Result<AuthorModel>.Succeed(author));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Result<AuthorModel>>> UpdateMember([FromBody] UpdateAuthorRequest request, [FromRoute] int id)
        {
            var author = await _service.UpdateAuthor(id, request);
            return Ok(Result<AuthorModel>.Succeed(author));
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Result<AuthorModel>>> DeleteMember([FromRoute] int id)
        {
            var author = await _service.DeleteAuthor(id);
            return Ok(Result<AuthorModel>.Succeed(author));
        }
    }
}