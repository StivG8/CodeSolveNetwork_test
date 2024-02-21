using CodeSolveNetwork.Context.Entities.Common;

namespace CodeSolveNetwork.Context.Entities
{
    public class Task : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual TaskCategory Category { get; set; }
        public virtual ProgrammingLanguage Language { get; set; }
        public virtual ICollection<Solution> Solutions { get; set; }
    }
}
