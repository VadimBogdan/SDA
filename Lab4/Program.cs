using UI;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface.GetInstance().Attach();
            //using (var ctx = new BoardContext())
            //{
            //    var rubric = new Rubric() { RubricName = "Building" };

            //    ctx.Rubrics.Add(rubric);
            //    ctx.SaveChanges();
            //}
        }
    }
}
