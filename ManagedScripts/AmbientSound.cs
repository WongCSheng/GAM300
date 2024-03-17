using ScriptAPI;
using System;

public class AmbientSound : Script
{
    [SerializeField] private String bgm;
    private AudioComponent play;
    private GameObject ob;

    public override void Awake()
    {
        ob = gameObject;
    }

    public override void Start()
    {
        play = gameObject.GetComponent<AudioComponent>();
    }

    public override void Update()
    {
        if(Vector3.Distance(GameObjectScriptFind("FPS_Controller_Script").GetComponent<TransformComponent>().GetPosition(),
            ob.transform.GetPosition()) < 10.0f)
        {
            play.play(bgm);
            play.set3DCoords(ob.GetComponent<TransformComponent>().GetPosition(), bgm);
        }
        else
        {
            if(play.checkPlaying(bgm))
            {
                play.stop(bgm);
            }
        }
    }


}
