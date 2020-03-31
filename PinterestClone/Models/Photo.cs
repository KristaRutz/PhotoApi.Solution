using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PinterestClone.Models
{
  public class Photo
  {
    public int PhotoId { get; set; }

    public string Title { get; set; }

    public string Url { get; set; }

    public string UserName { get; set; }

    public string TagList { get; set; }

    public static List<Photo> GetPhotos()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Photo> photoList = JsonConvert.DeserializeObject<List<Photo>>(jsonResponse.ToString());

      return photoList;
    }

    public static Photo GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Photo photo = JsonConvert.DeserializeObject<Photo>(jsonResponse.ToString());

      return photo;
    }
  }
}