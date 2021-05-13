namespace CarRentApp.API.Dtos.Photo
{
     public class PhotoDto
     {
          public int Id { get; set; }
          public int CarId { get; set; }
          public string Path { get; set; }
          public int Priority { get; set; }
     }
}
