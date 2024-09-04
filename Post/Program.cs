using System;
using System.Collections;
using System.Collections.Generic;

namespace HelloWorld 
{
	class Program
	{            
	   static string input = "";
	   static string userName;
	   static string password;

		static void Main()
		{
			LogIn();
			input = "";

			Post();
		}

		static void Post()
		{
			var posts = new List<ImagePost>();
			string title;
			string imageUrl;
			bool isPublic = false;

			do
			{
				do
				{
					Console.Clear();
					Console.WriteLine("Please enter your post title");
					title = Console.ReadLine();
					Console.Clear();
					isPublic = CheckPrivacy();
					imageUrl = CheckImageUrl();
					Console.WriteLine("Type \"post\" to publish the post, type anything else to re-type your post");
					input = Console.ReadLine();
					Console.Clear();
				}
				while (input.ToLower() != "post");

				Console.WriteLine("Post published successfully!");

				if (imageUrl == "")
				{
					posts.Add(new ImagePost(title, userName, isPublic));
				}
				else
				{
					posts.Add(new ImagePost(title, userName, isPublic, imageUrl));
				}

				Console.WriteLine("if you want to publish another post, press Enter, if you are done type \"exit\"");
				input = Console.ReadLine();
			}
			while (input.ToLower() != "exit");

			if (posts.Count > 0)
			{
				Console.Clear();
				Console.WriteLine("if you want to update one of your posts, type \"update\"");
				input = Console.ReadLine().ToLower();
				if (input == "update")
				{
					UpdatePost(posts);
				}
			}

			if (posts.Count == 1)
			{
				Console.WriteLine("This is the post that you've posted");
			}
			else if (posts.Count > 1)
			{
				Console.WriteLine("These are the posts that you've posted");
			}
			else
			{
				Console.WriteLine("You didn't post anything :/");
			}

			foreach (ImagePost post in posts)
			{
				if (posts.Count == 0) break;

				Console.WriteLine(post.PostReturn());
				Console.WriteLine("-------------------------------------------");
			}
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}

		static void UpdatePost(List<ImagePost> array)
		{
			Console.Clear();
			Console.WriteLine("Type the title of the post you want to update");
			input = Console.ReadLine();
			int counter = 0;

			foreach (ImagePost post in array)
			{
				counter++;
				if (post.GetTitle() != input.ToLower())
				{
					if (counter < array.Count)
					{
						continue;
					}
					Console.Clear();
					Console.WriteLine("There is no post with this title, press any key to continue");
					Console.ReadKey();		
				}
				else
				{
					do
					{
						Console.Clear();
						Console.WriteLine("Please enter the new post title");
						post.Title = Console.ReadLine();
						Console.Clear();
						post.IsPublic = CheckPrivacy();
						post.ImageUrl = CheckImageUrl();
						Console.WriteLine("Type \"update\" to update the post, type anything else to re-update your post");
						input = Console.ReadLine();
						Console.Clear();
					}
					while (input.ToLower() != "update");

					Console.WriteLine("Post updated successfully!");
				}
			}
		}

		static string CheckImageUrl()
		{
			Console.WriteLine("[Optional] Please enter the Url of the image that you want to associate with your post, \n" +
							  "if there is no images to associate, then leave the entry field empty");

			string url = Console.ReadLine();
			Console.Clear();

			while ((url.Length < 14 || !url.StartsWith("http".ToLower())) && url != "")
			{
				if (!url.StartsWith("https://".ToLower()))
				{
					if (!url.StartsWith("http://".ToLower()) && url != "")
					{
						while (true)
						{
							Console.WriteLine("The image Url should begin with \"https://\" or \"http://\" ");
							url = Console.ReadLine();
							Console.Clear();

							if (url.StartsWith("https://".ToLower()) || url.StartsWith("http://".ToLower()) || url == "")
							{
								break;
							}
						}
					}
				}

				Console.WriteLine("Image Url is invalid!");
				url = Console.ReadLine();
				Console.Clear();
			}
			Console.Clear();
			return url;
		}

		static bool CheckPrivacy()
		{
			bool isTrue;
			bool pub = false;

			do
			{
				Console.WriteLine("Please enter your post privacy settings, type \"true\" if you want it to be public \nor type \"false\" if you want it to be private");
				try
				{
				   pub = bool.Parse(Console.ReadLine());
				   Console.Clear();
				   isTrue = true;
				}
				catch (Exception)
				{
					Console.Clear();
					Console.WriteLine("Please type \"true\" or \"false\"!\n");
					isTrue = false;
				}
			}
			while (!isTrue);

			Console.Clear();
			return pub;

		}

		static void LogIn()
		{
			Console.WriteLine("Please enter your username and password\n");
			CheckUserName();
			CheckPassword();
		}

		static void CheckUserName()
		{
			while (true)
			{
				Console.Write("Username:");
				input = Console.ReadLine();
				Console.Clear();

				if (input.Contains('-') || input.Contains('*') || input.Contains('!') || input.Contains('@') || input.Contains('#') ||
					input.Contains('$') || input.Contains('%') || input.Contains('^') || input.Contains('&') || input.Contains('(') ||
					input.Contains(')') || input.Contains('=') || input.Contains('+') || input.Contains('/') || input.Contains('|') ||
					input.Contains('{') || input.Contains('}') || input.Contains('[') || input.Contains(']') || input.Contains(':') ||
					input.Contains(';') || input.Contains('~') || input.Contains('<') || input.Contains('>') || input.Contains('\'')||
					input.Contains('\"')|| input.Contains('?') || input.Contains(' '))
				{
					Console.WriteLine("Username cannot contain these charachters:\n" +
						"\"- * ! @ # $ % ^ & ) ( = + / | } { ] [ : ; ~ > < \' \" ? \" or empty spaces \n");
					continue;
				}
				
				userName = input;
				break;
			}          

		}

		static void CheckPassword()
		{
			while (true)
			{
				Console.Write("Password:");
				input = Console.ReadLine();
				Console.Clear();

				if (input.Length < 6)
				{
					Console.WriteLine("Password is too short!, it should be at least 6 characters \n");
				}
				else if (input.Length > 40)
				{
					Console.WriteLine("Password is too long!, it should not exceed 40 charachters \n");
				}
				else
				{
					password = input;
					Console.Clear();
					break;
				}
			}

			do
			{
				Console.Write("Type your password again:");
				input = Console.ReadLine();
				Console.Clear();

				if (input != password)
				{
					Console.WriteLine("Password is wrong!");
				}
			} 
			while (input != password);
		}
	}
}
