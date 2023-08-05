namespace Api_monopoly.Apps.Client.Dtos.GameFieldUserDtos
{
    public class GameFieldUserUpdateDto
    {
        public int Id { get; set; }
        public int User { get; set; }
        public int Room { get; set; }
        public string FieldName { get; set; }
        public DateTime date { get; set; }
    }
}
