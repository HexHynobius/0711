using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour
{
    [Header("固定每秒產生物件")]
    public float SetTime;
    [Header("敵人")]
    public GameObject[] Enemys;

    [Header("PauseUI")]
    public GameObject PauseUI;

    public float TotalHP;
    float ScriptHP;
    public Image PlayerHPImage;

    [Header("分數文字")]
    public Text ScoreText;
    int TotalScore;
    // Start is called before the first frame update
    void Start()
    {
        ScriptHP = TotalHP;
        InvokeRepeating("CreateEnemys", SetTime, SetTime);
    }

    void CreateEnemys()
    {
        Instantiate(Enemys[Random.Range(0, Enemys.Length)], new Vector3(Random.Range(-1.8f, 1.8f), transform.position.y, transform.position.z), transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void Pause(bool isPause)
    {
        PauseUI.SetActive(isPause ? true : false);
        FindObjectOfType<Player>().enabled = isPause ? false : true;
        Time.timeScale = isPause ? 0 : 1;
    }

    public void Hurtplayer(float Hurt)
    {
        ScriptHP -=Hurt;
        PlayerHPImage.fillAmount = ScriptHP / TotalHP;
        if(PlayerHPImage.fillAmount <=0)
        {
            Application.LoadLevel("GameOver");
        }
    }
    public void AddScore(int Add)
    {
        TotalScore +=Add;
        ScoreText.text = "Score:"+TotalScore;
    }
}
