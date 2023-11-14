using UnityEngine.UI;
using UnityEngine;

public class InternetAccessCheck : MonoBehaviour
{
    [SerializeField] private InternetAccess InternetAccess;

    [SerializeField] GameObject FormNoneInternet;
    
    private void Awake()
    {
        StartCoroutine(InternetAccess.TestConnection(result =>
        {
            if(result == false)
            {
                FormNoneInternet.SetActive(true);
            }
        }));
    }
}
