using Microsoft.EntityFrameworkCore;

namespace CoWorkingSystem.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatDate { get; set; } = DateTime.Now;
        public List<UseModel>? ClientUses { get; set; }
    }
}
