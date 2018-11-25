using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjJesus : MonoBehaviour
{
    public static FallingObjJesus INSTANCE = null;

    public Transform fallingObjPrefab;
    public GameObject panda;

    void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else
        {
            if (INSTANCE != this)
            {
                Destroy(gameObject);
            }
        }
    }
    
    public void GenerateFallingObj()
    {
        if (!GameManager.INSTANCE.GameOver)
        {
            Instantiate(fallingObjPrefab, panda.transform.position, Quaternion.identity);
        }
    }

    public int GetTheNumberOfFallingObjInTheScene()
    {
        return GameObject.FindGameObjectsWithTag("FallingObj").Length;
    }
}
