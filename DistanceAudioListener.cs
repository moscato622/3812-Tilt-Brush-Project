using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceAudioListener : MonoBehaviour
{

    [Tooltip("Get Audio Source.")]
    private AudioSource HeartbeatAudioClip;
    public Transform AudioSourceGameObject;
    public float HeartbeatDuration;
    private float NewHeartbeatDuration;
    public float OriHeartbeatDuration;
    private float LerpTime;
    private bool Triggered;

    //[Tooltip("List of possible tracker positions.")]
    //public GameObject[] TrackingMarkers;

    // Use this for initialization
    void Start()
    {
        HeartbeatAudioClip = AudioSourceGameObject.transform.GetComponent<AudioSource>();
        //OriHeartbeatDuration = 2f;
        HeartbeatDuration = OriHeartbeatDuration;
        NewHeartbeatDuration = OriHeartbeatDuration;
        LerpTime = 0f;
        HeartbeatAudioClip.Play();
        StartCoroutine(HeartBeatAudioPlayer());
    }

    // Update is called once per frame
    void Update()
    {


        //Debug.Log(HeartbeatDuration);
        if (Triggered)
        {
            LerpTime += 0.2f * Time.fixedDeltaTime;
            HeartbeatDuration = Mathf.Lerp(OriHeartbeatDuration, NewHeartbeatDuration, LerpTime);
        }
        else
        {
            if (HeartbeatDuration == OriHeartbeatDuration)
            {
                return;
            }
            else
            {
                LerpTime += 0.2f * Time.fixedDeltaTime;
                HeartbeatDuration = Mathf.Lerp(NewHeartbeatDuration, OriHeartbeatDuration, LerpTime);
            }
        }

    }

    private IEnumerator HeartBeatAudioPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(HeartbeatDuration);
            HeartbeatAudioClip.Play();
            //this.GetComponentInChildren<HeartBeat>().theHeart.GetComponent<SerialController>().SendSerialMessage("1");
        }
    }

    public void EnterTrigger(float DurationInput)
    {
        print("TriggerEntered");
        NewHeartbeatDuration = DurationInput;
        Triggered = true;
        LerpTime = 0f;
        Debug.Log(DurationInput);
    }

    public void GazedTrigger(float DurationInput) {
        print("GazedTrigger");
        NewHeartbeatDuration = DurationInput;
        Triggered = true;
        LerpTime = 0f;
        Debug.Log(DurationInput);
    }

    public void ExitTrigger()
    {
        LerpTime = 0f;
        Triggered = false;
        Debug.Log(OriHeartbeatDuration);
    }
}
