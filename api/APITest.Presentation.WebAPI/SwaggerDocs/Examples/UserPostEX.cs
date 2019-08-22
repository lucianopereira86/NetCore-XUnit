using APITest.Presentation.WebAPI.Models.VM;
using Swashbuckle.AspNetCore.Examples;

namespace APITest.Presentation.WebAPI.SwaggerDocs.Examples
{
    public class UserPostEX : IExamplesProvider
    {
        public object GetExamples()
        {
            return new UserPostVM
            {
                name = "Luciano",
                age = 33
            };
        }
    }
}
