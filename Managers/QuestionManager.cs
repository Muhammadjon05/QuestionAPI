using MongoDB.Driver;
using QuestionAPI.Entities;
using QuestionAPI.Managers.Contracts;
using QuestionAPI.Models;

namespace QuestionAPI.Managers;

public class QuestionManager
{
    private readonly IQuestion _questionRepository;

    public QuestionManager(IQuestion questionRepository)
    {
        _questionRepository = questionRepository;
    }
    public async Task<List<Question>> GetQuestions()
    {
        return await _questionRepository.GetQuestions();
    }

    public async Task<Question> GetQuestionById(int id)
    {
        if (id == null)
        {
            return null;
        }
        var question =  await _questionRepository.GetQuestionById(id);
        return question;
    }

    public async  Task<Question> AddQuestion(CreateQuestionModel model)
    {
        var question = ParseToModel(model);
        await _questionRepository.AddQuestion(question:question);
        return question;
    }

    public async Task<Question> Update(CreateQuestionModel model,int questionId)
    {
        var question = await _questionRepository.GetQuestionById(questionId);
        if (question != null)
        {
            question = ParseToModel(model);
            await _questionRepository.Update(question: question);
            return question;
        };
        return null;
    }

    public async Task<string> Delete(int id)
    {
        var question = await _questionRepository.GetQuestionById(id);
        if (question != null)
        {;
            await _questionRepository.Delete(id);
            return "Succes";
        };
        return "Not found";
    }

    private Question ParseToModel(CreateQuestionModel model)
    {
        var question = new Question()
        {
            Title = model.Title,
            Choices = model.Choices,
        };
        if (model.Medias.Photo != null)
        {
            question.Media = new Media()
            {
                PhotoId =  FileHelper.SavingFiles.QuestionImages(model.Medias.Photo, question.Id),
                isExist = true
            };
        }
        else
        {
            question.Media = new Media()
            {
                isExist = false

            };

        }
        return question;
    }

}

