using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionnaireApi.Domain;

namespace QuestionnaireApi.Controllers;
 
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController(QuestionnarieContext context, IConfiguration configuration) : ControllerBase
    {
        readonly QuestionnarieContext _context = context;
        readonly IConfiguration _config = configuration;
        [HttpGet("question/{questionId}")]
        public async Task<IResult> GetQuestion(int questionId)
        {
            var question = await _context.Questions
                .Include(q=>q.Answers)
                .FirstOrDefaultAsync(q=>q.Id == questionId);

            if (question is not null)
                return TypedResults.Ok(question);
            return TypedResults.BadRequest($"Question with id={questionId} not found");
        }

        [HttpPost("user-answer/{answerId}")]
        public async Task<IResult> SaveAnswer(int answerId)
        {
            _context.Results.Add(new() {  InterviewId = Convert.ToInt32(_config["Interview:Id"]), UserAnswerId = answerId });
            await _context.SaveChangesAsync();
             
            var sequenceNumber = _context.Questions
                 .Include(q => q.Answers)
                 .First(q => q.Answers.Any(a => a.Id.Equals(answerId)))
                 .SequenceNumber;

            var answer = await _context.Answers
                .FirstOrDefaultAsync(a => a.Id.Equals(answerId));

            if (answer is not null)
            {
                var question = _context.Questions
                    .First(q => q.Id.Equals(answer.QuestionId));

                var questionCount = _context.Surveys
                    .Include(s=>s.Questions)
                    .First(s => s.Id.Equals(question.SurveyId)).Questions.Count;

                if(questionCount > question.SequenceNumber)
                    return TypedResults.Ok(question.SequenceNumber + 1);
                return TypedResults.Ok("it is last question");
            }
            return TypedResults.BadRequest();
        }
    }
 
