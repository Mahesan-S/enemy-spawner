using UnityEngine;

public class Powers : MonoBehaviour{

    [SerializeField] float mode;
    void Start(){
       /* string PowerName = gameObject.name;
        switch (PowerName) {
            
            case "FreezePower":
                mode = 1;
                break;
            
            case "LifePower":
                mode = 2;
                break;
            
            case "ShootPower":
                mode = 3;
                break;
            
            default:
                print("no object found");
                break;
        }*/
    }

    void Update(){
        
    }
    private void OnTriggerEnter(Collider collider){
        if (collider.gameObject.CompareTag("Player")) {

            switch (mode) {
                
                case 1:
                    Enemys.SetEnemyFreezeTimer();
                    break;
                
                case 2:
                    collider.gameObject.GetComponent<PlayerMovement>().PlayerLifeTimer();
                    break;
                
                case 3:
                    collider.gameObject.GetComponent<PlayerPowers>().PowerTimer();
                    break;
                case 4:
                    collider.gameObject.GetComponent<PlayerMovement>().IncreaseHealth();
                    break;
                
                default:
                    //print("nooooo call");
                    break;
            }

            this.gameObject.GetComponent<PowerGenetator>().SpawnPowers();
            Destroy(this.gameObject);
        }
    }
}
