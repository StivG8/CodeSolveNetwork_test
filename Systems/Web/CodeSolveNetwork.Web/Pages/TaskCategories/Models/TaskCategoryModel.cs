namespace CodeSolveNetwork.Web.Pages.TaskCategories.Models
{
    public class TaskCategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Tasks { get; set; }
    }
}
