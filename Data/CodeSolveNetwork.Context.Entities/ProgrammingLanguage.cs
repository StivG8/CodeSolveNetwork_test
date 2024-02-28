using CodeSolveNetwork.Context.Entities.Common;

namespace CodeSolveNetwork.Context.Entities
{
    public class ProgrammingLanguage : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
