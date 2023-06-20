﻿using QuestionAPI.Entities;

namespace QuestionAPI.Managers.Contracts;

public interface IQuestion
{
    Task <List<Question>>GetQuestions();
    Task<Question> GetQuestionById(int id);
    Task AddQuestion(Question question);
    Task Update(Question question);
    Task Delete(int question);
    
}