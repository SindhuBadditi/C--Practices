using System;
using System.Collections.Generic;

class Playlist
{
    /*
    1. Add Song at Beginning
    2. Add Song at End
    3. Remove Song
    4. Display First Song
    5. Display Last Song
    6. Display All Songs
    7. Check Song
    8. Display Total Songs
    9. Clear Playlist
    10. Exit
    */

    static void Main(String[] args)
    {
        LinkedList<string> songs = new LinkedList<string>();

        while (true)
        {
            Console.WriteLine("\n===== Music Playlist System =====");
            Console.WriteLine("1. Add Song at Beginning");
            Console.WriteLine("2. Add Song at End");
            Console.WriteLine("3. Remove Song");
            Console.WriteLine("4. Display First Song");
            Console.WriteLine("5. Display Last Song");
            Console.WriteLine("6. Display All Songs");
            Console.WriteLine("7. Check Song");
            Console.WriteLine("8. Display Total Songs");
            Console.WriteLine("9. Clear Playlist");
            Console.WriteLine("10. Exit");

            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nAdd Song at Beginning");
                    Console.Write("Enter song name: ");
                    string firstSong = Console.ReadLine();

                    songs.AddFirst(firstSong);

                    Console.WriteLine("Song added successfully.");
                    break;

                case 2:
                    Console.WriteLine("\nAdd Song at End");
                    Console.Write("Enter song name: ");
                    string lastSong = Console.ReadLine();

                    songs.AddLast(lastSong);

                    Console.WriteLine("Song added successfully.");
                    break;

                case 3:
                    Console.WriteLine("\nRemove Song");
                    Console.Write("Enter song name: ");
                    string removeSong = Console.ReadLine();

                    if (songs.Contains(removeSong))
                    {
                        songs.Remove(removeSong);
                        Console.WriteLine($"{removeSong} removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"{removeSong} not found.");
                    }
                    break;

                case 4:
                    Console.WriteLine("\nFirst Song");

                    if (songs.Count > 0)
                    {
                        Console.WriteLine("First Song: " + songs.First.Value);
                    }
                    else
                    {
                        Console.WriteLine("Playlist is empty.");
                    }
                    break;

                case 5:
                    Console.WriteLine("\nLast Song");

                    if (songs.Count > 0)
                    {
                        Console.WriteLine("Last Song: " + songs.Last.Value);
                    }
                    else
                    {
                        Console.WriteLine("Playlist is empty.");
                    }
                    break;

                case 6:
                    Console.WriteLine("\nDisplay All Songs");

                    foreach (string song in songs)
                    {
                        Console.Write(song + " ");
                    }

                    Console.WriteLine();
                    break;

                case 7:
                    Console.WriteLine("\nCheck Song");
                    Console.Write("Enter song name: ");
                    string searchSong = Console.ReadLine();

                    if (songs.Contains(searchSong))
                    {
                        Console.WriteLine($"{searchSong} is available in the playlist.");
                    }
                    else
                    {
                        Console.WriteLine($"{searchSong} is not available in the playlist.");
                    }
                    break;

                case 8:
                    Console.WriteLine("\nTotal Songs: " + songs.Count);
                    break;

                case 9:
                    Console.WriteLine("\nClear Playlist");

                    songs.Clear();

                    Console.WriteLine("Playlist cleared successfully.");
                    break;

                case 10:
                    Console.WriteLine("Exiting...");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}