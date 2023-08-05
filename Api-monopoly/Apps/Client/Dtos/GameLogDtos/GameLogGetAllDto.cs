namespace Api_monopoly.Apps.Client.Dtos.GameLogDtos
{
    public class GameLogGetAllDto
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Room { get; set; }
        public int dice { get; set; }
        public int dice2 { get; set; }
        public int currentLocation { get; set; }
        public int endLocation { get; set; }
        public DateTime date { get; set; }
        public decimal wallet { get; set; }
        public decimal spent { get; set; }
    }
}
