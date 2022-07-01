using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sira : MonoBehaviour
{

    public GameObject[] siras;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (siras[0].transform.name=="siraNull")
        {
            if (siras[0].transform.name == "siraNull")
            {
                siras[4] = siras[1];
                if (siras[1].transform.name == "siraNull")
                {
                    siras[4] = siras[2];
                    if (siras[2].transform.name == "siraNull")
                    {
                        siras[4] = siras[2];
                        if (siras[3].transform.name == "siraNull")
                        {
                            siras[4] = null;
                        }

                    }
                }

            }

           

           

           
          
        }

        if (siras[0].transform.name == "sira0")
        {
            siras[4] = siras[0];
        }
    }
}
