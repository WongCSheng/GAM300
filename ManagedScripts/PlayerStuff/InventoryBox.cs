using ScriptAPI;
using System;
using static System.Net.Mime.MediaTypeNames;

public class InventoryBox : Script
{
    [SerializeField]
    public int BoxNumber;
    public string storedObjName;

    //public Sprite emptyBox;

    public override void Awake()
    {
        //GetComponent<Button>().onClick.AddListener(AssignViewObjectString);
    }

    public override void Start()
    {
    }

    public override void Update()
    {
        DisplayItem();
        // if (storedObjName != "")
        // {
        //     if (gameObject.GetComponent<NameTagComponent>().GetTag() == "Note" && notesGrp.activeInHierarchy(notesGrp.GetEntityID()))
        //     {
        //         if (storedObjName != gameObject.GetComponent<UISpriteComponent>().GetTextureName())
        //         {
        //             for (int i = 0; i < myInventoryScript.noteObjImg.Count; i++)
        //             {
        //                 if (myInventoryScript.noteObjImg[i] == storedObjName)
        //                 {
        //                     gameObject.GetComponent<UISpriteComponent>().SetTextureName(myInventoryScript.noteObjImg[i]);
        //                     gameObject.SetActive(gameObject.GetEntityID(), true);
        //                 }
        //             }
        //         }
        //     }

        //     else if (gameObject.GetComponent<NameTagComponent>().GetTag() == "Item" && itemsGrp.activeInHierarchy(itemsGrp.GetEntityID()))
        //     {
        //         if (storedObjName != gameObject.GetComponent<UISpriteComponent>().GetTextureName())
        //         {
        //             for (int i = 0; i < myInventoryScript.itemObjImg.Count; i++)
        //             {
        //                 if (myInventoryScript.itemObjImg[i] == storedObjName)
        //                 {
        //                     gameObject.GetComponent<UISpriteComponent>().SetTextureName(myInventoryScript.itemObjImg[i]);
        //                     gameObject.SetActive(gameObject.GetEntityID(), true);
        //                 }
        //             }
        //         }
        //     }

        //     else if (gameObject.GetComponent<NameTagComponent>().GetTag() == "Painting" && paintingsGrp.activeInHierarchy(paintingsGrp.GetEntityID()))
        //     {
        //         if (storedObjName != gameObject.GetComponent<UISpriteComponent>().GetTextureName())
        //         {
        //             for (int i = 0; i < myInventoryScript.paintingsObjImg.Count; i++)
        //             {
        //                 if (myInventoryScript.paintingsObjImg[i] == storedObjName)
        //                 {
        //                     gameObject.GetComponent<UISpriteComponent>().SetTextureName(myInventoryScript.paintingsObjImg[i]);
        //                     gameObject.SetActive(gameObject.GetEntityID(), true);
        //                 }
        //             }
        //         }
        //     }
        // }

        // else if (storedObjName == "")
        // {
        //     gameObject.GetComponent<Button>().interactable = false;
        // }
    }

    public void DisplayItem()
    {
        if(InventoryScript.currentTab == "Items")
        {
            gameObject.GetComponent<UISpriteComponent>().SetTextureName(InventoryScript.itemObjsInInventory[BoxNumber]);
        }
        else if (InventoryScript.currentTab == "Paintings")
        {
            gameObject.GetComponent<UISpriteComponent>().SetTextureName(InventoryScript.paintingObjsInInventory[BoxNumber]);
        }
        else if (InventoryScript.currentTab == "Notes")
        {
            gameObject.GetComponent<UISpriteComponent>().SetTextureName(InventoryScript.noteObjsInInventory[BoxNumber]);
        }
    }

    public void AssignViewObjectString()
    {
        //myViewObjScript.examineObject = storedObjName;
    }

    //public void UseObject()
    //{
    //    if (storedObjName == "Starting Battery" || storedObjName == "Toilet_Battery")
    //    {
    //        for (int i = 0; i < myInventoryScript.itemObjsInInventory.Count; i++)
    //        {
    //            if (myInventoryScript.itemObjsInInventory[i] == storedObjName)
    //            {
    //                myInventoryScript.itemObjsInInventory[i] = "";
    //                storedObjName = "";
                        

    //            }
    //        }
    //    }
    //}
}