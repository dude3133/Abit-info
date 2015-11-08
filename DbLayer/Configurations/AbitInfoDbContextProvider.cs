namespace DbLayer.Configurations
{
    public interface IAbitInfoDbContextProvider
    {
        IAbitInfoDbContext Context { get; }
    };
    public class AbitInfoDbContextProvider : IAbitInfoDbContextProvider
    {
        public IAbitInfoDbContext Context
        {
            get { return new AbitInfoDbContext(); }
        }
    }
}
