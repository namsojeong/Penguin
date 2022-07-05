using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CameraApp : MonoBehaviour
{
    [SerializeField]
    GameObject[] cameraAppObj;

    //string path = Path.Combine(Application.persistentDataPath, "database.json");
    string path = @"C:\Github\Pen\ScreenShot\test.png";

    public void OnCamera()
    {
        cameraAppObj[0].SetActive(true);
        cameraAppObj[1].SetActive(true);
        cameraAppObj[2].SetActive(false);
        cameraAppObj[3].SetActive(false);
    }
    public void OnDownCamera()
    {
        cameraAppObj[0].SetActive(false);
        cameraAppObj[1].SetActive(false);
        cameraAppObj[2].SetActive(true);
        cameraAppObj[3].SetActive(true);
    }

    public void TakePicture()
    {
        StartCoroutine("Rendering");
    }
    IEnumerator Rendering()
    {
       yield return new WaitForEndOfFrame();

        byte[] imgBytes;

        Texture2D texture = new Texture2D(1400, 1400, TextureFormat.RGB24, false);
        texture.ReadPixels(new Rect(0, 900, 1400,1400), 0, 0, false);

        texture.Apply();
        imgBytes = texture.EncodeToJPG();

        File.WriteAllBytes(path, imgBytes);
        RefreshAndroidGallery();
        Debug.Log("캡쳐");
    }
    
    // 캡쳐 후 이 함수 실행 시 갤러리에 저장
    [System.Diagnostics.Conditional("UNITY_ANDROID")]
    private void RefreshAndroidGallery()
    {
        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2]
        { "android.intent.action.MEDIA_MOUNTED", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + path) });
        objActivity.Call("sendBroadcast", objIntent);
    }
}
