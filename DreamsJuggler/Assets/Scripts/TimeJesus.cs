using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeJesus : MonoBehaviour
{
    public float secondSpawnTime; // the time until the second egg is spawned
    public float spawnTimeMultiplier; // this will increse the time after each egg will be spawned (first egg after 0s, second egg after secondSpawnTime s, third egg after secondSpawnTime * spawnTimeMultiplier)
    private float timeUntilNextSpawn; // the time after the next egg will be spawned 
    private float timeForTheCurrentNumberOfFallenObj; // the time the current number of eggs are kept in the air
    private float fallingObjLevel; //this will be incremented everytime an egg is spawned and will be decremented everytime an egg dies
    private int numberOfFallingObjInTheScene;
    
    void Start ()
    {
        timeUntilNextSpawn = secondSpawnTime;
        timeForTheCurrentNumberOfFallenObj = 0;
        fallingObjLevel = 1;
        FallingObjJesus.INSTANCE.GenerateFallingObj();
        numberOfFallingObjInTheScene = 1;
    }
	
	void Update ()
    {
        if (GameManager.INSTANCE.ControlsON)
        {
            UIJesus.INSTANCE.SetCurrentScoreLabels(numberOfFallingObjInTheScene, timeForTheCurrentNumberOfFallenObj, GameManager.INSTANCE.LostObjects);
            if (numberOfFallingObjInTheScene != 0)
            {
                TrySettingNewBest();
            }
            IncrementTheTimeForTheCurrentNumberOfFallingObj();
            if (timeForTheCurrentNumberOfFallenObj >= timeUntilNextSpawn)
            {
                IncreaseTheFallingObjLevel();
            }
            numberOfFallingObjInTheScene = FallingObjJesus.INSTANCE.GetTheNumberOfFallingObjInTheScene();
            if (numberOfFallingObjInTheScene < fallingObjLevel)
            {
                DecreaseTheFallingObjLevel();
            }
        }
	}

    private void TrySettingNewBest()
    {
        HighscoreJesus.INSTANCE.SetNewBest(numberOfFallingObjInTheScene, timeForTheCurrentNumberOfFallenObj);
    }

    private void IncrementTheTimeForTheCurrentNumberOfFallingObj()
    {
        timeForTheCurrentNumberOfFallenObj += Time.deltaTime;
    }

    private void IncreaseTheFallingObjLevel()
    {
        timeForTheCurrentNumberOfFallenObj = 0;
        fallingObjLevel++;
        timeUntilNextSpawn *= spawnTimeMultiplier;
        FallingObjJesus.INSTANCE.GenerateFallingObj();
    }

    private void DecreaseTheFallingObjLevel()
    {
        timeUntilNextSpawn /= Mathf.Pow(spawnTimeMultiplier, (fallingObjLevel - numberOfFallingObjInTheScene));
        fallingObjLevel = numberOfFallingObjInTheScene;
        timeForTheCurrentNumberOfFallenObj = 0;
    }
}
