﻿/*!*************************************************************************
****
\file Painting_Script.cs
\author Celine Leong
\par DP email: jiayiceline.leong@digipen.edu
\par Course: csd3450
\date 15-1-2024
\brief  Gameplay script for player interaction with paintings
****************************************************************************
***/
using Microsoft.VisualBasic;
using ScriptAPI;
using System;

public class p02 : Script
{
    [SerializeField]
    public string Painting_Name;
    public string Painting_Texture;

    public GameObject _InteractUI;
    public GameObject paintingLight;
    public GameObject gallerySwitchLight;

    [Header("AudioStuff")]
    public AudioComponent AudioPlayer;

    public GameObject hidingGameObject;
    public GameObject ghost;
    public static bool isPaintingCollected;

    float timer = 2.0f;
    bool paintingMoved = false;
    override public void Awake()
    {
        AudioPlayer = gameObject.GetComponent<AudioComponent>();
        isPaintingCollected = false;
    }

    public override void Start()
    {
    }

    // Update is called once per frame
    override public void Update()
    {
        //if (GalleryLetter.isNotePicked) // Don't allow player to proceed with puzzle before getting the hint.
        {
            if (!isPaintingCollected && gameObject.GetComponent<RigidBodyComponent>().IsRayHit())
            {
                Console.WriteLine("p02");
                InteractUI.isShow = true;

                if (Input.GetKeyDown(Keycode.E))
                {
                    Console.WriteLine("Picked up p02");
                    isPaintingCollected = true;

                    // Trigger Painting Event
                    AudioPlayer.play("gallery_movepainting");
                    //gameObject.GetComponent<ColliderComponent>().SetEnabled(false);
                    //GameplaySubtitles.counter = 8;

                    paintingMoved = false;
                    timer = 2.0f;

                    paintingLight.GetComponent<Blinking>().SetEnabled(false);
                    paintingLight.GetComponent<PointlightComponent>().SetColorAlpha(0.0f);
                }
            }
            else
            {
                //_InteractUI.SetActive(false);
            }
            if (isPaintingCollected && !paintingMoved)
            {
                if (timer >= 0.0f)
                {
                    Console.WriteLine("Moving p02");
                    //gameObject.transform.SetPosition(gameObject.transform.GetPosition() + gameObject.transform.getRightVector() * 50.0f * Time.deltaTime); // Right Vector is moving backwards instead
                    gameObject.transform.SetPosition(gameObject.transform.GetPosition() + new ScriptAPI.Vector3(0, 0, 75) * Time.deltaTime);
                    gameObject.GetComponent<RigidBodyComponent>().SetPosition(gameObject.transform.GetPosition());
                    timer -= Time.deltaTime;
                }
                else
                {
                    Console.WriteLine("Moving done p02");
                    paintingMoved = true;
                    gallerySwitchLight.GetComponent<Blinking>().SetEnabled(true); // only enable switch light after moving painting
                }
            }
        }
    }
}
