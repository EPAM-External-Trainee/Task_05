using GenericType.Models;

namespace GenericTypeNUnitTest.FileWorkTests.Abstract
{
    public abstract class GenericFileWorker
    {
        protected const string _pathToFiles = @"..\..\..\FileWorkTests\Resources\";
        protected const string _binaryFileExtension = ".bin";
        protected const string _xmlFileExtension = ".xml";
        protected const string _jsonFileExtension = ".json";

        protected Student Student { get; set; }

        protected StudentsCollection<Student> Students { get; set; }
    }
}