﻿/*
    IOExtensions 
    Copyright (c) 2024-2025 Alastair Lundy

    This Source Code Form is subject to the terms of the Mozilla Public
    License, v. 2.0. If a copy of the MPL was not distributed with this
    file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System.IO;

using AlastairLundy.Extensions.IO.Internal.Localizations;

namespace AlastairLundy.Extensions.IO.Directories;

public static class DirectoryHelper
{
    
    
    /// <summary>
    /// Checks if a Directory is empty or not.
    /// </summary>
    /// <param name="directory">The directory to be searched.</param>
    /// <returns>true if the directory is empty; returns false otherwise.</returns>
    /// <exception cref="DirectoryNotFoundException">Thrown if the directory does not exist.</exception>
    public static bool IsDirectoryEmpty(string directory)
    {
        if (Directory.Exists(directory))
        {
            return Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0;
        }
        else
        {
            throw new DirectoryNotFoundException(Resources.Exceptions_IO_DirectoryNotFound.Replace("{x}", directory));
        }
    }
}