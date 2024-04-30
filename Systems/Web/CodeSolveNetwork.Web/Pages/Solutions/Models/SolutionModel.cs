namespace CodeSolveNetwork.Web.Pages.Solutions.Models
{
    public class SolutionModel
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public string TaskTitle { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool IsPublished { get; set; }
    }
}
