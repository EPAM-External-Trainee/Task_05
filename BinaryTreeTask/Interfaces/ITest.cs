using BinaryTree.Enums;
using System;

namespace BinaryTree.Interfaces
{
    /// <summary>Interface that describes test info</summary>
    public interface ITest
    {
        /// <summary>Testing <see cref="Enums.Subject"/></summary>
        Subject Subject { get; set; }

        /// <summary>Date and time of the test</summary>
        DateTime TestDate { get; set; }
    }
}