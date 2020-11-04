using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOverLimit : MonoBehaviour
{

    public float limitX = -15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < limitX) Destroy(gameObject);
    }
}
