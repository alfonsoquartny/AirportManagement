using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Vector3 rotChanger;
    public GameObject prefab;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Instantiate(prefab,rotChanger, Quaternion.identity);
        
        }


    }

}
