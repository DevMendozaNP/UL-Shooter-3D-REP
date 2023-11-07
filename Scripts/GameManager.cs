using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int TotalEnemyAmount;
    private int EnemyAmountPerPoint;
    private int Residuo;
    
    [SerializeField]
    private SpawnPoint SpawnPoint1;
    [SerializeField]
    private SpawnPoint SpawnPoint2;
    [SerializeField]
    private SpawnPoint SpawnPoint3;

    [SerializeField]
    private float TimerTime = 0.0f;
    private float timer = 0.0f;

    private void Awake()
    {
        timer = TimerTime;
    }

    void Start()
    {
        EnemyAmountPerPoint = TotalEnemyAmount / 3;
        Residuo = TotalEnemyAmount % 3;
        SpawnPoint1.SpawnEnemy(EnemyAmountPerPoint);
        SpawnPoint2.SpawnEnemy(EnemyAmountPerPoint);
        SpawnPoint3.SpawnEnemy(EnemyAmountPerPoint + Residuo);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            SpawnPoint1.SpawnEnemy(EnemyAmountPerPoint);
            SpawnPoint2.SpawnEnemy(EnemyAmountPerPoint);
            SpawnPoint3.SpawnEnemy(EnemyAmountPerPoint + Residuo);
            TimerTime -= 5;
            timer = Mathf.Clamp (TimerTime, 10, 100);
        }
    }

}
