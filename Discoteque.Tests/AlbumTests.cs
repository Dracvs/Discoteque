using Discoteque.Business.IServices;
using Discoteque.Business.Services;
using Discoteque.Data;
using Discoteque.Data.IRepositories;
using Discoteque.Data.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NuGet.Frameworks;

namespace Discoteque.Tests;


[TestClass]
public class AlbumTests
{
    private readonly IRepository<int, Album> _albumRepository;
    private readonly IRepository<int, Artist> _artistRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAlbumService _albumService;
    private readonly Album _correctAlbum;
    private readonly Album _wrongAlbum;
    private const string ALBUM_SERVICE_EXCEPTION = "Album Exception Thrown";

    public AlbumTests()
    {
        _albumRepository = Substitute.For<IRepository<int, Album>>();
        _artistRepository = Substitute.For<IRepository<int, Artist>>();
        _unitOfWork = Substitute.For<IUnitOfWork>();
        _albumService = new AlbumService(_unitOfWork);
        _correctAlbum = new Album(){
            Name = "Midnight Sun",
            ArtistId = 1,
            Cost = 60,
            Genre = Genres.Rock,
            Year = 1985
        };
        _wrongAlbum = new Album(){
            Name = "Midnight Sun",
            ArtistId = 1,
            Cost= 60,
            Genre = Genres.Rock,
            Year = 1900
        };
    }

    [TestMethod]
    public async Task IsAlbumCreatedCorrectly()
    {
        // Arrange
        _artistRepository.FindAsync(1).Returns(Task.FromResult(new Artist()));
        _albumRepository.AddAsync(_correctAlbum).Returns(Task.FromResult(_correctAlbum));
        _unitOfWork.AlbumRepository.Returns(_albumRepository);
        _unitOfWork.ArtistRepository.Returns(_artistRepository);

        // Act
        var newAlbum = await _albumService.CreateAlbum(_correctAlbum);


        // Assert
        Assert.AreEqual(newAlbum.StatusCode, System.Net.HttpStatusCode.OK);
    }

    [TestMethod]
    public async Task ShouldWrongAlbumReturningBadRequest()
    {
        // Arrange
        _artistRepository.FindAsync(1).Returns(Task.FromResult(new Artist()));
        _albumRepository.AddAsync(_correctAlbum).Returns(Task.FromResult(_correctAlbum));
        _unitOfWork.AlbumRepository.Returns(_albumRepository);
        _unitOfWork.ArtistRepository.Returns(_artistRepository);

        // act
        var newAlbum = await _albumService.CreateAlbum(_wrongAlbum);

        // Assert
        Assert.AreEqual(newAlbum.StatusCode, System.Net.HttpStatusCode.BadRequest);
    }

    [TestMethod]
    public async Task IsExceptionHandled()
    {
        // arrange
        _artistRepository.FindAsync(1).Returns(Task.FromResult(new Artist()));
        _albumRepository.AddAsync(_correctAlbum)
            .ThrowsAsyncForAnyArgs(new Exception(ALBUM_SERVICE_EXCEPTION));
        _unitOfWork.AlbumRepository.Returns(_albumRepository);
        _unitOfWork.ArtistRepository.Returns(_artistRepository);

        // act
        var newAlbum = await _albumService.CreateAlbum(_correctAlbum);

        // assert
        Assert.IsTrue(newAlbum.Message.Contains(ALBUM_SERVICE_EXCEPTION));
    }
}
