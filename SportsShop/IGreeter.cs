using Microsoft.Extensions.Configuration;

namespace SportsShop
{
    public interface IGreeter
    {
        string getMessageOftheDay();
    }

    public class Greeter : IGreeter
    {
        private IConfiguration _configuration;

        public Greeter(IConfiguration configuration)
        {
            _configuration = configuration;
        } 
        
        public string getMessageOftheDay()
        {
            return _configuration["Greeting"];
        }
    }
}