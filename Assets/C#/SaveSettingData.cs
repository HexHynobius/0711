using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveSettingData : MonoBehaviour
{
    string Path;

    [Header("語言下拉選單")]
    public Dropdown LanDropdown;
    [Header("解析度下拉選單")]
    public Dropdown ScreenSizeDropdown;

    FileStream file;

    public enum Platform
    {
        PC,
        Mobile
    }
    [Header("選擇要切換的平台")]
    public Platform platform;
    [Header("顯示文字檔兩個Dropdown資料")]
    public string[] Datas;
    WWW Reader;
    string ReaderPC;

    private void Awake()
    {
        //建立一個文字檔名稱為Save.txt，並儲存在Application.persistentDataPath路徑下
        Path = Application.persistentDataPath + "Save.txt";
        Debug.Log(Path);

        //檢查此路徑是否已有文字檔 是
        if (File.Exists(Path))
        {
            //先用LLog檢驗
            Debug.Log("抓取手機內的文字檔案");
            //讀取文字檔內容
            ReadString();
        }
        //檢查此路徑是否已有文字檔 否
        else
        {
            Debug.Log("在手機建立一個文字檔");
            //建立一個文字檔
            file = new FileStream(Path, FileMode.Create);
            file.Close();
        }
    }

    //按下返回按紐就自動儲存解析度和語言的Dropdown Value
    public void SaveData()
    {
        WriteString(ScreenSizeDropdown.value + "@" + LanDropdown.value);
    }
    void WriteString(string Data)
    {
        //找到Application.persistentDataPath路徑下的文字檔案並開啟
        file = new FileStream(Path, FileMode.Open);
        //把要儲存的資料的文字檔
        StreamWriter sw = new StreamWriter(file);
        //在文字檔寫入要儲存的文字
        sw.WriteLine(Data);
        //資料寫入完畢關閉文字檔
        sw.Close();
    }

    void ReadString()
    {
        switch (platform)
        {
            case Platform.Mobile:
                Reader = new WWW(Path);
                Datas = Reader.text.Split('@');
                ScreenSizeDropdown.value = int.Parse(Datas[0]);
                LanDropdown.value = int.Parse(Datas[1]);
                break;

            case Platform.PC:
                ReaderPC = File.ReadAllText(Path);
                Datas = ReaderPC.Split('@');
                ScreenSizeDropdown.value = int.Parse(Datas[0]);
                LanDropdown.value = int.Parse(Datas[1]);
                break;
        }
    }


}
