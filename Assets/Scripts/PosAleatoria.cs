using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosAleatoria : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>().position = new Vector3(Random.Range(-10,10), 0 ,Random.Range(-10, 10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
