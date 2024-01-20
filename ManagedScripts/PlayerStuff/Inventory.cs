using ScriptAPI;

public class InventoryScript : Script
{
    public GameObject InventoryObject;
    public View_Object _ViewObjectScript;

    public List<string> noteObjsInInventory;
    public List<string> itemObjsInInventory;
    public List<string> paintingObjsInInventory;

    public GameObject noteBttnGrp;
    public GameObject itemBttnGrp;
    public GameObject paintingBttnGrp;

    public List<string> noteObjImg;
    public List<string> itemObjImg;
    public List<string> paintingsObjImg;

    public string storedObjName;

    //item images
    //public GameObject Item1;  
    //public GameObject Item2;
    //public GameObject Item3;
    //public GameObject Item4;
    //public GameObject Item5;
    //public GameObject Item6;   
    //public GameObject Item7;
    //public GameObject Item8;
    //public GameObject Item9;
    //public GameObject Item10;
    //public GameObject Item11;
    //public GameObject Item12;

    //boxes
    public GameObject Box1;  
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Box4;
    public GameObject Box5;
    public GameObject Box6;   
    public GameObject Box7;
    public GameObject Box8;
    public GameObject Box9;
    public GameObject Box10;
    public GameObject Box11;
    public GameObject Box12;

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

    public bool InventoryIsOpen { get; set;} = false;
    public bool isInit { get; set; } = false;
    public override void Awake()
    {
    }

    public override void Update()
    {
        var entityID = gameObject.GetEntityID();

        // Doing this because Awake doesn't get called for some reason.
        if(!isInit)
        {
            Console.WriteLine("Initialising");
            isInit = true;
            initObjects();
        }

        if(Input.GetKeyDown(Keycode.I))
        {
            InventoryIsOpen = !InventoryIsOpen;
            toggleInventory();
            populateBoxes(itemObjsInInventory);
            Input.KeyRelease(Keycode.I);
        }

        if (InventoryIsOpen) // Inventory opened
        {
            //Console.WriteLine("Open\n");
            Cursor.visible = true;
            Cursor.LockState = CursorLockMode.None;
            checkMouseInput();
        }
        else    // Inventory closed
        {
            //Console.WriteLine("Closed\n");
            Cursor.visible = false;
            Cursor.LockState = CursorLockMode.Locked;
        }


        // if (storedObjName != "")
        // {
        //     if (gameObject.GetComponent<NameTagComponent>().GetTag() == "Note" && NotesTab.activeInHierarchy(NotesTab.GetEntityID()))
        //     {
        //         if (storedObjName != gameObject.GetComponent<UISpriteComponent>().GetTextureName())
        //         {
        //             for (int i = 0; i < noteObjImg.Count; i++)
        //             {
        //                 if (noteObjImg[i] == storedObjName)
        //                 {
        //                     gameObject.GetComponent<UISpriteComponent>().SetTextureName(noteObjImg[i]);
        //                     gameObject.SetActive(gameObject.GetEntityID(), true);
        //                 }
        //             }
        //         }
        //     }

        //     else if (gameObject.GetComponent<NameTagComponent>().GetTag() == "Item" && ItemTab.activeInHierarchy(ItemTab.GetEntityID()))
        //     {
        //         if (storedObjName != gameObject.GetComponent<UISpriteComponent>().GetTextureName())
        //         {
        //             for (int i = 0; i < itemObjImg.Count; i++)
        //             {
        //                 if (itemObjImg[i] == storedObjName)
        //                 {
        //                     gameObject.GetComponent<UISpriteComponent>().SetTextureName(itemObjImg[i]);
        //                     gameObject.SetActive(gameObject.GetEntityID(), true);
        //                 }
        //             }
        //         }
        //     }

        //     else if (gameObject.GetComponent<NameTagComponent>().GetTag() == "Painting" && PaintingsTab.activeInHierarchy(PaintingsTab.GetEntityID()))
        //     {
        //         if (storedObjName != gameObject.GetComponent<UISpriteComponent>().GetTextureName())
        //         {
        //             for (int i = 0; i < paintingsObjImg.Count; i++)
        //             {
        //                 if (paintingsObjImg[i] == storedObjName)
        //                 {
        //                     gameObject.GetComponent<UISpriteComponent>().SetTextureName(paintingsObjImg[i]);
        //                     gameObject.SetActive(gameObject.GetEntityID(), true);
        //                 }
        //             }
        //         }
        //     }
        // }
    }

    public void toggleInventory()
    {
        Console.WriteLine("Toggle Inventory\n");

        InventoryObject.SetActive(InventoryObject.GetEntityID(), InventoryIsOpen);
        
    }

    public void populateBoxes(List<string> ItemList)
    {
        Console.WriteLine("Populating Boxes\n");
        List<GameObject> BoxList = new List<GameObject>
        {
            Box1,
            Box2,
            Box3,
            Box4,
            Box5,
            Box6,
            Box7,
            Box8,
            Box9,
            Box10,
            Box11,
            Box12
        };
        
        for(int i = 0; i < 12; ++i)
        {
            Console.WriteLine(ItemList[i]);
        }

        for(int i = 0; i < 12; ++i)
        {
            Console.WriteLine("Populating box: " + i);
            BoxList[i].GetComponent<UISpriteComponent>().SetTextureName(ItemList[i]);
        }
    }

    public void checkMouseInput()
    {
        //Console.WriteLine("Checking Mouse Input\n");
        //if (Input.GetMouseButtonDown(Keycode.M1))
        //{
            //if(withinButton(ItemsTab)) 
            if(Input.GetKeyDown(Keycode.J)) // Temporary as Mouse Collision not working with UI buttons
            {
                Console.WriteLine("Collide Items\n");
                populateBoxes(itemObjsInInventory);
            }
            //if(withinButton(NotesTab)) 
            if(Input.GetKeyDown(Keycode.K)) // Temporary as Mouse Collision not working with UI buttons
            {
                Console.WriteLine("Collide Notes\n");
                populateBoxes(noteObjsInInventory);
            }
            //if(withinButton(PaintingsTab)) 
            if(Input.GetKeyDown(Keycode.L)) // Temporary as Mouse Collision not working with UI buttons
            { 
                Console.WriteLine("Collide Paintings\n");
                populateBoxes(paintingObjsInInventory);
            }
        //}
    }
    public void initObjects()
    {
        Console.WriteLine("Init objects\n");
        InventoryObject = GameObjectScriptFind("InventoryObject");

        Box1            = GameObjectScriptFind("Box1");
        Box2            = GameObjectScriptFind("Box2");
        Box3            = GameObjectScriptFind("Box3");
        Box4            = GameObjectScriptFind("Box4");
        Box5            = GameObjectScriptFind("Box5");
        Box6            = GameObjectScriptFind("Box6");
        Box7            = GameObjectScriptFind("Box7");
        Box8            = GameObjectScriptFind("Box8");
        Box9            = GameObjectScriptFind("Box9");
        Box10           = GameObjectScriptFind("Box10");
        Box11           = GameObjectScriptFind("Box11");
        Box12           = GameObjectScriptFind("Box12");

        ItemsTab        = GameObjectScriptFind("ItemsTab");
        NotesTab        = GameObjectScriptFind("NotesTab");
        PaintingsTab    = GameObjectScriptFind("PaintingsTab");

        itemObjsInInventory = new List<string>
        {
            "Notes2.dds",
            "Notes4.dds",
            "Notes6.dds",
            "Notes8.dds",
            "Notes10.dds",
            "Notes12.dds",
            "Notes1.dds",
            "Notes3.dds",
            "Notes5.dds",
            "Notes7.dds",
            "Notes9.dds",
            "Notes11.dds"
        };

        noteObjsInInventory = new List<string>
        {
            "Notes1.dds",
            "Notes2.dds",
            "Notes3.dds",
            "Notes4.dds",
            "Notes5.dds",
            "Notes6.dds",
            "Notes7.dds",
            "Notes8.dds",
            "Notes9.dds",
            "Notes10.dds",
            "Notes11.dds",
            "Notes12.dds"
        };

        paintingObjsInInventory = new List<string>
        {
            "Notes1.dds",
            "Notes3.dds",
            "Notes5.dds",
            "Notes7.dds",
            "Notes9.dds",
            "Notes11.dds",
            "Notes2.dds",
            "Notes4.dds",
            "Notes6.dds",
            "Notes8.dds",
            "Notes10.dds",
            "Notes12.dds"
        };

        // ItemText        = GameObjectScriptFind("Item Text");
        // NotesText       = GameObjectScriptFind("Notes Text");
        // PaintingsText   = GameObjectScriptFind("Paintings Text");
        // MouseClick      = GameObjectScriptFind("MouseClick");
        // UseText         = GameObjectScriptFind("Use Text");
        // Ikey            = GameObjectScriptFind("I Key");
        // CloseText       = GameObjectScriptFind("Close Text");
    }
    // ************************************ Not used ********************************//
    public void ExamineObj()
    {
        _ViewObjectScript.OnDisable();
        _ViewObjectScript.isExaming = true;
        InventoryObject.SetActive(InventoryObject.GetEntityID(), false);
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
    
    // ************************************ Not working ********************************//
    bool withinArea(float mouse, float min, float max) // Not working
    {
        bool within = false;
        if (mouse > min && mouse < max)
            within = true;
        return within;
    }

    bool withinButton(GameObject obj) // Not working
    {
        // Vector3 ObjectPos = obj.GetComponent<TransformComponent>().GetPosition();//objectpos in ndc
        // Vector3 ObjectScale = obj.GetComponent<TransformComponent>().GetScale();//obj scale in ndc
        // float mouseX = Input.GetLocalMousePosX();
        // float mouseY = Input.GetLocalMousePoxY();
        // float minX = ObjectPos.X - ObjectScale.X / 2;
        // float maxX = ObjectPos.X + ObjectScale.X / 2;
        // float maxy = -ObjectPos.Y + ObjectScale.Y / 2;
        // float miny = -ObjectPos.Y - ObjectScale.Y / 2;
        // Console.WriteLine("MouseX: " + mouseX + " MinX: " + minX + " MaxX: " + maxX + "\n");
        // Console.WriteLine("MouseY: " + mouseY + " MinY: " + miny + " MaxY: " + maxy + "\n");
        // if (withinArea(mouseX, minX, maxX) && withinArea(mouseY, miny, maxy))
        //     return true;
        // else
        //     return false;

        return obj.GetComponent<UISpriteComponent>().IsMouseCollided();
    }

    // ************************************ Not needed ********************************//

    // void ShowPaintingInInventory()
    // {
    //     for (int x = 0; x < paintingObjsInInventory.Count; x++)
    //     {
    //         if (paintingObjsInInventory[x] != "")
    //         {
    //             //if (paintingButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName == "")
    //             //{
    //             //    paintingButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName = paintingObjsInInventory[x];
    //             //}
    //         }
    //     }
    // }
    // void ShowNoteInInventory()
    // {
    //     for (int x = 0; x < noteObjsInInventory.Count; x++)
    //     {
    //         if (noteObjsInInventory[x] != "")
    //         {
    //             //if (noteButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName == "")
    //             //{
    //             //    noteButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName = noteObjsInInventory[x];
    //             //}
    //         }
    //     }
    // }

    // void ShowItemIninventory()
    // {
    //     for (int x = 0; x < itemObjsInInventory.Count; x++)
    //     {
    //         if (itemObjsInInventory[x] != "")
    //         {
    //             //if (itemButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName == "")
    //             //{
    //             //    itemButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName = itemObjsInInventory[x];
    //             //}
    //         }
    //     }
    // }

    // public void ClickItemBttn()
    // {
    //     paintingBttnGrp.SetActive(paintingBttnGrp.GetEntityID(), false);
    //     itemBttnGrp.SetActive(itemBttnGrp.GetEntityID(), true);
    //     noteBttnGrp.SetActive(noteBttnGrp.GetEntityID(), false);

    //     ShowItemIninventory();
    // }

    // public void ClickPaintingBttn()
    // {
    //     paintingBttnGrp.SetActive(paintingBttnGrp.GetEntityID(), true);
    //     itemBttnGrp.SetActive(itemBttnGrp.GetEntityID(), false);
    //     noteBttnGrp.SetActive(noteBttnGrp.GetEntityID(), false);

    //     ShowPaintingInInventory();

    // }

    // public void ClickNoteBttn()
    // {
    //     paintingBttnGrp.SetActive(paintingBttnGrp.GetEntityID(), false);
    //     itemBttnGrp.SetActive(itemBttnGrp.GetEntityID(), false);
    //     noteBttnGrp.SetActive(noteBttnGrp.GetEntityID(), true);

    //     ShowNoteInInventory();

    // }


    // public bool isInventoryOpen()
    // {
    //     return InventoryIsOpen;
    // }


}
