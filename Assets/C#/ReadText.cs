using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ReadText : MonoBehaviour
{
    //������ɸ��|
    string CHPath;
    //�^����ɸ��|
    string ENPath;

    [Header("��ܤ����r�ɸ��")]
    public string CHData;
    [Header("��ܭ^���r�ɸ��")]
    public string ENData;

    [Header("��ܤ����r�ɸ��")]
    public string[] CHDatas;
    [Header("��ܭ^���r�ɸ��")]
    public string[] ENDatas;

    public enum Platform
    {
        PC,
        Mobile
    }


    [Header("��ܭn���������x")]
    public Platform Platforms;

    WWW CHreader;
    WWW ENreader;


    private void Awake()
    {
        CHPath = Application.streamingAssetsPath + "/Language/CH.txt";
        ENPath = Application.streamingAssetsPath + "/Language/EN.txt";
        switch (Platforms)
        {
            case Platform.Mobile:
                //�z�L���}Ū�����|�ɮ�
                CHreader = new WWW(CHPath);
                ENreader = new WWW(ENPath);
                CHDatas = CHreader.text.Split('\n');
                ENDatas = ENreader.text.Split('\n');
                break;
            case Platform.PC:
                //Ū�����|���ɮפ��e
                CHData = File.ReadAllText(CHPath);
                ENData = File.ReadAllText(ENPath);
                //Ū�X��ƶi�����
                CHDatas = CHData.Split('\n');
                ENDatas = ENData.Split('\n');
                break;
        }
    }

}
