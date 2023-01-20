using System.Net.Http;
using System.Threading.Tasks;
using CardTransactionHostedService.Core.Interfaces;

namespace CleanArchitecture.Infrastructure.Http;


public class HttpService : IHttpService
{
  public async Task<int> GetUrlResponseStatusCodeAsync(string url)
  {
    using (var client = new HttpClient())
    {
      var result = await client.GetAsync(url);

      return (int)result.StatusCode;
    }
  }
}
