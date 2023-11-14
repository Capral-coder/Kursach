using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SettingsDB;

public class SearchButton : MonoBehaviour
{
    [SerializeField] InputField friendName;
    [SerializeField] int counter = 1;
    [SerializeField] Text AddFriendText;
    [SerializeField] Button AddFriendButton;
    [SerializeField] GameObject AddFriendForm;
    [SerializeField] GameObject MessageForm;

    private DB db;
    private string friendNameStr;
    private string groupID;
    private string userID;
    private string error;

    void Start()
    {
        db = GetComponent<DB>();
        AddFriendButton.onClick.AddListener(ButtonAddFriend);

    }
    
    public void Exit()
    {
        MessageForm.SetActive(false);
    }
    
    public void Proverka()
    {
        LoadData();
        if(friendName.text != userID)
        {
            if(friendName.text == db.userName)
            {
                Debug.Log("Yest user");
                AddFriendForm.SetActive(true);
                AddFriendText.text = db.userName+" "+db.groupName;

                db.userName = friendNameStr;
            }    
        }
        else
        {
            Debug.Log("Vashe imya");
        }     
        
    }

    public void SearchButtons()
    {
        counter = PlayerPrefs.GetInt("counter", counter);
        StartCoroutine(db.LoadDataUser(friendName.text));
        Invoke("Proverka", 0.5f);
    }

    void LoadData()
    {
        userID = PlayerPrefs.GetString("userID", userID);
    }

    public void ButtonAddFriend()
    {
        db.SaveFriends(userID, friendNameStr);
        AddFriendForm.SetActive(false);
    }
}


//if (Application.platform == RuntimePlatform.Android)
//  {
//    if (Input.GetKeyDown(KeyCode.Escape)) 
//    {
//      Application.Quit(); 
//    }
//  }