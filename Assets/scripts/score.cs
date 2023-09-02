using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{


    [SerializeField]
    public Text S = null;
    public  int sco;


    // Use this for initialization
    void Start()
    {
        sco = 0;
    }

    // Update is called once per frame
    void Update()
    {
        sco = sco + 1;
        S.text = "score = " + sco;
    }
}
