using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 1;
    // déclarez une nouvelle variable privée de type PlayerController nommée playerControllerScript.
    private PlayerController playerControllerScript;
    void Start() {
        // utilisez GameObject.Find(String).GetComponent<Component>() pour trouver le component de
        // type PlayerController sur le GameObject nommé «Player»
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void Update() {
        // SI LA VARIABLE gameOver DU SCRIPT PlayerController du GameObject nommé «Player»
        // N'EST PAS VRAIE, ME DÉPLACER 
        if (playerControllerScript.gameOver == false ) { 
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }
}
