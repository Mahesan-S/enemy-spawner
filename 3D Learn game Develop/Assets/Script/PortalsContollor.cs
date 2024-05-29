using System.Collections.Generic;
using UnityEngine;

public class PortalsContollor : MonoBehaviour{

    GameObject[] PortalsGameObject;
    List<GameObject> ActivatePortal = new List<GameObject>();
    void Start(){
        PortalsGameObject = GameObject.FindGameObjectsWithTag("Portals");
        foreach(GameObject portalObject in PortalsGameObject) { 
            portalObject.SetActive(false);
        }
        SpawnPortal();
    }

    void Update(){
        Portals.timer -= Time.deltaTime;
    }
    public void SpawnPortal() { 
        int portal_1 = Random.Range(0, PortalsGameObject.Length);
        int portal_2 = 0;

        do{
            portal_2 = Random.Range(0, PortalsGameObject.Length);
        } while (portal_1 == portal_2);

        while(ActivatePortal.Count > 0) {
            ActivatePortal[0].SetActive(false);
            ActivatePortal.RemoveAt(0);
        }

        ActivatePortal.Add(PortalsGameObject[portal_1]);
        ActivatePortal.Add(PortalsGameObject[portal_2]);

        PortalsGameObject[portal_1].SetActive(true);
        PortalsGameObject[portal_2].SetActive(true);

        PortalsGameObject[portal_1].GetComponent<Portals>().SetDestination(PortalsGameObject[portal_2].GetComponent<Transform>());
        PortalsGameObject[portal_2].GetComponent<Portals>().SetDestination(PortalsGameObject[portal_1].GetComponent<Transform>());
    }
}
