using System.Threading.Tasks;
using SuitSupply.Tailoring.E2ETests.Technical.APIs;
using SuitSupply.Tailoring.E2ETests.Technical.Models.DomainModels;
using SuitSupply.Tailoring.E2ETests.Technical.Models.Enums;
using SuitSupply.Tailoring.E2ETests.Technical.Persistence.ReadModel;
using SuitSupply.Tailoring.E2ETests.Technical.Persistence.WriteModel;
using TechTalk.SpecFlow;
using FluentAssertions;
using SuitSupply.Tailoring.E2ETests.Technical.Models.Commands;
using SuitSupply.Tailoring.E2ETests.Technical.Utilities;
namespace SuitSupply.Tailoring.E2ETests.BusinessFlow
{
    [Binding]
    public class PickAlteringTaskSteps
    {

        private string _tailorNumber;
        private string _alteringTaskNumber;

        private readonly ScenarioContext _scenarioContext;
        private readonly IReadModelRepository _readModelRepository;
        private readonly IWriteModelRepository _writeModelRepository;
        private readonly IAlteringTaskEndpoint _alteringTaskEndpoint;
        public PickAlteringTaskSteps(ScenarioContext scenarioContext,
            IReadModelRepository readModelRepository,
            IWriteModelRepository writeModelRepository,
            IAlteringTaskEndpoint alteringTaskEndpoint)
        {
            _scenarioContext = scenarioContext;
            _readModelRepository = readModelRepository;
            _writeModelRepository = writeModelRepository;
            _alteringTaskEndpoint = alteringTaskEndpoint;
        }

        [Given(@"Mehrdad as a Tailor with ""([^""]*)")]
        public async Task GivenMehrdadAsATailorWith(string tailorNumber)
        {
            var randomTailorNumber = StringExtensions.GetRandomNumber();
            _tailorNumber = tailorNumber + randomTailorNumber;
            _scenarioContext["tailorNumber"] = _tailorNumber;
            var tailor = new Tailor(_tailorNumber);
            await _writeModelRepository.CreateTailor(tailor);
            await _readModelRepository.AddTailor(tailor);
        }

        [Given(@"AlteringTask with ""([^""]*)"" is Waiting for Pick")]
        public async Task GivenAlteringTaskWithIsWaitingForPick(string alteringTaskNumber)
        {
            var randomAlteringTaskNumber = StringExtensions.GetRandomNumber();
            _alteringTaskNumber = alteringTaskNumber + randomAlteringTaskNumber;
            _scenarioContext["alteringTaskNumber"] = _alteringTaskNumber;
            var alteringTask = new AlteringTask(_alteringTaskNumber);
            await _writeModelRepository.CreateAlteringTask(alteringTask);
            await _readModelRepository.AddAlteringTask(alteringTask);
        }

        [When(@"Mehrdad has a request for Picking the AlteringTask")]
        public async Task WhenMehrdadHasARequestForPickingTheAlteringTask()
        {
            await Task.Delay(2000);
            var dd = new PickAlteringTaskCommand
            {
                TailorNumber = _scenarioContext["tailorNumber"].ToString(),
                AlteringTask = _scenarioContext["alteringTaskNumber"].ToString(),
            };
            //Api call
            await _alteringTaskEndpoint.Pick(dd);
        }

        [Then(@"Mehrdad should see the AlteringTask as Picked")]
        public async Task ThenMehrdadShouldSeeTheAlteringTaskAsPicked(decimal expectedTotalOfT2)
        {
            await Task.Delay(2000);
            var pickedAlteringTask = await _readModelRepository.GetAlteringTask(_scenarioContext["alteringTaskNumber"].ToString());
            pickedAlteringTask.State.Should().Be(AlteringTaskState.Picked);
        }


    }
}
