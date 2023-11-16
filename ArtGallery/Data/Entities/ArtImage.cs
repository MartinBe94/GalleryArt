using Data.Interface;
using Data.Models;

namespace Data.Entities;

public class ArtImage: IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public User User { get; set; }
}
