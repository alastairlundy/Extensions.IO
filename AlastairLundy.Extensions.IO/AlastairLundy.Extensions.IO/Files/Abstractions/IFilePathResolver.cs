﻿using System.IO;

namespace AlastairLundy.Extensions.IO.Files.Abstractions;

public interface IFilePathResolver
{
    /// <summary>
    /// Resolves the file path to a specific file.
    /// </summary>
    /// <param name="inputFilePath">The input file path to resolve.</param>
    /// <param name="outputFilePath">The resolved file path.</param>
    /// <exception cref="FileNotFoundException">Thrown if the input file path is null or empty.</exception>
    void ResolveFilePath(string inputFilePath, out string outputFilePath);
}