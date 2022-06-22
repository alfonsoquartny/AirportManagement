using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class aiController : MonoBehaviour
{

    public GameObject Target;
  NavMeshAgent _navmeshAgent;
    public bool npcBusy;
    public GameObject exit;

    private Animator animator;

    private bool isWalk;
    public GameObject entry;

    public GameObject planeBarObject;
    public Image planeBar;
    private bool winCust;
    public float npcBusyTimer;

    public bool masaTemas;

    public bool loseCust;
    public GameObject angryImage;


    public int randomLoby;
    public bool leaved;
    void Start()
    {
        randomLoby = Random.Range(10, 55);

        entry = GameObject.FindGameObjectWithTag("entry");
        exit = GameObject.FindGameObjectWithTag("exit");
        animator = gameObject.GetComponent<Animator>();

        _navmeshAgent = GetComponent<NavMeshAgent>();
        npcBusy = false;
        planeBar = GetComponentInChildren<Image>();
        planeBar = planeBarObject.GetComponent<Image>();

        planeBar.fillAmount = 1;
        _navmeshAgent.speed = 0;

    }

    void Update()
    {
        if (isWalk == true)
        {
            animator.SetBool("isWalk",isWalk);
        }
        if (isWalk == false)
        {
            animator.SetBool("isWalk",isWalk);
        }
        if (loseCust==true)
        {
            _navmeshAgent.speed = 5f;

            Target = exit;
            _navmeshAgent.SetDestination(Target.transform.position);
            npcBusy = true;
           angryImage.SetActive(true);
            Destroy(gameObject, 11f);
            isWalk = false;
        }
        if (winCust == true)
        {
         
            Target = entry;
            _navmeshAgent.SetDestination(Target.transform.position);
            Destroy(gameObject, 7f);
            _navmeshAgent.speed = 7.5f;
        }

        if (npcBusy == false)
        {
           planeBar.fillAmount -= Time.deltaTime/randomLoby;
            _navmeshAgent.SetDestination(Target.transform.position);
            _navmeshAgent.speed = 3.5f;

            npcBusy = true;

        }
        if(npcBusy==true)
        {
            npcBusyTimer -= Time.deltaTime * 2;
           
            Destroy(planeBarObject);
            isWalk = true;


        }

        if (npcBusyTimer < 0)
        {
            winCust = true;
        }

     
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Desktop"))
        {
            isWalk = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Desktop"))
        {
            isWalk = true;
        }
    }

}
