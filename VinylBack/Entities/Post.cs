namespace VinylBack.Entities
{
    public class Post
    {
        public int Id { get; set; } 
        public string PosterName { get; set; }
        public string Title { get; set;}
        public string Description { get; set;}

        public List<PostComment> Comments { get; set; }
    }
}
