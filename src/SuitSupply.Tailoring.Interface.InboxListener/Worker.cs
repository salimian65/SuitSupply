namespace SuitSupply.Tailoring.Interface.InboxListener
{
    public class Worker : BackgroundService
    {
        private readonly App _app;

        public Worker(App app)
        {
            _app = app;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                _app.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return Task.CompletedTask;
           
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
