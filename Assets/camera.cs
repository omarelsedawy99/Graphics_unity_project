using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {
    int counter;
    int x;
	// Use this for initialization
	void Start () {
        counter = 0;
        x = 0;
    }
	
	// Update is called once per frame
	void Update () {
        counter++;
        
        print(counter + " "+x);
        if (counter/20 % 2 == 0)
        {
            transform.Rotate(0f, 100f * Time.deltaTime, 0f);
        }else
        transform.Rotate(0f, -100f * Time.deltaTime, 0f);


    }
}
