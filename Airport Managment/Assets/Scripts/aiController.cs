using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class aiController : MonoBehaviour
{

    public GameObject Target;
  public GameObject spawnTarget;
    private bool spawnBusy;
  NavMeshAgent _navmeshAgent;
    public bool npcBusy;
    public GameObject exit;

    private Animator animator;
   public managment managment;
    private GameObject managmentOb;
    public bool masaTemas;

    public bool isWalk;
    public GameObject entry;

    public GameObject planeBarObject;
    public Image sabirBar;
    public GameObject bars;
    public Image planeBar;
   public bool winCust;
    public float npcBusyTimer;

    public spawnZoneManagment spawnZoneManagment;
    public bool loseCust;
    public GameObject angryImage;

    public money money;
    private bool earnMoney;

    public int randomLoby;
    public bool leaved;
    int randomSabir;
    public int[] winnableMoney;
    public GameObject speedReset;
   private sira sira;
    int aktifBar;
    void Start()
    {
        aktifBar = Random.Range(1, 4);

        money = GameObject.Find("money").GetComponent<money>();
        speedReset = GameObject.Find("speedReset");

        managmentOb = GameObject.FindGameObjectWithTag("MainCamera");

        managment = managmentOb.GetComponent<managment>();
        sira = GameObject.Find("Manager").GetComponent<sira>();

        gameObject.transform.name = "npc";

        randomLoby = Random.Range(10, 55);
     randomSabir = Random.Range(26, 65);

        entry = GameObject.FindGameObjectWithTag("entry");
        exit = GameObject.FindGameObjectWithTag("exit");
        animator = gameObject.GetComponent<Animator>();

        _navmeshAgent = GetComponent<NavMeshAgent>();
        npcBusy = false;
        planeBar = GetComponentInChildren<Image>();
        planeBar = planeBarObject.GetComponent<Image>();
        sabirBar.fillAmount = 1;

        planeBar.fillAmount = 1;
        _navmeshAgent.speed = 0;

      
    }

    void Update()
    {
        if (aktifBar == 1&&npcBusy==false)
        {
            sabirBar.gameObject.SetActive(true);
            planeBar.gameObject.SetActive(false);
        }
        if (aktifBar == 2&&npcBusy==false)
        {
            sabirBar.gameObject.SetActive(false);
            planeBar.gameObject.SetActive(true);
        }
        if (aktifBar == 3 && npcBusy == false)
        {
            sabirBar.gameObject.SetActive(true);
            planeBar.gameObject.SetActive(true);
        }
        if (spawnBusy == false)
        {
            spawnTarget = sira.siras[7];
            _navmeshAgent.SetDestination(spawnTarget.transform.position);
            speedReset.transform.position=spawnTarget.transform.position;

        }
        else
        {
            spawnTarget = null;
        }

        if (earnMoney == true && npcBusyTimer <0&&npcBusyTimer > -1)
        {
            earnMoney = false;

            npcBusyTimer = -1;

            money.moneyInt = money.moneyInt + 75;
            Vibrator.Vibrate(200);

        }
        if (masaTemas == true)
        {
            isWalk = false;
        }
        
        if (isWalk == true)
        {
            animator.SetBool("isWalk",true);
        }
        if (isWalk == false)
        {
            animator.SetBool("isWalk",false);
        }
        if (loseCust==true)
        {
            _navmeshAgent.speed = 4f;

            Target = exit;
            _navmeshAgent.SetDestination(Target.transform.position);
            npcBusy = true;
           angryImage.SetActive(true);
            Destroy(bars);
            Destroy(gameObject, 11f);
            isWalk = true;

            spawnZoneManagment.busy = false;
            spawnZoneManagment = null;

        }
        if (winCust == true)
        {
         
            Target = entry;
            managment.spawnNpc = true;
            _navmeshAgent.SetDestination(Target.transform.position);
            Destroy(gameObject, 7f);
            _navmeshAgent.speed = 4.5f;
            earnMoney = true;

            spawnZoneManagment.busy = false;
            spawnZoneManagment = null;


      
        }

        if (npcBusy == false)
        {
           planeBar.fillAmount -= Time.deltaTime/randomLoby;
            sabirBar.fillAmount -= Time.deltaTime/randomSabir;
            _navmeshAgent.SetDestination(Target.transform.position);
            _navmeshAgent.speed = 3.5f;

            npcBusy = true;

        }
        if(npcBusy==true)
        {
            npcBusyTimer -= Time.deltaTime * 2;
            spawnBusy = true;

            Destroy(bars);


        }

        if (npcBusy == true && masaTemas == false)
        {
            isWalk = true;
        }
        if (npcBusy == true && masaTemas == true)
        {
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
            Target = null;
            Debug.Log("masa");
            masaTemas = true;
            spawnZoneManagment = other.gameObject.GetComponent<spawnZoneManagment>();
            
        }

        if (other.gameObject.CompareTag("sira"))
        {
            spawnBusy = true;
        }


        if (other.gameObject.transform.name == ("speedReset") && npcBusy == false)
        {
            _navmeshAgent.speed = 0;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Desktop"))
        {
            masaTemas = false;

        }

       

    }


}
