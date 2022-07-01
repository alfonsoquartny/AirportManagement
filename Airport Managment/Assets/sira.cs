using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sira : MonoBehaviour
{

    public GameObject[] siras;
    public bool canSpawn;
    public float timer;
    private float defaultTimer;

    public GameObject[] prefab;

    void Start()
    {
        defaultTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {

        if (siras[7] == siras[0] || siras[7] == siras[1] || siras[7] == siras[2] || siras[7] == siras[3] || siras[7] == siras[4]|| siras[7] == siras[5] || siras[7] == siras[6])
        {
            canSpawn = true;
        }
        else
        {
            canSpawn = false;
        }

        if (canSpawn == true)
        {
            timer -= Time.deltaTime;
        }

        if (timer < 0)
        {

            var randomNpc = Random.Range(0, 3);
            if(randomNpc == 0)
            {
                Instantiate(prefab[0]);

            }
            if (randomNpc == 1)
            {
                Instantiate(prefab[1]);

            }
            if (randomNpc == 2)
            {
                Instantiate(prefab[2]);

            }
            timer = defaultTimer;
        }


        if (siras[0].transform.name=="siraNull")
        {
            if (siras[0].transform.name == "siraNull")
            {
                siras[7] = siras[1];
                if (siras[1].transform.name == "siraNull")
                {
                    siras[7] = siras[2];
                    if (siras[2].transform.name == "siraNull")
                    {
                        siras[7] = siras[3];
                        if (siras[3].transform.name == "siraNull")
                        {
                            siras[7] = siras[4];
                            if (siras[4].transform.name == "siraNull")
                            {
                                siras[7] = siras[5];
                                if (siras[5].transform.name == "siraNull")
                                {
                                    siras[7] = siras[6];
                                    if (siras[6].transform.name == "siraNull")
                                    {
                                        siras[7] =null;
                                    }
                                }
                            }
                        }

                    }
                }

            }

        


        }

        if (siras[0].transform.name == "sira0")
        {
            siras[7] = siras[0];
        }
    }
}
