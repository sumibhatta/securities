using Securities.API.Models;
using Securities.API.Services;

namespace Securities.API.DB
{
    public class BaseConnection
    {
        protected readonly IConnectionConfig _config;
        public BaseConnection(IConnectionConfig tconfig)
        {
            _config = tconfig;
        }
    }
}
