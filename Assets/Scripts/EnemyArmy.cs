using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArmy : MonoBehaviour
{
    [SerializeField] private int columns, rows;
    [SerializeField] private GameObject enemy, enemyColumn;
    [SerializeField] private WinLose winLose;
    public float stepTime, stepValue;
    public int enemies;

    private void Awake()
    {
        for(int i = 0; i < columns; i++)
        {
            Instantiate(enemyColumn, Vector3.zero, Quaternion.identity, gameObject.transform);
            for (int y = 0; y < rows; y++)
            {
                Instantiate(enemy, Vector3.zero, Quaternion.identity, gameObject.transform.GetChild(i));
                enemies++;
            }
        }
    }
    private void Start()
    {
        StartCoroutine(EnemyMover());
    }
    private void Update()
    {
        if (enemies == 0 && winLose.won != true) winLose.GameWin();
    }
    private IEnumerator EnemyMover()
    {
        while (true)
        {
            yield return new WaitForSeconds(stepTime);
            Step();
        }
    }
    private void Step()
    {
        var o = gameObject;
        var position = o.transform.position;
        position = new Vector3(position.x, position.y - stepValue, position.z);
        o.transform.position = position;
    }
}