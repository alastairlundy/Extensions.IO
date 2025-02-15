﻿/*
    IOExtensions 
    Copyright (c) 2024 Alastair Lundy

    This Source Code Form is subject to the terms of the Mozilla Public
    License, v. 2.0. If a copy of the MPL was not distributed with this
    file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Collections.Generic;

namespace AlastairLundy.Extensions.IO.Files.Removal;

public interface IFileRemover
{
    event EventHandler<string> FileDeleted;
    
    bool TryDeleteFile(string file);

    void DeleteFile(string file);

    void DeleteFiles(IEnumerable<string> files);        
}