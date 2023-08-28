using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CamState
{
    FP, // First Person View
    TP, // Third Person View
    TV  // Top View
}
public class ViewChanger : MonoBehaviour
{
    [SerializeField] private GameObject fpCamera;
    [SerializeField] private GameObject tpCamera;
    [SerializeField] private GameObject tvCamera;

    private CamState camNextState;

    private void Start() {
        camNextState = CamState.FP;
    }

    void Update()
    {
        if(Input.GetKeyDown("v")){
            switch(camNextState){
                case CamState.FP:
                    fpCamera.SetActive(true);
                    tpCamera.SetActive(false);
                    tvCamera.SetActive(false);
                    camNextState = CamState.TP;
                    break;
                case CamState.TP:
                    fpCamera.SetActive(false);
                    tpCamera.SetActive(true);
                    tvCamera.SetActive(false);
                    camNextState = CamState.TV;
                    break;
                case CamState.TV:
                    fpCamera.SetActive(false);
                    tpCamera.SetActive(false);
                    tvCamera.SetActive(true);
                    camNextState = CamState.FP;
                    break;
            }
        }
    }
}
