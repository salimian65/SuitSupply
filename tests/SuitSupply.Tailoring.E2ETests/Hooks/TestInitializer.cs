using System.Diagnostics;
using System.Threading.Tasks;
using SuitSupply.Tailoring.E2ETests.Technical.Persistence.ReadModel;
using SuitSupply.Tailoring.E2ETests.Technical.Persistence.WriteModel;
using TechTalk.SpecFlow;
namespace SuitSupply.Tailoring.E2ETests.Hooks
{
    [Binding]
    public sealed class TestInitializer
    {
        private readonly IReadModelRepository _readModelRepository;
        private readonly IWriteModelRepository _writeModelRepository;
        private static readonly Process Process;


        public TestInitializer(
            IReadModelRepository readModelRepository,
            IWriteModelRepository writeModelRepository)
        {
            _readModelRepository = readModelRepository;
            _writeModelRepository = writeModelRepository;
        }

        static TestInitializer()
        {
            Process = new Process();
        }

        [BeforeScenario]
        public async Task RemoveAllAlteringTasks()
        {
            await _readModelRepository.RemoveAllAlteringTasksAsync();
        }


        [BeforeFeature]
        public static void StartServiceHost()
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "ConfigurationFactory.AppSettings.Tailoring.ExecutableFileName",
                Arguments = "ConfigurationFactory.AppSettings.Tailoring.ExecutableFilePath",
            };
            Process.StartInfo = startInfo;
            Process.Start();

        }

        [AfterFeature]
        public static void StopServiceHost()
        {
            Process.Kill();
            Process.WaitForExit();
            Process.Dispose();
        }

        [AfterScenario]
        public async Task FlushDB(ScenarioContext scenarioContext)
        {
            //teardown
            var tailorNumber = scenarioContext["tailorNumber"].ToString();
            var alteringTaskNumber = scenarioContext["alteringTaskNumber"].ToString();
            await _writeModelRepository.DeleteEventsAsync(tailorNumber);
            await _readModelRepository.RemoveAlteringTaskAsync(alteringTaskNumber);
        }
    }
}
