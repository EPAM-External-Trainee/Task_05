using BinaryTree.Enums;
using System;

namespace BinaryTree.Interfaces
{
    public interface ITest
    {
        Subject Subject { get; set; }

        DateTime TestDate { get; set; }

        int Mark { get; set; }
    }
}