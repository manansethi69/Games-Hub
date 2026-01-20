using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFramework.Core
{
    using Interfaces;
    using QSTXFramework.UI;
    public class AppCollection : Singleton<AppCollection>,IAppLife
    {
        private bool isFirst = true;
        public bool IsFirst
        {
            get
            {
                if (isFirst)
                {
                    isFirst = false;
                    return true;
                }
                return false;
            }
        }
        List<IAppEntry> _appEntries = new List<IAppEntry>
        {
            UISystem.Instance,
            LevelSystem.Instance
        };
        List<IAppExit> _appExits = new List<IAppExit>
        {
            LevelSystem.Instance,
        };

        public void OnAppEntry()
        {
            foreach(IAppEntry appEntry in _appEntries)
            {
                appEntry.OnAppEntry();
            }
        }

        public void OnAppExit()
        {
            foreach(IAppExit appExit in _appExits)
            {
                appExit.OnAppExit();
            }
        }
    }
}
