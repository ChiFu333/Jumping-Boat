using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItemsGenerator : MonoBehaviour
{
    public GameObject[] items;
    public Transform[] pointsToSpawn = new Transform[8];
    public float[] deltaStart = new float[8];
    public float[] between = new float[8];
    public float maxLen = 1000;
    
    private List<int[]> itemPull = new List<int[]>()
    {
        new int[]{0,1,2},
        new int[]{0,3,4},
        new int[]{0,3,4},
        new int[]{5,3,4},
        new int[]{5,3,4},
        new int[]{6,3,5,4},
        new int[]{6,3,5,4},
        new int[]{6,3,5},
    };
    void Start()
    {
        for(int i = 0; i < pointsToSpawn.Length; i++)
        {
            float offset = deltaStart[i] + 10;
            do
            {
                Vector3 pos = new Vector3(offset,pointsToSpawn[i].position.y);
                Instantiate(items[itemPull[i][Random.Range(0,itemPull[i].Length)]],pos,Quaternion.identity);
                offset += between[i];
            } while (offset < maxLen);
        }
    }
}
