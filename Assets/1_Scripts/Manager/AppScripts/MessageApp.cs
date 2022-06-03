using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Message
{
}

public class MessageApp : MonoBehaviour
{
    public Dictionary<int, string> messages = new Dictionary<int, string>(); 
    [SerializeField]
    int cnt = 10;

    int ranMin;

    [SerializeField]
    Text chat;


    void Chatting(AbilityE ability)
    {
        ranMin = (int)ability * 10;
        int ran = Random.RandomRange(ranMin, cnt + 1);
        if(messages.TryGetValue(ran, out string v))
        {
            chat.text = string.Format(v);
        }
    }

}
