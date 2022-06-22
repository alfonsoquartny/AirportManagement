using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnZoneManagment : MonoBehaviour
{

    public bool busy;
    public bool working;
    public bool temas;

    public Animator animator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (temas == true)
        {
            animator.SetBool("isWalk", false);

        }
        else
        {
            animator.SetBool("isWalk", true);
        }
    }


}
