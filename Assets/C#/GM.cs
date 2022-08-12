using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [Header("�T�w�C���ͪ���")]
    public float SetTime;
    [Header("�ĤH")]
    public GameObject[] Enemys;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemys", SetTime, SetTime);
    }

    void CreateEnemys()
    {
        Instantiate(Enemys[Random.Range(0, Enemys.Length)], new Vector3(Random.Range(-1.8f, 1.8f),transform.position.y, transform.position.z), transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
