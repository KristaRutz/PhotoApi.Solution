using System.Threading.Tasks;
using RestSharp;

namespace PinterestClone.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll(string username, string tag, string title, string url, string size, string page)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"photos?title={title}&username={username}&url={url}&tag={tag}&size={size}&page={page}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetCount(string username, string tag, string title, string url)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"photos/count?title={title}&username={username}&url={url}&tag={tag}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"photos/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newPhoto)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"photos", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPhoto);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newPhoto)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"photos/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newPhoto);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"photos/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "applications/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}