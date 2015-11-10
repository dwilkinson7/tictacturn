using UnityEngine;
using System.Collections;

public class LeftClick : MonoBehaviour {

    private Camera mainCam;
    private string state;
                             
    public void OnClick()
    {
        mainCam = FindObjectOfType<Camera>();
        if (mainCam.GetComponent<GameScript>().state.Equals("stand"))
            mainCam.GetComponent<GameScript>().state = "left";
    }
}
