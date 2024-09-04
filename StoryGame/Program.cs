using System;

namespace My_First_Project
{
    class Program
    {
        private static string name;
        
        static void Main()
        {
            Intro();
        }

        static void Intro()
        {
            Console.WriteLine("Hello to my game... my friend.. Please enter your name..");
            name = Console.ReadLine();
            Console.WriteLine($"Okay {name}, Press any key to begin the game.. choose wisely!");
            Console.ReadKey();
            
            StartStory();
        }

        private static void StartStory()
        {
            var intro = new StoryTemplate();
            var sewer = new StoryTemplate();
            var street = new StoryTemplate();
            var _2doorRoom = new StoryTemplate();
            var killer = new StoryTemplate();


            intro.Des = @"Hi smartgaga, you found yourself in a dark room, you couldn't see anything
due to the darkness of the room, you found a torch beside you.. you turn it on
and you find that there is a window.. and a door.";
            intro.Choices = @"1.Try to open the door and exit the room 

2.Try to jump out of the window";
            intro.Inputs = new[] {"1", "2"};
            intro.Branches = new[] {sewer, sewer};


            sewer.Des = @"You fell into some water with a stinky smell.. it looks like your are in the sewer,
it really stinks in here... anyway.. you crawled into the sewers and saw a light 
coming from the end of the tunnel.. its a room.. another room.. this time with
three doors, hmmmmmmm.";
            sewer.Choices = @"1.Try to open the first door and exit the room 

2.Try to open the second door and exit the room

3.Try to open the third door and exit the room ";
            sewer.Inputs = new[] {"1", "2", "3"};
            sewer.Branches = new[] {street, street, _2doorRoom};


            street.Des = @"Finally.. you made it out of that place.. now you are in a street and you will
hail a cab and go to your home..";


            _2doorRoom.Des = @"Aaaand.. your are in another room smartgaga.. like those rooms never end!..
anyway.. this time there are 2 doors in front of you.. one of them is black
black colored, and the other one is white.. a hard decision, isn't it?";
            _2doorRoom.Choices = @"1.Try to open the first (black) door and exit the room 

2.Try to open the second (white) door and exit the room";
            _2doorRoom.Inputs = new[] {"1", "2"};
            _2doorRoom.Branches = new[] {killer, street};


            killer.Des = @"Uh oh.. you found yourself in another room.. but this time.. you are not alone!!
There are three men wearing the plague masks from the 16th century.. behind them    
There are numerous knifes and daggers!!! It seems that they mean business.. Goodbye smartgaga!";
                
            
            Process(intro);
        }

        static void Process(StoryTemplate template)
        {
            string input = "";
            Console.Clear();
            Console.WriteLine(template.Des.Replace("smartgaga", name));
            Console.WriteLine($"\n{template.Choices}");

            if (template.Inputs == null)
            {
                Console.ReadKey();
                goto End;
            }

            while (true)
            {
                input = Console.ReadLine();
                bool isOkay = false;
                
                for (int i = 0; i < template.Inputs.Length; i++)
                {
                    if (input != template.Inputs[i] && i == (template.Inputs.Length -1))
                    {
                        Console.WriteLine("\nYour input is invalid!! please enter a valid input!");
                    }
                    else if (input == template.Inputs[i])
                    {
                        isOkay = true;
                        break;
                    }
                }

                if (isOkay) break;
            }

            if (template.Inputs != null)
            {
                Process(template.Branches[(Convert.ToInt32(input) - 1)]);
            }
            
            End:
            if (template.Inputs == null)
            {
                End();
            } 

        }

        static void End()
        {
            Console.Clear();
            Console.WriteLine("Hope you enjoyed the game.. do you wanna replay the game? if yes please type \"Yes\" ");
            Console.WriteLine("or if you wanna exit.. please press enter..");
            var input = Console.ReadLine();
            if (input.ToLower() == "yes")
            {
               StartStory(); 
            }
        }
    }
}