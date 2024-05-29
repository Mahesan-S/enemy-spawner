using UnityEngine;

public class Portals : MonoBehaviour{

    Transform Destination;
    public static float timer = 3;
    void Start(){
        
    }

    void Update(){
        
    }
    private void OnTriggerEnter(Collider collsion){
        if (collsion.gameObject.CompareTag("Player") && timer < 0f){
            
            if(Destination == null) { return; }
            timer = 3f;
            collsion.gameObject.transform.position = new Vector3(Destination.position.x, collsion.gameObject.transform.position.y, Destination.position.z);

            if (this.gameObject.CompareTag("Portals")) {
                transform.parent.GetComponent<PortalsContollor>().SpawnPortal();
            }
            else {
                collsion.gameObject.GetComponent<PlayerPortal>().RemoveProtals(Destination.gameObject);
                collsion.gameObject.GetComponent<PlayerPortal>().RemoveProtals(gameObject);
            }
            
        }
    }
    public void SetDestination(Transform DestinationValue) {
        Destination = DestinationValue;
    }
}
