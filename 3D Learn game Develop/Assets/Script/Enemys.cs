using UnityEngine;
using UnityEngine.AI;

public class Enemys : MonoBehaviour{

    Transform PlayerTranfrom;
    NavMeshAgent EnemyNav;
    PlayerMovement PlayerScript;
    EnemySpawn EnemySpawnScript;
    

    float EnemyHealth;
    static float FreezeTimer;


    void Start(){
        PlayerScript  = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        PlayerTranfrom = GameObject.FindWithTag("Player").GetComponent<Transform>();
        EnemySpawnScript = GameObject.Find("EnemySpawner").GetComponent<EnemySpawn>();
        EnemyNav = GetComponent<NavMeshAgent>();


        EnemyHealth = 5;
        FreezeTimer = 0;

    }

    void Update(){
        ChaseEnemy();
        FreezeTimer -= Time.deltaTime;
       //print(FreezeTimer);
    }

    void ChaseEnemy() {
        /*Vector3 EnemySeePostion = new Vector3(PlayerTranfrom.position.x, PlayerTranfrom.position.y, PlayerTranfrom.position.z); 
        transform.LookAt(EnemySeePostion);
        
        if(Vector3.Distance(PlayerTranfrom.position,this.transform.position) > 2.5f) {
            transform.position += transform.forward * speed * Time.deltaTime;    
        }*/

        if(FreezeTimer < 0) {
            EnemyNav.isStopped = false;
            EnemyNav.destination = PlayerTranfrom.position;
        }
        else {
            EnemyNav.isStopped = true;
        }
        
        
        if(Vector3.Distance(PlayerTranfrom.position, this.transform.position) < 2f) {
           
            PlayerScript.PlayerDamage();
            EnemySpawnScript.RemoveGameObject(this.gameObject);
            Destroy(this.gameObject);
        }
    }
    public void EnemyDamage(float damage = 3) {
        EnemyHealth -= damage;
        //print(EnemyHealth);
        if (EnemyHealth <= 0) {
            EnemySpawnScript.RemoveGameObject(this.gameObject);
            Destroy(this.gameObject);
            PlayerTranfrom.gameObject.GetComponent<PlayerMovement>().ScoreUpdate();
            
        }
    }

    public static void SetEnemyFreezeTimer(float timer = 5) {

        if(timer == 5) {
            FreezeTimer = timer;
        }
        else{
            FreezeTimer -= timer;
        }
        
    }

}
