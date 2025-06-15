public class Player {//A class for the players
    public string Mark {set;get;} //"X" or "O" with setters and getter
    public string Name{set;get;} // name with setter and getter

    public int score{set;get;}// Keep track of the score in case they wanted to play again

    public Player(string name,string mark){//Constructor for the player class 
        Name = name;
        Mark = mark;
        this.score = 0;
    }

    public void PlaceMark(string[] board, int position){//method for placing the mark on the board
        board[position-1] = this.Mark;

    }
}