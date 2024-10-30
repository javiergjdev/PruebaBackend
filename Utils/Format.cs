using System.Text.Json;

namespace PruebaBackend_Javier.Utils;

public class Format
{
    
    public static T? DeserializeJson<T>(Task<string> jsonTask)
    {
        string cleanedJson = CleanCustomerJson(jsonTask.Result);
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        try
        {
            var result = JsonSerializer.Deserialize<T>(cleanedJson, options);
            return result;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"Error deserializando JSON: {jsonEx.Message}");
            return default;
        }
    }

    public static string CleanCustomerJson(string consumeServices)
    {
        
        Span<char> buffer = stackalloc char[consumeServices.Length];
        int length = 0;

        for (int i = 0; i < consumeServices.Length; i++)
        {
            char currentChar = consumeServices[i];

            if (currentChar == '\\' && i + 1 < consumeServices.Length)
            {
                char nextChar = consumeServices[i + 1];

                if (nextChar == 'r' || nextChar == 'n')
                {
                    i++;
                    continue;
                }
                else if (nextChar == '"')
                {
                    // Reemplazar \" con "
                    buffer[length++] = '"';
                    i++;
                    continue;
                }
            }

            buffer[length++] = currentChar;
        }

        var cleanedJson = new string(buffer.Slice(0, length));
        
        cleanedJson = consumeServices.Replace("\\r\\n", "")
            .Replace("\\", "")
            .Replace("\"{", "{")
            .Replace("}\"", "}");

        return cleanedJson;

    }
}