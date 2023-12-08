namespace VinylBack.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterName { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
    }
}
