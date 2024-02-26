﻿/*!*************************************************************************
****
\file Door_Script.cs
\author Elton Teo
\par DP email: e.teo@digipen.edu
\par Course: csd3450
\date 10-12-2023
\brief  Script for door logic
****************************************************************************
***/
using ScriptAPI;
using System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Door_Script : Script
{
    public GameObject playerGameObject;
    public CameraComponent playerCamera;
    //public GameObject _InteractUI;
    //public Animator doorAnimator;
    public GameObject lockpickGroup;
    public GameObject lockpick;
    public float doorState = 0; //0 is closed, 1 is open
    public bool locked = true;
    public bool forcedLocked;
    public bool chainedShut;
    //public AudioClip[] _DoorSounds;
    //public AudioSource _DoorAudioSource;
    public bool collided;

    [Header("VO Variables")]
    //public Text mySubtitles;
    //public String[] myVOTexts;
    //public AudioClip[] forceLocked_VOLines;
    //public AudioSource voSource;
    private int forcelockedAudioCount = -1;
    private bool playForcedLockedAudio;

    public GameObject doorStates;
    public GameObject doorText;
    public int doorIndex;
    public GameObject popupUI;

    float toRadians(float degree)
    {
        return degree * (3.1415926535897931f / 180);
    }

    public override void Awake()
    {
        doorText = GameObjectScriptFind("DoorText");    // Hate this please change after milestone
    }

    // Update is called once per frame
    override public void Update()
    {
        if (!forcedLocked && gameObject.GetComponent<RigidBodyComponent>().IsRayHit())
        {
            doorStates.GetComponent<DoorState>().doorLookedAt = true;

            if (doorStates.GetComponent<DoorState>().Doors[doorIndex] == DoorState.State.Unlocked)
            {
                doorText.GetComponent<UISpriteComponent>().SetFontMessage("Press E to enter");
                if (Input.GetKeyDown(Keycode.E))
                {
                    Vector3 rotation = playerGameObject.transform.GetRotation();
                    Quaternion quat = new Quaternion(rotation);
                    Vector3 rotationToVector = new Vector3(-Mathf.Sin(toRadians(rotation.Y)), 0.0f, Mathf.Cos(toRadians(rotation.Y))) * 200;
                    playerGameObject.GetComponent<RigidBodyComponent>().SetPositionRotationAndVelocity(playerGameObject.transform.GetPosition() + rotationToVector, new Vector4(quat.X, quat.Y, quat.Z, quat.W), new Vector3(1, 1, 1).Normalize(), new Vector3(1, 1, 1).Normalize());
                }
            }
            else // Locked
            {
                doorText.GetComponent<UISpriteComponent>().SetFontMessage("Press E to lockpick");
                if (Input.GetKeyDown(Keycode.E))
                {
                    doorStates.SetActive(false);
                    lockpickGroup.SetActive(true);
                    lockpick.GetComponent<LockPick1>().doorIndex = doorIndex;
                    playerGameObject.SetActive(false);
                    GraphicsManagerWrapper.ToggleViewFrom2D(true);

                    if (!popupUI.GetComponent<PopupUI>().lockpickDisplayed)
                        lockpick.GetComponent<LockPick1>().newLock();
                }
            }
        }

        //if (collided)
        //{
        //    if (Input.GetKeyDown(Keycode.E))
        //    {
        //        if (!locked)
        //        {
        //            Open_CloseFunction();
        //            _InteractUI.SetActive(true);
        //        }
        //        else if (chainedShut)
        //        {

        //        }
        //        else if (forcedLocked)
        //        {
        //            playForcedLockedAudio = true;
        //            forcelockedAudioCount = -1;
        //        }
        //        else if (!lockpick.ActiveInHierarchy() && !forcedLocked)
        //        {
        //            _InteractUI.SetActive(false);
        //            lockpick.SetActive(true);
        //            lockpickScript.newLock();
        //        }
        //    }

        //    if (lockpickScript.unlocked)
        //    {
        //        lockpickScript.unlocked = false;
        //        lockpick.SetActive(false);
        //        locked = false;
        //        _InteractUI.SetActive(true);
        //    }
        //}

        if (playForcedLockedAudio)
        {
            PlayVO();
        }
    }


    //override public void OnTriggerEnter(ColliderComponent other)
    //{
    //    if (other.gameObject.GetComponent<NameTagComponent>().GetName() == "Enemy")
    //    {
    //        Open_CloseFunction();
    //    }
    //}

    //override public void OnTriggerExit(ColliderComponent other)
    //{
    //    if (other.gameObject.GetComponent<NameTagComponent>().GetName() == "Enemy")
    //    {
    //        Open_CloseFunction();
    //    }
    //}

    public void Open_CloseFunction()
    {
        if (doorState == 0)
        {
            //doorAnimator.SetBool("Open", true);
            doorState = 1;
        }
        else
        {
            //doorAnimator.SetBool("Open", false);
            doorState = 0;
        }
    }

    public void PlayVO()
    {
        bool changedAudio = false;

        // NOTE: Audio
        //if (!voSource.isPlaying())
        //{
        //    if (!changedAudio && forcelockedAudioCount < 2)
        //    {
        //        //select audio clip
        //        voSource.clip = forceLocked_VOLines[forcelockedAudioCount += 1];
        //        voSource.Play();

        //        //select subtitle
        //        mySubtitles.enabled = true;
        //        mySubtitles.text = myVOTexts[forcelockedAudioCount];
        //        changedAudio = true;
        //    }
        //    else
        //    {
        //        mySubtitles.enabled = false;
        //    }
        //}
        //else if (voSource.isPlaying())
        //{
        //    changedAudio = false;
        //}
    }
}
