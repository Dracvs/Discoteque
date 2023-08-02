using System.Net;
using System.Text.RegularExpressions;
using Discoteque.Data.Dto;
using Discoteque.Data.Models;

namespace Discoteque.Business.Utils;
public static class Utilities
{
    
    #region General Utilities
    public static string GetLengthInMinuteNotation(int seconds)
    {        
        var value = new DateTime();
        value = value.AddSeconds(seconds);
        return value.ToString("mm:ss");
    }

    public static bool AreForbiddenWordsContained(string name)
    {
        var prohibitedWords = new List<string>(){"Revolución", "Poder","Amor","Guerra"};
        return prohibitedWords.Any(keyword => Regex.IsMatch(name, Regex.Escape(keyword), RegexOptions.IgnoreCase));
    }
    #endregion

    #region BaseMessage Responses
    public static BaseMessage<Album> BuildResponse(HttpStatusCode statusCode, string Message, List<Album> elements)
    {
        return new BaseMessage<Album>
        {
            Message = Message,
            TotalElements = elements.Count,
            StatusCode = statusCode,
            ResponseElements = elements
        };
    }

    public static BaseMessage<Artist> BuildResponse(HttpStatusCode statusCode, string Message, List<Artist> elements)
    {
        return new BaseMessage<Artist>
        {
            Message = Message,
            TotalElements = elements.Count,
            StatusCode = statusCode,
            ResponseElements = elements
        };
    }
    public static BaseMessage<Song> BuildResponse(HttpStatusCode statusCode, string Message, List<Song> elements)
    {
        return new BaseMessage<Song>
        {
            Message = Message,
            TotalElements = elements.Count,
            StatusCode = statusCode,
            ResponseElements = elements
        };
    }

    public static BaseMessage<Tour> BuildResponse(HttpStatusCode statusCode, string Message, List<Tour> elements)
    {
        return new BaseMessage<Tour>
        {
            Message = Message,
            TotalElements = elements.Count,
            StatusCode = statusCode,
            ResponseElements = elements
        };
    }
    #endregion


}