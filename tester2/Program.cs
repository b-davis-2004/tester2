//Teehee :D

//NEED TO ADD IMPORT FUNCTION FOR SAVE FILE AND USER PROMPTING FOR BOTH IMPORT AND EXPORT

//COORD 19 - CEMETARY HAPPY ENDING??????? - HINT IN THE MARKET SCENE

//ADD DETAIL TO ALL THE PUZZLES

//ADD PLACATE FOR ENEMIESCODE.CS

//Calling on Logic.cs to use for questions
using Quiz;


// Enum for directions
// ties into static direction 
enum Direction
{
    North,
    South,
    East,
    West,
    Invalid,
    ExportCoordinates
}


//EnemyEncounter program. Will plug in correleating names and responses defined under enemiesCode.cs

public static class EnemyEncounter
{
    public static void Handle(Enemy enemy)
    {
        Console.WriteLine($"\n You notice {enemy.Name}! {enemy.AttackStyle}!");
        Console.WriteLine("What will you do?"); //prompts path of action based on user selection
        Console.WriteLine("1. Fight");
        Console.WriteLine("2. Run");
        Console.WriteLine("3. Try to negotiate");

        Console.Write("Enter the number of your choice: ");
        string? input = Console.ReadLine()?.Trim();

        switch (input)
        {
            case "1":
                Fight(enemy); //activates correlating response, different for every enemy
                break;
            case "2":
                Run(enemy);
                break;
            case "3":
                Negotiate(enemy);
                break;
        }
    }

    private static void Fight(Enemy enemy)
    {
        Console.WriteLine($" You fight {enemy.Name} head-on!.");
        Console.WriteLine($" {enemy.Conflict}");

        Console.WriteLine("Do you:");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Change your mind and Retreat");

        string? input = Console.ReadLine()?.Trim();
        if (input == "1")
        {
            Console.WriteLine($"{enemy.conflictResponse1}");
        }
        else if (input == "2")
        {
            //gives user designated story, then terminates program in response to player failure
            Console.WriteLine($"{enemy.conflictResponse2}."); 
            Program.TriggerEndScene("You succumb to your wounds.");
        }
    }

    private static void Negotiate(Enemy enemy)
    {
        Console.WriteLine($"You try to reason with {enemy.Name}...");
        Console.WriteLine($"{enemy.Placate}");
        
        //uses random number gen for a number of 1 or 2 to decide if negotiations will fail or succeed
        int result = Program.GetOneOrTwo();

    
        if (result == 1)
        {
            Console.WriteLine($"Your negotiation succeded! \n{enemy.Name} allows you to continue on your adventure unharmed.");
        }
        else
        {
            Program.TriggerEndScene($"Your negotiation failed! \nYou were bested by {enemy.Name}.");
        }
    }

    private static void Run(Enemy enemy)
    {
        //auto succeed if choose run
        Console.WriteLine($" You bolt into the shadows, escaping the {enemy.Name}'s attack.");
    }
    
}

public class Program
{
    static int x = 0;
    static int y = 0; // Defining initial x and y coordinates 

    static void Main()
    {
        Console.WriteLine("Would you like to:");
        Console.WriteLine("1. Start a New Game");
        Console.WriteLine("2. Continue from Last Save");

        string? choice = Console.ReadLine()?.Trim();

        switch (choice)
        {
            case "1":
                x = 0;
                y = 0;
                StartAdventure();
                break;
            case "2":
                ImportCoordinates();
                GameContinue();
                break;
            default:
                Console.WriteLine("Invalid choice. Starting new game by default.");
                x = 0;
                y = 0;
                StartAdventure();
                break;
        }

    }


    //for random pass-fail for negotiate sequence
    public static int GetOneOrTwo()
    {
        Random rand = new Random();
        return rand.Next(1, 3); // returns either 1 or 2
    }
    public static void StartAdventure()
    {
        //Beginning game welcome sequence
        Console.WriteLine("Welcome to your adventure!");
        Console.WriteLine("You wake up in a clearing, laid out on soft grass. As you sit up, you take in your surroundings.");
        Console.WriteLine("This still, calm clearing is bordered by trees on all sides. Unlike this quiet oasis, the forest beyond seems desnse but alive.");
        Console.WriteLine("Something inside you knows you cannout stay here, so you move to your feet and make the decisions...");
        while (true)
        {
            MoveCharacter();
        }
    }
        public static void GameContinue()
    {
        //Starts moveCharacter without welcome squence for load games
        while (true)
        {
            MoveCharacter();
        }
    }

    static void MoveCharacter()
    {
        //Prompts 
        Direction userDirection = GetUserDirection();
        UpdateCoordinates(userDirection);
        Console.WriteLine($"You chose: {userDirection}");
        Console.WriteLine($"Current Coordinates: ({x}, {y})");
        HandleLocation(x, y);
    }

    static void HandleLocation(int x, int y)
    {
        //Instead of using if else statements, im trying a dictionary instead
        //All action variables can and presumably will be altered
        //IS THERE A MORE EFFECTIVE WAY OF DOING THIS?
        //WHY IS MY CODE SO REDUNDANT
        //I figured out the missing coords and added it to them :D
        var scenarios = new Dictionary<(int, int), Action>
        {
            {(-200, -200), () => CoordOne()},
            {(-200, -100), () => CoordTwo()},
            {(-200, 0), () => CoordThree()},
            {(-200, 100), () => CoordFour()},
            {(-200, 200), () => CoordFive()},
            {(-100, -200), () => CoordSix()},
            {(-100, -100), () => CoordSeven()},
            {(-100, 0), () => CoordEight()},
            {(-100, 100), () => CoordNine()},
            {(-100, 200), () => CoordTen()},
            {(0, -200), () => CoordEleven()},
            {(0, -100), () => CoordTwelve()},
            {(0, 0), () => StartingPoint()},
            {(0, 100), () => CoordThirteen()},
            {(0, 200), () => CoordFourteen()},
            {(100, -200), () => CoordFifteen()},
            {(100, -100), () => CoordSixteen()},
            {(100, 0), () => CoordSeventeen()},
            {(100, 100), () => CoordEighteen()},
            {(100, 200 ), () => CoordNineteen()},
            {(200, -200), () => CoordTwenty()},
            {(200, -100), () => CoordTwentyOne()},
            {(200, 0), () => CoordTwentyTwo()},
            {(200, 100), () => CoordTwentyThree()},
            {(200, 200), () => CoordTwentyFour()}
        };

        if (scenarios.TryGetValue((x, y), out Action? scenario))
        {
            scenario.Invoke();
        }
    }


    //If rewriting enemies code, can use same theory as questions. No health system, only do or die options
    //Could do multi challenge rather than singular like questions function tho
    //Recall from enemiesCode.cs

    //Happy Scenes will have no user interaction OR will be peaceful moments where any user interaction will have no true consquences
    static void CoordTwo() 
    {
        Console.WriteLine("You stand at the side of a towering mountain, you can see snow at the peak glistening in the sunlight.");
        Console.WriteLine("Before you can begin to scale the mountain, an assassin emerges from a nearby cave and approaches you.");
        EnemyEncounter.Handle(EnemyLibrary.Assassin);
    } //assassin

    static void CoordThree() 
    { 
        Console.WriteLine("You make your way to a grassy plain, bees are buzzing between the tall grass.");
        Console.WriteLine("You think this may be a moment to rest, however, you see something slithering through the reeds.");
        EnemyEncounter.Handle(EnemyLibrary.Snake);
    } //snake

    static void CoordFour() 
    { 
        Console.WriteLine("You hear the bustle of a nearby village market, in the distance you can see rows of merchant stalls");
        Console.WriteLine("A suspicious stranger is walking towards you on the path, they avert their eyes, but you get the feeling they’re watching you");
        Console.WriteLine("As you attempt to pass the stranger");
        EnemyEncounter.Handle(EnemyLibrary.Thief);
    } //thief

    static void CoordSix() 
    { 
        Console.WriteLine("You set up a campfire at the mountainside. \n The warmth of the flame relaxes you almost enough to fall asleep, however, you think better of it and instead decide to brew some tea."); 
    } //happy scene

    static void CoordEight() 
    { 
        Console.WriteLine("Walking through the forest, you see squirrels chasing one another along the tree branches. \n Your eyes follow them until they disappear into a bramble bush. \n You decide to pick some berries to take with you."); 
    } //happy scene

    static void CoordNine() 
    { 
        Console.WriteLine("You make your way to a farm, you can smell the manure of the fields and hear the sounds of animals grazing"); 
        EnemyEncounter.Handle(EnemyLibrary.Hog);
    } //couldn't think of complex motivations for the hog i'm sorry 
    

    static void CoordEleven() 
    { 
        Console.WriteLine("You make your way to a grassy meadow full of beautiful flowers. The fresh, aromatic scent is a welcome change to the stench of mud!"); 
    } //happy scene

    static void CoordTwelve() 
    { 
        Console.WriteLine("Trees line the path ahead, leading to a lush forest. Sunlight dapples the ground through the leaves.");
        Console.WriteLine("You hear the sound of rustling branches, and turn to see a moose chewing on the moss of a nearby tree");
        EnemyEncounter.Handle(EnemyLibrary.Hog);
    } //moose

    static void StartingPoint() 
    { 
        Console.WriteLine("You are at the starting point."); 
    }

    static void CoordThirteen() 
    { 
        Console.WriteLine("You find yourself in a Covenstead, the room is filled with mysterious smoke and vials of strange liquid line the walls.");
        Console.WriteLine("The witches note your intrusion, and turn towards you with wands raised");
        Console.WriteLine("The witches will hex you unless you defeat them");
        EnemyEncounter.Handle(EnemyLibrary.Witch);
    } // WITCHES

    static void CoordFourteen() 
    { 
        Console.WriteLine("At the village outskirts you can hear music and children singing at a nearby fete. \n The tune is one you remember from your own childhood, and the familiar sound comforts you. \n You hum it to yourself as you walk.");
    } //happy scene


    static void CoordSixteen() 
    { 
        Console.WriteLine("In the clearing you see a cluster of small huts and tents. A campfire crackles in the centre."); 
        Console.WriteLine("A group of masked men wearing armour and animal hides emerge from one of the huts, they spot you and reach for their weapons");
        EnemyEncounter.Handle(EnemyLibrary.Bandit);
    } //bandits

    static void CoordNineteen() 
    { 
        Console.WriteLine("Walking through the cemetery, it's quiet reminds you of the heaviness in your bones. While there is much adventure to be discovered, a small voice in your head says it is oaky to rest... it is okay to go home."); 
        Console.WriteLine("Do you listen and rest here?");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");

        string? input = Console.ReadLine()?.Trim();
            if (input == "1")
            {
            Console.WriteLine("You find a soft patch of grass to lay down in, much like how you woke up. \n The stillness allows your eyes to fall close quietly.");
            TriggerEndScene("With one final thought, you let yourself drift off from this fairytale land... You are going home.");
        }
        else if (input == "2")
        {
            //gives user designated story, then terminates program in response to player failure
            Console.WriteLine("You reject the small voice, deciding your adventure wasn't over just yet and continue on."); 
            
        }
    } //happy scene

    static void CoordTwenty() 
    { 
        Console.WriteLine("You stand at the edge of a riverbank. You can hear the rush of water between rocks as the sunlight glimmers on the water.");
        Console.WriteLine("The river water relieves your parched mouth, but your stomach still aches with hunger.");
        EnemyEncounter.Handle(EnemyLibrary.Fish);
    } //fish

    static void CoordTwentyOne() 
    { 
        Console.WriteLine("The river current is much too fast to cross, however you manage to find a small stone bridge."); 
        Console.WriteLine("However, as you begin to make your way across, a troll appears before you!");
        EnemyEncounter.Handle(EnemyLibrary.Troll);
    } //troll(s)

    static void CoordTwentyTwo() 
    { 
        Console.WriteLine("As you reach a small stream you reach in to feel the water is pleasently warm on your fingertips. \n You decide to bathe, washing off the mud that's caked to your skin. \n You leave feeling refreshed and rejuvinated."); 
    } //happy scene


    static void CoordOne()
    {
        Console.WriteLine("You are at the Mountain Top. A spirit whispers a riddle into the wind...");

        //riddle defined as local and can be reused in otehr coords
        QuestionPrompt riddle = new QuestionPrompt("I speak without a mouth and hear without ears. I have no body, but I come alive with the wind. What am I?","echo"); 
    
        bool success = riddle.Ask(); // Store the result

        if (success)
        {
            Console.WriteLine("The wind carries the spirits praise, wishing you well on your adventure forward.");
            //positive response
        }
        else
        {
            Console.WriteLine("The spirit deems you unworthy to continue your journey.");
            TriggerEndScene("Your vision fades to an endless black.");
            // negative response
        }
    }

    static void CoordFive()
    { 
        Console.WriteLine("You come across a Hearthstone, its old and weathered, but you can make out a riddle inscribed on its face. ");  // description of location

        QuestionPrompt riddle = new QuestionPrompt("What has keys but can't open locks?", "piano");   //puzzle 3
    
        bool success = riddle.Ask(); // Store the result

        if (success)
        {
           Console.WriteLine("As you speak your answer aloud, the breeze seems to whisper to you... You will find rest where many before you found theirs eternal.");
           //positive response
        }
        else
        {
            Console.WriteLine("Nothing happens... Maybe you answered wrong? Maybe there was nothing here?");
        }
    }

    static void CoordSeven()
    { 
        Console.WriteLine("Exploring the ruins of an abandoned village, you are surrounded by crumbling buildings and a strange loneliness overwhelms you.");  // description of location
        Console.WriteLine("As you make your way to the outskirts, a locked gate blocks your path, to find where the key is hidden you must answer a riddle.");
        // description of encounter
    
        QuestionPrompt riddle = new QuestionPrompt("What has a face but can't smile?", "clock"); //puzzle 6
    
        bool success = riddle.Ask(); // Store the result

        if (success)
        {
          Console.WriteLine("The gates suddenly open before you without an operator, allowing your free exploration beyond.");
          //positive response
        }
        else
        {
          Console.WriteLine("The gates remain firmly shut, stangnating further exploration.");
          TriggerEndScene("Exposure forces your adventure to an end.");
           // negative response
        }
    }

    //IF MATH PUZZLE IS SUCCESS, MAP IS REVEALED
    //Most definitive hint towards the cemetary as the happy ending of the game. 
    //Ever other ending is basically just death
    static void CoordTen() //Marketplace
    {
        Console.WriteLine("You wander deeper in the village, entering the Marketplace. Villagers work stalls selling various trinket and goods.");  //math puzzle???? like coins or sum shit
        Console.WriteLine("An elder merchant leans hunched over his stall, displaying only one item: A rolled up parchment.");
        Console.WriteLine("Approaching the man's stall, you question him about his singular item's contents.");
        Console.WriteLine("In a hushed voice, he states the parchment contains a map of this known, foriegn world and... a way out. But for the right price, he'll give you a glimpse.");
    
            QuestionPrompt riddle = new QuestionPrompt("The merchant requests 2 Gold coins for to view the map, plus 2 more for his time. How many coins do you give him?", "4");  //mathy math
    
            bool success = riddle.Ask(); // Store the result

            if (success)
            {
                Console.WriteLine("With his fee paid, the merchant unravels the parchment.");
                Console.WriteLine($"The Map is Revealed: \n (-200, -200) Mountain Top (-200, -100) Mountain side \n (-200, 0) Grassy Plain \n (-200, 100)  Village Outskirt \n(-200, 200) Heartstone \n (-100, -200) Mountain Side \n(-100, -100) Ruins \n(-100, 0) Forest \n (-100, 100) Farmland \n(-100, 200) Marketplace \n(0, -200) Grassy plain \n(0, -100) Forest \n(0, 0) Origin Point \n(0, 100) Covenstead \n(0, 200) Village Outskirt \n(100, -200) Lake \n (100, -100) Bandit Camp \n(100, 0) Forest \n(100, 100) Convent \n(10, 200) Cemetery \n(200, -200) River \n(200, -100) Toll Bridge \n(200, 0) River \n(200, 100) Estuary \n(200, 200) Sea");
                Console.WriteLine("As you study the map, something about the cemetary seems to call you. \nLike an intrinsic pull towards it. Whispering... Home.");
            }
            else
            {
              Console.WriteLine("The merchant refuses to show you the map since you refused to pay his fees.");
              // negative response
            }
    }

    static void CoordFifteen()
    { 
        Console.WriteLine("At the edge of the lake you see a small row boat tied to the pier.");
        Console.WriteLine("A fisherman emerges from a nearby lakehouse and says you can use his boat if you answer his riddle.");  // description of location
        // description of encounter
        
        QuestionPrompt riddle = new QuestionPrompt("What has a head, a tail, but no body?", "coin");  //puzzle 5
    
        bool success = riddle.Ask(); // Store the result

        if (success)
        {
            Console.WriteLine("The fisherman allows you on his boat to explore the lake. \nWhen you return to shore, he send you on your way with some fish to fill your belly for you long journey.");
          //positive response
        }
        else
        {
           Console.WriteLine("The fisherman shakes his head in disappointment, deny you access to his boat. Recklessly, you decide to swim the lake instead.");
           TriggerEndScene("Unfortunetly, you are a weak swimmer and promptly drown.");
           // negative response
        }
    }

    static void CoordSeventeen()
    { 
        Console.WriteLine("Following the path through the forest, there are trees towering over you giving shelter from the heat. Carved into one is a question...");  // description of location
        // description of encounter

        QuestionPrompt riddle = new QuestionPrompt("What can travel around the world while staying in the corner?", "stamp"); //puzzle 4
    
        bool success = riddle.Ask(); // Store the result

        if (success)
        {
            Console.WriteLine("You speak your answer allowed and the trees seem to hum a warning... \n Don't go West... Danger lies in wait.");
            //positive response
        }
        else
        {
            Console.WriteLine("The forest takes on an eery energy, urging you to keep moving.");
            // negative response
        }
    }

    static void CoordEighteen()
    { 
        Console.WriteLine("You walk through an old covnent, lit only by candlelight.");
        Console.WriteLine("One of the nuns greets you. She says she will aid you in your quest if you can prove you are worthy by answering a riddle.");  // description of location
        // description of encounter

        QuestionPrompt riddle = new QuestionPrompt("The more of this there is, the less you see. What is it?", "darkness"); //puzzle 2
    
        bool success = riddle.Ask(); // Store the result

        if (success)
        {
            Console.WriteLine("The nun closes her eyes, bowing her head. 'Chase the sunrise to find home. Chase the sunset to find adventure,' she reveals");
            //positive response
        }
        else
        {
            Console.WriteLine("The nun sighs and turns you away, refusing aid to the unworthy.");
            // negative response
        }
    }

    static void CoordTwentyThree()
    {
        Console.WriteLine("You make your way to an Estuary. The current runs quickly, and birds circle overhead. At the edge of the water there is an old wooden sign with a riddle on it.");  // description of location
        // description of encounter

        QuestionPrompt riddle = new QuestionPrompt("What gets wetter as it dries", "towel"); //puzzle 7
    
        bool success = riddle.Ask(); // Store the result

        if (success)
        {
            Console.WriteLine("The wind whips around you, filling your nose with the sent of the sea to the east, beckoning you to follow it.");
            //positive response
        }
        else
        {
            Console.WriteLine("The breeze dies around you and a foul oder fills your nostrils. Time to get moving.");
        }
    }

    static void CoordTwentyFour()
    {
        Console.WriteLine("Ahead of you is a vast ocean. The sea seems to inch closer to you, licking the pale sand at your feet. The waves seem to rumble a riddle...");  // description of location
        // description of encounter

        QuestionPrompt riddle = new QuestionPrompt("What starts with T, ends with T, and has T in it?", "teapot"); //puzzle 8
    
        bool success = riddle.Ask(); // Store the result

        if (success)
        {
            Console.WriteLine("The sea calms before you, answering with only a gentle mist against your cheeks.");
            //positive response
        }
        else
        {
            Console.WriteLine("The sea roars and the waves sweep your feet out from under your, dragging you into the rip tides.");
            TriggerEndScene("You succumb to the draw of the sea.");
            // negative response
        }
    }


    static Direction GetUserDirection()
    {
        Console.WriteLine("What direction do you go? (North, South, East, West) Use Command 'Export' at anytime to save game progress.");
        string? input = Console.ReadLine()?.Trim().ToLower(); // Handle null safety

        // defining each direction correlating with enum
        return input switch
        {
            "north" => Direction.North,
            "south" => Direction.South,
            "west" => Direction.West,
            "east" => Direction.East,
            "export" => Direction.ExportCoordinates,
            _ => Direction.Invalid
        };
    }

    //Defining and incrimenting coordinates based on user choice
    static void UpdateCoordinates(Direction direction)
    {
        int moveX = x;
        int moveY = y;

        switch (direction)
        {
            case Direction.North:
                moveX -= 100;
                break;
            case Direction.South:
                moveX += 100;
                break;
            case Direction.East:
                moveY += 100;
                break;
            case Direction.West:
                moveY -= 100;
                break;
            case Direction.ExportCoordinates:
                ExportCoordinates();
                return;
            default:
                Console.WriteLine("Invalid direction.");
                return;
        }
        //outerbounds limit for movement
        if (moveX < -200 || moveX > 200 || moveY < -200 || moveY > 200)
        {
            //Need to update this message to be on theme
            Console.WriteLine("Error: Coordinates are out of bounds. Try again.");
        }
        else
        {
            // Only update the coordinates if they are within the valid range
            x = moveX;
            y = moveY;
        }
    }

    //End scene trigger function to be added as negative consequence.
    //Can also be used for possible positive end game scene if we chose to
    public static void TriggerEndScene(string reason = "")
    {
        Console.WriteLine("\n=== END OF GAME ===");

        if (!string.IsNullOrWhiteSpace(reason))
        {
            Console.WriteLine($"Reason: {reason}");
        }

        Console.WriteLine("Thank you for playing! Your journey ends here.");
        Environment.Exit(0); // Terminates the program
    }

    //Exports current coordinates into txt file
    //Executed under directions by user
    public static void ExportCoordinates() 
    {
        string filePath = "coordinates.txt";
        string content = $"Current Coordinates: ({x}, {y})";

        try
        {
            File.WriteAllText(filePath, content);
            Console.WriteLine($"Coordinates exported to {filePath}");
        }
        catch (Exception ex)
        {
        Console.WriteLine($"Failed to export coordinates: {ex.Message}");
        }
    }

    public static void ImportCoordinates()
    {
        string filePath = "coordinates.txt";

        try
        {
            if (File.Exists(filePath))
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine($"Loaded save file: {content}");

                // Expected format: "Current Coordinates: (x, y)"
                var parts = content.Replace("Current Coordinates:", "").Trim()
                    .Trim('(', ')') // remove parentheses
                    .Split(',');

                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int savedX) &&
                    int.TryParse(parts[1], out int savedY))
                {
                    x = savedX;
                    y = savedY;
                    Console.WriteLine("Game resumed from saved coordinates.");
                }
                else
                {
                    Console.WriteLine("Save file format invalid. Starting new game instead.");
                }
            }
            else
            {
                Console.WriteLine("No save file found. Starting new game instead.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to load save file: {ex.Message}");
        }
    }

}


//Puzzles notes for referral
//1.	"I speak without a mouth and hear without ears. I have no body, but I come alive with wind. What am I?", "echo" //
//2.	"The more of this there is, the less you see. What is it?", "darkness" //
//3.	"What has keys but can't open locks?", "piano" //
//4.	"What can travel around the world while staying in the corner?", "stamp" //
//5.	“What has a head, a tail, but no body?", "coin" //
//6.	"What has a face but can't smile?”, "clock" //
//7.	"What gets wetter as it dries", "towel" //
//8.	"What starts with T, ends with T, and has T in it?", "teapot"//
