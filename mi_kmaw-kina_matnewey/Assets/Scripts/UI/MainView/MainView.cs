using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using QSTXFramework.UI;
using QSTXFramework.UI.MVP;
using QSTXFramework.UI.MVP.Interfaces;

public class MainModel : Model
{
    public int curLevel = 1;
}

public class MainPresenter : Presenter
{
    public void ChangeCurLevel(Toggle toggle)
    {
        if (toggle.isOn)
        {
            _model.Get<MainModel>().curLevel = int.Parse(toggle.name.Split('_')[1]);
        }
    }
    public void StartGame()
    {
        UISystem.Instance.Exit(ViewID.MainView);
        //SceneManager.LoadScene($"GameScene{_model.Get<MainModel>().curLevel}");
        if(_model.Get<MainModel>().curLevel==1)
            SceneManager.LoadScene("LevelTest");
        else if (_model.Get<MainModel>().curLevel == 2)
            SceneManager.LoadScene("");
        else if (_model.Get<MainModel>().curLevel == 3)
            SceneManager.LoadScene("");
        else if (_model.Get<MainModel>().curLevel == 4)
            SceneManager.LoadScene("");
        else if (_model.Get<MainModel>().curLevel == 5)
            SceneManager.LoadScene("");
        else if (_model.Get<MainModel>().curLevel == 6)
            SceneManager.LoadScene("");
        else if (_model.Get<MainModel>().curLevel == 7)
            SceneManager.LoadScene("");
        else if (_model.Get<MainModel>().curLevel == 8)
            SceneManager.LoadScene("");
        else
            SceneManager.LoadScene("LevelTest");
    }
}
public class MainView : View
{
    private Toggle[] toggles = new Toggle[10];
    private Button startBtn;
    protected override void Awake()
    {
        GameObject posObj = GameObject.Find("Grid/Tilemap");
        for (int i = 0; i < 10; ++i)
        {
            toggles[i] = GameObject.Find($"Toggle_{i + 1}").GetComponent<Toggle>();
            if (posObj)
            {
                toggles[i].transform.position = Camera.main.WorldToScreenPoint(posObj.transform.GetChild(i).position);
            }
            if (i + 1 > LevelSystem.Instance.MaxLevel)
                toggles[i].interactable = false;
        }
        toggles[LevelSystem.Instance.MaxLevel - 1].isOn = true;
        startBtn = GameObject.Find("StartButton").GetComponent<Button>();
        PreInit(new MainPresenter(), new MainModel());
    }
    public override void OnViewEnter()
    {
        toggles[0].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[0]); });
        toggles[1].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[1]); });
        toggles[2].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[2]); });
        toggles[3].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[3]); });
        toggles[4].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[4]); });
        toggles[5].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[5]); });
        toggles[6].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[6]); });
        toggles[7].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[7]); });
        toggles[8].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[8]); });
        toggles[9].onValueChanged.AddListener(delegate{_presenter.Get<MainPresenter>().ChangeCurLevel(toggles[9]); });
        startBtn.onClick.AddListener(_presenter.Get<MainPresenter>().StartGame);
    }

    public override void OnViewExit()
    {
        toggles[0].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[0]); });
        toggles[1].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[1]); });
        toggles[2].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[2]); });
        toggles[3].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[3]); });
        toggles[4].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[4]); });
        toggles[5].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[5]); });
        toggles[6].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[6]); });
        toggles[7].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[7]); });
        toggles[8].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[8]); });
        toggles[9].onValueChanged.RemoveListener(delegate { _presenter.Get<MainPresenter>().ChangeCurLevel(toggles[9]); });
        startBtn.onClick.RemoveListener(_presenter.Get<MainPresenter>().StartGame);
    }

}