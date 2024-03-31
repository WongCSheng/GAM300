using ScriptAPI;
using System;

public class FireplaceAudio : Script
{
    String[] ClosetVO;
    AudioComponent audioComponent;

    public override void Awake()
    {
        ClosetVO = new string[17];

        audioComponent = new AudioComponent();
    }

    public override void Start()
    {
        Vector3 fireplace_pos = gameObject.GetComponent<TransformComponent>().GetPosition();
        audioComponent.set3DCoords(fireplace_pos, "fireplace");
    }

    public override void Update()
    {
        audioComponent.play("fireplace");
        //audioComponent.setVolume(0.6f, "fireplace");
    }
}