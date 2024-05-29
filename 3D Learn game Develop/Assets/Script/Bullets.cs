using UnityEngine;

public class Bullets : MonoBehaviour{

    void Start(){
    }
    void FixedUpdate(){
        
    }
    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<Enemys>().EnemyDamage();
        }
        /*else if (collision.gameObject.CompareTag("PowerEnemy")) {
            collision.gameObject.GetComponent<Enemys>().EnemyDamage(0.2f);
        }*/
        Destroy(this.gameObject);
    }
}
