using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Top_bar_name : MonoBehaviour
{
    [SerializeField] Text nametext;

    void Start()
    {
        string userID = PlayerPrefs.GetString("userID");
        nametext.text = userID;
    }

}
