using ScriptAPI;
using System;

public class Painting_Script : Script
{
    private GameObject playerObject;

    //public Material _PaintingMaterial;
    //public GameObject _OpenPaintingTrigger;

    [SerializeField]
    public string Painting_Name;
    public string Inventory_Texture_Name;
    public bool opened;
    private bool collided;

    //public Animator _PaintingAnimator;
    //public Flashlight_Script _FlashlightScript;
    //private GraphicComponent _color;

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
        playerObject = GameObjectScriptFind("Player");
        //painting1.GetComponent<NameTagComponent>().SetTag("Painting");
        //painting1.GetComponent<NameTagComponent>().SetName("p01");
    }

    // Update is called once per frame
    override public void Update()
    {
        if (Input.GetKeyDown(Keycode.E) && isWithinRange()) // Maybe add 1 more condition to check if its within player's view
        {
            Console.WriteLine("Picked up painting");
            InventoryScript.addPaintingIntoInventory(Inventory_Texture_Name);
            gameObject.SetActive(false);
        }
        //Console.WriteLine("paint script");

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

    public bool isWithinRange()
    {
        Vector3 itemPos = gameObject.transform.GetPosition();
        Vector3 playerPos = playerObject.transform.GetPosition();
        float distance = Vector3.Distance(itemPos, playerPos);
        Console.WriteLine(distance);
        return distance < 5.0;
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
