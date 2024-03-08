namespace CodeSolveNetwork.Web.Pages.ProgrammingLanguages.Models
{
    public class ProgrammingLanguageModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<string> Tasks { get; set; }
    }
}
