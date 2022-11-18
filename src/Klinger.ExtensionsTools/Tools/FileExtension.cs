using Klinger.ExtensionsTools.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Klinger.ExtensionsTools.Tools
{
    public static class FileExtension
    {
        public static string Folder { get; private set; } = "temp";
        public static string WwwRoot { get; private set; } = "wwwroot";
        public static string CurrentDirectory { get; private set; } = CreateBaseDirectory();

        /* Description
         * Configuration ServiceCollection
         */
        public static void SetFileExtension(this IServiceCollection service,
                                            bool wwwRoot = true,
                                            string directory = null,
                                            string folder = "temp")
        {
            if (!wwwRoot)
            {
                CurrentDirectory = directory;
            }
            Folder = folder;
            CreateFolder();
        }

        /* Description
         * Salve File
         */
        public static async Task<string> SaveFile(this IFormFile file, string imgPrefixo)
        {
            if (file is null || file.Length <= 0) return string.Empty;
            var name = imgPrefixo + Path.GetExtension(file.FileName);
            var pathtemp = Path.Combine(CurrentDirectory, Folder, name);

            if (File.Exists(pathtemp))
            {
                return Folder + "/" + name;
            }
            using (var stream = new FileStream(pathtemp, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Folder + "/" + name;
        }

        /* Description
         * Obter File
         */
        public static FileStream GetFile(this string path)
        {
            if (string.IsNullOrEmpty(path)) throw new NullReferenceException("Path is null declared");

            var pathtemp = Path.Combine(CurrentDirectory, path);

            if (!File.Exists(pathtemp)) return null;

            return File.OpenRead(pathtemp);
        }

        /* Description
         * Mover file
         */
        public static bool MoveFile(this string path, string newPath)
        {
            if (string.IsNullOrEmpty(path)) throw new NullReferenceException("Path is null declared");

            path = Path.Combine(CurrentDirectory, path);
            newPath = Path.Combine(CurrentDirectory, newPath);

            if (!File.Exists(path)) throw new DomainToolsException("Path not found");
            if (!File.Exists(newPath)) throw new DomainToolsException("New Path not found");

            File.Move(path, newPath);
            return true;
        }

        /* Description
         * Deletar File
         */
        public static bool DeleteFile(this string path)
        {
            if (string.IsNullOrEmpty(path)) throw new NullReferenceException("Path is null declared");

            var pathtemp = Path.Combine(CurrentDirectory, path);
            if (!File.Exists(pathtemp)) return false;

            File.Delete(pathtemp);
            return true;
        }

        private static string CreateBaseDirectory() =>
            Path.Combine(Directory.GetCurrentDirectory(), WwwRoot);
        private static void CreateFolder()
        {
            if (!Directory.Exists(CurrentDirectory))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), WwwRoot));
            }

            if (!Directory.Exists(Path.Combine(CurrentDirectory, Folder)))
            {
                Directory.CreateDirectory(Path.Combine(CurrentDirectory, Folder));
            }
        }
    }
}
