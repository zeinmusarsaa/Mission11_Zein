namespace Mission11_Zein.Models.ViewModels
{
    public class BookListViewModels
    {
        public IQueryable<Book> Books { get; set; }

        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
        public IEnumerable<string> Categories { get; set; }
    }
}
