using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class SaveSettingData : MonoBehaviour
{
    string Path;

    [Header("�y���U�Կ��")]
    public Dropdown LanDropdown;
    [Header("�ѪR�פU�Կ��")]
    public Dropdown ScreenSizeDropdown;

    FileStream file;

    public enum Platform
    {
        PC,
        Mobile
    }
    [Header("��ܭn���������x")]
    public Platform platform;
    [Header("��ܤ�r�ɨ��Dropdown���")]
    public string[] Datas;
    WWW Reader;
    string ReaderPC;

    private void Awake()
    {
        //�إߤ@�Ӥ�r�ɦW�٬�Save.txt�A���x�s�bApplication.persistentDataPath���|�U
        Path = Application.persistentDataPath + "Save.txt";
        Debug.Log(Path);

        //�ˬd�����|�O�_�w����r�� �O
        if (File.Exists(Path))
        {
            //����LLog����
            Debug.Log("������������r�ɮ�");
            //Ū����r�ɤ��e
            ReadString();
        }
        //�ˬd�����|�O�_�w����r�� �_
        else
        {
            Debug.Log("�b����إߤ@�Ӥ�r��");
            //�إߤ@�Ӥ�r��
            file = new FileStream(Path, FileMode.Create);
            file.Close();
        }
    }

    //���U��^���ôN�۰��x�s�ѪR�שM�y����Dropdown Value
    public void SaveData()
    {
        WriteString(ScreenSizeDropdown.value + "@" + LanDropdown.value);
    }
    void WriteString(string Data)
    {
        //���Application.persistentDataPath���|�U����r�ɮרö}��
        file = new FileStream(Path, FileMode.Open);
        //��n�x�s����ƪ���r��
        StreamWriter sw = new StreamWriter(file);
        //�b��r�ɼg�J�n�x�s����r
        sw.WriteLine(Data);
        //��Ƽg�J����������r��
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
