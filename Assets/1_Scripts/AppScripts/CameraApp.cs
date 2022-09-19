using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.Android;

public class CameraApp : MonoBehaviour
{
    [SerializeField]
    GameObject[] cameraAppObj;

    //string path = @"C:\Github\Pen\ScreenShot\test.png";

    public string folderName = "WithPenggzzi";
    public string fileName = "Pengzzi";
    public string extName = "png";

    private string RootPath
    {
        get
        {
#if UNITY_EDITOR || UNITY_STANDALONE
            return Application.dataPath;
#elif UNITY_ANDROID
            return $"/storage/emulated/0/DCIM/{Application.productName}/";
#endif
        }
    }

    private string folderPath => $"{RootPath}/{folderName}";
    private string TotalPath => $"{folderPath}/{fileName}_{DateTime.Now.ToString("MMdd_HHmmss")}.{extName}";

    private string lastSavedPath;

    public void TakePictureAndCheck()
    {
        CheckPermission(Permission.ExternalStorageRead);
    }
    private void CheckPermission(string permission)
    {
        // 안드로이드 : 저장소 권한 확인하고 요청하기
        if (Permission.HasUserAuthorizedPermission(permission) == false)
        {
            PermissionCallbacks pCallbacks = new PermissionCallbacks();
            pCallbacks.PermissionGranted += _ => StartCoroutine(TakePicture()); // 승인 시 기능 실행

            pCallbacks.PermissionDenied += str => Debug.Log($"거절");

            Permission.RequestUserPermission(permission, pCallbacks);
        }
        else
        {
            StartCoroutine(TakePicture());
        }
    }

    private IEnumerator TakePicture()
    {
        yield return new WaitForEndOfFrame();
        ChangeTextureAndSave();
    }

    private void ChangeTextureAndSave()
    {
        string totalPath = TotalPath;

        Texture2D screenTex = new Texture2D(1440, 1440, TextureFormat.RGB24, false);
        Rect area = new Rect(0f, 900f, 1440, 1440);

        // 현재 스크린으로부터 지정 영역의 픽셀들을 텍스쳐에 저장
        screenTex.ReadPixels(area, 0, 0);

        bool succeeded = true;
        try
        {
            // 폴더가 존재하지 않으면 새로 생성
            if (Directory.Exists(folderPath) == false)  Directory.CreateDirectory(folderPath);

            File.WriteAllBytes(totalPath, screenTex.EncodeToPNG());
        }
        catch (Exception e)
        {
            succeeded = false;
            Debug.LogWarning($"Screen Shot Save Failed : {totalPath}\n{e}");
        }

        Destroy(screenTex);// 만든 텍스쳐 삭제

        if (succeeded)
            lastSavedPath = totalPath; // 최근 경로에 저장

        RefreshAndroidGallery(totalPath);
    }

    [System.Diagnostics.Conditional("UNITY_ANDROID")]
    private void RefreshAndroidGallery(string imageFilePath)
    {
#if !UNITY_EDITOR
        AndroidJavaClass classPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject objActivity = classPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass classUri = new AndroidJavaClass("android.net.Uri");
        AndroidJavaObject objIntent = new AndroidJavaObject("android.content.Intent", new object[2]
        { "android.intent.action.MEDIA_SCANNER_SCAN_FILE", classUri.CallStatic<AndroidJavaObject>("parse", "file://" + imageFilePath) });
        objActivity.Call("sendBroadcast", objIntent);
#endif
    }

    #region ON/OFF
    public void OnCamera()
    {
        cameraAppObj[0].SetActive(true);
        cameraAppObj[1].SetActive(true);
        cameraAppObj[2].SetActive(false);
        cameraAppObj[3].SetActive(false);
        cameraAppObj[4].SetActive(false);
        cameraAppObj[5].SetActive(false);
    }
    public void OnDownCamera()
    {
        cameraAppObj[0].SetActive(false);
        cameraAppObj[1].SetActive(false);
        cameraAppObj[2].SetActive(true);
        cameraAppObj[3].SetActive(true);
        cameraAppObj[4].SetActive(true);
        cameraAppObj[5].SetActive(true);
    }
    #endregion

}
