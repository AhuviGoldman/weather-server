using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.services
{
    public interface IWeatherService
    {
        Task<string> GetByCityNameAsync(string cityName);
        Task<string> Get3DaysByCityNameAsync(string cityName);
    }
}
