using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QSTXFramework.Core;
using QSTXFramework.UI;
using UnityEngine.SceneManagement;

namespace GameModules
{
    public class GameEntry : MonoBehaviour
    {
        //private void Awake()
        //{
        //    if (AppCollection.Instance.IsFirst)
        //        AppCollection.Instance.OnAppEntry();
        //    DontDestroyOnLoad(this.gameObject);
        //}
        //private void Start()
        //{
        //    UISystem.Instance.Enter(ViewID.MainView);
        //}
        private void OnApplicationQuit()
        {
            AppCollection.Instance.OnAppExit();
        }

        public void loadMainMenu(){
            SceneManager.LoadScene("Homepage"); 
        }

    }
}
