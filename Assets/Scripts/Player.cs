public class Player
{
    public string name;
    public int lives;
    public int remainingTurnsToTake = 1;
    public bool immunity = false;
    public Player(string s, int i){
        name = s; lives = i;
    }
}
