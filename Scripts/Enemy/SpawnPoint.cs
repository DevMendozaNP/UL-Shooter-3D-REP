using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject Enemy;
    public Transform PlayerRef;
    private EnemyController enemyController;

    private void Start()
    {
        enemyController = Enemy.GetComponent<EnemyController>();
        enemyController.Player = PlayerRef;
    }
    
    public void SpawnEnemy(int EnemyAmount)
    {
        for(int i = 0; i < EnemyAmount; i++)
        {
            Enemy = Instantiate(Enemy);
            Enemy.transform.position = transform.position;
        }
    }

}
