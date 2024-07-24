namespace BookStoreMaui.Shared.Dtos
{
    public record BookDetailsDto(int Id, string Title, string Image, 
                                 AuthorDto Author, int NumPages, string Format, 
                                 string Description, GenreDto[] Genres, string? BuyLink)
    {

        //https://ya.ru/search?text=%D0%B2%D0%B2%D0%B2&lr=20039
        public string BookLink => string.IsNullOrWhiteSpace(BuyLink)
                                  ? $"https://ya.ru/search?text={Title.Replace(" ", "+")}+by+{Author.Name.Replace(" ","+")}" 
                                  : BuyLink;
    }
}
