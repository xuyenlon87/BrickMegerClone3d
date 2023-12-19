using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawMap : MonoBehaviour
{
    [SerializeField] TextAsset testMap;
    [SerializeField] GameObject brickPrefabGreen;
    [SerializeField] GameObject brickPrefabBlack;
    [SerializeField] GameObject brickPrefabRed;
    [SerializeField] GameObject brickPrefab;
    // Start is called before the first frame update
    void Start()
    {
        string data = testMap.text;
        string[] dataArray = data.Split("\r\n");
        int row = dataArray.Length;
        int col = dataArray[0].Split(",").Length;
        int[,] map = new int[row, col];
        for(int i = 0; i < row; i++)
        {
            if(dataArray.Length > 0)
            {
                string[] dataArray2 = dataArray[i].Split(",");
                for(int j = 0; j < dataArray2.Length; j++)
                {
                    map[i, j] = int.Parse(dataArray2[j]);
                    if(map[i,j] == 2)
                    {
                        Instantiate(brickPrefabGreen, new Vector3(j, 0, -i), Quaternion.identity);
                    }
                    else if(map[i,j] == 1)
                    {
                        GameObject brickStart = Instantiate(brickPrefabBlack, new Vector3(j, 0, -i), Quaternion.identity);
                    }
                    else if (map[i, j] == 3)
                    {
                        GameObject brickStart = Instantiate(brickPrefabRed, new Vector3(j, 0, -i), Quaternion.identity);

                    }
                    else if (map[i, j] == 0)
                    {
                        GameObject brickStart = Instantiate(brickPrefab, new Vector3(j, 0, -i), Quaternion.identity);

                    }
                }
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
