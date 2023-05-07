using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    //[SerializeField] GameObject milkshakeGameObject;
    [SerializeField] TMP_Text moovementSpeed; 
    [SerializeField] GameObject rightHornButtonGraphic, leftHornButtonGraphic;
    [SerializeField] Transform cylinderTransform;
    [HideInInspector] public bool leftButton, rightButton;
    readonly int maxCamFOV = 130, minCamFOV = 70, fovStabilizer = 3;
    Animator cowCamAnimator;
    Camera mainCam;

    public float shakeMoveSpeed;
    readonly float shakeMultiplier = 0.002f, shakeThreshold = 2f; 
    float moovementSpeedValue, shakeAcceleration;

    bool finishAnimationPlayed;
    bool timeIsUp;

    void Awake()
    {
        //milkshakeGameObject.SetActive(false);
        mainCam = Camera.main;
        cowCamAnimator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        GameEvents.TimeIsUp += OnTimeIsUp;
    }

    void OnDisable()
    {
        GameEvents.TimeIsUp -= OnTimeIsUp;
    }

    void FixedUpdate()
    {
        Movement();
        if (timeIsUp)
            OnTimeIsUp();
    }

    public void LeftButton()
    {
        leftButton = !leftButton;
        leftHornButtonGraphic.SetActive(!leftButton);
    }

    public void RightButton()
    {
        rightButton = !rightButton;
        rightHornButtonGraphic.SetActive(!rightButton);
    }

    void Movement()
    {
        var normalizeValue = 35;
        moovementSpeedValue = shakeMoveSpeed * normalizeValue;
        moovementSpeed.text = moovementSpeedValue.ToString("0.00") + " km/ph";
        if (shakeMoveSpeed > 0)
        {
            cowCamAnimator.Play("RidingCow");
            SoundManager.Instance.RunningSound();
        }
        else
            SoundManager.Instance.RunningSoundStop();
        if (timeIsUp) return;
        if (leftButton && rightButton)
        {
            cowCamAnimator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
            shakeAcceleration = Input.acceleration.magnitude;
            if (shakeAcceleration > shakeThreshold)
            {
                shakeMoveSpeed += shakeAcceleration * shakeMultiplier;
                cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
                IncreaseFoV();
            }
            else
                SlowDown();
        }
        else
            SlowDown();
    }

    void OnTimeIsUp()
    {
        SlowDown();
        timeIsUp = true;
        leftButton = false;
        rightButton = false;
        if(shakeMoveSpeed == 0)
            GameEvents.OnGameEnded();
    }

    void SlowDown()
    {
        if (shakeMoveSpeed == 0) return;
        DecreaseFoV();
        shakeMoveSpeed -= shakeMultiplier + shakeMultiplier;
        cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
        shakeMoveSpeed = shakeMoveSpeed <= 0 ? 0 : shakeMoveSpeed;
    }
    
    void IncreaseFoV()
    {
        mainCam.fieldOfView = minCamFOV + moovementSpeedValue/fovStabilizer;
        mainCam.fieldOfView = mainCam.fieldOfView > maxCamFOV ? maxCamFOV : mainCam.fieldOfView;
    }

    void DecreaseFoV()
    {
        mainCam.fieldOfView = minCamFOV + moovementSpeedValue/fovStabilizer;
        mainCam.fieldOfView = mainCam.fieldOfView < minCamFOV ? minCamFOV : mainCam.fieldOfView;
    }

    void FinishGameAnimPlayed() //Accessed by FinishGame animation
    {
        GameEvents.OnFinishGameAnimPlayed();
    }

}
