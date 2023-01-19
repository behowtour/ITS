using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    [Header("Static variables")]
    public GameObject[] enemyPrefabs;
    public int[] enemyRate;
    public int[] enemyWeight;
    

    [Header("Dynamic variables")]
    public GameObject lastEnemy;

    private Camera cam;
    private CameraManager cameraManager;
    private int allPartsOfChances;
    private float camLastY, camCurrentY;
    private int numberOfEnemy;
    private System.Data.DataTable dataTableEnemies;

    [SerializeField]
    private float camSpeed;

    [SerializeField]
    private bool needCheckSpawn;

    void Start()
    {
        cam = GetComponent<Camera>();
        allPartsOfChances = 0;
        for (int i = 0; i < enemyRate.Length; i++)
        {
            allPartsOfChances += enemyRate[i];
        }
        camCurrentY = Mathf.Epsilon;
        camLastY = Mathf.Epsilon;
        numberOfEnemy = 0;

        InitializeEnemiesDataTable();
        FillEnemiesDataTable(enemyPrefabs, enemyRate, enemyWeight);

        needCheckSpawn = false;
    }

    private void Update()
    {
        
    }

    public void GenerateEnemy(float heroSpeed)
    {
        //camSpeed = heroSpeed;
        if (!needCheckSpawn && heroSpeed > 5)
        {
            needCheckSpawn = true;
        }
        if (needCheckSpawn && heroSpeed < 4.3)
        {
            float typeOfNextEnemy = 0;
            int nextEnemyFinder = 0;
            int enemyRoll = 0;

            GameObject newEnemy;
            enemyRoll = Random.Range(0, 100);
            foreach (System.Data.DataRow row in dataTableEnemies.Rows)
            {
                Debug.Log(row);
            }

            for (int i = 0; i < enemyRate.Length; i++)
            { 
                nextEnemyFinder += enemyRate[i];
                if (typeOfNextEnemy < nextEnemyFinder)
                {
                    newEnemy = Instantiate(enemyPrefabs[i]);
                    //newEnemy.name = "Point_" + numberOfEnemy;
                    newEnemy.transform.position = cam.transform.position + new Vector3 (0,camCurrentY+ConstantSettings.screenHeightWorld/2 + 2,10);
                    lastEnemy = newEnemy;
                    numberOfEnemy++;
                    break;
                }
            }
            needCheckSpawn = false;
        }
    }


    private void InitializeEnemiesDataTable()
    {
        System.Data.DataColumn column;
        
        //enemyPrefab column
        column = new System.Data.DataColumn();
        column.DataType = System.Type.GetType("System.Object");
        column.ColumnName = "enemyPrefab";
        column.ReadOnly = false;
        column.Unique = false;
        dataTableEnemies.Columns.Add(column);

        //enemyRate column
        column = new System.Data.DataColumn();
        column.DataType = System.Type.GetType("System.Int32");
        column.ColumnName = "enemyRate";
        column.ReadOnly = false;
        column.Unique = false;
        dataTableEnemies.Columns.Add(column);

        //enemyWeight column
        column = new System.Data.DataColumn();
        column.DataType = System.Type.GetType("System.Int32");
        column.ColumnName = "enemyWeight";
        column.ReadOnly = false;
        column.Unique = false;
        dataTableEnemies.Columns.Add(column);

        //mbSpawn column bool
        column = new System.Data.DataColumn(); 
        column.DataType = System.Type.GetType("System.Boolean");
        column.ColumnName = "mbSpawn";
        column.ReadOnly = false;
        column.Unique = false;
        dataTableEnemies.Columns.Add(column);

        dataTableEnemies.AcceptChanges();
    }

    private void FillEnemiesDataTable(GameObject[] enemyPrefabs, int[] enemyRate, int[] enemyWeight)
    {
        System.Data.DataRow row;
        if (enemyPrefabs.Length != enemyRate.Length && enemyPrefabs.Length != enemyWeight.Length)
        {
            Debug.Log("массивы врагов разной длины. Перепроверьте!");
            return;
        }
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            row = dataTableEnemies.NewRow();
            row["enemyPrefab"] = enemyPrefabs[i];
            row["enemyRate"] = enemyRate[i];
            row["enemyWeight"] = enemyWeight[i];
            row["mbSpawn"] = false;
            dataTableEnemies.Rows.Add(row);
        }
        dataTableEnemies.AcceptChanges();
    }
}
