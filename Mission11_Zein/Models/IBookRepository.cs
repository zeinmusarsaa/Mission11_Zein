namespace Mission11_Zein.Models
{
    public interface IBookRepository
    {
        public IQueryable<Book> Books { get; }
    }
}
