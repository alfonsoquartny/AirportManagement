using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siraNamer : MonoBehaviour
{


    public string startName;

    public bool temas;
    private aiController ai;
    void Start()
    {
       startName=gameObject.transform.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (temas == true)
        {
            gameObject.transform.name = "siraNull";
        }
        else
        {
            gameObject.transform.name = startName;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("npc"))
        {
            ai=other.GetComponent<aiController>();
            ai.isWalk = false;
            temas = true;
        }

       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("npc"))
        {

            temas = false;
        }
    }
}
