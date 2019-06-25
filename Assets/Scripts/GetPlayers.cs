using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayers : MonoBehaviour
{
    GameManager manager;
    Button addPlayer, beginGame;

    List<Player> players = new List<Player>();


    public InputField inputField;
    // Start is called before the first frame update
    void Awake()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        manager.gameObject.SetActive(false);

        beginGame = GameObject.Find("BeginGame").GetComponent<Button>();
        beginGame.onClick.AddListener(BeginGame);

        addPlayer = GameObject.Find("AddPlayer").GetComponent<Button>();
        addPlayer.onClick.AddListener(AddPlayer);

        inputField.gameObject.SetActive(false);

        inputField.GetComponentInChildren<Button>().onClick.AddListener(SubmitName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SubmitName(){
        players.Add(new Player(inputField.text, 3));
        inputField.text = "";
        inputField.gameObject.SetActive(false);
    }

    void AddPlayer(){
        inputField.gameObject.SetActive(true);
        
    }

    void BeginGame(){
        manager.gameObject.SetActive(true);
        manager.SetPlayers(players);
    }
}
