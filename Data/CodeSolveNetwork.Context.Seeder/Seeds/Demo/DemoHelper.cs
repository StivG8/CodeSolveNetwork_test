
using CodeSolveNetwork.Context.Entities;

namespace CodeSolveNetwork.Context.Seeder.Seeds.Demo
{
    public class DemoHelper
    {
        public IEnumerable<Entities.Task> GetTasks = new List<Entities.Task>
        {
            new Entities.Task()
            {
                Uid = Guid.NewGuid(),
                Title = "Task to solve problems",
                Description="Some description",
                Category = new TaskCategory()
                {
                    Uid = Guid.NewGuid(),
                    Name = "Loops"
                }
            },
        };
    }
}
