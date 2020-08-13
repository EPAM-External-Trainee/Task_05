using GenericType.Models;

namespace GenericTypeNUnitTest.FileWorkTests.Abstract
{
    public abstract class GenericFileWorker
    {
        protected const string _pathToFiles = @"..\..\..\FileWorkTests\Resources\";
        protected Student Student { get; set; }
        protected StudentsCollection<Student> Students { get; set; }
    }
}