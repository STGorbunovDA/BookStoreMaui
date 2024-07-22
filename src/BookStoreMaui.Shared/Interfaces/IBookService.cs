using BookStoreMaui.Shared.Dtos;

namespace BookStoreMaui.Shared.Interfaces
{
    public interface IBookService
    {
        Task<BookDetailsDto> GetBookAsync(int bookId);
        Task<PagedResult<BookListDto>> GetBooksAsync(int pageNo, int pageSize, string? genreSlug = null);
        Task<PagedResult<BookListDto>> GetBooksByAuthorAsync(int pageNo, int pageSize, string authorSlug);
        Task<GenreDto[]> GetGenresAsync(bool topOnly);
        Task<BookListDto[]> GetPopularBooksAsync(int count, string? genreSlug = null);
        Task<BookListDto[]> GetSimilarBookAsync(int bookId, int count);
    }
}
