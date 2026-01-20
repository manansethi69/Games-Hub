using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QSTXFramework;
using QSTXFramework.Core.Interfaces;

public class LevelSystem : Singleton<LevelSystem>, IAppLife
{
    private int maxLevel = 1;
    public int MaxLevel
    {
        get => maxLevel;
    }
    public void PassLevel(int level)
    {
        maxLevel = Math.Max(maxLevel, level);
    }
    public void ResetLevel()
    {
        maxLevel = 1;
    }
    private void Init()
    {
        maxLevel = PlayerPrefs.GetInt("MaxLevel",1);
    }
    public void OnAppEntry()
    {
        Init();
    }

    public void OnAppExit()
    {
        PlayerPrefs.SetInt("MaxLevel", maxLevel);
    }
}
