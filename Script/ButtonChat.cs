using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SettingsDB;

public class ButtonChat : MonoBehaviour
{
    [SerializeField] Text buttonText;

    private string userID;
    private string groupName;

    private DB db;

    void Awake()
    {
        db = GetComponent<DB>();
    }

    void Start()
    {
        userID = PlayerPrefs.GetString("userID", userID);
        StartCoroutine(db.LoadDataUser(userID));
        buttonText.text = groupName;
    }

}
