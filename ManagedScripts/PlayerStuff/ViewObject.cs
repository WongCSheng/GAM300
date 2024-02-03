using ScriptAPI;
using System;
using System.Diagnostics;

public class View_Object : Script
{
    GameObject ObjectViewer;
    GameObject ObjectViewerCam;
    GameObject ObjectViewerModel;
    GameObject MainCam;

    public static string ObjectName;
    public static bool OnEnter;
    public static bool isExamining;

    //public GameDataManager myGameDataManager;
    //public Text added;

    TransformComponent target;                     //transform

    
    float root_y;
    float rotateValue;
    bool isZoomed;

    public override void Awake()
    {
    }

    public override void Start()
    {
        Console.WriteLine("Init ObjectViewer\n");
        ObjectViewer        = GameObjectScriptFind("ObjectViewer");
        ObjectViewerCam     = GameObjectScriptFind("ObjectViewerCam");
        ObjectViewerModel   = GameObjectScriptFind("ObjectViewerModel"); // or should I use ObjectName instead?
        MainCam             = GameObjectScriptFind("playerCameraObject");
        ObjectViewer.SetActive(false);
        gameObject.SetActive(false);

        OnEnter = false;
        isExamining = false;
        rotateValue = 0.0f;
        root_y = gameObject.transform.GetPosition().Y;
    }
    public override void Update()
    {
        //var mainCamID = mainCam.GetEntityID();
        //var examineCamID = examineCam.GetEntityID();
        //var examineUIID = examineUI.GetEntityID();
        if (OnEnter)
        {
            // Change Rendering Cam to ObjectViewerCam here
            // Hide and lock cursor??
            isExamining = true;
            isZoomed = false;
            OnEnter = false;
        }
        
        if(isExamining)
        {
            CheckMouseInput();
            CheckKeyboardInput();
            UpdateCamera();
        }
    }

    public void CheckKeyboardInput() // Need to test
    {
        Console.WriteLine("Check Keyboard Input ViewObject");
        // Keyboard Controls
        if (Input.GetKey(Keycode.A))
        {
            Console.WriteLine("A pressed");

            rotateValue += 1;

            if (target.gameObject.GetComponent<NameTagComponent>().GetTag() == "Painting")
            {
                //eulerAngles
                target.SetRotation(new Vector3(0, rotateValue, 0));
            }
            else
            {
                target.SetRotation(new Vector3(90, 180, rotateValue));
            }
        }
        else if (Input.GetKey(Keycode.D))
        {
            Console.WriteLine("D pressed");

            rotateValue -= 1;

            if (target.gameObject.GetComponent<NameTagComponent>().GetTag() == "Painting")
            {
                target.SetRotation(new Vector3(0, rotateValue, 0));
            }
            else
            {
                target.SetRotation(new Vector3(90, 180, rotateValue));
            }
        }

        if (Input.GetKey(Keycode.S))
        {
            Console.WriteLine("S pressed");

            if (target.GetPosition().Y > 0.4)
            {
                root_y -= 0.01f;
                target.SetPositionY(root_y);
            }
        }
        else if (Input.GetKey(Keycode.W))
        {
            Console.WriteLine("D pressed");

            if (target.GetPosition().Y < 3.7)
            {
                root_y += 0.01f;
                target.SetPositionY(root_y);
            }
        }
    }

    public void CheckMouseInput()
    {
        Console.WriteLine("Check Mouse Input ViewObject");
        // Mouse Controls
        if (Input.GetMouseButtonDown(Keycode.M1)) //left click to zoom
        {
            Console.WriteLine("Left click pressed");

            isZoomed = !isZoomed;
        }
        if (Input.GetMouseButtonDown(Keycode.M2)) //right click to exit
        {
            Console.WriteLine("Right click pressed");

            isExamining = false;
            isZoomed = false;
            ObjectViewer.SetActive(false);

            // Switch Rendering Cam to MainCam here

            GameObjectScriptFind("InventoryObject").SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public void UpdateCamera()
    {
        if (isZoomed)
        {
            CameraComponent cam = ObjectViewerCam.GetComponent<CameraComponent>();
            cam.SetFieldOfView(Mathf.Lerp(cam.GetFieldOfView(), 30, 30 * Time.deltaTime));
        }
        else
        {
            CameraComponent cam = ObjectViewerCam.GetComponent<CameraComponent>();
            cam.SetFieldOfView(Mathf.Lerp(cam.GetFieldOfView(), 60, 5f * Time.deltaTime));
        }
    }
}