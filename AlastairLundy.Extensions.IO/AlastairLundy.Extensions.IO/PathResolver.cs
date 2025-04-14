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
            if (DoesPathExist(path))
            {
                if (path.EndsWith(Path.DirectorySeparatorChar))
                {
                    return PathType.Directory;
                }
                else
                {
                    
                }
            }
        }

        public bool DoesPathExist(string path)
        {
            try
            {
                if (File.Exists(path) || Directory.Exists(path))
                {
                    return true;
                }

                string normalized = NormalizePath(path);
                string absolutePath = ToAbsolutePath(normalized);

                return File.Exists(absolutePath) || Directory.Exists(absolutePath);
            }
            catch
            {
                return false;
            }
        }

        public bool IsPathFullyQualified(string path)
        {
            bool exists = DoesPathExist(path);

            if (exists)
            {
                return path.Equals(ToAbsolutePath(path));
            }
            else
            {
                return false;
            }
        }

        public string ToRelativePath(string path)
        {
            string newPath = NormalizePath(path);
            
            int colonIndex = newPath.IndexOf(":", StringComparison.Ordinal);
            int slashIndex = newPath.IndexOf(@"\", StringComparison.Ordinal);
            
            newPath = newPath.Replace("::", string.Empty);

            if (colonIndex != -1 && slashIndex != -1 && slashIndex == (colonIndex + 1))
            {
                int remainingLength = newPath.Length - colonIndex;

                newPath = newPath.Substring(slashIndex + 1, remainingLength);
            }
            else
            {
                if (colonIndex != -1)
                {
                    int remainingLength = newPath.Length - colonIndex;

                    newPath = newPath.Substring(colonIndex, remainingLength);
                }
                else
                {
                    newPath = newPath.Replace(@"\\?\", string.Empty);
                }
            }
            
            return newPath;
        }

        public string ToAbsolutePath(string path)
        {
            
        }

        public string NormalizePath(string path)
        {
            string newPath = path.Normalize();
            
            newPath = newPath.Replace("//", Path.DirectorySeparatorChar.ToString());
            newPath = newPath.Replace("\\", Path.DirectorySeparatorChar.ToString());
            
            
            return newPath;
        }

        public FileModel GetFile(string path)
        {
            if (DoesPathExist(path))
            {
                return new FileModel(path);
            }
            
            string normalized = NormalizePath(path);
            normalized = ToAbsolutePath(normalized);
            
            return new FileModel(normalized);
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