using System.Collections.Generic;
using UnityEngine;

public class PlayerPortal : MonoBehaviour{

    GameObject PlayerPortalGameObject;
    float SpawnDistance;
    List<GameObject> PlayerPortalList = new List<GameObject>();

    void Start(){
        PlayerPortalGameObject = Resources.Load<GameObject>("PlayerPortal");
        SpawnDistance = 5;
    }

    void Update(){
        
    }
    public void SpawnPortal() {
        Vector3 direction = transform.forward;
        Vector3 postion = Vector3.zero;
        
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward,out hit, SpawnDistance)) {
            Vector3 HitPosition = hit.point;
            postion = new Vector3(HitPosition.x,HitPosition.y,HitPosition.z);
            //print(HitPosition);
        }
        else {
            postion = transform.position + new Vector3(direction.x * SpawnDistance, transform.position.y - 1, direction.z * SpawnDistance);
        }

        Quaternion rotation = transform.rotation;
        //rotation *= Quaternion.AngleAxis(90, Vector3.up);

        PlayerPortalList.Add(Instantiate(PlayerPortalGameObject, postion, rotation));


        if(PlayerPortalList.Count > 2) {
            RemoveProtals(PlayerPortalList[0]);
        }
        if(PlayerPortalList.Count == 2) {
            PlayerPortalList[0].GetComponent<Portals>().SetDestination(PlayerPortalList[1].GetComponent<Transform>());
            PlayerPortalList[1].GetComponent<Portals>().SetDestination(PlayerPortalList[0].GetComponent<Transform>());
        }
    }

    public void RemoveProtals(GameObject PortalsObject) {
        PlayerPortalList.Remove(PortalsObject);
        Destroy(PortalsObject);
    }


}
