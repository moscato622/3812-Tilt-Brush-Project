using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour {

    public LayerMask CameraLayerMask;
    public GameObject SteamVRHeadCollider;
    private float DurationTime;
    private bool check;
	// Use this for initialization
	void Start () {
        check = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate() {
        RaycastHit hit;
        Ray CameraRay = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position,transform.forward,Color.red);
        if (Physics.Raycast(CameraRay, out hit, 10000f, CameraLayerMask))
        {
            if (hit.transform.tag == "isHeSlow")
            {
                if (check)
                {
                    return;
                }
                else {
                    DurationTime = hit.transform.GetComponent<GazeMarker>().Duration;
                    onGazeOn();
                    Debug.Log("Slow");
                    check = true;
                }

            }
        }
        else {
            if (!check)
            {
                return;
            }
            else {

                onGameOff();
                Debug.Log("Normal");
                check = false;
            }

        }
    }

    void onGazeOn() {
        SteamVRHeadCollider.GetComponent<DistanceAudioListener>().GazedTrigger(DurationTime);
    }

    void onGameOff() {
        SteamVRHeadCollider.GetComponent<DistanceAudioListener>().ExitTrigger();
    }
}
