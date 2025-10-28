namespace Shop.Data.Models
{
    public class Items
    {
        private Items item;

        public Items(Items item = null)
        {
            if (item != null)
            {
                this.Id = item.Id;
                this.Name = item.Name;
                this.Description = item.Description;
                this.Image = item.Image;
                this.Price = item.Price;
                this.Category = this.Category;
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public Categorys Category { get; set; }
    }
}
