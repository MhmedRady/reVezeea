using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Luxury_Back
{
    public class JsonStringLocalizer : IStringLocalizer
    {
        //deserialize
        private readonly JsonSerializer _serializer = new JsonSerializer();

        public LocalizedString this[string name] { get { var value = GetValueString(name); return new LocalizedString(name, value); } }

        public LocalizedString this[string name, params object[] arguments] { get { var value = this[name]; return value.ResourceNotFound ? value : new LocalizedString(name, String.Format(value.Value, arguments)); } }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using StreamReader streamReader = new StreamReader(fileStream);
            using JsonTextReader reader = new JsonTextReader(streamReader);

            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName)
                    continue;
                var key = reader.Value as string;
                reader.Read();
                var value = _serializer.Deserialize<string>(reader);
                yield return new LocalizedString(key, value);
            }
        }
        //get value with language that i want
        private string GetValueString(string key)
        {
            //Resources/ar-EG.json
            //Resources/en-UC.json
            var filePath = $"Resources/{Thread.CurrentThread.CurrentCulture.Name}.json";
            var fullFilePath = Path.GetFullPath(filePath);
            if (File.Exists(fullFilePath))
            {
                var result = GetValueFromJson(key, fullFilePath);
                return result;
            }

            return string.Empty;

        }
        private string GetValueFromJson(string PropertyName, string FilePath)
        {

            if (string.IsNullOrEmpty(PropertyName) || string.IsNullOrEmpty(FilePath))
                return string.Empty;

            using FileStream fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new StreamReader(fileStream);
            using JsonTextReader reader = new JsonTextReader(streamReader);

            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.PropertyName & reader.Value as string == PropertyName)
                {
                    reader.Read();
                    return _serializer.Deserialize<string>(reader);
                }
            }
            return string.Empty;
        }
    }

        
    }
