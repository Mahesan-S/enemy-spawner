using UnityEngine;

public class PlayerPowers : MonoBehaviour{

    Vector3[] TribleBulletsDirection ={
        Vector3.forward *6,
        Vector3.forward *6 +Vector3.left,
        Vector3.forward *6 +Vector3.right
    };
    float TribleBulletTime;

    PlayerMovement PlayerScript;
    void Start(){
        PlayerScript = GetComponent<PlayerMovement>();
    }

    void FixedUpdate(){
        TribleBulletTime -= Time.deltaTime;
    }
    public void onFire() {
        if(TribleBulletTime > 0){
            foreach (Vector3 Direction in TribleBulletsDirection){
                PlayerScript.FireAccess(Direction);

            }
        }
        else {
            PlayerScript.FireAccess(TribleBulletsDirection[0]);
        }
    }
    public void PowerTimer(float timer = 10) {
        TribleBulletTime = timer;
        //print(TribleBulletTime);
    }
}
