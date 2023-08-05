namespace Api_monopoly.Apps.Client.Dtos.Product
{
    public class ProductGetAllDto
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string classes { get; set; }
        public string ImgName { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
    }
}
