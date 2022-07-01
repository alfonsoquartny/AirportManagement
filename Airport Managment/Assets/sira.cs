using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sira : MonoBehaviour
{

    public GameObject[] siras;
    public bool canSpawn;
    public float timer;
    private float defaultTimer;

    public GameObject prefab;
    void Start()
    {
        defaultTimer = timer;
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
                        siras[4] = siras[3];
                        if (siras[3].transform.name == "siraNull")
                        {
                            siras[4] = null;
                        }

                    }
                }

            }



            if (siras[4] == null)
            {
                canSpawn = false;
            }
            else
            {
                canSpawn = true;

            }
            if (canSpawn == true)
            {
                timer -= Time.deltaTime;
            }

            if (timer < 0)
            {
                Instantiate(prefab);
                timer = defaultTimer;
            }


        }

        if (siras[0].transform.name == "sira0")
        {
            siras[4] = siras[0];
        }
    }
}
