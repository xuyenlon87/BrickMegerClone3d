using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<LevelManager>();
            }
            return instance;
        }
    }
    [SerializeField] TextAsset testMap;
    [SerializeField] GameObject brickPrefabGreen;
    [SerializeField] GameObject brickPrefabBlack;
    [SerializeField] GameObject brickPrefabRed;
    [SerializeField] GameObject brickPrefab;
    [SerializeField] GameObject playerPrefab;
    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DrawMap()
    {
        string data = testMap.text;
        string[] dataArray = data.Split("\r\n");
        int row = dataArray.Length;
        int col = dataArray[0].Split(",").Length;
        int[,] map = new int[row, col];
        for (int i = 0; i < row; i++)
        {
            if (dataArray.Length > 0)
            {
                string[] dataArray2 = dataArray[i].Split(",");
                for (int j = 0; j < dataArray2.Length; j++)
                {
                    map[i, j] = int.Parse(dataArray2[j]);
                    if (map[i, j] == 2)
                    {
                        Instantiate(brickPrefabGreen, new Vector3(j, 0, -i), Quaternion.identity);
                    }
                    else if (map[i, j] == 1)
                    {
                        GameObject brickStart = Instantiate(brickPrefabBlack, new Vector3(j, 0, -i), Quaternion.identity);
                        Instantiate(playerPrefab, (brickStart.transform.position + Vector3.up), Quaternion.identity);
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
}
