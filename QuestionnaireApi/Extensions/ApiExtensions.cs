
using QuestionnaireApi.Domain;
namespace QuestionnaireApi.Extensions;
    public static class ApiExtensions
    {
        public static void RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<QuestionnarieContext>();
        }
    }
 
