using System.Threading.Tasks;

namespace DataStructures.Api.Common
{
    public abstract class CommandHandlerAsync<TInput, TOutput>
    {
        public abstract Task<TOutput> ExecuteAsync(TInput command);
    }
}
