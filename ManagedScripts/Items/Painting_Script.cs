using ScriptAPI;
using System;

public class Painting_Script : Script
{
    [Header("Paintings")]
    
    //public Material _PaintingMaterial;
    //public GameObject _OpenPaintingTrigger;

    [SerializeField]
    public GameObject painting1, painting2, painting3, painting4,
        painting5, painting6, painting7, painting8;

    //public Animator _PaintingAnimator;

    public bool opened;

    //public Flashlight_Script _FlashlightScript;
    //private GraphicComponent _color;

    [SerializeField] private bool collided;

    //public InventoryScript _inventory;

    [Header("AudioStuff")]
    public AudioSource AudioPlayer;
    public AudioComponent[] voClip = new AudioComponent[2];

    public float timer;

    override public void Awake()
    {
        voClip[0].setFilePath("pc_stealpainting1");
        voClip[1].setFilePath("pc_shinelightafterreceipt"); //This one should be items VO
        //_color.a = 1;
        timer = 1.0f;
        Console.WriteLine("Painting script");
    }

    public override void Start()
    {
        painting1.GetComponent<NameTagComponent>().SetTag("Painting");
        painting1.GetComponent<NameTagComponent>().SetName("p01");
        painting1.SetActive(painting1.GetEntityID(), true);

        //painting2.GetComponent<NameTagComponent>().SetTag("Painting");
        //painting2.GetComponent<NameTagComponent>().SetName("p02");

        //painting3.GetComponent<NameTagComponent>().SetTag("Painting");
        //painting3.GetComponent<NameTagComponent>().SetName("p03");

        //painting4.GetComponent<NameTagComponent>().SetTag("Painting");
        //painting4.GetComponent<NameTagComponent>().SetName("p04");

        //painting5.GetComponent<NameTagComponent>().SetTag("Painting");
        //painting5.GetComponent<NameTagComponent>().SetName("p05");

        //painting6.GetComponent<NameTagComponent>().SetTag("Painting");
        //painting6.GetComponent<NameTagComponent>().SetName("p06");

        //painting7.GetComponent<NameTagComponent>().SetTag("Painting");
        //painting7.GetComponent<NameTagComponent>().SetName("p07");

        //painting8.GetComponent<NameTagComponent>().SetTag("Painting");
        //painting8.GetComponent<NameTagComponent>().SetName("p08");
    }

    // Update is called once per frame
    override public void Update()
    {
        if(Input.GetMouseButtonDown(Keycode.M1) && interact(gameObject, collided))
        {
            if(gameObject.GetComponent<NameTagComponent>().GetName() == "p01")
            {
                painting1.SetActive(painting1.GetEntityID(), false);
                //AudioPlayer.Play(voClip[0]);
            }
        }
        
        //if (collided == true && _color.getColourAlpha() > 0.5f)
        //{
            //_color = _PaintingMaterial.color;
            //_color.SetColourAlpha(_color.getColourAlpha() - 0.2f * Time.deltaTime);
            //_PaintingMaterial.color = _color;
        //}
        //else if (collided == false && _color.getColourAlpha() < 1f)
        //{
            //_color = _PaintingMaterial.color;
            //_color.SetColourAlpha(_color.getColourAlpha() + 0.5f * Time.deltaTime);
            //_PaintingMaterial.color = _color;
        //}

        //if (!_FlashlightScript.activateLight)
        //{
        //    collided = false;
        //}

        //if (gameObject.GetComponent<RigidBodyComponent>().IsSensorActivated()) // returns true if player is near it
        //{
        //    if (timer <= 0.0f)
        //    {
        //        if (!receiptFound)
        //        {
        //            //Audio.play(voClip[0]);
        //        }
        //        else
        //        {
        //            //Audio.play(voClip[1]);
        //        }
        //    }
        //    else
        //    {
        //        timer -= Time.deltaTime;
        //    }

        //    if (Input.GetKeyDown(Keycode.E) && !paintingTaken && paintingParent.GetEntityID() != 0)
        //    {
        //        paintingParent.SetActive(paintingParent.GetEntityID(), false);
        //        paintingTaken = true;
        //    }
        //}
        //else
        //{
        //    timer = 1.0f;
        //}

        //if (_color.getColourAlpha() <= 0.6f)
        //{
            //_OpenPaintingTrigger.SetActive(_OpenPaintingTrigger.GetEntityID(), true);

            //checks if player has receipt, if so play a specific VO, else play another VO
            //for (int x = 0; x < _inventory.noteObjsInInventory.Count; x++)
            //{
            //    if (_inventory.noteObjsInInventory[x] != "Reciept")
            //    {
            //        if (!playedAudio)
            //        {
            //            //playerVOSource.clip = voClip[0];
            //            //playerVOSource.Play();
            //            //subtitles.enabled = true;
            //            //subtitlesBG.enabled = true;
            //            //subtitles.text = "Martin (Internal): \"Something�s behind this painting...\"";
            //            //playedAudio = true;
            //        }

            //        //if (!playerVOSource.isPlaying && playedAudio)
            //        //{
            //        //    subtitles.enabled = false;
            //        //    subtitlesBG.enabled = false;
            //        //    break;
            //        //}
            //    }
            //    else if (_inventory.noteObjsInInventory[x] == "Reciept")
            //    {
            //        if (!playedAudio)
            //        {
            //            //playerVOSource.clip = voClip[1];
            //            //playerVOSource.Play();
            //            //subtitles.enabled = true;
            //            //subtitlesBG.enabled = true;
            //            //subtitles.text = "Martin (Internal): \"Looks like the receipt was right.\"";
            //            //playedAudio = true;
            //        }

            //        //if (!playerVOSource.isPlaying && playedAudio)
            //        //{
            //        //    subtitles.enabled = false;
            //        //    subtitlesBG.enabled = false;
            //        //    break;
            //        //}
            //    }
            //}
        //}
    }

    public bool interact(GameObject go, bool set)
    {
        if (Input.GetKey(Keycode.E))
        {
            go.SetActive(go.GetEntityID(), set);
        }

        return false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Player's Light")
    //    {
    //        collided = true;
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player's Light")
    //    {
    //        collided = false;
    //    }
    //}
}
