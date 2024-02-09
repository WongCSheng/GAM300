using ScriptAPI;
using System;

public class PlayButton : Script
{
    public AudioComponent bgm;
    AudioSource audioPlayer;
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
        bgm.setFilePath("skyclad_sound_ambience_dark_loop_dynamic_tones_howling_moaning_mournful_eerie_105");
        bgm = gameObject.GetComponent<AudioComponent>();
        sprite = gameObject.GetComponent<UISpriteComponent>();
    }

    public override void Update()
    {
        audioPlayer.Play(bgm);

        if (Input.GetMouseButtonDown(Keycode.M1) && sprite.IsMouseCollided())
        {
            //GraphicsManagerWrapper.ToggleViewFrom2D(false);
            audioPlayer.Stop(bgm);
            SceneLoader.LoadStartingCutscene();
        }
    }
}
