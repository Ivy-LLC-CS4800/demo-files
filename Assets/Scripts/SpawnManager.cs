using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    // Variables
    [SerializeField] public Transform[] spawnPoints;
    [SerializeField] private DebrisFactory debrisFactory;
    [SerializeField] private int numberOfDebrisToSpawn = 8;
    private int correctNumberOfSpawnPoints = 12;

    private Dictionary<int, Transform> spawnPointDictionary;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        InitializeSpawnPoints();
        SpawnDebris();
    }//end Start()

    private void InitializeSpawnPoints() {
        if (spawnPoints.Lenth != correctNumberOfSpawnPoints) {
            Debug.LogError($"Exactly {correctNumberOfSpawnPoints} spawn points must be assigned.");
            return;
        }//end if

        // Fill the spawn point dictionary
        spawnPointDictionary = new Dictionary<int, Transform>();
        for (int i = 0; i < spawnPoint.Length; i++) {
            spawnPointDictionary.Add(i + 1, spawnPoints[i]);
        }//end for-loop
    }//end InitializeSpawnPoints()

    private void SpawnDebris() {
        if (debrisFactory == null) {
            Debug.LogError("DebrisFactory not assigned");
        }//end if

        if (numberOfDebrisToSpawn > spawnPointDictionary.Count) {
            Debug.LogError("Not enough spawn points for the number of debris.");
            return;
        }//end if

        for (int i = 0; i < numberOfDebrisToSpawn; i++) {
            int randomKey = GetRandomSpawnPointKey();
            if (randomKey == -1) {
                Debug.LogError("No spawn points available.");
                break;
            }//end for-loop

            Transform spawnPoints = spawnPointDictionary[randomKey];
            spawnPointDictionary.Remove(randomKey);

            DebrisType = (DebrisType)Random.Range(0, 4);
            
            // TODO: Log the type only allow it twice

            debrisFactory.CreateDebris(randomType, spawnPoint.position, Quaternion.identity);
        }//end for-loop
    }//end SpawnDebris()

    private int GetRandomSpawnPointKey() {
        if (spawnPointDictionary.Count == 0) {
            return -1;
        }//end if

        int[] keys = new int[spawnPointDictionary.Count];
        spawnPointDictionary.Keys.CopyTo(keys, 0);
        return keys[Random.Range(0, keys.Length)];
    }//end GetRandomSpawnPointKey()
}//end SpawnManager
