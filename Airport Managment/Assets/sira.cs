using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sira : MonoBehaviour
{


    public bool dolu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "npc")
        {
            dolu = false;
        }
    }
}
