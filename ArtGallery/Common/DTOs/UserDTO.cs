﻿namespace Common.DTOs;

public class UserDTO
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public List<ArtImageDTO> ArtImageDTOs { get; set; }
}