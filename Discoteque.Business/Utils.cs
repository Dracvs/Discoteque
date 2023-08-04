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
    public static BaseMessage<T> BuildResponse<T>(HttpStatusCode statusCode, string message, List<T>? elements = null)
    where T : class    
    {
        return new BaseMessage<T>(){
            StatusCode = statusCode,
            Message = message,
            TotalElements = (elements != null && elements.Any()) ? elements.Count : 0,
            ResponseElements = elements ?? new List<T>()
        };
    }
    #endregion


}