namespace MakeTopGreatAgain.Data
{
    public class GroupData
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTime StartedAt { get; init; }
        public UserData? Sensei { get; init; }
    }
}
