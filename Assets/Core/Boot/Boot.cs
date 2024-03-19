using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class Boot : MonoBehaviour
{
    [Header("Media")]
    [SerializeField] private VideoPlayer videoBootClass;
    [SerializeField] private VideoClip whiteBoot;
    [SerializeField] private VideoClip blackBoot;
    [SerializeField] private VideoClip fullBoot;
    [SerializeField] private GameObject VideoScreen;

    //Set a timer to wait boot video complete playing and call LoadGame function from GameLoader class.
    IEnumerator DelayAndLoadGame(float waitTime, bool CDIsTrue)
    {
        yield return new WaitForSeconds(waitTime);
        VideoScreen.SetActive(false);
        ControllerManager controllerManagerClass = new ControllerManager();
        controllerManagerClass.CheckIfPSController();

        if ( CDIsTrue ) 
        {
            GameLoader gameLoaderClass = new GameLoader();
            gameLoaderClass.LoadGame("E:\\");
        }

        else
        {
            GameLoader gameLoaderClass = new GameLoader();
            gameLoaderClass.LoadGame("");
        }
        
    }

    //Call black boot after game has selected from Game Menu.
    public void CallBlackBoot()
    {
        SetVideoBoot(blackBoot);
        StartCoroutine(DelayAndLoadGame(8, false));
        GameLoader gameLoaderClass = new GameLoader();
        gameLoaderClass.LoadGame("");
    }

    // Start is called before the first frame update.
    void Start()
    {
        (string cdGameID, bool CDFound) = GameLoader.GetCDGameID();

        //Start CD game or load main menu.
        if (CDFound)
        {
            Debug.Log("CD Game ID: " + cdGameID);

            // Start Fullboot video and load CD game directly.
            SetVideoBoot(fullBoot);
            StartCoroutine(DelayAndLoadGame(15.6f, true));
        }
        else
        {
            Debug.Log("Falha ao obter o CD Game ID, carregando menu.");

            // Start whiteboot video and load main menu if there's no CD in drive.
            SetVideoBoot(whiteBoot);
            StartCoroutine(DelayAndLoadGame(7, false));
        }
    }

    //Set boot video by NewClip variable
    void SetVideoBoot(VideoClip NewClip)
    {
        videoBootClass.Pause();
        videoBootClass.clip = NewClip;
        videoBootClass.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
