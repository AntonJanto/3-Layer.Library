using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using NextIT.Assignment.Models;

namespace NextIT.Assignment.WebApi.Data.Json
{
    public class FileContext
    {
        private readonly string _libraryJsonPath;
        private readonly string _usersJsonPath;
        public IList<Book> Library { get; private set; }
        public IList<User> Users { get; private set; }

        public FileContext(IConfiguration configuration)
        {
            _libraryJsonPath = configuration["Files:LibraryJsonPath"];
            _usersJsonPath = configuration["Files:UsersJsonPath"];

            Library = File.Exists(_libraryJsonPath) ? ReadListData<Book>(_libraryJsonPath) : new List<Book>();
            Users = File.Exists(_usersJsonPath) ? ReadListData<User>(_usersJsonPath) : new List<User>();
        }

        private IList<T> ReadListData<T>(string filePath)
        {
            using (var jsonReader = File.OpenText(filePath))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public void SaveChanges()
        {
            // storing library
            string libraryJson = JsonSerializer.Serialize(Library);

            using (StreamWriter outputFile = new StreamWriter(_libraryJsonPath, false))
            {
                outputFile.Write(libraryJson);
            }

            // storing users
            string usersJson = JsonSerializer.Serialize(Users);

            using (StreamWriter outputFile = new StreamWriter(_usersJsonPath, false))
            {
                outputFile.Write(usersJson);
            }
        }
    }
}