
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
                    Name = "Loops",
                },
                Language=new ProgrammingLanguage()
                {
                    Name="C#",
                },
                Solutions=new List<Solution>()
                {
                    new Solution()
                    {
                        Code="some code",
                        Description="some description",
                        Dislikes=0,
                        Likes=0,
                        IsPublished=false,
                    }
                }
            },
        };
    }
}
