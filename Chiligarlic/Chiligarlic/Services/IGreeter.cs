using Microsoft.Extensions.Configuration;

namespace Chiligarlic.Services
{
    public interface IGreeter
    {
        string GetMessageofTheDay();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetMessageofTheDay()
        {
            return _configuration["Greeting"];
        }
    }
}