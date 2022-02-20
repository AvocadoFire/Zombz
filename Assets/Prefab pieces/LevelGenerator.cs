using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] int Player_Distance_Spawn = 50;
    [SerializeField] PlayerController player;
    [SerializeField] Transform levelPart_Start;
    [SerializeField] List<Transform> levelPartEasyList;
    [SerializeField] List<Transform> levelPartMediumList;
    [SerializeField] List<Transform> levelPartHardList; 
    [SerializeField] List<Transform> levelPartImpossibleList;
    [SerializeField] int easyAmount;
    [SerializeField] int mediumAmount;
    [SerializeField] int hardAmount;

    enum Difficulty { Easy, Medium, Hard, Impossible };





    Vector3 lastEndPosition;
    int levelPartsSpawned;

    private void Start()
    {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startingSpawnLevelParts = 2;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < Player_Distance_Spawn)
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {

        List<Transform> difficultyLevelPartList;
        switch (GetDifficulty())
        {
            default:
            case Difficulty.Easy:       difficultyLevelPartList = levelPartEasyList;        break;
            case Difficulty.Medium:     difficultyLevelPartList = levelPartMediumList;      break;
            case Difficulty.Hard:       difficultyLevelPartList = levelPartImpossibleList;  break;
            case Difficulty.Impossible: difficultyLevelPartList = levelPartImpossibleList;  break;
        }

        Transform chosenLevelPart = difficultyLevelPartList[Random.Range(0, difficultyLevelPartList.Count)];
        
        Transform lastLevelPartTransform = SpawnLevel(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;        
        levelPartsSpawned++;    
    }
    private Transform SpawnLevel(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = 
            Instantiate (levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;

    }

    private Difficulty GetDifficulty()
    {
        if (levelPartsSpawned >= hardAmount) return Difficulty.Impossible;
        if (levelPartsSpawned >= mediumAmount) return Difficulty.Hard;
        if (levelPartsSpawned >= easyAmount) return Difficulty.Medium;
        return Difficulty.Easy;
    }
}
