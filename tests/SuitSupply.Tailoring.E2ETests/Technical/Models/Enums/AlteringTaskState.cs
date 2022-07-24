namespace SuitSupply.Tailoring.E2ETests.Technical.Models.Enums
{
    public enum AlteringTaskState : byte
    {
        WaitingForPick = 1,
        Picked = 2,
        Unpicked = 3,
        Finished = 4,
    }
}
