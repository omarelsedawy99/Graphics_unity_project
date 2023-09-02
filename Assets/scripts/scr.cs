using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr : MonoBehaviour
{

    public Animator anim;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("zom"))
        {
            anim.SetTrigger("attackTrig");
            //speed = 0f;
            //gameObject.SetActive(false); 
            //playerObject.transform.Rotate(new Vector3(-500, 0, 0) );
        }

    }*/
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            if (Input.GetMouseButton(0))
                transform.Translate(-4.85f * Time.deltaTime, 0f, 5.5f * Time.deltaTime);
            if (Input.GetMouseButton(1))
                transform.Translate(4.85f * Time.deltaTime, 0f, 5.5f * Time.deltaTime);
        }
        else
            transform.Translate(0f, 0f, 7f * Time.deltaTime);

    }
}
