/*
    AlastairLundy.Extensions.IO 
    Copyright (c) 2024-2025 Alastair Lundy

    This Source Code Form is subject to the terms of the Mozilla Public
    License, v. 2.0. If a copy of the MPL was not distributed with this
    file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using AlastairLundy.Extensions.IO.Abstractions.Paths;

using AlastairLundy.Resyslib.IO.Files;
using AlastairLundy.Resyslib.IO.Paths;

namespace AlastairLundy.Extensions.IO
{
    public class PathResolver : IPathResolver
    {
        
        
        public bool DoesPathHaveExtension(string path)
        {
            if (DoesPathExist(path))
            {
                
            }
            
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns></returns>
        public string CombinePaths(string path1, string path2)
        {
            StringBuilder stringBuilder = new StringBuilder();

            List<string> path1Components =  path1.Split(' ').ToList();
            List<string> path2Components = path2.Split(' ').ToList();

           for(int i = 0; i < path1Components.Count; i++)
           {
               if (path1Components[i].Equals(path2Components[i]))
               {
                   stringBuilder.Append(path1Components[i]);
                   stringBuilder.Append(Path.DirectorySeparatorChar);
                   
                   path1Components.RemoveAt(i);
                   path2Components.RemoveAt(i);
               }
           }

           foreach (string component in path1Components)
           {
               stringBuilder.Append(component);
               stringBuilder.Append(Path.DirectorySeparatorChar);
           }

           foreach (string component in path2Components)
           {
               stringBuilder.Append(component);
               stringBuilder.Append(Path.DirectorySeparatorChar);
           }

           return stringBuilder.ToString();
        }

        public string ExpandEnvironmentVariablesInPath(string path)
        {
            
        }
    }
}