
namespace TextFilter.Common.Interfaces.FileRepositories
{
    public interface IFileReader
    {
        Task<string> ReadFileAsync(string path);
        string GetDefaultText();
    }
}
