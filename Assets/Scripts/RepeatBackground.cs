using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    // Une variable privée startPos qui garde en mémoire la position de l’objet au démarrage
    private Vector3 startPos;
    // Déclarez une nouvelle variable privée de type float repeatWidth qui va contenir 
    // la distance du centre vers un des bords de l’arrière-plan.
    private float repeatWidth;
    void Start() {
        startPos = transform.position;
        // Dans Start(), obtenez la largeur du Box Collider divisée par 2 (i.e. la distance du 
        // centre vers un de ses bords) avec la propriété size.x des BoxCollider.
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }
    void Update() {
        // Un code qui remet la position de l’arrière-plan Background à son point de départ 
        // s'il s’est déplacé de repeatWidth unités sur l’axe de x.
        if (transform.position.x < startPos.x - repeatWidth) {
            transform.position = startPos;
        }
    }
}

