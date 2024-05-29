using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour{

    Rigidbody PlayerRb;
    Vector2 PlayerMove;
    GameObject bulletPrefab;
    TextMeshProUGUI Score;
    
    //TMP_Text Score;

    int ApplyForce = 50;
    float BulletSpeed = 500;
    float health;
    float tempValue;
    float LifeTimer;
    float LookSpeed;
    void Start(){
        PlayerRb = this.GetComponent<Rigidbody>();
        bulletPrefab = Resources.Load<GameObject>("Bullet");
        Score = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
    }
    void Awake(){
        health = 15;
        tempValue = 0;
        LifeTimer = 0;
        LookSpeed = 40;

    }

    void FixedUpdate(){
        PlayerRb.AddForce((transform.forward * PlayerMove.y * ApplyForce) + (transform.right * PlayerMove.x * ApplyForce));
        //PlayerRb.AddForce(transform.forward * 20);
        PlayerRb.velocity = Vector3.ClampMagnitude(PlayerRb.velocity, 30);
        
        LifeTimer -= Time.deltaTime;
    }

    public void MoveAccess(Vector2 input) {
        PlayerMove = input;
    }
    public void LookAccess(Vector2 input) {
        Vector3 temp = input;
        Quaternion quaternion = Quaternion.Euler(0, temp.x * 30f * Time.deltaTime, 0);
        PlayerRb.MoveRotation(PlayerRb.rotation * quaternion);
    }

    public void FireAccess(Vector3 Direction) {

        Direction = transform.TransformDirection(Direction);
        Vector3 postion = this.transform.position + Direction / 6 * 2;
        //print($"{transform.position} {direction} multiple -> {direction * 2} total -> {transform.position + direction * 2}");

        GameObject bullet = Instantiate(bulletPrefab, postion, this.transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(new Vector3(Direction.x / 6 * BulletSpeed, 0, Direction.z / 6 * BulletSpeed));
    }

    public void PlayerDamage(float damage = 1) {

        if(LifeTimer < 0) {

            health -= damage;
            GameObject.Find("PostProcesser").GetComponent<PostProcessor>().takeDamage();
            GameObject.Find("Canvas").GetComponent<MenuControl>().HealthReduceAndIncreace(-damage);
            //print(health);
            if (health == 0){
                Time.timeScale = 0;
                GameObject.Find("Canvas").GetComponent<MenuControl>().ActiveGameOverPanel();
                    //Invoke("ActiveGameOverPanel", 2f);
            }
        }
       
    }

    public void ScoreUpdate(float point = 10){
        tempValue += point;
        //print(tempValue + " " + point);
        Score.text = $"Score {tempValue}";

    }
    public void PlayerLifeTimer(float LifeTime = 10) {
        LifeTimer = LifeTime;
    }
    public void SetLookSpeed(float _speed) {

        if(LookSpeed < 100) {
            LookSpeed *= _speed;
        }
        else
        {
            LookSpeed = 40;
        }
        

    }
    public void IncreaseHealth(float HealthValue = 1f) {
        
        health += HealthValue;
        GameObject.Find("Canvas").GetComponent<MenuControl>().HealthReduceAndIncreace();
    }

}
