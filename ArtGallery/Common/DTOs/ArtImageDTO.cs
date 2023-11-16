namespace Common.DTOs;

public class ArtImageDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public UserDTO UserDTO { get; set; }
}
