using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAdsManager : MonoBehaviour
{


    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            // ���� ���� �� �ݹ��Լ� "HandleShowResult" ȣ�� 
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    // ���� ����� �� �ڵ����� ȣ��Ǵ� �ݹ� �Լ� 
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                // ���� ���������� ��û�� ��� ���� ���� 
                break;
            case ShowResult.Skipped:
                // ��ŵ �Ǿ��ٸ� ���� �׷����� �ϸ� ������ �� �� ���ݾ�! ���� â�� ����߁���?
                break;
            case ShowResult.Failed:
                break;
        }
    }
}
