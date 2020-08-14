using BinaryTree.Enums;
using BinaryTree.Interfaces;
using BinaryTree.Models;
using BinaryTree.MyBinaryTree;
using System;

namespace BinaryTree.FileWorker
{
    /// <summary>Class that describes working with files</summary>
    public static class MyFileWorker
    {
        /// <summary><see cref="IFileWorker"/> object</summary>
        private static IFileWorker _fileWorker;

        /// <summary>Serializing the <see cref="BinaryTree{T}"/> to the selected <see cref="SerializationType"/></summary>
        /// <param name="path">Path to file</param>
        /// <param name="binaryTree"><see cref="BinaryTree{T}"/></param>
        /// <param name="type"><see cref="SerializationType"/></param>
        public static void SerializeBinaryTree(string path, BinaryTree<Student> binaryTree, SerializationType type)
        {
            try
            {
                switch (type)
                {
                    case SerializationType.XML: _fileWorker = new XmlWorker(); _fileWorker.SerializeBinaryTree(path, binaryTree); return;
                }
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }
        }

        /// <summary>Deserializing the <see cref="BinaryTree{T}"/> to the selected <see cref="DeserializationType"/></summary>
        /// <param name="path">Path to file</param>
        /// <param name="type"><see cref="DeserializationType"/></param>
        /// <returns><see cref="BinaryTree{T}"/> from file</returns>
        public static BinaryTree<Student> DeserializeBinaryTree(string path, DeserializationType type)
        {
            try
            {
                switch (type)
                {
                    case DeserializationType.XML: _fileWorker = new XmlWorker(); return _fileWorker.DeserializeBinaryTree(path);
                }
            }
            catch(Exception exc)
            {
                throw new Exception(exc.Message);
            }

            return null;
        }
    }
}