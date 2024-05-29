using UnityEngine;
using UnityEngine.InputSystem;

public class InputAccess : MonoBehaviour{
    PlayerMovement PlayerScript;
    PlayerPowers PlayerPowerScript;
    PlayerPortal PlayerPortalScript;
    void Start(){
        PlayerScript = GetComponent<PlayerMovement>();
        PlayerPowerScript = GetComponent<PlayerPowers>();
        PlayerPortalScript = GetComponent<PlayerPortal>();
    }

    void Update(){
        
    }
    void OnMove(InputValue input){
        PlayerScript.MoveAccess(input.Get<Vector2>());
    }
    void OnLook(InputValue input) {
       PlayerScript.LookAccess(input.Get<Vector2>());
    }
    void OnFire() {
        PlayerPowerScript.onFire();
        //print("fire");
    }
    void OnSpawnPortal(){
        //print("call");
        PlayerPortalScript.SpawnPortal();
    }
}
