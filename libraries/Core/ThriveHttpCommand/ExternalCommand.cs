using RestSharp;
using RestSharp.Serializers;

namespace ThriveHttpCommand;

public class ExternalCommand: IExternalCommand {
    public Task Post<T>(string url, string path, T command, CancellationToken cancellationToken = default)
        where T : notnull {
        var client = new RestClient(url);

        var request = new RestRequest(path, Method.Post);
        request.AddBody(command, ContentType.Json);

        return client.PostAsync<dynamic>(request, cancellationToken);
    }

    public Task Put<T>(string url, string path, T command, CancellationToken cancellationToken = default)
        where T : notnull {
        var client = new RestClient(url);

        var request = new RestRequest(path, Method.Put);
        request.AddBody(command, ContentType.Json);

        return client.PutAsync<dynamic>(request, cancellationToken);
    }

    public Task Delete<T>(string url, string path, T command, CancellationToken cancellationToken = default)
        where T : notnull {
        var client = new RestClient(url);

        var request = new RestRequest(path, Method.Delete);
        request.AddBody(command, ContentType.Json);

        return client.DeleteAsync<dynamic>(request, cancellationToken);
    }
}