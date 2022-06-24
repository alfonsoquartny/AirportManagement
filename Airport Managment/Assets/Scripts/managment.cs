using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class managment : MonoBehaviour
{
    Vector3 touchPosWorld;
    TouchPhase touchPhase = TouchPhase.Ended;

    public Transform nextSpawnPos;
    public GameObject prefab;
    public spawnZoneManagment spawnManagment;
    public aiController _aiController;

   public money money;
    private GameObject valueObject;
    private value value;
    private bool selected;

    public GameObject selectedNPC;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            if (Input.touchCount == 1 && Input.GetTouch(0).phase == touchPhase)
            {

            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
            if (Physics.Raycast(ray, out hit))
            {

                Debug.Log(hit.transform.name);
                if (hit.collider != null)
                {

                    GameObject touchedObject = hit.transform.gameObject;

                    if (hit.transform.gameObject.name == "npc")
                    {
                        selectedNPC = hit.transform.gameObject;
                        selected = true;

                    }
                    if(hit.transform.gameObject.CompareTag("None"))
                    {
                        selectedNPC=null;
                        _aiController = null;
                    }
                    spawnManagment = touchedObject.GetComponent<spawnZoneManagment>();


                    Debug.Log("Touched " + touchedObject.transform.name);
                    if (touchedObject.transform.name == "SpawnZone")
                    {
                        valueObject = touchedObject;
                        value = touchedObject.GetComponent<value>();
                    }
                        if (touchedObject.transform.name=="SpawnZone"||touchedObject.transform.name== "spawnZone(Clone)")
                        {
                      
                        if (spawnManagment.working == false&&money.moneyInt>=value.valueMoney)
                        {

                            Instantiate(prefab, touchedObject.transform);
                            money.moneyInt = money.moneyInt - value.valueMoney;

                            spawnManagment.working = true;
                        }

                        if (spawnManagment.working == true&&selected==true&&spawnManagment.busy==false)
                        {
                           _aiController.Target=touchedObject;
                           spawnManagment.busy = true;
                        }
                       

                       
                        }

                    
                }

            }

            _aiController = selectedNPC.GetComponent<aiController>();
        }

      

    }
}
