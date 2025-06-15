public class Board{//Board class for displaying all the necessary information
    private string[] board = {" "," "," "," "," ", " ", " ", " ", " "}; //Actual board of the game that will display the marks.
    // Property to access the board array
    public string[] Array_Board
    {
        get { return board; } // Returns the entire array
        set { board = value; } // Sets the entire array
    }
    private int[] available_positions = {1,2,3,4,5,6,7,8,9};//Board to give information to the user about the list of available positions
    //property to access the available positions board
    public int[] Availablepositions
    {
        get {return available_positions;}// return the entire array
        set {available_positions = value;}//sets the entire array
    }
    public void DisplayBoard(){//Method for looping and displaying the board
        Console.ForegroundColor = ConsoleColor.Blue;
        for (int i =1; i<=board.Length;i++){
            Console.Write($" {board[i-1]} |");
            if(i%3 == 0){
                Console.Write("\n-----------\n");
            }
           
            }
            Console.ResetColor();
        }
    public void DisplayAvailablePositions(){//Method for displaying all the available positions.
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("the following shows you the lists of positions that are avaiable for you to choose from:");
        for(int i = 1; i<= available_positions.Length;i++){
            if(board[i-1] == "X" || board[i-1] == "O"){
                Console.Write("   |");
            }else{
                Console.Write($" {i} |");
            }
            if(i%3 == 0){
                Console.Write("\n-----------\n");
            }
        }
        Console.ResetColor();
    }

    public void Print_title(){//A nice way to print the title.
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to:");
        Console.WriteLine();

        Console.WriteLine("=================================================================================");
        Console.WriteLine("████████╗██╗ ██████╗    ████████╗ █████╗  ██████╗    ████████╗ ██████╗ ███████╗");
        Console.WriteLine("╚══██╔══╝██║██╔════╝    ╚══██╔══╝██╔══██╗██╔════╝    ╚══██╔══╝██╔═══██╗██╔════╝");
        Console.WriteLine("   ██║   ██║██║            ██║   ███████║██║            ██║   ██║   ██║█████╗  ");
        Console.WriteLine("   ██║   ██║██║            ██║   ██╔══██║██║            ██║   ██║   ██║██╔══╝  ");
        Console.WriteLine("   ██║   ██║╚██████╗       ██║   ██║  ██║╚██████╗       ██║   ╚██████╔╝███████╗");
        Console.WriteLine("   ╚═╝   ╚═╝ ╚═════╝       ╚═╝   ╚═╝  ╚═╝ ╚═════╝       ╚═╝    ╚═════╝ ╚══════╝");
        Console.WriteLine("=================================================================================");
        Console.WriteLine();
        Console.ResetColor();
    }
    



}