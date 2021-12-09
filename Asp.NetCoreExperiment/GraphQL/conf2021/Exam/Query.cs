﻿using Exam.Models;
namespace Exam;

public class Query
{
    [Serial]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<ExamPaper> GetExamPaper([Service] ExamContext context) =>
        context.ExamPapers;
    [UsePaging(MaxPageSize = 3)]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Question> GetQuestions([Service] ExamContext context) =>
    context.Questions;


    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<IDescribe> GetDescribes()
    {
        return new List<IDescribe>
        {
            new SubjectTypeDescribe
            {
                Id = 1,
                Describe ="问题科目类型"
            },
            new QuestionTypeDescribe
            {
                Id = 2,
                Describe ="试题类型 "
            },

        }.AsQueryable();
    }
}

public interface IDescribe
{
    int Id { get; set; }
    string? Describe { get; set; }
}
public class SubjectTypeDescribe : IDescribe
{
    public int Id { get; set; }
    public string? Describe { get; set; }
}
public class QuestionTypeDescribe : IDescribe
{
    public int Id { get; set; }
    public string? Describe { get; set; }
    public string[] Types { get; set; } = new string[] {"单选题","多选题","判断题" };
}
