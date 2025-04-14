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
            throw new System.NotImplementedException();
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

        public string GetFileNameWithoutExtension(string path)
        {
            throw new System.NotImplementedException();
        }

        public string GetFileName(string path)
        {

        }

        public string CombinePaths(string path1, string path2)
        {
            
        }

        public string ExpandEnvironmentVariablesInPath(string path)
        {
            
        }
    }
}