using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie : MonoBehaviour {



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("zom"))
        {
            Destroy(other.gameObject);
            //gameObject.SetActive(false); 
            
            //playerObject.transform.Rotate(new Vector3(-500, 0, 0) );
        }

    }
    // Use this for initialization
    void Start () {
        
      
    }


    // Update is called once per frame
    void Update () {
		
	}
}
