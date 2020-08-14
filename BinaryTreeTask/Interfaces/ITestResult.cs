namespace BinaryTree.Interfaces
{
    /// <summary>Interface that describes test result info</summary>
    public interface ITestResult : ITest
    {
        /// <summary>Mark of the test</summary>
        int Mark { get; set; }
    }
}