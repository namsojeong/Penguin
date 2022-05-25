using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraApp : MonoBehaviour
{

    void Capture()
    {
        // 캡쳐 
        //RefreshAndroidGallery( //이미지파일경로 );
    }

    // 캡쳐 후 이 함수 실행 시 갤러리에 저장
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
