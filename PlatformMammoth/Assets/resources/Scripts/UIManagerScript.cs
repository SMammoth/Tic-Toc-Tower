using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UIManagerScript : MonoBehaviour 
{
	public GameObject defaultButton;
	public GameObject defaultQuitButton;

	GameObject UI_ConfirmQuit;
	GameObject UI_Toggle_Multiplayer;

	public static bool Mode_Multiplayer;
	
	public string[] Characters;
	int Player1 = 1;
	int Player2 = 0;
	int Player3 = 0;
	int Player4 = 0;

	Vector2 CurrentPlayer1Pos;
	Vector2 CurrentPos;

	void Awake ()
	{

	}

	void Start () 
    {
		Time.timeScale = 1;
		Time.fixedDeltaTime = .02f;

		UI_ConfirmQuit = GameObject.FindWithTag ("UI_ConfirmQuit");
		UI_ConfirmQuit.SetActive (false);

		//UI_Toggle_Multiplayer = GameObject.FindWithTag ("UI_Toggle_Multiplayer");

		GUIGameScript.Char_Player1 = Characters [Player1];
		GUIGameScript.Char_Player2 = null;
		GUIGameScript.Char_Player3 = null;
		GUIGameScript.Char_Player4 = null;


		GameObject.Find("Player1").GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Characters/Character_" + Characters[Player1]);

		EventSystem.current.SetSelectedGameObject(defaultButton);
	}
	
	void Update () 
    {
		GameObject.FindWithTag ("UI_Text_PersonalHighscore").GetComponent<Text>().text = "HIGHSCORE: " + PlayerPrefs.GetInt("Highscore");


		if(Input.GetKeyDown(KeyCode.Q))
		{
			PlayerPrefs.DeleteAll();
		}

		CurrentPos = GameObject.Find ("Player2").transform.position;
		CurrentPlayer1Pos = GameObject.Find ("Player1").transform.position;
	}
	
	public void Multiplayer()
	{
		if(UI_Toggle_Multiplayer.GetComponent<Toggle>().isOn)
		{
			Mode_Multiplayer = true;
			UI_Toggle_Multiplayer.GetComponentInChildren<Text>().text = "MULTI PLAYER";
		}
		else
		{
			Mode_Multiplayer = false;
			UI_Toggle_Multiplayer.GetComponentInChildren<Text>().text = "SINGLE PLAYER";
		}
	}

	public void StartGame()
    {
		GUIGameScript.Timer = 10;

		Application.LoadLevel("GameScene");
    }

	public void QuitGame()
	{
		UI_ConfirmQuit.SetActive (true);
		EventSystem.current.SetSelectedGameObject(defaultQuitButton);

		GameObject.Find ("UI_Button_Play").GetComponent<Button> ().interactable = false;
		GameObject.Find ("UI_Button_Quit").GetComponent<Button> ().interactable = false;
		GameObject.Find ("UI_Button_Highscore").GetComponent<Button> ().interactable = false;
	}

	public void ConfirmOrCancel(string ConfirmOrQuit)
	{
		if(ConfirmOrQuit == "Confirm")
		{
			Application.Quit();
		}
		else if(ConfirmOrQuit == "Cancel")
		{
			GameObject.Find ("UI_Button_Play").GetComponent<Button> ().interactable = true;
			GameObject.Find ("UI_Button_Quit").GetComponent<Button> ().interactable = true;
			GameObject.Find ("UI_Button_Highscore").GetComponent<Button> ().interactable = true;

			UI_ConfirmQuit.SetActive (false);
			EventSystem.current.SetSelectedGameObject(defaultButton);
		}
	}

	public void CharacterSelect(int PlayerNR)
	{
		if(PlayerNR == 1)
		{
			Player1 += 1;
			if(Player1 >= Characters.Length)
			{
				Player1 = 1;
			}

			GUIGameScript.Char_Player1 = Characters [Player1];
			GameObject.Find("Player" + PlayerNR).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Characters/Character_" + Characters[Player1]);
		}
		else if(PlayerNR == 2)
		{
			Player2 += 1;

			if(Player2 >= Characters.Length)
			{
				Player2 = 0;
			}
						
			GUIGameScript.Char_Player2 = Characters [Player2];
			GameObject.Find("Player" + PlayerNR).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Characters/Character_" + Characters[Player2]);
		}
		else if(PlayerNR == 3)
		{
			Player3 += 1;
			if(Player3 >= Characters.Length)
			{
				Player3 = 0;
			}
			
			GUIGameScript.Char_Player3 = Characters [Player3];
			GameObject.Find("Player" + PlayerNR).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Characters/Character_" + Characters[Player3]);
		}
		else if(PlayerNR == 4)
		{
			Player4 += 1;
			if(Player4 >= Characters.Length)
			{
				Player4 = 0;
			}
			
			GUIGameScript.Char_Player4 = Characters [Player4];
			GameObject.Find("Player" + PlayerNR).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Characters/Character_" + Characters[Player4]);
		}
	}
}
