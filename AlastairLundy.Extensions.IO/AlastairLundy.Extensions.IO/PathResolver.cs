using System;
using System.IO;
    
using AlastairLundy.Extensions.IO.Abstractions.Paths;

using AlastairLundy.Resyslib.IO.Files;
using AlastairLundy.Resyslib.IO.Paths;

namespace AlastairLundy.Extensions.IO
{
    public class PathResolver : IPathResolver
    {
        public bool DoesPathHaveExtension(string path)
        {
            
        }

        public PathType GetPathType(string path)
        {
            
        }

        public bool DoesPathExist(string path)
        {
            
        }

        public bool IsPathFullyQualified(string path)
        {
            bool exists = DoesPathExist(path);

            if (exists)
            {
                
            }
            else
            {
                return false;
            }
        }

        public string ToRelativePath(string path)
        {
            
        }

        public string ToAbsolutePath(string path)
        {
            
        }

        public string NormalizePath(string path)
        {
            
        }

        public FileModel GetFile(string path)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetFileNameWithoutExtension(string path)
        {
            string fileName = GetFileName(path);
            
            int extensionLength = fileName.Length - fileName.LastIndexOf('.');
            
            string extension = fileName.Substring(fileName.LastIndexOf(".",
                StringComparison.Ordinal), extensionLength);
            
           return fileName.Remove(fileName.IndexOf(extension,
               StringComparison.Ordinal), extension.Length);
        }

        
        public string GetFileName(string path)
        {
            string normalizedPath = NormalizePath(path);
            
            string actualPath = ToAbsolutePath(normalizedPath);

            bool hasExtension = DoesPathHaveExtension(actualPath);

            if (hasExtension)
            {
                return actualPath;
            }
            else
            {
                
            }
        }

        public string CombinePaths(string path1, string path2)
        {
            
        }

        public string ExpandEnvironmentVariablesInPath(string path)
        {
            
        }
    }
}