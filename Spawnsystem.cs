using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnsystem : MonoBehaviour
{

    public GameObject[] spawnPoints;

    public enum SpawnType { Random, OneByOne }

    public SpawnType spawnType;
    public string toSpawnResourceName = "Enemy";
    public int numberOfObjectsToSpawnOnContact = 1;
    public int maxGameobjectsToSpawn = 5;

    private int nextSpawnPointIndex = 0;
    private int spawnedObjects = 0;
    private GameObject toSpawn;
    public GameObject target;

    public GameObject[] enemiesAlive;
    

    public GameObject Camera;
    CameraM Kamera;

    
   



    // Start is called before the first frame update
    void Start()
    {
        toSpawn = Resources.Load(toSpawnResourceName) as GameObject;
        GameObject c = GameObject.FindGameObjectWithTag("MainCamera");
        GameObject g = GameObject.FindGameObjectWithTag("MainCamera");
        
        
        
        Kamera = g.GetComponent<CameraM>();


    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] enemiesAlive = GameObject.FindGameObjectsWithTag("Gunman");
        if (enemiesAlive.Length == 0)
        {

            if (spawnedObjects >= maxGameobjectsToSpawn)
            {


                Kamera.GetComponent<CameraM>().readyToGo();
                target.SetActive(false);
                Destroy(this.gameObject);

            }
        }

    }



    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "MainCamera")
        {
            print("asdsad");
           
            target.SetActive(true);
            
            SpawnAnObject();
            
            

        }
    }

    private void SpawnAnObject()
    {

        Invoke("SpawnAnObject", 6);

        if (spawnedObjects >= maxGameobjectsToSpawn)
        {
          
            



            return;

            



        }

        for (int i = 0; i < numberOfObjectsToSpawnOnContact; i++)
        {
            GameObject spawnPoint = spawnPoints[0];
            

            if (spawnType == SpawnType.Random)
            {
                spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            }
            else if (spawnType == SpawnType.OneByOne)
            {
                spawnPoint = spawnPoints[nextSpawnPointIndex];
                nextSpawnPointIndex++;
                if (nextSpawnPointIndex >= spawnPoints.Length)
                    nextSpawnPointIndex = 0;
            }

            Instantiate(toSpawn, spawnPoint.transform.position, Quaternion.identity);
            spawnedObjects++;





        }

        

    }

   

}