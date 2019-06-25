using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    List<Player> players;
    int currentPlayer;
    Text turnTeller, ruleShower;

    Animator ruleAnim;

    static GameManager theOnlyManager;
    int numBalls = 15;

    RuleDecider ruleDecider = new RuleDecider();
    
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if(!theOnlyManager){
            theOnlyManager = this;
        }else {
            Destroy(gameObject);
        }

        ruleDecider.CreateList();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!turnTeller){
            turnTeller = GameObject.Find("TurnTeller").GetComponent<Text>();

            ruleShower = GameObject.Find("RuleShower").GetComponent<Text>();
            ruleAnim = ruleShower.gameObject.GetComponent<Animator>();

            if(players.Count > 0)
            turnTeller.text = players[currentPlayer].name + "'s turn";
        }
    }

    public void SetPlayers(List<Player> inputPlayers){
        SceneManager.LoadScene("Main");
        players = inputPlayers;
    }

    public void BallPotted(int number){
        numBalls--;
        if(numBalls == 0){
            SceneManager.LoadScene("Main");
            numBalls = 15;
        }
        //give a rule!
        ruleShower.text = ruleDecider.PickARule(players, currentPlayer);
        ruleAnim.SetTrigger("Animate");
        NextTurn();
    }

    public void BallMissed(){
        if(!players[currentPlayer].immunity)
            players[currentPlayer].lives--;
        
        int oldIndex = currentPlayer;
        NextTurn();

        if(players[oldIndex].lives < 1){
            players.Remove(players[oldIndex]);
        }

        if(players.Count == 1){
            //We have a winner
            ResetGame();
        }
    }

    void NextTurn(){
        players[currentPlayer].remainingTurnsToTake--;
        players[currentPlayer].immunity = false;

        if(players[currentPlayer].remainingTurnsToTake <= 0){
            currentPlayer = currentPlayer < players.Count - 1 ? currentPlayer + 1 : 0;
            turnTeller.text = players[currentPlayer].name + "'s turn!";
            players[currentPlayer].remainingTurnsToTake = 1;
        }
    }

    void ResetGame(){
        currentPlayer = 0;
        players.Clear();
        turnTeller = null;
        SceneManager.LoadScene("Intro");
    }
}
