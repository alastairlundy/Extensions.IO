﻿/*
    AlastairLundy.Extensions.IO 
    Copyright (c) 2024-2025 Alastair Lundy

    This Source Code Form is subject to the terms of the Mozilla Public
    License, v. 2.0. If a copy of the MPL was not distributed with this
    file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AlastairLundy.Extensions.IO.Files.Concatenation.Abstractions
{
    public interface IFileAppender
    {
        void AppendFile(string fileToBeAppended);
        void AppendFile(FileModel fileToBeAppended);
    
        Task AppendFileAsync(string fileToBeAppended, CancellationToken cancellationToken = default);
        Task AppendFileAsync(FileModel fileToBeAppended, CancellationToken cancellationToken = default);
    
        bool TryAppendFile(string fileToBeAppended);
        
        void AppendFiles(IOrderedEnumerable<string> filesToBeAppended);
        void AppendFiles(IEnumerable<string> filesToBeAppended);
        void AppendFiles(IEnumerable<FileModel> filesToBeAppended);
    
    
        bool TryAppendFiles(IEnumerable<string> filesToBeAppended);

        IEnumerable<string> ToEnumerable();
        string ToString();

        void WriteToFile(string filePath);
        void WriteToFile(FileModel file);

    }
}