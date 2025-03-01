using System.Text.RegularExpressions;

int x = 0;
int y = 0;
string[] directions = { "NORTH", "EAST", "SOUTH", "WEST" }; 
string f = "null";
bool loopy = true;

while (loopy == true)
{
    string userInput = Console.ReadLine();
    switch (userInput) 
    {
        case "MOVE":
            if (f == "NORTH") 
            { 
                if ((y + 1) < 6) 
                {
                    y += 1;
                }
            }
            else if (f == "EAST") 
            {
                if ((x + 1) < 6) 
                {
                    x += 1;
                }
            }
            else if (f == "SOUTH") 
            {
                if ((y - 1) > -1) 
                {
                    y -= 1;
                }
            }
            else if (f == "WEST") 
            {
                if ((x - 1) > -1) 
                {
                    x -= 1;
                }
            }
            else
            {
                Console.WriteLine("=> Robot not placed");
            }
            break;
        case "LEFT":
            if (f == "NORTH" || f == "WEST" || f == "SOUTH" || f == "EAST") 
            {
                int facingIndex = Array.IndexOf(directions, f); 
                if ((facingIndex - 1) < 0) 
                {
                    f = directions[3]; 
                }
                else
                {
                    f = directions[(facingIndex - 1)]; 
                }
            }
            else
            {
                Console.WriteLine("=> Robot not placed");
            }
            break;
        case "RIGHT":
            if (f == "NORTH" || f == "WEST" || f == "SOUTH" || f == "EAST") 
            {
                int facingIndex = Array.IndexOf(directions, f);
                if ((facingIndex + 1) > 3) 
                {
                    f = directions[0]; 
                }
                else
                {
                    f = directions[(facingIndex + 1)]; 
                }
            }
            else
            {
                Console.WriteLine("=> Robot not placed");
            }
            break;
        case "REPORT": 
            if (f == "NORTH" || f == "WEST" || f == "SOUTH" || f == "EAST") 
            {
                Console.WriteLine("=> Output: " + x + ", " + y + ", " + f); 
            }
            else
            {
                Console.WriteLine("=> Robot not placed");
            }
            break;
        case "EXIT": //Added command to exit program for ease of use
            loopy = false;
            Console.WriteLine("=> Program ended");
            break;
        default:
            if (Regex.IsMatch(userInput, @"^PLACE\s[0-5],[0-5],(NORTH|WEST|SOUTH|EAST)")) 
            {
                string trimmedInput = userInput.Remove(0, 6); 
                string[] placedArray = Regex.Split(trimmedInput, "[,]"); 
                try 
                {
                    x = Int32.Parse(placedArray[0]); 
                    y = Int32.Parse(placedArray[1]);
                    f = placedArray[2];
                }
                catch {
                    Console.WriteLine("=> An unexpected error occurred."); 
                }
            }
            else
            {
                Console.WriteLine("=> Invalid command"); 
            }
            break;
    }
}