namespace MusicFactory.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    using Newtonsoft.Json;

    using MusicFactory.Models;

    public class TestMusicFactory
    {
        private const string serviceRoot = "http://localhost:4986/api/";

        static void GetAlbums(HttpClient httpClient)
        {
            var response = httpClient.GetAsync("Albums/GetAlbums").Result;
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        }

        static void AddAlbum(HttpClient httpClient, Album theAlbum)
        {
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(theAlbum));
            postContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = httpClient.PostAsync("Albums/PostAlbum", postContent).Result;

            //try
            //{
            //    response.EnsureSuccessStatusCode();
            //    Console.WriteLine("Album added!");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Error adding Album");
            //}
        }

        private static void UpdateAlbumName(HttpClient httpClient, int albumId, string newName)
        {
            HttpContent putContent = new StringContent(newName);
            putContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = httpClient.PutAsJsonAsync("Albums/PutAlbum/" + albumId, newName).Result;

            //try
            //{
            //    response.EnsureSuccessStatusCode();
            //    Console.WriteLine("Album name updated!");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Error updating album name!");
            //}
        }

        private static void DeleteAlbum(HttpClient httpClient, int albumId)
        {
            var response = httpClient.DeleteAsync("Albums/GetAlbum/" + albumId).Result;

            //try
            //{
            //    response.EnsureSuccessStatusCode();
            //    Console.WriteLine("Album deleted!");
            //}
            //catch (Exception)
            //{
            //    Console.WriteLine("Error deleting album!");
            //}
        }

        public static void Main()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(serviceRoot);

            var album = new Album()
            {
                Title = "First Album",
                Producer = "Han Kubrat",
                Year = 2014
            };

            var songs = new List<Song>
            {
                new Song() 
                { 
                    Title = "First Song",
                    Genre = "chalga",
                    Year = 2014,
                    AlbumId = 1
                },
                new Song() 
                { 
                    Title = "Second Song",
                    Genre = "chalga",
                    Year = 2014,
                    AlbumId = 1
                },
                new Song() 
                { 
                    Title = "Third Song",
                    Genre = "chalga",
                    Year = 2014,
                    AlbumId = 1
                }
            };

            var artists = new List<Artist>
            {
                new Artist() 
                {
                    Name = "Pesho",
                    Country = "Goshev",
                    DateOfBirth = new DateTime(1984, 2, 2)
                },
                new Artist() 
                {
                    Name = "Gosho",
                    Country = "Peshov", 
                    DateOfBirth = new DateTime(1986, 11, 5)
                }
            };

            artists[0].Songs.Add(songs[0]);
            artists[0].Songs.Add(songs[1]);
            artists[1].Songs.Add(songs[2]);

            album.Artists = artists;

            AddAlbum(httpClient, album);
        }
    }
}