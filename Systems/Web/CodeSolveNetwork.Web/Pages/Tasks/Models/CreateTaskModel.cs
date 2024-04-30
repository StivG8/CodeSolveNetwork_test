namespace CodeSolveNetwork.Web.Pages.Tasks.Models
{
    public class CreateTaskModel
    {
        public Guid ProgrammingLanguageId { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
