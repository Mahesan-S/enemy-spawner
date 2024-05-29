using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour{

    [SerializeField] List<Transform> SpawnLocation;
    GameObject EnemysPrefab;
    List<GameObject> EnemyGameObjectList = new List<GameObject>();

    float timer,MaxTimer;
    int Waves;
    int NumberOfEnemys;
    float BreakTimeOfEachWave;
    
    void Start(){
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("spawner");
        foreach (GameObject obj in tempArray){
            SpawnLocation.Add(obj.transform);
        }
        
        EnemysPrefab = Resources.Load<GameObject>("Enemy");
        //print(SpawnLocation[0].position + " " + SpawnLocation[1].position);
        timer = 0;
        MaxTimer = 3f;
        Waves = 1;
        NumberOfEnemys = 10;
        BreakTimeOfEachWave = 2;
    }

    void Update(){
        SpawnEnemy();
    }

    void SpawnEnemy(){
        
        if (NumberOfEnemys >= 0){

            if (timer < 0){

                NumberOfEnemys--;
                Vector3 SpawnPostion = SpawnLocation[Random.Range(0, SpawnLocation.Count)].position + Vector3.up;
                EnemyGameObjectList.Add(Instantiate(EnemysPrefab, SpawnPostion, Quaternion.identity));
                timer = MaxTimer;
            }
        }
        else if (EnemyGameObjectList.Count == 0){

            Waves += 1;
            NumberOfEnemys = Waves * NumberOfEnemys;
            timer = BreakTimeOfEachWave;
        }
        
        timer -= Time.deltaTime;
        //print(Waves);
        
    }
    public void RemoveGameObject(GameObject enemyObj){
        EnemyGameObjectList.Remove(enemyObj);
    }
}
