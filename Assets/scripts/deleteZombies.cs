using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteZombies : MonoBehaviour {

    float speed = 4.4f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("zom"))
        {
            Destroy(other.gameObject);
            //speed = 0f;
            //gameObject.SetActive(false); 
            //playerObject.transform.Rotate(new Vector3(-500, 0, 0) );
        }

    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f, 6f * Time.deltaTime);
        if (Input.GetMouseButton(0))
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        if (Input.GetMouseButton(1))
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
    }
}
