using ScriptAPI;
using System;

public class FireplaceAudio : Script
{
    AudioComponent audioComponent;

    public override void Awake()
    {
        audioComponent = new AudioComponent();
    }

    public override void Update()
    {
        //audioComponent.play("fireplace");
        audioComponent.setVolume(0.6f, "fireplace");
        audioComponent.set3DCoords(transform.GetPosition(), "fireplace");
    }
}