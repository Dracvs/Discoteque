using Microsoft.VisualStudio.TestTools.UnitTesting;
using Discoteque.Business.IServices;
using Discoteque.Data.Models;
using Discoteque.Data.IRepositories;
using Moq;
using Discoteque.Data;
using Discoteque.Business.Services;

namespace Discoteque.Tests;

[TestClass]
public class AlbumTests
{
    private readonly Mock<IRepository<int, Album>> _albumRepository;
    private readonly Mock<IRepository<int, Artist>> _artistRepository;
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly  IAlbumService _albumServices;

    public AlbumTests()
    {
        _albumRepository = new Mock<IRepository<int, Album>>();
        _artistRepository = new Mock<IRepository<int, Artist>>();
        _unitOfWork = new Mock<IUnitOfWork>();
        _albumServices = new AlbumService(_unitOfWork.Object);
    }

    [TestMethod]
    public async Task IsAlbumCreatedCorrectly()
    {
        // Arrange
        var album = new Album(){
            Name = "Midnight Sonata",
            ArtistId = 1,
            Cost = 60,
            Genre = Genres.Rock,
            Year = 1985
        };

        var artist = new Artist();

        _artistRepository.Setup(m => m.FindAsync(It.IsAny<int>())).ReturnsAsync(artist);
        _albumRepository.Setup(m => m.AddAsync(It.IsAny<Album>())).Returns(Task.FromResult(It.IsAny<Album>));

        _unitOfWork.Setup(m => m.AlbumRepository).Returns(_albumRepository.Object);
        _unitOfWork.Setup(m => m.ArtistRepository).Returns(_artistRepository.Object);

        // Act
        var newAlbum = await _albumServices.CreateAlbum(album);
        
        // Assert
        Assert.AreEqual(newAlbum.StatusCode, System.Net.HttpStatusCode.OK);
    }
}
