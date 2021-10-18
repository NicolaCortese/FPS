using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    
    [SerializeField] Camera playerCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomIn = 40f;
    [SerializeField] float zoomOut = 60f;
    [SerializeField] float zoomInSensitivity = 0.5f;
    [SerializeField] float zoomOutSensitivity = 2f;
    
    bool isZoomed = false;

    private void OnDisable() {
        ZoomOut();
    }

    void Update()
    {
      
        if(Input.GetMouseButtonDown(1)){
            if(isZoomed==false)
            {
                ZoomIn();                
            }
            else
            {
                ZoomOut();
            }
        }
    }
    private void ZoomIn()
    {
        playerCamera.fieldOfView = zoomIn;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
        isZoomed = true;
    }
    private void ZoomOut()
    {
        playerCamera.fieldOfView = zoomOut;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
        isZoomed = false;
    }

    
}
