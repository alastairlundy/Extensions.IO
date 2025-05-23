﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using AlastairLundy.Extensions.IO.Abstractions.Files;
using AlastairLundy.Extensions.IO.Files;

namespace Extensions.IO.Tests.Data
{
    public static class ExeHelpers
    {

        public static string CmdExePath
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    return $"{Environment.SystemDirectory}{Path.DirectorySeparatorChar}cmd.exe";
                }
                
                throw new PlatformNotSupportedException();
            }
        }
        
        public static string WinCalcExePath
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    return $"{Environment.SystemDirectory}{Path.DirectorySeparatorChar}calc.exe";
                }
                
                throw new PlatformNotSupportedException();
            }
        }

    }
}