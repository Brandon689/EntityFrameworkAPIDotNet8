namespace EntityFrameworkAPIDotNet8.Entities
{
    public class Pokemon
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Hp { get; set; } = string.Empty;
    }
}
