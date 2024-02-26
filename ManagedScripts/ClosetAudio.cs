using ScriptAPI;
using System;

public class ClosetAudio : Script
{
    String[] cutsceneVO;
    AudioComponent audioComponent;

    public override void Awake()
    {
        cutsceneVO = new string[17];
        cutsceneVO[0] = "intro1_1";
        cutsceneVO[1] = "intro1_2";
        cutsceneVO[2] = "intro2_1";
        cutsceneVO[3] = "intro2_2";
        cutsceneVO[4] = "intro2_3";
        cutsceneVO[5] = "intro3_1";
        cutsceneVO[6] = "intro4_1";
        cutsceneVO[7] = "intro4_2";
        cutsceneVO[8] = "intro5_1";
        cutsceneVO[9] = "intro5_2";
        cutsceneVO[10] = "intro6_1";
        cutsceneVO[11] = "intro6_2";
        cutsceneVO[12] = "intro7_1";
        cutsceneVO[13] = "intro8_1";
        cutsceneVO[14] = "intro8_2";
        cutsceneVO[15] = "intro9_1";
        cutsceneVO[16] = "intro9_2";

        audioComponent = new AudioComponent();
    }

    public override void Start()
    {
        
    }

    public override void Update()
    {
        
    }

    public override void LateUpdate()
    {

    }

    public void Play_Cutscene_Audio(int counter)
    {
        audioComponent.play(cutsceneVO[counter]);
    }

    public bool finished_audio(int counter)
    {
        return audioComponent.finished(cutsceneVO[counter]) ? true : false;
    }

    public void stop_audio(int counter)
    {
        audioComponent.stop(cutsceneVO[counter]);
    }

    public void stop_all()
    {
        audioComponent.stopAll();
    }
}