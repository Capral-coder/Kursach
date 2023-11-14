using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase.Database;

namespace SettingsDB
{

    public class DB : MonoBehaviour
    {
        DatabaseReference dbRef;

        public string userName;
        public string groupName;
        public string emailName;
        public string counterFriend;
        public string nameFriend;

        void Awake()
        {
            dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        }

          public void SaveData(string usName, string emailID, string grName)
        {
            UserDB userDB = new UserDB(usName, emailID, grName);
            string json = JsonUtility.ToJson(userDB);
            dbRef.Child("users").Child(usName).SetRawJsonValueAsync(json);
        }
        public void SaveFriends(string _userName, string _friendName)
        {
            Friend friend = new Friend(_friendName);
            string json = JsonUtility.ToJson(friend);
            dbRef.Child("users").Child(_userName).Child("Friends").SetRawJsonValueAsync(json);
        }

        public IEnumerator LoadDataUser(string usName)
        {
            var userDB = dbRef.Child("users").Child(usName).GetValueAsync();

            yield return new WaitUntil(predicate: () => userDB.IsCompleted);

            if(userDB.Exception != null)
            {
                Debug.LogError(userDB.Exception);
            }
            else if(userDB.Result == null)
            {
                Debug.Log("Null");
            }
            else
            {
                DataSnapshot snapshot = userDB.Result;
                //Debug.Log(snapshot.Child("name").Value.ToString());
                userName = snapshot.Child("name").Value.ToString();
                emailName = snapshot.Child("email").Value.ToString();
                groupName = snapshot.Child("group").Value.ToString();
            }
        }

        public IEnumerator LoadDataLogin(string usName)
        {
            var userDB = dbRef.Child("users").Child(usName).GetValueAsync();

            yield return new WaitUntil(predicate: () => userDB.IsCompleted);

            if(userDB.Exception != null)
            {
                Debug.LogError(userDB.Exception);
            }
            else if(userDB.Result == null)
            {
                Debug.Log("Null");
            }
            else
            {
                DataSnapshot snapshot = userDB.Result;
                //Debug.Log(snapshot.Child("name").Value.ToString());
                userName = snapshot.Child("name").Value.ToString();
                groupName = snapshot.Child("group").Value.ToString();
            }
        }

        public IEnumerator LoadDataFriend(string _userName, string _friendName)
        {
            var friend = dbRef.Child("users").Child(_userName).Child("Friends").GetValueAsync();

            yield return new WaitUntil(predicate: () => friend.IsCompleted);

            if(friend.Exception != null)
            {
                Debug.LogError(friend.Exception);
            }
            else if(friend.Result == null)
            {
                Debug.Log("Null");
            }
            else
            {
                DataSnapshot snapshot = friend.Result;
                //Debug.Log(snapshot.Child("name").Value.ToString());
                nameFriend = snapshot.Child("friendName").Value.ToString();
            }
        }
    }

    public class UserDB
    {
        public string name;
        public string email;
        public string group;

        public UserDB(string name, string email, string group)
        {
            this.name = name;
            this.email = email;
            this.group = group;
        }
    }
    public class Friend
    {
        public string friendName;
        private int counter = 1;

        public Friend(string friendName)
        {

            counter = PlayerPrefs.GetInt("counter", counter);
            friendName = $"{friendName}_{counter}";
            counter++;
            PlayerPrefs.SetInt("counter", counter); 

            this.friendName = friendName;
            Debug.Log(friendName);
        }
    }
}

