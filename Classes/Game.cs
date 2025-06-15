using System.Drawing;
using System.Threading;
public class Game{
    Player player_1;  //Creating two player objects
    Player player_2;
    Player current_player; //This object will be the current player.
    Board game_board = new Board();//Instantiating a new board object
    int attempts = 0; //This will track the number of attempts done to end the game if the attempts reach 9 with no more available positions
    

    public void PlayGame(){//This method is the gameplay loop that will keep looping throughout the game
        int pos = GetPosition();  
        current_player.PlaceMark(game_board.Array_Board,pos);
        attempts++;
        if(CheckWinner(game_board.Array_Board)){
            current_player.score++;
            DisplayResult();
            return;
        }
        if(GameOver()){
            DisplayResult();
            return;
        }
        SwitchPlayer();
        PlayGame();//Call the function recursively

    }
    
    public void GetPlayers(){//This run only once to get the information about the players and their marks
        game_board.Print_title();
        Console.WriteLine("Player 1, please enter your name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Please choose your mark X or O?");
        string mark = Console.ReadLine().ToUpper();
        while(mark != "X" && mark != "O"){
            Console.WriteLine("Please choose a valid mark: ");
            mark = Console.ReadLine().ToUpper();
        }
        player_1 = new Player(name,mark);
         Console.WriteLine("Player 2, please enter your name: ");
         name = Console.ReadLine();
         if(player_1.Mark == "X"){
            mark = "O";
         }else{
            mark = "X";
         }
         player_2 = new Player(name,mark);
         current_player = player_1;
        Console.WriteLine($"{player_1.Name} your mark is {player_1.Mark}");
        Console.WriteLine($"{player_2.Name} your mark is {player_2.Mark}");
        SlowPrint("The game will start right now",100);
        SlowPrint(".....",150);

    }

    public int GetPosition(){ // get the position of of the mark from the player
        Console.Clear();
        //Display all the information needed for the player
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("The following board will display the current state of the game and all the marks that are placed:");
        game_board.DisplayBoard();
        game_board.DisplayAvailablePositions();
        int pos = 0;
        bool validInput = false;
        Console.WriteLine($"{current_player.Name}, it is your turn, please enter a position from 1 to 9 to place your mark.");
        
        while (!validInput){//get the position after checking all the conditions are met
        try
        {
        pos = int.Parse(Console.ReadLine());
       // Check if the position is within the valid range
        if (pos >= 1 && pos <= 9 && game_board.Array_Board[pos-1] != "X" && game_board.Array_Board[pos-1] != "O" ){
            validInput = true; // Exit the loop
        }
        else{
            Console.WriteLine("Please enter a number between 1 and 9 (Make sure that the position is available).");
        }
        }
        catch{
        Console.WriteLine("Please enter a valid number.");
        }
        } 
        
        return pos;
    }

    public bool CheckWinner(string[] board){//This will check the conditions of the board for any possible winner
        for(int i = 1; i<=9;i+=3){
            int index = i-1;
            //Check rows
            if(board[index] != " " &&board[index] == board[index+1] && board[index+1] == board[index+2]){
                return true;
            }
            //Check diagonally
            if(index == 0 && board[index] != " " && board[index] == board[4] && board[4] == board[8] ){
               return true; 
            }
            if(index == 6 && board[index] != " " && board[index] == board[4] && board[4] == board[2] ){
               return true; 
            }
        }
        //Check Columns
        for(int i =0; i<3;i++){
            if(board[i] != " " && board[i]==board[i+3] && board[i+3] == board[i+6] ){
                return true;
            }
        }
        return false;
    }
    public bool GameOver(){//If the attempts reach 9 the game is over and this will run.
        if(attempts == 9){
            return true;
        }else{
            return false;
        }
    }

    void SlowPrint(string text, int delay)//A method just for slow printing to look better
    {
         while (Console.KeyAvailable) 
        {
             Console.ReadKey(true); // Clear existing input before printing
        }
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(delay);
        }

        Console.WriteLine(); // Move to the next line after printing
    }

    void SwitchPlayer(){//Switch player alternatively at the end of each execution of PlayGame()

        if (current_player == player_1)
        {
        current_player = player_2;
        }
        else
        {
        current_player = player_1;
        }
        
    }

    public void DisplayResult(){//method for displaying the results at the end 
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("========================================");
        if(CheckWinner(game_board.Array_Board)){
        Console.WriteLine($"The Winner is {current_player.Name} ");
        }else{
            Console.WriteLine("The Game ended in a tie with no winners");
        }
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.ResetColor();
        game_board.DisplayBoard();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"The score of {player_1.Name} is {player_1.score}");
        Console.WriteLine($"The score of {player_2.Name} is {player_2.score}");
        Console.ResetColor();
        PlayAgain();

    }

    public void Restart(){//Reset the values and restart the game
        attempts =0;
        game_board.Array_Board = new string[] {" "," "," "," "," ", " ", " ", " ", " "};
        PlayGame();
    }

    public void PlayAgain(){//Ask the player to play again
        SlowPrint("Press Y to play again!!!",150);
        string keypressed = Console.ReadLine().ToUpper();
        if(keypressed == "Y"){
            Restart();
        }else{
            Environment.Exit(0);
        }
    }

    public void BlockInputDuringTransition(int durationMs)//This method will block accidental user input in transition between pages
    {
    // Clear existing input
    while (Console.KeyAvailable)
    {
        Console.ReadKey(true); // Discard buffered keys
    }

    // Block new input for a duration
    DateTime start = DateTime.Now;
    while ((DateTime.Now - start).TotalMilliseconds < durationMs)
    {
        if (Console.KeyAvailable)
        {
            Console.ReadKey(true); // Continue discarding new input
        }
        Thread.Sleep(10); // Reduce CPU usage
    }
    }
}
