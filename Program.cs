
Game jeu = new Game();//Creaete a new game object
jeu.GetPlayers();//Get the players information
//Thread.Sleep(250);
jeu.BlockInputDuringTransition(1600);
jeu.PlayGame();//Start the game
 Console.ReadKey();