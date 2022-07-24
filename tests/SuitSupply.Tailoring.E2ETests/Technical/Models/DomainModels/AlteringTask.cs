using SuitSupply.Tailoring.E2ETests.Technical.Models.Enums;

namespace SuitSupply.Tailoring.E2ETests.Technical.Models.DomainModels
{
    public class AlteringTask
    {
      
        public AlteringTask(string alteringTaskNumber)
        {
            AlteringTaskNumber = alteringTaskNumber;
        }

        public string AlteringTaskNumber { get; set; }
        public AlteringTaskState State { get; set; }
    }
}
