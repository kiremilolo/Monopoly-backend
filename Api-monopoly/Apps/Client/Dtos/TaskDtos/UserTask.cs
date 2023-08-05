namespace Api_monopoly.Apps.Client.Dtos.Task
{
    public class UserTask
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public int TaskId { get; set; } 
        public decimal Point { get; set; }  
       public decimal MaxPoint { get; set; }    
        public bool IsDelete { get; set; }
        public DateTime UpdateDate { get; set; }    
    }
}
