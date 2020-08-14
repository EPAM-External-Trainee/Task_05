using System;

namespace GenericType.Interfaces
{
    /// <summary>The interface describes the version of the class</summary>
    public interface IClassVersion
    {
        /// <summary>Class version</summary>
        Version Version { get; set; }
    }
}