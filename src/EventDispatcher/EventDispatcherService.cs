using EventsDispatcher.Tools;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace EventDispatcher
{
    public class EventDispatcherService : IHostedService, IDisposable
    {
        private const long TimerIntervalInMilliseconds = 300;
        private readonly ILogger<EventDispatcherService> _logger;
        private Timer _timer;
        private SqlConnection _connection;
        private ChangeTracker tracker;
        private BusDispatcher busDispatcher;

        public EventDispatcherService(ILogger<EventDispatcherService> logger, IConfiguration configuration)
        {
            _logger = logger;
            var connectionString = configuration.GetConnectionString("EventDispatcherDbConnection");
            _connection = new SqlConnection(connectionString);
            tracker = new ChangeTracker(_connection);
            busDispatcher = new BusDispatcher();
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            //_logger.LogInformation("Timed Hosted Service running.");
            _connection.Open();
            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(TimerIntervalInMilliseconds));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            _timer.Change(Timeout.Infinite, 0);
            try
            {
                var eventItems = tracker.Read();
                foreach (var eventItem in eventItems)
                {
                    busDispatcher.Dispatch(eventItem);
                    tracker.MarkAsProcessed(eventItem.Id);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            finally
            {
                _timer.Change(TimerIntervalInMilliseconds, TimerIntervalInMilliseconds);
            }

            //_logger.LogInformation(
            //    "Timed Hosted Service is working.");
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            //_logger.LogInformation("Timed Hosted Service is stopping.");

            _connection.Close();
            _connection.Dispose();

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
