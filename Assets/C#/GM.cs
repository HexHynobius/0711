using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    [Header("固定每秒產生物件")]
    public float SetTime;
    [Header("敵人")]
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
