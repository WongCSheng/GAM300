/*!*************************************************************************
****
\file playButton.cs
\author Matthew Cheung
\par DP email: j.cheung@digipen.edu
\par Course: csd3450
\date 22-11-2023
\brief  Script for main menu play button
****************************************************************************
***/
using ScriptAPI;
using System;

public class PlayButton : Script
{
    public AudioComponent bgm;
    float temp_change;
    public AudioSource audioPlayer;
    public string bgmName;
    private UISpriteComponent sprite;
    bool withinArea(float mouse, float min, float max)
    {
        bool within = false;
        if (mouse > min && mouse < max)
            within = true;
        return within;
    }

    public override void Awake()
    {
        GraphicsManagerWrapper.ToggleViewFrom2D(true);
        bgmName = "Horror_Menu_Finale_Finale";
        bgm = gameObject.GetComponent<AudioComponent>();
        audioPlayer = new AudioSource();
        sprite = gameObject.GetComponent<UISpriteComponent>();
    }

    public override void Start()
    {
        temp_change = 50.0f;
    }

    public override void Update()
    {
        if (bgm.finished(bgmName))
        {
            bgm.play(bgmName);
            //AudioSource.Play(bgmName);
            Console.WriteLine("Mainmenu Update()");
        }

        if(Input.GetKeyDown(Keycode.V))
        {
            temp_change -= 5f;
            bgm.setBGMVol(temp_change);
        }

        if(Input.GetKeyDown(Keycode.B))
        {
            temp_change += 5f;
            bgm.setBGMVol(temp_change);
        }

        if (Input.GetMouseButtonDown(Keycode.M1) && sprite.IsMouseCollided())
        {
            //GraphicsManagerWrapper.ToggleViewFrom2D(false);
            bgm.FadeOut(2, bgmName);
            SceneLoader.LoadStartingCutscene();
        }
    }

    public override void OnDestroy()
    {
        bgm.stop(bgmName);
    }
}
