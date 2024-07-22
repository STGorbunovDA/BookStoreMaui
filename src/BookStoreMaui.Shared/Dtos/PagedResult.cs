namespace BookStoreMaui.Shared.Dtos
{
    public record PagedResult<TRecord>(TRecord[] Records, int TotalCount);
}
