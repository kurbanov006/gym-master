using System.Data;

public record PagedResponse<T> : BaseFilter
{
    public int TotalPages { get; set; }
    public int TotalRecords { get; set; }
    public T? Data { get; set; }
    private PagedResponse(int pageNumber, int pageSize, int totalRecords, T? data) : base(pageNumber, pageSize)
    {
        Data = data;
        TotalRecords = totalRecords;
        TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
    }
    public static PagedResponse<T> Create(int pageNumber, int pageSize, int totalRecords, T? data)
        => new(pageNumber, pageSize, totalRecords, data);
}