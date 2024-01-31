using System;
using ScriptAPI;

public class MilestoneScript : Script
{
    public GameObject bedroomLights;
    public GameObject monster;
    public GameObject bedroomDoor;
    public GameObject painting;
    public GameObject closet;
    public float timer;
    public float scriptEventtimer;
    public AudioComponent voClip;
    AudioComponent[] soundEffectstring;
    public AudioSource audioPlayer;
    public static int counter;
    public static bool next;

    public override void Awake()
    {
        timer = 0.0f;
        scriptEventtimer = 0.0f;
        //voClip = gameObject.GetComponent<AudioComponent>();
        soundEffectstring = new AudioComponent[4];
        counter = 2;
        next = true;
    }

    public override void Start()
    {
        soundEffectstring[0].setFilePath("pc_monsterrattledoor");
        soundEffectstring[1].setFilePath("Heartbeating_Sound");
        soundEffectstring[2].setFilePath("pc_monstergoesaway1");
        soundEffectstring[3].setFilePath("pc_monstergoesaway2");

        bedroomLights = GameObjectScriptFind("BedroomLight");
        monster = GameObjectScriptFind("Monster");
        bedroomDoor = GameObjectScriptFind("Bedroom Double Door");
        painting = GameObjectScriptFind("Frame");
        closet = GameObjectScriptFind("Body2");
    }

    public override void Update()
    {
        if (!painting.ActiveInHierarchy() && scriptEventtimer < 12.0f)
        {
            audioPlayer.Play(soundEffectstring[0]);
            bedroomLights.GetComponent<BlinkingLights>().is_Enabled = true;
            bedroomDoor.SetActive(true);
            scriptEventtimer += Time.deltaTime;
            if (closet.GetComponent<Hiding>().hiding)
            {
                audioPlayer.Play(soundEffectstring[1]);
                monster.SetActive(true);
                timer += Time.deltaTime;
                Vector3 vec = monster.transform.GetPosition();
                vec.X += 15.0f * Time.deltaTime;
                vec.Z += 15.0f * Time.deltaTime;
                monster.transform.SetPosition(vec);

                if (!closet.GetComponent<Hiding>().hiding)
                {
                    monster.GetComponent<GhostMovement>().is_Enabled = true;
                }

                if (timer > 2.0f)
                {
                    monster.SetActive(false);
                    timer = 0.0f;
                }
            }
        }
        if (scriptEventtimer > 12.0f)
        {
            monster.SetActive(false);
            if (counter < 4)
            {
                if (next)
                {
                    audioPlayer.Play(soundEffectstring[counter]);
                    next = false;
                }
                else if (audioPlayer.hasFinished(soundEffectstring[counter]))
                {
                    next = true;
                    ++counter;
                }
            }
        }

        if (scriptEventtimer > 15.0f)
        {
            monster.SetActive(true);
            audioPlayer.Play(soundEffectstring[1]);
        }

        if (scriptEventtimer > 16.0f)
        {
            monster.SetActive(false);
        }
    }
}
