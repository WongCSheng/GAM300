using ScriptAPI;

public class InventoryScript : Script
{
    public GameObject InventoryObject;
    public View_Object _ViewObjectScript;

    public static List<string> noteObjsInInventory;
    public static List<string> itemObjsInInventory;
    public static List<string> paintingObjsInInventory;
    public static string currentTab;

    //public Dictionary<string, string> ItemTexture;
    public GameObject noteBttnGrp;
    public GameObject itemBttnGrp;
    public GameObject paintingBttnGrp;

    public List<string> noteObjImg;
    public List<string> itemObjImg;
    public List<string> paintingsObjImg;

    public string storedObjName;

    //Items
    static public List<GameObject> painting_container;

    //buttons
    public GameObject ItemsTab;
    public GameObject NotesTab;
    public GameObject PaintingsTab;

    public GameObject ItemText;
    public GameObject NotesText;
    public GameObject PaintingsText;
    public GameObject MouseClick;
    public GameObject UseText;
    public GameObject Ikey;
    public GameObject CloseText;

    private static int paintingsCount;
    private static int notesCount;
    private static int itemsCount;


    public bool InventoryIsOpen { get; set;} = false;
    public override void Awake()
    {
        
    }

    public override void Start()
    {
        //Console.WriteLine("Initialising");
        initObjects();
    }

    public override void Update()
    {
        var entityID = gameObject.GetEntityID();

        if(Input.GetKeyDown(Keycode.I))
        {
            toggleInventory();
            Input.GetKeyUp(Keycode.I);
        }

        if (InventoryIsOpen) // Inventory opened
        {
            //Cursor.visible = true;
            //Cursor.LockState = CursorLockMode.None;
            checkMouseInput();
        }
        else    // Inventory closed
        {
            //Cursor.visible = false;
            //Cursor.LockState = CursorLockMode.Locked;
        }
    }

    public void toggleInventory()
    {
        Console.WriteLine("Toggle Inventory\n");
        InventoryIsOpen = !InventoryIsOpen;
        InventoryObject.SetActive(InventoryIsOpen);
    }

    public void checkMouseInput()
    {
        //Console.WriteLine("Checking Mouse Input\n");
        //if (Input.GetMouseButtonDown(Keycode.M1))
        //{
            if(withinButton(ItemsTab)) // Slightly off in y-axis
            {
                Console.WriteLine("Collide Items\n");
                currentTab = "Items";
            }
            if(withinButton(NotesTab)) // Slightly off in y-axis
            {
                Console.WriteLine("Collide Notes\n");
                currentTab = "Notes";
            }
            if (withinButton(PaintingsTab)) // Slightly off in y-axis
            { 
                Console.WriteLine("Collide Paintings\n");
                currentTab = "Paintings";
            }
        //}
    }

    public void initObjects()
    {
        Console.WriteLine("Init objects\n");
        InventoryObject = GameObjectScriptFind("InventoryObject");

        ItemsTab        = GameObjectScriptFind("ItemsTab");
        NotesTab        = GameObjectScriptFind("NotesTab");
        PaintingsTab    = GameObjectScriptFind("PaintingsTab");

        itemObjsInInventory = new List<string>
        {
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Notes1.dds",            "Notes3.dds",
            "Notes5.dds",            "Notes7.dds",
            "Notes9.dds",            "Notes11.dds"
        };

        noteObjsInInventory = new List<string>
        {
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Notes7.dds",            "Notes8.dds",
            "Notes9.dds",            "Notes10.dds",
            "Notes11.dds",           "Notes12.dds"
        };

        paintingObjsInInventory = new List<string>
        {
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Inventory Box Img.dds",            "Inventory Box Img.dds",
            "Inventory Box Img.dds",            "Inventory Box Img.dds"
        };

        InventoryObject.SetActive(false);
        InventoryIsOpen = false;
        currentTab = "Items";
        paintingsCount = 0;
        itemsCount = 0;
        notesCount = 0;

        // ItemText        = GameObjectScriptFind("Item Text");
        // NotesText       = GameObjectScriptFind("Notes Text");
        // PaintingsText   = GameObjectScriptFind("Paintings Text");
        // MouseClick      = GameObjectScriptFind("MouseClick");
        // UseText         = GameObjectScriptFind("Use Text");
        // Ikey            = GameObjectScriptFind("I Key");
        // CloseText       = GameObjectScriptFind("Close Text");
    }

    public static void addPaintingIntoInventory(string texture_name)
    {
        Console.WriteLine("Adding painting " + texture_name + "\n");
        paintingObjsInInventory[paintingsCount++] = texture_name;
    }

    public static void addNoteIntoInventory(string texture_name)
    {
        Console.WriteLine("Adding painting " + texture_name + "\n");
        noteObjsInInventory[notesCount++] = texture_name;
    }

    public static void addItemIntoInventory(string texture_name)
    {
        Console.WriteLine("Adding painting " + texture_name + "\n");
        itemObjsInInventory[itemsCount++] = texture_name;
    }

    // ************************************ Not used ********************************//
    public void ExamineObj()
    {
        _ViewObjectScript.OnDisable();
        _ViewObjectScript.isExaming = true;
        InventoryObject.SetActive(false);
    }

    public void UseObject()
    {
        if (storedObjName == "Starting Battery" || storedObjName == "Toilet_Battery")
        {
            for (int i = 0; i < itemObjsInInventory.Count; i++)
            {
                if (itemObjsInInventory[i] == storedObjName)
                {
                    itemObjsInInventory[i] = "";
                    storedObjName = "";
                }
            }
        }
    }

    bool withinButton(GameObject obj) // Working but y-pos slightly off
    {
        Vector3 ObjectPos = obj.transform.GetPosition();
        Vector3 ObjectScale = obj.transform.GetScale();
        float mouseX = Input.GetLocalMousePosX();
        float mouseY = Input.GetLocalMousePosY();
        float minX = ObjectPos.X - ObjectScale.X * 0.5f;
        float maxX = ObjectPos.X + ObjectScale.X * 0.5f;
        float minY = ObjectPos.Y - ObjectScale.Y * 0.5f;
        float maxY = ObjectPos.Y + ObjectScale.Y * 0.5f;
        Console.WriteLine("MouseX: " + mouseX + " MinX: " + minX + " MaxX: " + maxX);
        
        Console.WriteLine("MouseY: " + mouseY + " MinY: " + minY + " MaxY: " + maxY);
        if (mouseX >= minX && mouseX <= maxX && mouseY >= minY && mouseY <= maxY)
            return true;
        else
            return false;
    }
}
