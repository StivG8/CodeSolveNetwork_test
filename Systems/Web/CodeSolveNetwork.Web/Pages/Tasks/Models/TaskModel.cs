namespace CodeSolveNetwork.Web.Pages.Tasks.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        public string ProgrammingLanguage { get; set; }
        public string Category { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }

        public IEnumerable<string> Solutions { get; set; }
    }
}
