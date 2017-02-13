using ReferenceManager.Helpers;

namespace ReferenceManager.DAL
{
    public class Author
    {
        [SuppressDisplay]
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }
}
