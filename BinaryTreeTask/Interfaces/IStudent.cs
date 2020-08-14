﻿namespace BinaryTree.Interfaces
{
    /// <summary>Interface that describes information about the student</summary>
    public interface IStudent
    {
        /// <summary>Student name</summary>
        string Name { get; set; }

        /// <summary>Student surname</summary>
        string Surname { get; set; }
    }
}