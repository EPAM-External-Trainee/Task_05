using GenericType.Models;
using GenericType.Serializers;

namespace GenericTypeNUnitTest.FileWorkTests.Abstract
{
    /// <summary>A class containing general information for testing methods of <see cref="MyFileWorker{T}"/> class</summary>
    public abstract class GenericFileWorker
    {
        /// <summary>Path to files</summary>
        protected const string _pathToFiles = @"..\..\..\FileWorkTests\Resources\";

        /// <summary>Binary file extension</summary>
        protected const string _binaryFileExtension = ".bin";

        /// <summary>XML file extension</summary>
        protected const string _xmlFileExtension = ".xml";

        /// <summary>JSON file extension</summary>
        protected const string _jsonFileExtension = ".json";

        /// <summary><see cref="Student"/> object</summary>
        protected Student Student { get; set; }

        /// <summary><see cref="StudentsCollection{T}"/> object</summary>
        protected StudentsCollection<Student> Students { get; set; }
    }
}