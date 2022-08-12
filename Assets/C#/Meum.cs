using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using System.IO;

using UnityEngine.Audio;

public class Meum : MonoBehaviour
{
    [Header("解析度Dropdown")]
    public Dropdown SizeDropdown;

    [Header("語言Dropdown")]
    public Dropdown LanDropdown;
    //暫存語言Dropdown的ID值
    string SaveLanID = "SaveLanID";

    [Header("BGM")]
    public GameObject BGM;

    bool ControlAudio;

    [Header("聲音開圖片")]
    public Sprite OpenSound;
    [Header("聲音關圖片")]
    public Sprite CloseSound;
    [Header("聲音開按鈕")]
    public Image ButtonSound;

    public string[] filePaths;


    [Header("調整音量Slider")]
    public Slider ChangeAudioSlider;
    [Header("AudioMixer")]
    public AudioMixer AudioMixerObj;

    public InputField[] Keyboards;

    private void Awake()
    {
        filePaths = Directory.GetFiles(Application.streamingAssetsPath, "*.png");
#if UNITY_STANDALONE_WIN
        SizeDropdown.interactable = true;
#endif

#if UNITY_ANDROID || UNITY_IOS
        SizeDropdown.interactable = false;
#endif

        if (Staticvar.KeyboardsState[0] == null || Staticvar.KeyboardsState[1] == null || Staticvar.KeyboardsState[2] == null || Staticvar.KeyboardsState[3] == null)
        {
            Keyboards[0].text = "w";
            Keyboards[1].text = "s";
            Keyboards[2].text = "a";
            Keyboards[3].text = "d";
            for (int i = 0; i < Keyboards.Length; i++)
            { Staticvar.KeyboardsState[i] = Keyboards[i].text; }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectsWithTag("BGM").Length <= 0)
        {
            Instantiate(BGM);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Control_Audio()
    {
        ControlAudio = !ControlAudio;
        if (ControlAudio)
        {
            //ButtonSound.sprite = OpenSound;
            //ButtonSound.sprite = Resources.Load<Sprite>("Sprite/01");
            StreamingAssetsLoadTexture(0);
        }
        else
        {
            //ButtonSound.sprite = CloseSound;
            //ButtonSound.sprite = Resources.Load<Sprite>("Sprite/02");
            StreamingAssetsLoadTexture(1);
        }
        AudioListener.pause = ControlAudio;
    }

    void StreamingAssetsLoadTexture(int ID)
    {
        byte[] pngBytes = File.ReadAllBytes(filePaths[ID]);

        Texture2D tex = new Texture2D(0, 0);

        tex.LoadImage(pngBytes);

        Sprite FormTex = Sprite.Create(tex, new Rect(0f, 0f, tex.width, tex.height), new Vector2(0.5f, 0.5f));

        ButtonSound.sprite = FormTex;
    }
    public void ChangeAudio_Slider()
    {
        //AudioListener.volume = ChangeAudioSlider.value;
        AudioMixerObj.SetFloat("BGM", ChangeAudioSlider.value);
    }
    public void ChangScreenSize()
    {
        switch (SizeDropdown.value)
        {
            case 0:
                Screen.SetResolution(1080, 1920, false);
                break;
            case 1:
                Screen.SetResolution(720, 1280, false);
                break;
            case 2:
                Screen.SetResolution(480, 800, false);
                break;
        }
    }

    public void ChangLan()
    {
        PlayerPrefs.SetInt(SaveLanID, LanDropdown.value);
    }

    public void SetKeyboard(int ID)
    {
        Staticvar.KeyboardsState[ID] = Keyboards[ID].text;
    }


}
