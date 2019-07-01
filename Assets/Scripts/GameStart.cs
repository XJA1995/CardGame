using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    private GameObject RoleIntroduceText;

    private Button Hero1;
    private Button Hero2;
    private Button Hero3;

    private Button Hero1CardLibrary;
    private Button Hero2CardLibrary;
    private Button Hero3CardLibrary;

    private Button Hero1Introduce;
    private Button Hero2Introduce;
    private Button Hero3Introduce;

    private Button Hero1Return;

    public Date date = new Date(null);

    private void Awake()
    {
        RoleIntroduceText = GameObject.Find("RoleIntroduceText");

        Hero1 = GameObject.Find("Hero1").GetComponent<Button>();
        Hero2 = GameObject.Find("Hero2").GetComponent<Button>();
        Hero3 = GameObject.Find("Hero3").GetComponent<Button>();

        Hero1CardLibrary = GameObject.Find("Hero1CardLibrary").GetComponent<Button>();
        Hero2CardLibrary = GameObject.Find("Hero2CardLibrary").GetComponent<Button>();
        Hero3CardLibrary = GameObject.Find("Hero3CardLibrary").GetComponent<Button>();

        Hero1Introduce = GameObject.Find("Hero1Introduce").GetComponent<Button>();
        Hero2Introduce = GameObject.Find("Hero2Introduce").GetComponent<Button>();
        Hero3Introduce = GameObject.Find("Hero3Introduce").GetComponent<Button>();

        Hero1Return = GameObject.Find("Hero1Return").GetComponent<Button>();

        RoleIntroduceText.gameObject.SetActive(false);
    }


    public void OnClickReturn()
    {
        RoleIntroduceText.gameObject.SetActive(false);
        //date.HeroChoose = "Hero1";
    }

    public void OnClickHeroIntroduce()
    {
        RoleIntroduceText.gameObject.SetActive(true);
    }

    public void OnClickHero1CardLibrary()
    {
        SceneManager.LoadScene("CardManage");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
