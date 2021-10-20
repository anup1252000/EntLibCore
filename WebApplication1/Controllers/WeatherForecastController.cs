using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get()
        {
            int id = 0;
            var connection = new SqlDatabase("Data Source=sqlverify.database.windows.net;Initial Catalog=sqlverify;Persist Security Info=True;User ID=anup;Password=Reenah240986#");

            //var factory = new DatabaseProviderFactory();
            //var db = factory.Create("Data Source=sqlverify.database.windows.net;Initial Catalog=sqlverify;Persist Security Info=True;User ID=anup;Password=Reenah240986#");
            var command = connection.GetSqlStringCommand("select * from dbo.employee");
            IDataReader reader = connection.ExecuteReader(command);
            while (reader.Read())
            {
                id = (int)reader["id"];
            }

            return id;
        }
    }
}
