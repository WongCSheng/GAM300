using ScriptAPI;
using System;

public class FireplaceAudio : Script
{
    String[] ClosetVO;
    AudioComponent audioComponent;
    Vector3 temppos;

    public override void Awake()
    {
        ClosetVO = new string[17];
        temppos = new Vector3(11900.0f, 31.0f, 11100.0f);

        audioComponent = new AudioComponent();
    }

    public override void Update()
    {
        audioComponent.play("fireplace");
        audioComponent.setVolume(0.6f, "fireplace");
        audioComponent.set3DCoords(temppos, "fireplace"); ;
    }
}