using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class CameraStuff : MonoBehaviour
{
    [Header("Displays")]
    [SerializeField] private RawImage cameraDisplay;
    [SerializeField] private RawImage thumbnailDisplay;
    
    [Header("UI")]
    [SerializeField] private Button captureButton;
    
    [Header("Phone options")]
    [SerializeField] private bool useFrontCamera;
    
    //This is the list of where it is taking the camera
    private WebCamTexture _webCamTexture;

    public UnityEvent photoTaken;

    private IEnumerator Start()
    {
        captureButton.onClick.AddListener(CapturePhoto);
        yield return RequestCameraPermission();
    }

    private void CapturePhoto()
    {
        if (_webCamTexture == null || !_webCamTexture.isPlaying) return;
        
        Texture2D photo = new Texture2D(_webCamTexture.width, _webCamTexture.height, TextureFormat.RGBA32, false);
        
        //We can change here the relation with the pixels
        photo.SetPixels(_webCamTexture.GetPixels());
        photo.Apply();
        
        thumbnailDisplay.texture = photo;
        thumbnailDisplay.gameObject.SetActive(true);

        photoTaken?.Invoke();
        
        //Instead of saving it in the gallery, this one add it's to the persistent data
        GameSettings.PhotoToMaterial = photo;
    }
    

    //Ask for permission for the camera
    private IEnumerator RequestCameraPermission()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

        if (!Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            Debug.LogWarning("WebCam is not authorized");
            yield break;
        }
        InitializeCamera();
    }
    
    
    // Starts and assign the camera
    private void InitializeCamera()
    {
        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0)
        {
            Debug.LogWarning("No camera devices found");
        }

        string cameraName = null;
        foreach (WebCamDevice device in devices)
        {
            if (device.isFrontFacing == useFrontCamera)
            {
                cameraName = device.name;
                break;
            }
        }
        
        cameraName ??= devices[0].name;
        _webCamTexture = new WebCamTexture(cameraName, 1920, 1080, 30);
        
        cameraDisplay.texture = _webCamTexture;
        _webCamTexture.Play();

        StartCoroutine(AdjustDisplayAfterFrame());
    }

    private IEnumerator AdjustDisplayAfterFrame()
    {
        yield return null;

        if (useFrontCamera)
        {
            cameraDisplay.rectTransform.localScale = new Vector3(-1, 1, 1);
        }
    }
    
}