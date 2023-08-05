namespace Api_monopoly.Apps.Client.Dtos
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public bool IsDelete { get; set; }      
        public DateTime UpdateDate { get; set; }    
    }
}
