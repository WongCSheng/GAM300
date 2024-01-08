using ScriptAPI;
using System;

public class CutsceneSubtitle : Script
{
    AudioComponent[] AudioClips;
    AudioSource AudioPlayer;
    String[] Subtitles;
    //AudioSource audio;
    [SerializeField]
    public static int counter;
    public static bool next = true;
    public override void Awake()
    {
        Audiofiles = new AudioComponent[17];
        AudioPlayer = gameObject.GetComponent<AudioSource>();
        Subtitles = new String[17];
        GraphicsManagerWrapper.ToggleViewFrom2D(true);
        Subtitles[0] = "Father: My Son, if you are reading this, then I am dead,";
        Subtitles[1] = "Father: ...and I've left you with a terrible debt. But you don't have to be";
        Subtitles[2] = "Father: Your mother, God rest her soul, didn't tell us a lot about her family";
        Subtitles[3] = "Father: ...or their wealth";
        Subtitles[4] = "Father: She never mentioned them at all";

        Subtitles[5] = "Father: So imagine my surprise when I discovered their history";

        Subtitles[6] = "Father: I have seen what wealth they hold";
        Subtitles[7] = "Father: How much they have selfishly kept from us";

        Subtitles[8] = "Father: Believe me, I have tried to take what we were owed when her father died";
        Subtitles[9] = "Father: But I am not of their blood. I was always an outsider";

        Subtitles[10] = "Father: But you have their blood running within you";
        Subtitles[11] = "Father: And you deserve what was kept from you. Your rightful inheritance";

        Subtitles[12] = "Father: So my final gift to you, my son, is simply what should have been given to you before";
        Subtitles[13] = "Father: And if they still would not give, then take it, if you must";

        Subtitles[14] = "Father: By whatever means necessary";

        Subtitles[15] = "Father: Remember, no matter what they tell you";

        Subtitles[16] = "Father: You'll always be part of the family";

        AudioClips[0] = "intro1_1";
        AudioClips[1] = "intro1_2";
        AudioClips[2] = "intro2_1";
        AudioClips[3] = "intro2_2";
        AudioClips[4] = "intro2_3";
        AudioClips[5] = "intro3_1";
        AudioClips[6] = "intro4_1";
        AudioClips[7] = "intro4_2";
        AudioClips[8] = "intro5_1";
        AudioClips[9] = "intro5_2";
        AudioClips[10] = "intro6_1";
        AudioClips[11] = "intro6_2";
        AudioClips[12] = "intro7_1";
        AudioClips[13] = "intro8_1";
        AudioClips[14] = "intro8_2";
        AudioClips[15] = "intro9_1";
        AudioClips[16] = "intro9_2";

        //foreach(String str in Audiofiles)
        //{
        //    audio.add_clips(str);
        //}

        counter = 0;
        next = true;

    }

    public override void Update()
    {
        UISpriteComponent Sprite = gameObject.GetComponent<UISpriteComponent>();
        if (Input.GetKeyDown(Keycode.SPACE))
        {
            AudioPlayer.stop(AudioClips[counter]);
            GraphicsManagerWrapper.ToggleViewFrom2D(false);
            SceneLoader.LoadMainGame();
        }
        else
        {
            //audio.playQueue();

            if (counter > 16)//cutscene over
            {
                GraphicsManagerWrapper.ToggleViewFrom2D(false);
                SceneLoader.LoadMainGame();
            }
            else
            {
                if (next)
                {
                    Sprite.SetFontMessage(Subtitles[counter]);
                    AudioPlayer.play(AudioClips[counter]);
                    next = false;
                }
                else if (AudioPlayer.finished(AudioClips[counter]))
                {
                    if (next)
                    {
                        Sprite.setColourAlpha(1);
                        Sprite.SetFontMessage(Subtitles[counter]);
                        //audio.Play(Audiofiles[counter]);
                        AudioPlayer.play(AudioClips[counter]);
                        next = false;
                    }
                    else if (AudioPlayer.finished(AudioClips[counter]))
                    {
                        next = true;
                        ++counter;
                    }
                }
            }
        }
    }
}