using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atck : MonoBehaviour {
    public Animator anim;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("attackBox"))
        {
            anim.SetTrigger("attackTrig");
            //speed = 0f;
            //gameObject.SetActive(false); 
            //playerObject.transform.Rotate(new Vector3(-500, 0, 0) );
        }
        if (other.gameObject.CompareTag("dainasour"))
        {
            
                anim.SetTrigger("fall");
                //speed = 0f;
                //gameObject.SetActive(false); 
                //playerObject.transform.Rotate(new Vector3(-500, 0, 0) );
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("dainasour"))
        {
            anim.SetTrigger("attackTrig");
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update () {
        

    }
}
