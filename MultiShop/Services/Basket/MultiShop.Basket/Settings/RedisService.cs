using StackExchange.Redis;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        public string _host { get; set; }
        public int _port { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect()
        {
            try
            {
                _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to connect to Redis", ex);
            }
        }

        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
    }
}
