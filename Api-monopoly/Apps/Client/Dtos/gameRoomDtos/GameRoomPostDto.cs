namespace Api_monopoly.Apps.Client.Dtos.gameRoomDtos
{
    public class GameRoomPostDto
    {
        public int Id { get; set; }
        public string License { get; set; }
        public int CreatedUser { get; set; }
        public int winnerUser { get; set; }
        public DateTime endDate { get; set; }
        public bool IsDelete { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
