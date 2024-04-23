namespace eHospitalServer.Infrastructure.Utilities;
public static class CommonExtensions
{
    public static string ConvertToTurkishCharacters(this string str)
    {
        Dictionary<string, string> characters = new()
        {
            { "ü", "u" },
            { "ş", "s" },
            { "ı", "i" },
            { "ö", "o" },
            { "ç", "c" },
            { "ğ", "g" },
            { "#", "sharp" },
            { "?", "" }
        };

        var turkishCharacter = str.ToLower();
        foreach (var character in characters)
        {
            turkishCharacter = turkishCharacter.Replace(character.Key, character.Value);
        }

        var turkishCharacters = turkishCharacter.Split(" ");
        turkishCharacter = string.Join("-", turkishCharacters);

        return turkishCharacter;
    }
}
