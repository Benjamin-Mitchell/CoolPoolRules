using System.Collections;
using System.Collections.Generic;
using System;

public class RuleDecider {

    public string PickARule(List<Player> players, int currentPlayer){
        Random random = new Random();
        rule ruleToCall = rules[random.Next(rules.Count)];
        return ruleToCall(players, currentPlayer);
    }

    List<rule> rules = new List<rule>();

    public void CreateList(){
        rules.Add(rule0);
        rules.Add(rule1);
        rules.Add(rule2);
        rules.Add(rule3);
        rules.Add(rule4);
        rules.Add(rule5);
    }

    delegate string rule(List<Player> players, int currentPlayer);

    string rule0(List<Player> players, int currentPlayer){
        //Go again
        players[currentPlayer].remainingTurnsToTake++;
        return "GO AGAIN";
    }
    
    string rule1(List<Player> players, int currentPlayer){
        //Go again Twice
        players[currentPlayer].remainingTurnsToTake+=2;
        return "GO AGAIN AGAIN";
    }

    string rule2(List<Player> players, int currentPlayer){
        //Gain a life
        players[currentPlayer].lives++;
        return "GAIN A LIFE";
    }
    
    string rule3(List<Player> players, int currentPlayer){
        //Gain Immunity
        players[currentPlayer].immunity = true;
        return "IMMUNITY";
    }

    string rule4(List<Player> players, int currentPlayer){
        //next player go twice
        int index = currentPlayer + 1 < players.Count ? currentPlayer + 1 : 0;
        players[index].remainingTurnsToTake += 2;
        return players[index].name + " GO TWO MORE TIMES!!";
    }

    string rule5(List<Player> players, int currentPlayer){
        //previous player go twice
        int index = currentPlayer - 1 > 0 ? currentPlayer - 1 : players.Count - 1;
        players[index].remainingTurnsToTake += 2;
        return players[index].name + " GO TWO MORE TIMES!!";
    }

    string rule6(List<Player> players, int currentPlayer){
        //player chooses another player to take 4 shots;
        //if they pot them all, the choosing player is out
        return "un-implemented";
    }

    
    string rule7(List<Player> players, int currentPlayer){
        //use the lowest ball on the table to pot the white ball.
        //success is +2 lives
        return "un-implemented";
    }

    
    string rule8(List<Player> players, int currentPlayer){
        //if black is still in play, use it to pot the white.
        //success is +2 lives
        return "un-implemented";
    }

    
    string rule9(List<Player> players, int currentPlayer){
        //take next shot with your eyes closed
        players[currentPlayer].remainingTurnsToTake++;
        return "TAKE ANOTHER SHOT - WITH YOUR EYES CLOSED!";
    }

    string rule8(List<Player> players, int currentPlayer){
        //if black is still in play, use it to pot the white.
        //success is +2 lives
        return "un-implemented";
    }
}