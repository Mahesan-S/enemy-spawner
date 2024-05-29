using System.Collections.Generic;
using UnityEngine;

public class PowerGenetator : MonoBehaviour{

    List<GameObject> PowerList = new List<GameObject>();
    Collider Floor;
    
    void Start(){
        
        PowerList.Add(Resources.Load<GameObject>("ShootPower"));
        PowerList.Add(Resources.Load<GameObject>("LifePower"));
        PowerList.Add(Resources.Load<GameObject>("FreezePower"));
        PowerList.Add(Resources.Load<GameObject>("Health"));

        Floor = GameObject.Find("Floor").GetComponent<Collider>();
    }

    void FixedUpdate(){
        int number = Random.Range(0, 100);
        if(number == 0) {
            //SpawnPowers();
        }
    }

    public void SpawnPowers() {

        Vector3 postion = Vector3.zero;
        
        float ScaleX = PowerList[0].transform.localScale.x;
        Vector3 Scale = new Vector3(ScaleX, ScaleX, ScaleX);
        
        int index = 0;
        
        do {
            float Xaxis = Random.Range(Floor.bounds.min.x, Floor.bounds.max.x);
            float Zaxis = Random.Range(Floor.bounds.min.z, Floor.bounds.max.z);
            postion = new Vector3(Xaxis, Floor.bounds.max.y + 1, Zaxis);
            index++;

        } while (Physics.CheckBox(postion,Scale) && index > 10);


        Instantiate(PowerList[Random.Range(0,PowerList.Count)], postion, Quaternion.identity);
    }
}
