using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour {
    float speed = 4.4f;
    public Animator anim;

    // Use this for initialization
    void Start () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("zom"))
        {
            anim.SetTrigger("attackTrig");

            //speed = 0f;
            //gameObject.SetActive(false); 
            //playerObject.transform.Rotate(new Vector3(-500, 0, 0) );
        }

    }
    // Update is called once per frame
    void Update () {

        transform.Translate(0f, 0f, 6.5f * Time.deltaTime);
        if (Input.GetMouseButton(0))
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        if (Input.GetMouseButton(1))
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }
}
