using APITest.Presentation.WebAPI.Models.VM;
using Swashbuckle.AspNetCore.Examples;

namespace APITest.Presentation.WebAPI.SwaggerDocs.Examples
{
    public class UserPutEX : IExamplesProvider
    {
        public object GetExamples()
        {
            return new UserPutVM
            {
                id = 1,
                name = "Luciano",
                age = 33
            };
        }
    }
}
