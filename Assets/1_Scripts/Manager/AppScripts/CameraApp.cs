using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraApp : MonoBehaviour
{

    void Capture()
    {
        // ĸ�� 
        //RefreshAndroidGallery( //�̹������ϰ�� );
    }

    // ĸ�� �� �� �Լ� ���� �� �������� ����
    [System.Diagnostics.Conditional("UNITY_ANDROID")]
    private void RefreshAndroidGallery(string imageFilePath)
    {
        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2]
        { "android.intent.action.MEDIA_MOUNTED", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + imageFilePath) });
        objActivity.Call("sendBroadcast", objIntent);
    }
}
