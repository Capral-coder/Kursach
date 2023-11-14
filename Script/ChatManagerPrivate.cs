using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
using Photon.Chat;
using ExitGames.Client.Photon;
using System;


public class ChatManagerPrivate : MonoBehaviour, IChatClientListener
{
    public GameObject imagePrefab;
    public Transform container;

    private int instanceCount = 0;

    public string chatName;
    public ResizeImageByText yourScript;
    
    private string userID;

    ChatClient chatClient;
    [SerializeField] Text chatText;
    [SerializeField] InputField textMessage;
    [SerializeField] InputField textUsername;

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log($"{level}, {message}");
    }

    public void OnDisconnected()
    {
        chatClient.Unsubscribe(new string[] {chatName});
    }

    public void OnConnected()
    {   
         
        //GameObject newImage = Instantiate(imagePrefab, container);
        //float yOffset = instanceCount * -200f; 
        //newImage.transform.localPosition = new Vector3(0, yOffset, 0);
        //instanceCount++; 

        chatText.text += "Ви приєдналися до чату";
        chatClient.Subscribe(chatName);
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log(state);
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        for (int i = 0; i < senders.Length; i++)
        {
            //GameObject newImage = Instantiate(imagePrefab, container);
            //float yOffset = instanceCount * -200f; 
            //newImage.transform.localPosition = new Vector3(0, yOffset, 0);
            //yourScript.textMeshPro.text += $"\n{senders[i]}: {messages[i]}";
            //instanceCount++;

            chatText.text += $"\n{senders[i]}: {messages[i]}";
        }
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        //throw new System.NotImplementedException();
    }    

    public void OnSubscribed(string[] channels, bool[] results)
    {
        for (int i = 0; i < channels.Length; i++)
        {
            //GameObject newImage = Instantiate(imagePrefab, container);
            //float yOffset = instanceCount * -200f; 
            //newImage.transform.localPosition = new Vector3(0, yOffset, 0);
            //instanceCount++;

            chatText.text += $"\nВи підключилися до {channels[i]}."; 

        }
    }    

    public void OnUnsubscribed(string[] channels)
    {
        for (int i = 0; i < channels.Length; i++)
        {   
            //GameObject newImage = Instantiate(imagePrefab, container);
            //float yOffset = instanceCount * -200f; 
            //newImage.transform.localPosition = new Vector3(0, yOffset, 0);
            //yourScript.textMeshPro.text = $"Вы отключились от {channels[i]}."; 
            //instanceCount++;   

            chatText.text += $"\nВи відключилися від {channels[i]}.";            
        }
    }   

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        //throw new System.NotImplementedException();
    }    

    public void OnUserSubscribed(string channel, string user)
    {
        //GameObject newImage = Instantiate(imagePrefab, container);
        //float yOffset = instanceCount * -200f; 
        //newImage.transform.localPosition = new Vector3(0, yOffset, 0);
        //yourScript.textMeshPro.text = $"Пользыватель {user} подключился {channel}.";
        //instanceCount++;   

        chatText.text += $"\nКористувач {user} підключився {channel}.";
    }  

    public void OnUserUnsubscribed(string channel, string user)
    {
        //GameObject newImage = Instantiate(imagePrefab, container);
        //float yOffset = instanceCount * -200f; 
        //newImage.transform.localPosition = new Vector3(0, yOffset, 0);
        //yourScript.textMeshPro.text = $"Пользыватель {user} подключился {channel}.";
        //instanceCount++;   

        chatText.text += $"\nКористувач {user} відключився {channel}.";
    }

    void Start()
    {
        userID = PlayerPrefs.GetString("userID");
        chatClient = new ChatClient(this); 
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(userID));
    }
    
    void Update()
    {
        chatClient.Service();
    }

    public void SendButton()
    {
        if(textUsername.text == "")
        {
            if(textMessage.text == "")
            {
                Debug.Log("Pusto");
            }
            else
            {
                chatClient.PublishMessage(chatName, textMessage.text);
                textMessage.text = "";
            }
        }
    }
}
