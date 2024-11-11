using BlogPlatform.Models.Request;
using BlogPlatform.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("api/[controller]")]
public class CommentsController : ControllerBase
{
    private static List<CommentResponse> _comments = new List<CommentResponse>();

    [HttpPost]
    public IActionResult AddComment(CommentRequest commentRequest)
    {
        var comment = new CommentResponse
        {
            Id = Guid.NewGuid(),
            Content = commentRequest.Content,
            PostId = commentRequest.PostId,
            UserId = commentRequest.UserId
        };

        _comments.Add(comment);
        return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == id);
        if (comment == null)
        {
            return NotFound();
        }

        return Ok(comment);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_comments);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var comment = _comments.FirstOrDefault(c => c.Id == id);
        if (comment == null)
        {
            return NotFound();
        }

        _comments.Remove(comment);
        return NoContent();
    }
}