using UnityEngine;

//Sets an object to active only if the user is playing on mobile.
public class ShowOnMobile : MonoBehaviour {
    void Start(){
        gameObject.SetActive(Application.isMobilePlatform);
    }
}