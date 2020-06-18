using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPV_CAM : MonoBehaviour
{
    WebCamTexture webcamTexture;
    RenderTexture renderTexture;
    public Camera cam;
    public Material mat;
    //public Shader shader;
    // Start is called before the first frame update
    void Start()
    {        
        //renderTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32);
        //cam.SetReplacementShader(shader, "");
        WebCamDevice[] webCams = WebCamTexture.devices;
        foreach (WebCamDevice webCam in webCams)
        {
            if (webCam.name.StartsWith("USB2.0"))
            {
                Debug.Log("background camera:" + webCam.name);
                webcamTexture = new WebCamTexture(webCam.name);
                webcamTexture.Play();
                break;
            }
        }
        mat.SetTexture("_CamTex", webcamTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnPreRender()
    //{
        //cam.targetTexture = renderTexture;
        //cam.forceIntoRenderTexture = true;
        //Graphics.Blit(webcamTexture, null as RenderTexture);
    //}

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Debug.Log(source.format+""+destination.format);
        //Debug.Log("OnRenderImage");
        //Graphics.Blit(webcamTexture, null as RenderTexture);
        Graphics.Blit(source, destination, mat);
        //Graphics.Blit(source, destination);
        //Graphics.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), source, mat, -1);
        //cam.targetTexture = null;
    }

    //void OnPostRender()
    //{
        //Debug.Log("OnPostRender");
        //Graphics.Blit(webcamTexture, renderTexture);
        //Graphics.DrawTexture(new Rect(10, 10, 100, 100), webcamTexture);
        //cam.targetTexture = null;
        //Debug.Log("haha");
    //}
}
