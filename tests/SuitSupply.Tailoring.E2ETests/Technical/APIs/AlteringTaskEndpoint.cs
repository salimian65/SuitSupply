using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using SuitSupply.Tailoring.E2ETests.Technical.Models;
using SuitSupply.Tailoring.E2ETests.Technical.Models.Commands;
using SuitSupply.Tailoring.E2ETests.Technical.Models.DomainModels;
using SuitSupply.Tailoring.E2ETests.Technical.Models.Dtos;

namespace SuitSupply.Tailoring.E2ETests.Technical.APIs
{
    public class AlteringTaskEndpoint : IAlteringTaskEndpoint
    {
        private readonly RestClient _client;

        public AlteringTaskEndpoint(AppSettings appSettings)
        {
            _client = new RestClient(appSettings.OMSServiceHost.Url);
        }

        public async Task<List<AlteringTask>> Get()
        {
            var request = new RestRequest($"api/v1/AlteringTask", Method.Get);
            var restResponse = await _client.GetAsync<List<AlteringTask>>(request);
            return restResponse;
        }

        public async Task Pick(PickAlteringTaskCommand command)
        {
            var request = new RestRequest($"api/v1/AlteringTask/pick", Method.Put);
            await _client.PutAsync(request);

        }

        public async Task Finish(FinishAlteringTaskCommand command)
        {
            var request = new RestRequest($"api/v1/AlteringTask/finish", Method.Put);
            await _client.GetAsync<AlteringTaskDto>(request);

        }
    }
}
