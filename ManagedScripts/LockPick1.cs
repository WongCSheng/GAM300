﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Xml;
using ScriptAPI;

public class LockPick1 : Script
{
    [Header("Tutorial UI Variables")]
/*    public Image _TutorialImage;
    public Sprite[] _TutorialImgSprites;
    public Text _Press2Continue;*/
    [SerializeField] int _TutorialStep;

    //public Text mySubtitles;
    //public Image mySubtitlesBG;
    //public AudioSource myVOSource;
    public AudioComponent audio;
    public bool _TutorialCompleted;

    [Header("Lockpick Variables")]
    public GameDataManager myGameDataManager;
    public GameObject Door_UI;
    public CameraComponent cam;
    public CameraComponent playerCam;
    public TransformComponent innerLock;
    public TransformComponent pickPosition;
    public FPS_Controller_Script playerController;
    public GameObject lockObject;
    public string difficultyLvl;
    public float maxAngle = 90;
    public float lockSpeed = 10;
    public bool unlocked;
    //public AudioClip[] lockSoundEffects;
    //public AudioClip[] rattleSoundEffects;
    String[] lockSoundEffects;
    String[] rattleSoundEffects;
    float delay = 0.4f;
    public GameObject _NumOfTries;
    //public Text _AmtOfTries;

    [Range(1, 25)]
    public float lockRange = 10;

    [SerializeField] private int numOfTries;
    private float percentage;
    private float eulerAngle;
    private float unlockAngle;
    private Vector3 unlockRange;
    private float keyPressTime;
    private bool movePick;
    private bool deduct;
    private bool displayTutorial;
    [SerializeField] bool played;

    // Start is called before the first frame update
    override public void Awake() 
    {
        lockSoundEffects = new String[8];
        rattleSoundEffects = new String[6];
        
        newLock();
        lockSoundEffects[0] = "Lock Turning Audio";
        lockSoundEffects[1] = "temp_locksuccess";

        lockSoundEffects[3] = "pc_lockpickfail";
        lockSoundEffects[4] = "pc_lockpickstart";
        lockSoundEffects[5] = "pc_lockpicksuccess1";
        lockSoundEffects[6] = "pc_lockpicksuccess2";
        lockSoundEffects[7] = "pc_tryfrontdoor1";
        lockSoundEffects[8] = "pc_tryfrontdoor2";

        for (int iterator = 0; iterator < 6; ++iterator)
        {
            rattleSoundEffects[iterator] = "temp_lockrattle" + (iterator + 1);
        }

        //foreach(String str in lockSoundEffects)
        //{
        //    myVOSource.add_clips(str);
        //}

        //foreach(String str in rattleSoundEffects)
        //{
        //    myVOSource.add_clips(str);
        //}

        audio = gameObject.GetComponent<AudioComponent>();
    }

    // Update is called once per frame
    override public void Update()
    {
        if (!_TutorialCompleted)
        {
            //if (!audio.finished(myVOSource[1]) && !played)
            //{
            //    audio.play(myVOSource[1]);
            //    mySubtitlesBG.enabled = true;
            //    mySubtitles.text = "Martin (Internal): Hopefully, I won’t forget how to do this.";
            //    played = true;

            //}
            //else if (!audio.finished(myVOSource[1]) && played)
            //{
            //    mySubtitles.text = "";
            //    mySubtitlesBG.enabled = false;
            //    _NumOfTries.SetActive(gameObject.GetEntityID(), true);
            //    movePick = true;
            //    _TutorialCompleted = true;
            //}
        }
        else if (_TutorialCompleted)
        {
            //_NumOfTries.SetActive(_NumOfTries.GetEntityID(),true);

            #region Move Pick
            if (movePick)
            {
                Console.WriteLine(Input.GetMousePosition().X + "\t" + Input.GetMousePosition().Y);
                Vector3 dir = Input.GetMousePosition() - new Vector3(Screen.width / 2, Screen.height / 2, 0);
                //Vector3 dir = Input.GetMousePosition() - new Vector3(609, 278, 0);
                //Vector3 dir = Input.GetMousePosition() - new Vector3(Input.GetLocalMousePosX(), Input.GetLocalMousePoxY(), 0);
                //Vector3 dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);

                eulerAngle = Vector3.Angle(dir, new Vector3(0, 1, 0));

                Vector3 cross = Vector3.Cross(new Vector3(0, 1, 0), dir);
                if (cross.Z < 0) { eulerAngle = -eulerAngle; }
                eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);

                //Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, new Vector3(0, 0, 1));
                //transform.SetRotation(new Vector3(rotateTo.X, rotateTo.Y, rotateTo.Z));

                eulerAngle = 3.1415926535897931f - eulerAngle;
                transform.SetRotation(new Vector3(0, 0, eulerAngle));
                Vector2 addedPosition = new Vector2(-Mathf.Sin(eulerAngle) * 2.5f, Mathf.Cos(eulerAngle) * 2.5f);
                transform.SetPosition(new Vector3(addedPosition.X, 1 + addedPosition.Y, -15));
            }

            if (Input.GetKeyDown(Keycode.E))
            {
                movePick = false;
                keyPressTime = 1;
                /* GetComponent<AudioSource>().clip = lockSoundEffects[0];
                 GetComponent<AudioSource>().Play();*/
            }
            if (Input.GetKeyUp(Keycode.E))
            {
                movePick = true;
                keyPressTime = 0;
                deduct = true;
            }
            #endregion

            #region Check if pick is at correct position
            percentage = Mathf.Round(100 - Mathf.Abs(((eulerAngle - unlockAngle) / 100) * 100));
            float lockRotation = ((percentage / 100) * maxAngle) * keyPressTime;
            float maxRotation = (percentage / 100) * maxAngle;
            float lockLerp = Mathf.LerpAngle(innerLock.GetRotation().Z, lockRotation, Time.deltaTime * lockSpeed);
            innerLock.SetRotation(new Vector3(0, 0, lockLerp));

            if (lockLerp >= maxRotation - 1)
            {
                if (eulerAngle < unlockRange.Y && eulerAngle > unlockRange.X)
                {
                    movePick = true;
                    keyPressTime = 0;
                    //myVOSource.Play(lockSoundEffects[1]);
                    audio.play(lockSoundEffects[1]);
                    /*GetComponent<AudioSource>().clip = lockSoundEffects[1];
                    GetComponent<AudioSource>().Play();*/

                    //Coroutine(StartDelay());
                    //async Task<int> StartDelay()
                    //IEnumerator StartDelay()
                    //{
                    //    yield return new WaitForSeconds(1.2f);
                    //    playerController.enabled = true;
                    //    playerController.lockCursor = true;
                    //    playerCam.enabled = true;
                    //    Door_UI.SetActive(false);
                    //    unlocked = true;
                    //    _NumOfTries.SetActive(false);
                    //    lockObject.SetActive(false);
                    //}
                }
                else
                {
                    //float randomRotation = ScriptAPI.Random.Range(0, 3.1415926535897931f);
                    //Vector3 rotation = transform.GetRotation();
                    //transform.SetRotation(rotation + new Vector3(0, 0, ScriptAPI.Random.Range((-randomRotation - 1), (randomRotation + 1))));

                    if (Input.GetKeyDown(Keycode.E) || Input.GetKey(Keycode.E))
                    {
                        if (!audio.isPlaying(lockSoundEffects[1]))
                        {
                            delay -= Time.deltaTime;

                            if (delay <= 0)
                            {
                                //GetComponents<AudioSource>()[1].clip = rattleSoundEffects[Random.Range(0, rattleSoundEffects.Length)];
                                //GetComponents<AudioSource>()[1].Play();
                                audio.play(rattleSoundEffects[(int)ScriptAPI.Random.Range(0, 6)]);
                                delay = 0.2f;
                            }
                        }
                    }

                    if (deduct == true)
                    {
                        numOfTries -= 1;
                        deduct = false;
                    }

                    if (numOfTries <= 0)
                    {
                        //GetComponent<AudioSource>().clip = lockSoundEffects[2];
                        //GetComponent<AudioSource>().volume = 0.5f;
                        //GetComponent<AudioSource>().Play();
                        //movePick = false;

                        //Coroutine(Deactivate(), 1);

                        //IEnumerator<int> Deactivate()
                        //{
                        //    _NumOfTries.SetActive(false);
                        //    playerController.enabled = true;
                        //    playerController.lockCursor = true;
                        //    playerCam.enabled = true;
                        //    Door_UI.SetActive(false);
                        //    lockObject.SetActive(false);
                        //}
                    }
                }
            }
            #endregion

            //_AmtOfTries.text = numOfTries.ToString();

            //if (numOfTries <= 1)
            //{
            //    _AmtOfTries.color = Color.red;
            //}
        }
    }

    public void newLock()
    {
        innerLock = GameObjectScriptFind("InnerLock").GetTransformComponent();
        //Cursor.visible = false;
        //GetComponent<AudioSource>().volume = 1f;

        //Door_UI.SetActive(Door_UI.GetEntityID(), true);

        //_AmtOfTries.color = Color.white;
        keyPressTime = 0;
        unlocked = false;
        deduct = true;
        //playerController.is_Enabled = false;
        //playerCam. = false;
        //cam.transform.SetRotation(Quaternion(new))
        //unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
        //unlockRange = new Vector3(unlockAngle - lockRange, unlockAngle + lockRange, 0.0f);

        if (difficultyLvl == "Easy")
        {
            numOfTries = 10;
        }
        else if (difficultyLvl == "Normal")
        {
            numOfTries = 5;
        }
        else if (difficultyLvl == "Hard")
        {
            numOfTries = 3;
        }

        if (_TutorialCompleted)
        {
            movePick = true;
        }
    }
}
