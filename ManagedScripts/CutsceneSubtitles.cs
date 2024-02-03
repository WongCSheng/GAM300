using ScriptAPI;
using System;

public class CutsceneSubtitle : Script
{
    AudioComponent[] Audiofiles;
    AudioComponent sampleAudio = new AudioComponent();
    AudioSource audioPlayer;
    String[] Subtitles;
    [SerializeField]
    public static int counter;
    public static bool next = true;
    bool test = false;
    public override void Awake()
    {
        Audiofiles = new AudioComponent[17];
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

        //Audiofiles[0].setFilePath("intro1_1");
        //Audiofiles[1].setFilePath("intro1_2");
        //Audiofiles[2].setFilePath("intro2_1");
        //Audiofiles[3].setFilePath("intro2_2");
        //Audiofiles[4].setFilePath("intro2_3");
        //Audiofiles[5].setFilePath("intro3_1");
        //Audiofiles[6].setFilePath("intro4_1");
        //Audiofiles[7].setFilePath("intro4_2");
        //Audiofiles[8].setFilePath("intro5_1");
        //Audiofiles[9].setFilePath("intro5_2");
        //Audiofiles[10].setFilePath("intro6_1");
        //Audiofiles[11].setFilePath("intro6_2");
        //Audiofiles[12].setFilePath("intro7_1");
        //Audiofiles[13].setFilePath("intro8_1");
        //Audiofiles[14].setFilePath("intro8_2");
        //Audiofiles[15].setFilePath("intro9_1");
        //Audiofiles[16].setFilePath("intro9_2");

        sampleAudio.setFilePath("intro1_1");

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
            //audioPlayer.Stop(Audiofiles[counter]);
            audioPlayer.Stop(sampleAudio);
            GraphicsManagerWrapper.ToggleViewFrom2D(false);
            SceneLoader.LoadMainGame();
        }
        else
        {
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
                    //audioPlayer.Play(Audiofiles[counter]);
                    audioPlayer.Play(sampleAudio);
                    next = false;
                }
                else if (test/*audioPlayer.hasFinished(Audiofiles[counter])*/)
                {
                    if (next)
                    {
                        Sprite.setColourAlpha(1);
                        Sprite.SetFontMessage(Subtitles[counter]);
                        //audio.Play(Audiofiles[counter]);
                        //audioPlayer.Play(Audiofiles[counter]);
                        next = false;
                    }
                    else if (test/*audioPlayer.hasFinished(Audiofiles[counter])*/)
                    {
                        next = true;
                        ++counter;
                    }
                }
            }
        }
    }
}