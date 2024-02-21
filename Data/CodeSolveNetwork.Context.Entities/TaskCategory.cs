using CodeSolveNetwork.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSolveNetwork.Context.Entities
{
    public class TaskCategory : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
