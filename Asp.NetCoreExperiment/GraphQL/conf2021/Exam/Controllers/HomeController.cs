
using Exam.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;

namespace Exam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ExamContext _context;

        public HomeController(ILogger<HomeController> logger, ExamContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet("/InitData")]
        public async Task<bool> ExamPapers()
        {
            try
            {
                #region �������
                var questionType = new QuestionType
                {
                    TypeName = "����ѡ����"
                };
                QuestionType[] questionTypes ={
                questionType,
                new QuestionType
                {
                    TypeName = "����ѡ����"
                },
                new QuestionType
                {
                    TypeName = "�ж���"
                }
             };
                await _context.QuestionTypes.AddRangeAsync(questionTypes);
                await _context.SaveChangesAsync();
                #endregion
                #region ��ӿ�Ŀ����
                var subjectType = new SubjectType
                {
                    TypeName = "C Sharp(C#)"
                };
                SubjectType[] subjectTypes = {
                subjectType,
                new SubjectType
                {
                     TypeName="SQL Server"
                }
            };
                await _context.SubjectTypes.AddRangeAsync(subjectTypes);
                await _context.SaveChangesAsync();
                #endregion
                #region ����Ծ�
                var examPaper = new ExamPaper
                {
                    Title = "C#��������һ��2021��",
                    Memo = "",            
                    CreateTime = DateTime.Now
                };
                ExamPaper[] examPagers ={
                examPaper,
                new ExamPaper
                {
                    Title="C#�����������2021��",
                    Memo="",                 
                    CreateTime=DateTime .Now
                },

                new ExamPaper
                {

                    Title="C#������������2021��",
                    Memo="",                
                    CreateTime=DateTime .Now
                },
            };
                await _context.ExamPapers.AddRangeAsync(examPagers);
                await _context.SaveChangesAsync();
                #endregion
                #region �������
                var question1 = new Question
                {
                    Question1 = "C#����ȡ���ˣ�  ���﷨��",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };

                var question2 = new Question
                {
                    Question1 = @"������MyClass������count���ڣ� �����ԡ�
class MyClass
{
     int i;
     int count { get { return i; } }
}",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };
                var question3 = new Question
                {
                    Question1 = "�� �����ֻ����ѭ������ѭ�������������ʹ�á�",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };
                var question4 = new Question
                {
                    Question1 = "��C#Ӧ�ó����У�һ���ڳ���Ŀ�ͷʹ�ùؼ��֣� �������������ռ䡣",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };
                var question5 = new Question
                {
                    Question1 = "�쳣����ʹ��ʱ��һ�㽫���ܳ����쳣�������ڣ� ��������С�",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };
                var question6 = new Question
                {
                    Question1 = "WinForms�����У������ѡ��ؼ��� Checked����ֵ����Ϊ True����ʾ�� ����",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };
                var question7 = new Question
                {
                    Question1 = "��ADO.NET�У�SqlConnection �����ڵ������ռ��ǣ� ����",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };
                var question8 = new Question
                {
                    Question1 = "�����ĸ������������ֽڸ�ʽ��д�ļ��� ����",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };
                var question9 = new Question
                {
                    Question1 = "C#������ϻ����õ�����ļ�����������������( )��",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };
                var question10 = new Question
                {
                    Question1 = "�����ת���в�����ʽת�����ǣ� ����",
                    QuestionTypeId = questionType.Id,
                    SujectTypeId = subjectType.Id,
                    Score = 10
                };
                Question[] questions = {
               question1,
               question2,
               question3,
               question4,
               question5,
               question6,
               question7,
               question8,
               question9,
               question10
            };
                await _context.Questions.AddRangeAsync(questions);
                await _context.SaveChangesAsync();
                #endregion
                #region ��Ӵ�
                Answer[] answers =
                {
                new Answer
                {
                    QuestionId=question1.Id,
                    IsTrue=false,
                    Sequre="A",
                    Answer1="ѭ��"
                },
                new Answer
                {
                    QuestionId=question1.Id,
                    IsTrue=true,
                    Sequre="B",
                    Answer1="ָ�� "
                },
                new Answer
                {
                    QuestionId=question1.Id,
                    IsTrue=false,
                    Sequre="C",
                    Answer1="�ж� "
                },
                new Answer
                {
                    QuestionId=question1.Id,
                    IsTrue=false,
                    Sequre="D",
                    Answer1="����"
                },
                new Answer
                {
                    QuestionId=question2.Id,
                    IsTrue=true,
                    Sequre="A",
                    Answer1="ֻ��"
                },
                new Answer
                {
                    QuestionId=question2.Id,
                    IsTrue=false,
                    Sequre="B",
                    Answer1="ֻд"
                },
                new Answer
                {
                    QuestionId=question2.Id,
                    IsTrue=false,
                    Sequre="C",
                    Answer1="�ɶ�д"
                },
                new Answer
                {
                    QuestionId=question2.Id,
                    IsTrue=false,
                    Sequre="D",
                    Answer1="���ɶ�����д"
                },
                new Answer
                {
                    QuestionId=question3.Id,
                    IsTrue=true,
                    Sequre="A",
                    Answer1="break"
                },
                new Answer
                {
                    QuestionId=question3.Id,
                    IsTrue=false,
                    Sequre="B",
                    Answer1="goto"
                },
                new Answer
                {
                    QuestionId=question3.Id,
                    IsTrue=false,
                    Sequre="C",
                    Answer1="return "
                },
                new Answer
                {
                    QuestionId=question3.Id,
                    IsTrue=false,
                    Sequre="D",
                    Answer1="continue"
                },
               new Answer
                {
                    QuestionId=question4.Id,
                    IsTrue=false,
                    Sequre="A",
                    Answer1="class"
                },
                new Answer
                {
                    QuestionId=question4.Id,
                    IsTrue=true,
                    Sequre="B",
                    Answer1="using"
                },
                new Answer
                {
                    QuestionId=question4.Id,
                    IsTrue=false,
                    Sequre="C",
                    Answer1="in"
                },
                new Answer
                {
                    QuestionId=question4.Id,
                    IsTrue=false,
                    Sequre="D",
                    Answer1="this"
                },
               new Answer
                {
                    QuestionId=question5.Id,
                    IsTrue=false,
                    Sequre="A",
                    Answer1="click"
                },
                new Answer
                {
                    QuestionId=question5.Id,
                    IsTrue=false,
                    Sequre="B",
                    Answer1="catch"
                },
                new Answer
                {
                    QuestionId=question5.Id,
                    IsTrue=true,
                    Sequre="C",
                    Answer1="try"
                },
                new Answer
                {
                    QuestionId=question5.Id,
                    IsTrue=false,
                    Sequre="D",
                    Answer1="show"
                },
               new Answer
                {
                    QuestionId=question6.Id,
                    IsTrue=true,
                    Sequre="A",
                    Answer1="�ø�ѡ��ѡ��"
                },
                new Answer
                {
                    QuestionId=question6.Id,
                    IsTrue=false,
                    Sequre="B",
                    Answer1="�ø�ѡ�򲻱�ѡ��"
                },
                new Answer
                {
                    QuestionId=question6.Id,
                    IsTrue=false,
                    Sequre="C",
                    Answer1="����ʾ�ø�ѡ����ı���Ϣ"
                },
                new Answer
                {
                    QuestionId=question6.Id,
                    IsTrue=false,
                    Sequre="D",
                    Answer1="��ʾ�ø�ѡ����ı���Ϣ"
                },
               new Answer
                {
                    QuestionId=question7.Id,
                    IsTrue=false,
                    Sequre="A",
                    Answer1="System"
                },
                new Answer
                {
                    QuestionId=question7.Id,
                    IsTrue=false,
                    Sequre="B",
                    Answer1="System.Data"
                },
                new Answer
                {
                    QuestionId=question7.Id,
                    IsTrue=false,
                    Sequre="C",
                    Answer1="System.Data.OleDb"
                },
                new Answer
                {
                    QuestionId=question7.Id,
                    IsTrue=true,
                    Sequre="D",
                    Answer1="System.Data.SqlClient"
                },
               new Answer
                {
                    QuestionId=question8.Id,
                    IsTrue=true,
                    Sequre="A",
                    Answer1="FileStream�� "
                },
                new Answer
                {
                    QuestionId=question8.Id,
                    IsTrue=false,
                    Sequre="B",
                    Answer1="StreamReade"
                },
                new Answer
                {
                    QuestionId=question8.Id,
                    IsTrue=false,
                    Sequre="C",
                    Answer1="BinaryWriter��"
                },
                new Answer
                {
                    QuestionId=question8.Id,
                    IsTrue=false,
                    Sequre="D",
                    Answer1="BinaryReader"
                },
               new Answer
                {
                    QuestionId=question9.Id,
                    IsTrue=true,
                    Sequre="A",
                    Answer1="���롢���롢����"
                },
                new Answer
                {
                    QuestionId=question9.Id,
                    IsTrue=false,
                    Sequre="B",
                    Answer1="���롢���ӡ�����"
                },
                new Answer
                {
                    QuestionId=question9.Id,
                    IsTrue=false,
                    Sequre="C",
                    Answer1="���롢���С��༭"
                },
                new Answer
                {
                    QuestionId=question9.Id,
                    IsTrue=false,
                    Sequre="D",
                    Answer1="�༭�����롢����"
                },
               new Answer
                {
                    QuestionId=question10.Id,
                    IsTrue=false,
                    Sequre="A",
                    Answer1="intת����short"
                },
                new Answer
                {
                    QuestionId=question10.Id,
                    IsTrue=false,
                    Sequre="B",
                    Answer1="shortת����long"
                },
                new Answer
                {
                    QuestionId=question10.Id,
                    IsTrue=false,
                    Sequre="C",
                    Answer1="charת����int"
                },
                new Answer
                {
                    QuestionId=question10.Id,
                    IsTrue=true,
                    Sequre="D",
                    Answer1="bytesת����float"
                },
               new Answer
                {
                    QuestionId=question3.Id,
                    IsTrue=false,
                    Sequre="A",
                    Answer1=""
                }
            };
                await _context.Answers.AddRangeAsync(answers);
                await _context.SaveChangesAsync();
                #endregion

                #region ����û�
                var user = new User
                {
                    Name = "����",
                    UserName = "zhangsan",
                    Password = "@f232fd(feef",
                    Salt = "sfw32==",
                    Tel = "13456879562"
                };
                User[] users =
                {
                    user,
                    new User
                    {
                        Name = "����",
                        UserName = "lisi",
                        Password = "@22ewfd(feef",
                        Salt = "42syt==",
                        Tel = "13456879562"
                    }
                };
                await _context.Users.AddRangeAsync(users);
                await _context.SaveChangesAsync();
                #endregion
                #region �û�
                UserExam[] userExams =
                {
                    new UserExam
                    {
                        UserId=user.Id,
                        ExamPapgerId=examPaper.Id,
                        BeginTime=DateTime .Parse("2021-12-01"),
                        EndTime=DateTime .Parse("2022-12-01"),
                    }
                };
                await _context.UserExams.AddRangeAsync(userExams);
                await _context.SaveChangesAsync();
                #endregion
                #region �Ծ�����
                examPaper.Questions.Add(question1);
                examPaper.Questions.Add(question2);
                examPaper.Questions.Add(question3);
                examPaper.Questions.Add(question4);
                examPaper.Questions.Add(question5);
                examPaper.Questions.Add(question6);
                examPaper.Questions.Add(question7);
                examPaper.Questions.Add(question8);
                examPaper.Questions.Add(question9);
                examPaper.Questions.Add(question10);

                foreach (var userExam in userExams)
                {
                    examPaper.UserExams.Add(userExam);
                }
                await _context.SaveChangesAsync();
                #endregion

                return true;
            }
            catch (Exception exc)
            {
                _logger.LogCritical(exc, exc.Message);
                return false;
            }
        }

    }

    class HomeControllerTerst
    {
        public void FFF()
        {
            var ContextOptions = new DbContextOptionsBuilder<ExamContext>()
               .UseSqlite(CreateInMemoryDatabase())
               .Options;
            var context = new ExamContext(ContextOptions);
            var homeCon = new HomeController(null, context);
        }
        DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            return connection;
        }
    }
}