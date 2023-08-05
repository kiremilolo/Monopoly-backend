namespace Api_monopoly.Apps.ManageApi.Dtos.Task
{
    public class TaskUpdateDto
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public decimal Point { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
