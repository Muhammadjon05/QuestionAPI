﻿using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace QuestionAPI.Entities;

public class Question
{
    
    
    [BsonId]
    public int  Id { get; set; }
    public string Title { get; set; }
    public List<Choice> Choices { get; set; }
    public Media Media { get; set; }

    public Question()
    {
        Choices = new List<Choice>();
    }
}