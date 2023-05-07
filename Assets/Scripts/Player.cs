using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class Player : MonoBehaviour
{
    [SerializeField] Image milkshake;
    [SerializeField] GameObject milkshakeGameObject;
    [SerializeField] Score score;
    [SerializeField] MenuScript menuScript;
    [SerializeField] Timer timer;
    Camera mainCam;
    int maxCamFOV = 130, minCamFOV = 70;
    Transform cylinderTransform;
    Animator cowCamAnimator;
    Animator WorldJump;
    [SerializeField] TMP_Text moovementSpeed; //Cows speed 
    [SerializeField] GameObject rightHornButtonGraphic, leftHornButtonGraphic;
    [HideInInspector] public bool leftButton, rightButton;

    float shakeMultiplier = 0.002f;
    public float shakeMoveSpeed;
    float shakeThreshold = 1.15f;
    float shake;
    float moovementSpeedValue;

    float time;
    bool gunShot;
    bool fillMilkshake;

    // Start is called before the first frame update
    void Awake()
    {
        milkshakeGameObject.SetActive(false);
        mainCam = Camera.main;
        cowCamAnimator = GetComponent<Animator>();
        cylinderTransform = GameObject.Find("Cylinder").GetComponent<Transform>();

        //https://answers.unity.com/questions/377819/getcomponent-for-siblings-and-parents.html Where I got inspirtion for getting parent animator from.

        WorldJump = transform.parent.GetComponent<Animator>();

       // WorldJump = GetComponent;
    }

    void LateUpdate()
    {
        if (shake > shakeThreshold) 
        { 
            mainCam.fieldOfView += shakeMoveSpeed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        TimeIsUp();
        Movement();
        MilkshakeFill();
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
        if (leftButton && rightButton)
        {
            PlayGunShot();
            
            cowCamAnimator.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
            shake = Input.acceleration.magnitude;
            cowCamAnimator.SetTrigger("isRiding");
           
            if (shake > shakeThreshold)
            {
                shakeMoveSpeed += shake * shakeMultiplier;
                cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
                DistortCamera();
                SoundManager.Instance.RunningSound();
                CowIsNOTJumping();
            }
            else
            {
                CowIsJumping();

                SlowDown();
            }
        }
        else
        {
            SlowDown();
            CowIsNOTJumping();
        }
        var normalizeValue = 35;
        moovementSpeedValue = shakeMoveSpeed * normalizeValue;
        moovementSpeed.text = moovementSpeedValue.ToString("0.00") + " km/t";
        
        if(shakeMoveSpeed == 0)
            SoundManager.Instance.RunningSoundStop();
    }

    void CowIsJumping()
    {
        // the COW gameobject is holding the WorldJump animator controller
        WorldJump.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
        WorldJump.SetBool("IsJumping", true);
        //if (WorldJump.GetBool("Isjumping") == true)
        //{
            // CountdownEvent.;
       // }
    }

    void CowIsNOTJumping()
    {
        // the COW gameobject is holding the WorldJump animator controller
        WorldJump.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
        WorldJump.SetBool("IsJumping", false);
    }

    void TimeIsUp()
    {
        if (timer.timeLeft <= 0)
        {
            leftButton = false;
            rightButton = false;
            shake = 0;
            if(shakeMoveSpeed == 0)
                menuScript.EndGame();
        }
    }
    void PlayGunShot()
    {
        if (!gunShot)
        {
            SoundManager.Instance.GunshotSound();
            gunShot = true;
        }
    }

    void SlowDown()
    {
        shakeMoveSpeed -= shakeMultiplier + shakeMultiplier;
        //Godt til threshholds (minder om et if statement) (ser om shakeMoveSpeed er mindre end 0 og sætter derefter det til 0)
        if (timer.timeLeft <= 0)
        {
            var slowAmount = 2;
            shakeMoveSpeed -= shakeMultiplier * slowAmount;
        }
        shakeMoveSpeed = shakeMoveSpeed < 0 ? 0 : shakeMoveSpeed;
        cylinderTransform.Rotate(0, shakeMoveSpeed, 0);
        UnDistortCamera();
    }
    
    void DistortCamera()
    {
        mainCam.fieldOfView = minCamFOV + moovementSpeedValue/3; //Magic number is a stabilizer to make the fov to increase faster
        mainCam.fieldOfView = mainCam.fieldOfView > maxCamFOV ? maxCamFOV : mainCam.fieldOfView;
    }

    void UnDistortCamera()
    {
        mainCam.fieldOfView = minCamFOV + moovementSpeedValue/3; //Magic number is a stabilizer to make the fov to decrease slower
        mainCam.fieldOfView = mainCam.fieldOfView < minCamFOV ? minCamFOV : mainCam.fieldOfView;
    }
    
    void MilkshakeFill()
    {
        if (!fillMilkshake) return;
        var milkshakeStart = 0f;
        var scoreToMilkshake = 1000f;
        var milkshakeTarget = score.scoreValue / scoreToMilkshake;
        var duration = 2f;
        time += Time.deltaTime;
        milkshakeGameObject.SetActive(true);
        milkshake.fillAmount = Mathf.Lerp(milkshakeStart, milkshakeTarget, time / duration);
        SoundManager.Instance.MilkshakeSound();
        Invoke(nameof(MilkshakeHasBeenFilled), duration);
    }

    void FillingMilkshake()
    {
        fillMilkshake = true;
    }

    void MilkshakeHasBeenFilled()
    {
        fillMilkshake = false;
        SoundManager.Instance.MilkshakeSoundStop();
    }
    
}
