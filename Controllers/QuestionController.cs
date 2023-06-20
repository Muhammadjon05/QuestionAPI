using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuestionAPI.Entities;
using QuestionAPI.Managers;
using QuestionAPI.Models;

namespace QuestionAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class QuestionController : ControllerBase
{
    private readonly QuestionManager _manager;

    public QuestionController(QuestionManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestions()
    {
        return Ok(await _manager.GetQuestions());
    }

    [HttpGet("{questionId}")]
    public async Task<IActionResult> GetQuestionById(int questionId)
    {
        return Ok(await _manager.GetQuestionById(questionId));
    }

    [HttpPost]
    public async Task<IActionResult> AddQuestion([FromForm]CreateQuestionModel model)
    {
        return Ok(await _manager.AddQuestion(model));
    }

    [HttpPost("Update{id}")]
    public async Task<IActionResult> Update(CreateQuestionModel model, int id)
    {

        return Ok(await _manager.Update(model, id));
    }
    [HttpPost("Delete{id}")]
    public async Task<string> Delete(int id)
    {
        return await _manager.Delete(id);
    }
}