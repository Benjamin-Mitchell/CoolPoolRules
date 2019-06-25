using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missed : MonoBehaviour
{
    GameManager manager;
    Button button;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(IAmPotted);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IAmPotted(){
        manager.BallMissed();
    }
}
