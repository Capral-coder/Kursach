using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrienMenager : MonoBehaviour
{
    [SerializeField] GameObject Form_friend_1;
    [SerializeField] GameObject Form_friend_2;
    [SerializeField] GameObject Form_friend_3;

    [SerializeField] Text name_friend_1;
    [SerializeField] Text name_friend_2;
    [SerializeField] Text name_friend_3;

    [SerializeField] Text group_friend_1;
    [SerializeField] Text group_friend_2;
    [SerializeField] Text group_friend_3;

    private string friend_1;
    private string friend_2;
    private string friend_3;

    private string group_fr_1;
    private string group_fr_2;
    private string group_fr_3;

    void Update()
    {
        friend_1 = PlayerPrefs.GetString("friend_1", friend_1);
        friend_2 = PlayerPrefs.GetString("friend_2", friend_2);
        friend_3 = PlayerPrefs.GetString("friend_3", friend_3);

        group_fr_1 = PlayerPrefs.GetString("group_fr_1", group_fr_1);
        group_fr_2 = PlayerPrefs.GetString("group_fr_2", group_fr_2);
        group_fr_3 = PlayerPrefs.GetString("group_fr_3", group_fr_3);
        
        if(friend_1 != "")
        {
            Form_friend_1.SetActive(true); 
            name_friend_1.text = friend_1;
            group_friend_1.text = group_fr_1;
        }

        if(friend_2 != "")
        {
            Form_friend_2.SetActive(true); 
            name_friend_2.text = friend_2;
            group_friend_2.text = group_fr_2;
        }

        if(friend_3 != "")
        {
            Form_friend_3.SetActive(true); 
            name_friend_3.text = friend_3;
            group_friend_3.text = group_fr_3;
        }
    }

}
