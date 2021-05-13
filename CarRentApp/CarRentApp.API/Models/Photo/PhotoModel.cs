namespace CarRentApp.API.Models.Photo
{
     public class PhotoModel
     {
          public int Id { get; set; }
          public int CarId { get; set; }
          public string Path { get; set; }
          public int Priority { get; set; }
     }
}
