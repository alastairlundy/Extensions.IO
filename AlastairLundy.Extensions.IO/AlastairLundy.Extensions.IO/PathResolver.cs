using AlastairLundy.Extensions.IO.Abstractions.Paths;
using AlastairLundy.Resyslib.IO.Files;
using AlastairLundy.Resyslib.IO.Paths;

namespace AlastairLundy.Extensions.IO
{
    public class PathResolver : IPathResolver
    {
        public bool DoesPathHaveExtension(string path)
        {
            throw new System.NotImplementedException();
        }

        public PathType GetPathType(string path)
        {
            throw new System.NotImplementedException();
        }

        public bool DoesPathExist(string path)
        {
            throw new System.NotImplementedException();
        }

        public bool IsPathFullyQualified(string path)
        {
            throw new System.NotImplementedException();
        }

        public string ToRelativePath(string path)
        {
            throw new System.NotImplementedException();
        }

        public string ToAbsolutePath(string path)
        {
            throw new System.NotImplementedException();
        }

        public string NormalizePath(string path)
        {
            throw new System.NotImplementedException();
        }

        public FileModel GetFile(string path)
        {
            throw new System.NotImplementedException();
        }

        public string GetFileNameWithoutExtension(string path)
        {
            throw new System.NotImplementedException();
        }

        public string GetFileName(string path)
        {
            throw new System.NotImplementedException();
        }

        public string GetPathExtension(string path)
        {
            throw new System.NotImplementedException();
        }

        public string CombinePaths(string path1, string path2)
        {
            throw new System.NotImplementedException();
        }

        public string ExpandEnvironmentVariablesInPath(string path)
        {
            throw new System.NotImplementedException();
        }
    }
}