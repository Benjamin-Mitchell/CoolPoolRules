using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    GameManager manager;
    Button button;
    
    public int number;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(IAmPotted);

        button.gameObject.GetComponentInChildren<Text>().text = number.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IAmPotted(){
        manager.BallPotted(number);
        Destroy(gameObject);
    }
}
