namespace TextFilter.Common.Interfaces.Services
{
    public interface ITextFilter
    {
        public Task<string> FilterText(string fileName);
    }
}
