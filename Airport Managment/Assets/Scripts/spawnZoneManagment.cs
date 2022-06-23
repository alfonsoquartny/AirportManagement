using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnZoneManagment : MonoBehaviour
{

    public bool busy;
    public bool working;
    public bool temas;

    public Animator animator;

    public MeshRenderer mesh1;
    public MeshRenderer mesh2;
    public MeshRenderer mesh3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (working == true)
        {
            mesh1.enabled=false;
            mesh2.enabled = false;
            mesh3.enabled = false;

        }
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
