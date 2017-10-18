using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDurationData : MonoBehaviour
{

    public float DurationTime;
    private float OriDurationTime;
    // Use this for initialization

    void OnTriggerEnter(Collider Player)
    {
        if (Player.transform.tag != "Player")
        {
            return;
        }
        else
        {
            Player.GetComponent<DistanceAudioListener>().EnterTrigger(DurationTime);
        }
    }

    void OnTriggerExit(Collider Player)
    {
        if (Player.transform.tag != "Player")
        {
            return;
        }
        else
        {
            Player.GetComponent<DistanceAudioListener>().ExitTrigger();
        }
    }
}
