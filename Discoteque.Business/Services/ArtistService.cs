using Discoteque.Business.IServices;
using Discoteque.Data.Models;

namespace Discoteque.Business.Services;

public class ArtistService : IArtistService
{
    async Task<Artist> IArtistService.CreateArtist(Artist artist)
    {
       // TODO: Implement Me!
       //Bórrame y me implementas correctamente
       /**
       Tarea #2
            Debes crear una lista de artistas, A partir del artista que llega
            Asignarle un ID al azar y devolver una lista ocn un solo elemento.
            List<Artist> artistsLlist, artists y Random() son los valores que utilizarás.
        */
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Artist>> GetArtistsAsync()
    {
       //TODO: IMPLEMENT ME!
       //Bórrame y me implementas correctamente

       /*
            Tarea #2
            Debes crear una lista de artistas, y devolver 5 artistas de tu elección
            El ID de estos artistas debe ser al azar utilizando Random.
            List<Artist> artistsList es la clase raíz que debes devolver.
       */
       throw new NotImplementedException();
    }

    public Task<Artist> UpdateArtist(Artist artist)
    {
        throw new NotImplementedException();
    }
}