using CodeSolveNetwork.Context.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSolveNetwork.Context.Entities
{
    public class Solution : BaseEntity
    {
        public virtual Task Task { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public bool IsPublished { get; set; }
    }
}
