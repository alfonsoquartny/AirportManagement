using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{

    private MeshRenderer yesilMesh;
    private MeshRenderer beyazesh;
    private MeshRenderer textMesh;

    private GameObject text;
    private GameObject yesil;
    private GameObject beyaz;
    void Start()
    {


        yesilMesh = yesil.GetComponentInParent<MeshRenderer>();
        beyazesh=beyaz.GetComponentInParent<MeshRenderer>();
       textMesh=text.GetComponentInParent<MeshRenderer>();

        yesilMesh = null;
        beyazesh = null;
        textMesh = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
