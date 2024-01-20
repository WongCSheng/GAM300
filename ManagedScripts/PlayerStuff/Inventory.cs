using ScriptAPI;

public class InventoryScript : Script
{
    public GameObject _InventoryObj;
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
    public GameObject Item1;
        
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

    public GameObject ItemTab;
    public GameObject NotesTab;
    public GameObject PaintingsTab;

    public GameObject ItemText;
    public GameObject NotesText;
    public GameObject PaintingsText;
    public GameObject MouseClick;
    public GameObject UseText;
    public GameObject Ikey;
    public GameObject CloseText;

    //public bool InventoryIsOpen { get; set;} = false;
    public bool InventoryIsOpen = false;

    public override void Awake()
    {
        initObjects();
    }

    public override void Update()
    {
        var entityID = gameObject.GetEntityID();

        if(Input.GetKeyDown(Keycode.I))
        {
            InventoryIsOpen = !InventoryIsOpen;
            toggleInventory();
            //GameObjectScriptFind("InventoryObject").GetComponent<UISpriteComponent>().SetEnableSprite(InventoryIsOpen);
            //gameObject.GetComponent<UISpriteComponent>().SetEnableSprite(InventoryIsOpen);
            Input.KeyRelease(Keycode.I);
        }

        if (InventoryIsOpen) // Inventory opened
        {
            Console.WriteLine("Open\n");
            Cursor.visible = true;
            Cursor.LockState = CursorLockMode.None;
        }
        else    // Inventory closed
        {
            Console.WriteLine("Closed\n");
            Cursor.visible = false;
            Cursor.LockState = CursorLockMode.Locked;
        }


        // if (Input.GetMouseButtonDown(Keycode.M1))
        // {
        //     if(withinButton(ItemTab))
        //     {

        //     }

        //     if(withinButton(NotesTab))
        //     {

        //     }

        //     if(withinButton(PaintingsTab)) 
        //     { 

        //     }
        // }

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
    public void ExamineObj()
    {
        _ViewObjectScript.OnDisable();
        _ViewObjectScript.isExaming = true;
        _InventoryObj.SetActive(_InventoryObj.GetEntityID(), false);
    }

    void ShowPaintingInInventory()
    {
        for (int x = 0; x < paintingObjsInInventory.Count; x++)
        {
            if (paintingObjsInInventory[x] != "")
            {
                //if (paintingButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName == "")
                //{
                //    paintingButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName = paintingObjsInInventory[x];
                //}
            }
        }
    }
    void ShowNoteInInventory()
    {
        for (int x = 0; x < noteObjsInInventory.Count; x++)
        {
            if (noteObjsInInventory[x] != "")
            {
                //if (noteButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName == "")
                //{
                //    noteButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName = noteObjsInInventory[x];
                //}
            }
        }
    }

    void ShowItemIninventory()
    {
        for (int x = 0; x < itemObjsInInventory.Count; x++)
        {
            if (itemObjsInInventory[x] != "")
            {
                //if (itemButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName == "")
                //{
                //    itemButtons[x].gameObject.GetComponent<InventoryBox>().storedObjName = itemObjsInInventory[x];
                //}
            }
        }
    }

    public void ClickItemBttn()
    {
        paintingBttnGrp.SetActive(paintingBttnGrp.GetEntityID(), false);
        itemBttnGrp.SetActive(itemBttnGrp.GetEntityID(), true);
        noteBttnGrp.SetActive(noteBttnGrp.GetEntityID(), false);

        ShowItemIninventory();
    }

    public void ClickPaintingBttn()
    {
        paintingBttnGrp.SetActive(paintingBttnGrp.GetEntityID(), true);
        itemBttnGrp.SetActive(itemBttnGrp.GetEntityID(), false);
        noteBttnGrp.SetActive(noteBttnGrp.GetEntityID(), false);

        ShowPaintingInInventory();

    }

    public void ClickNoteBttn()
    {
        paintingBttnGrp.SetActive(paintingBttnGrp.GetEntityID(), false);
        itemBttnGrp.SetActive(itemBttnGrp.GetEntityID(), false);
        noteBttnGrp.SetActive(noteBttnGrp.GetEntityID(), true);

        ShowNoteInInventory();

    }


    public bool isInventoryOpen()
    {
        return InventoryIsOpen;
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


    bool withinArea(float mouse, float min, float max)
    {
        bool within = false;
        if (mouse > min && mouse < max)
            within = true;
        return within;
    }

    bool withinButton(GameObject obj)
    {
        Vector3 ObjectPos = obj.GetComponent<TransformComponent>().GetPosition();//objectpos in ndc
        Vector3 ObjectScale = obj.GetComponent<TransformComponent>().GetScale();//obj scale in ndc
        float mouseX = Input.GetLocalMousePosX();
        float mouseY = Input.GetLocalMousePoxY();
        float minX = ObjectPos.X - ObjectScale.X / 2;
        float maxX = ObjectPos.X + ObjectScale.X / 2;
        float maxy = -ObjectPos.Y + ObjectScale.Y / 2;
        float miny = -ObjectPos.Y - ObjectScale.Y / 2;
        if (withinArea(mouseX, minX, maxX) && withinArea(mouseY, miny, maxy))
            return true;
        else
            return false;
    }
    public void toggleInventory()
    {
        GameObject InventoryObject = GameObjectScriptFind("InventoryObject");
        InventoryObject.SetActive(InventoryObject.GetEntityID(), InventoryIsOpen);
        //Item1.SetActive(Item1.GetEntityID(), !_InventoryObj.activeInHierarchy(Item1.GetEntityID()));
            
        //Item2.SetActive(Item2.GetEntityID(), !_InventoryObj.activeInHierarchy(Item2.GetEntityID()));
        //Item3.SetActive(Item3.GetEntityID(), !_InventoryObj.activeInHierarchy(Item3.GetEntityID()));
        //Item4.SetActive(Item4.GetEntityID(), !_InventoryObj.activeInHierarchy(Item4.GetEntityID()));
        //Item5.SetActive(Item5.GetEntityID(), !_InventoryObj.activeInHierarchy(Item5.GetEntityID()));
        //Item6.SetActive(Item6.GetEntityID(), !_InventoryObj.activeInHierarchy(Item6.GetEntityID()));
        //Item7.SetActive(Item7.GetEntityID(), !_InventoryObj.activeInHierarchy(Item7.GetEntityID()));
        //Item8.SetActive(Item8.GetEntityID(), !_InventoryObj.activeInHierarchy(Item8.GetEntityID()));
        //Item9.SetActive(Item9.GetEntityID(), !_InventoryObj.activeInHierarchy(Item9.GetEntityID()));
        //Item10.SetActive(Item10.GetEntityID(), !_InventoryObj.activeInHierarchy(Item10.GetEntityID()));
        //Item11.SetActive(Item11.GetEntityID(), !_InventoryObj.activeInHierarchy(Item11.GetEntityID()));
        //Item12.SetActive(Item12.GetEntityID(), !_InventoryObj.activeInHierarchy(Item12.GetEntityID()));

        // Box1.SetActive(Box1.GetEntityID(), !_InventoryObj.activeInHierarchy(Box1.GetEntityID()));
        // Box2.SetActive(Box2.GetEntityID(), !_InventoryObj.activeInHierarchy(Box2.GetEntityID()));
        // Box3.SetActive(Box3.GetEntityID(), !_InventoryObj.activeInHierarchy(Box3.GetEntityID()));
        // Box4.SetActive(Box4.GetEntityID(), !_InventoryObj.activeInHierarchy(Box4.GetEntityID()));
        // Box5.SetActive(Box5.GetEntityID(), !_InventoryObj.activeInHierarchy(Box5.GetEntityID()));
        // Box6.SetActive(Box6.GetEntityID(), !_InventoryObj.activeInHierarchy(Box6.GetEntityID()));
        // Box7.SetActive(Box7.GetEntityID(), !_InventoryObj.activeInHierarchy(Box7.GetEntityID()));
        // Box8.SetActive(Box8.GetEntityID(), !_InventoryObj.activeInHierarchy(Box8.GetEntityID()));
        // Box9.SetActive(Box9.GetEntityID(), !_InventoryObj.activeInHierarchy(Box9.GetEntityID()));
        // Box10.SetActive(Box10.GetEntityID(), !_InventoryObj.activeInHierarchy(Box10.GetEntityID()));
        // Box11.SetActive(Box11.GetEntityID(), !_InventoryObj.activeInHierarchy(Box11.GetEntityID()));
        // Box12.SetActive(Box12.GetEntityID(), !_InventoryObj.activeInHierarchy(Box12.GetEntityID()));

        // ItemTab.SetActive(ItemTab.GetEntityID(), !_InventoryObj.activeInHierarchy(ItemTab.GetEntityID()));
        // NotesTab.SetActive(NotesTab.GetEntityID(), !_InventoryObj.activeInHierarchy(NotesTab.GetEntityID()));
        // PaintingsTab.SetActive(PaintingsTab.GetEntityID(), !_InventoryObj.activeInHierarchy(PaintingsTab.GetEntityID()));

        // ItemText.SetActive(ItemText.GetEntityID(), !_InventoryObj.activeInHierarchy(ItemText.GetEntityID()));
        // NotesText.SetActive(NotesText.GetEntityID(), !_InventoryObj.activeInHierarchy(NotesText.GetEntityID()));
        // PaintingsText.SetActive(PaintingsText.GetEntityID(), !_InventoryObj.activeInHierarchy(PaintingsText.GetEntityID()));
        // MouseClick.SetActive(MouseClick.GetEntityID(), !_InventoryObj.activeInHierarchy(MouseClick.GetEntityID()));
        // UseText.SetActive(UseText.GetEntityID(), !_InventoryObj.activeInHierarchy(UseText.GetEntityID()));
        // Ikey.SetActive(Ikey.GetEntityID(), !_InventoryObj.activeInHierarchy(Ikey.GetEntityID()));
        // CloseText.SetActive(CloseText.GetEntityID(), !_InventoryObj.activeInHierarchy(CloseText.GetEntityID()));
    }
    public void initObjects()
    {
        //_InventoryObj = GameObjectScriptFind("InventoryObject");
            
        //Item1 = GameObjectScriptFind("Item1");
        //Item1.GetComponent<NameTagComponent>().SetTag("Item");
        //Item2 = GameObjectScriptFind("Item2");
        //Item3 = GameObjectScriptFind("Item3");
        //Item4 = GameObjectScriptFind("Item4");
        //Item5 = GameObjectScriptFind("Item5");
        //Item6 = GameObjectScriptFind("Item6");
        //Item7 = GameObjectScriptFind("Item7");
        //Item8 = GameObjectScriptFind("Item8");
        //Item9 = GameObjectScriptFind("Item9");
        //Item10 = GameObjectScriptFind("Item10");
        //Item11 = GameObjectScriptFind("Item11");
        //Item12 = GameObjectScriptFind("Item12");

        // Box1            = GameObjectScriptFind("Box1");
        // Box2            = GameObjectScriptFind("Box2");
        // Box3            = GameObjectScriptFind("Box3");
        // Box4            = GameObjectScriptFind("Box4");
        // Box5            = GameObjectScriptFind("Box5");
        // Box6            = GameObjectScriptFind("Box6");
        // Box7            = GameObjectScriptFind("Box7");
        // Box8            = GameObjectScriptFind("Box8");
        // Box9            = GameObjectScriptFind("Box9");
        // Box10           = GameObjectScriptFind("Box10");
        // Box11           = GameObjectScriptFind("Box11");
        // Box12           = GameObjectScriptFind("Box12");

        // ItemTab         = GameObjectScriptFind("ItemTab");
        // NotesTab        = GameObjectScriptFind("NotesTab");
        // PaintingsTab    = GameObjectScriptFind("PaintingsTab");

        // ItemText        = GameObjectScriptFind("Item Text");
        // NotesText       = GameObjectScriptFind("Notes Text");
        // PaintingsText   = GameObjectScriptFind("Paintings Text");
        // MouseClick      = GameObjectScriptFind("MouseClick");
        // UseText         = GameObjectScriptFind("Use Text");
        // Ikey            = GameObjectScriptFind("I Key");
        // CloseText       = GameObjectScriptFind("Close Text");
    }
}
