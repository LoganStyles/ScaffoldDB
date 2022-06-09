
using ScaffoldDB.Data;
using System.Text;

var _context = new ArtistsContext();
var artistDetails = _context.HighEarningEmployees.ToList();
foreach (var artist in artistDetails)
{
    Console.WriteLine(
        $"Artist: {Encoding.UTF8.GetString(artist.Name)}, Album: {artist.AlbumName} "
    );
}





