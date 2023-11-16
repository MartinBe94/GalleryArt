using Data.Context;
using Data.Entities;
using System.Reflection.Metadata;

namespace Data.Service;

public class ImageService
{
    public ArtGalleryContext _context;
    public ImageService(ArtGalleryContext context)
    {
        context = _context;
    }
    public List<ArtImage> GetArtImages()
    {
        {
            // Eager loading using Include method
            List<ArtImage> images = _context.ArtImages
                .Include(images => images.Id)  // Include the Posts navigation property
                .ToList();

            return images;
        }
    }
}
