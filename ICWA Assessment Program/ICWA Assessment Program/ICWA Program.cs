// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

int x = 0;
int y = 0;
string[] directions = { "NORTH", "EAST", "SOUTH", "WEST" }; //Array of the different directions, placed in clockwise order
string f = "null";
bool loopy = true;

while (loopy == true)
{
    string userInput = Console.ReadLine();
    switch (userInput) 
    {
        case "MOVE":
            if (f == "NORTH") //Check if facing NORTH
            { 
                if ((y + 1) < 6) //Check if movement would move robot outside boundary
                {
                    y += 1;
                }
            }
            else if (f == "EAST") //Check if facing EAST
            {
                if ((x + 1) < 6) //Check if movement would move robot outside boundary
                {
                    x += 1;
                }
            }
            else if (f == "SOUTH") //Check if facing SOUTH
            {
                if ((y - 1) > -1) //Check if movement would move robot outside boundary
                {
                    y -= 1;
                }
            }
            else if (f == "WEST") //Check if facing WEST
            {
                if ((x - 1) > -1) //Check if movement would move robot outside boundary
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
            if (f == "NORTH" || f == "WEST" || f == "SOUTH" || f == "EAST") //Checks if facing is valid so we can be sure robot has been placed
            {
                int facingIndex = Array.IndexOf(directions, f); //gets the index number of the current facing direction in direction array
                if ((facingIndex - 1) < 0) //checking to see if index number -1 would be out of bounds for array
                {
                    f = directions[3]; //if out of bounds, set the index to the end of the array
                }
                else
                {
                    f = directions[(facingIndex - 1)]; //if in bounds, set it to the preceeding value in the array
                }
            }
            else
            {
                Console.WriteLine("=> Robot not placed");
            }
            break;
        case "RIGHT":
            if (f == "NORTH" || f == "WEST" || f == "SOUTH" || f == "EAST") //Checks if facing is valid so we can be sure robot has been placed
            {
                int facingIndex = Array.IndexOf(directions, f);
                if ((facingIndex + 1) > 3) //inverse of code written for LEFT, checking to see if index number +1 would be out of bounds
                {
                    f = directions[0]; //if out of bounds, set back to beginning value
                }
                else
                {
                    f = directions[(facingIndex + 1)]; //otherwise, move to next value in array
                }
            }
            else
            {
                Console.WriteLine("=> Robot not placed");
            }
            break;
        case "REPORT": 
            if (f == "NORTH" || f == "WEST" || f == "SOUTH" || f == "EAST") //Checks if facing is valid so we can be sure robot has been placed
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
            if (Regex.IsMatch(userInput, @"^PLACE\s[0-5],[0-5],(NORTH|WEST|SOUTH|EAST)")) //checks if user has placed 
            {
                string trimmedInput = userInput.Remove(0, 6); //removing "PLACE " to get just the substring of values
                string[] placedArray = Regex.Split(trimmedInput, "[,]"); //removing commas and splitting into an array of individual values
                try 
                {
                    x = Int32.Parse(placedArray[0]); //assigning retrieved values to x, y and z
                    y = Int32.Parse(placedArray[1]);
                    f = placedArray[2];
                }
                catch {
                    Console.WriteLine("=> An unexpected error occurred."); //catch statement in case error occurs - shouldn't be possible due to regex
                }
            }
            else
            {
                Console.WriteLine("=> Invalid command"); //catch all error message for unrecognised commands or an invalid PLACE command
            }
            break;
    }
}