using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFramework.UI
{
    using MVP;
    using MVP.Interfaces;
    using QSTXFramework;
    using QSTXFramework.Core.Interfaces;
    public struct ViewData
    {
        public int layer;
        public string path;
    }
    public enum ViewID
    {
        MainView,
    }
    public class UISystem : Singleton<UISystem>, IAppLife
    {
        private Transform _canvasRoot;
        private Dictionary<ViewID, IView> _viewDict;
        private Stack<ViewID> _popStack;

        private Dictionary<ViewID, ViewData> _viewDataDict = new Dictionary<ViewID, ViewData>();
        private void Init()
        {
            _viewDict = new Dictionary<ViewID, IView>();
            _popStack = new Stack<ViewID>();
            _canvasRoot = GameObject.Instantiate(Resources.Load<GameObject>(GlobalConst.CANVAS_ROOT)).GetComponent<Transform>();
            GameObject.DontDestroyOnLoad(_canvasRoot);
            GameObject.DontDestroyOnLoad(GameObject.Instantiate(Resources.Load<GameObject>(GlobalConst.EVENT_SYSTEM)));
            _viewDataDict.Add(ViewID.MainView, new ViewData() { layer = GlobalConst.CANVAS_LAYER_0, path = GlobalConst.MAINVIEW });
        }
        public void Enter(ViewID viewID, bool erase = false)
        {
            ViewData viewData = _viewDataDict[viewID];
            GameObject obj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>(viewData.path));
            obj.transform.SetParent(_canvasRoot.GetChild(viewData.layer), false);
            IView view = obj.GetComponent<IView>();
            _viewDict.Add(viewID, view);
            view.OnViewEnter();
            if (erase)
            {
                while (_popStack.Count > 0)
                {
                    Exit(_popStack.Pop());
                }
            }
            _popStack.Push(viewID);
        }
        public void Exit(ViewID viewID)
        {
            _viewDict[viewID].OnViewExit();
            GameObject.Destroy(((View)_viewDict[viewID]).gameObject);
            _viewDict.Remove(viewID);
        }
        public void OnAppEntry()
        {
            Init();
        }

        public void OnAppExit()
        {
            throw new System.NotImplementedException();
        }
    }
}
