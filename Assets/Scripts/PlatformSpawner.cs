using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] platformePrefabs;
    float spawnZ = -15.0f;
    float platformLenght = 61.0f;
    float safeZone = 20f;
    int numberOfPlatformesOnTheScreen = 20;
    Transform playerTransform;
    [SerializeField] GameObject playerGo;
     
    List<GameObject> activePlatforms=new List<GameObject>();
    int lastPrefabIndex=0;
    void Start()
    {
        playerTransform = playerGo.transform;


        for (int i = 1; i <= numberOfPlatformesOnTheScreen; i++)
        {
            if (i < 2)
            {
                SpawnPlatforme(0);
            }
            else
            {
                SpawnPlatforme();
            }
        }
    }

 
    void Update()
    {
        float platformeLenghtupdated = spawnZ - (numberOfPlatformesOnTheScreen * platformLenght);
        if ((playerTransform.position.z-safeZone) > platformeLenghtupdated)
        {
            //test if player position.z is greater than the z scale of platforme

            SpawnPlatforme();  //if the player cross a platforme spawn another one
            StartCoroutine(PlatformDestruction());
        }
        
    }

    IEnumerator PlatformDestruction()
    {
        yield return new WaitForSecondsRealtime(7f);
        DestroPlatform();
    }

    void SpawnPlatforme(int prefabIndex = -1)
    {
        //pl means platform
        GameObject pL;
        if(prefabIndex==-1)
        {
            pL = Instantiate(platformePrefabs[RandomPrefabIndex()]) as GameObject;    
        }
        else
        {
            pL = Instantiate(platformePrefabs[prefabIndex]) as GameObject;
        }
       
        pL.transform.SetParent(transform);//make the platformes that spawn as a child of this game object
        pL.transform.position = Vector3.forward * spawnZ;// platform spawn position 
        spawnZ += platformLenght;//calculate z position of the platform
        activePlatforms.Add(pL);
    }

    void DestroPlatform()
    {
        Destroy(activePlatforms[0]);
        activePlatforms.RemoveAt(0);
    }

    int RandomPrefabIndex()
    {
        if (platformePrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(1, platformePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
            
    }

}
