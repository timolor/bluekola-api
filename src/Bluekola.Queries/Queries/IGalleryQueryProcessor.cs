using System.Threading.Tasks;

namespace Bluekola.Queries.Queries
{
    public interface IGalleryQueryProcessor
    {
        Task<int> SaveToGallery(string imageUrl);

    }
}