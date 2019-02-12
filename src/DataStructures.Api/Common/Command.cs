using System.Threading.Tasks;

namespace DataStructures.Api.Common
{
    public abstract class Command<TOutput>
    {
        public abstract Task<TOutput> ExecuteAsync();
    }
}
