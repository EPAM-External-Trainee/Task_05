using GenericType.Models;

namespace GenericTypeNUnitTest.FileWorkTests.Abstract
{
    public abstract class GenericFileWorker
    {
        protected const string _pathToFiles = @"..\..\..\FileWorkTests\Resources\";
        protected const string _binaryExtension = ".bin";
        protected const string _xmlExtension = ".xml";
        protected const string _jsonExtension = ".json";

        protected Student Student { get; set; }

        protected StudentsCollection<Student> Students { get; set; }
    }
}