using System.Collections;
using System.Collections.Generic;
namespace QSTXFramework.Core.Interfaces
{
    public interface ISceneLoaded
    {
        void OnSceneLoaded();
    }
    public interface ISceneUnloaded
    {
        void OnSceneUnloaded();
    }
    public interface ISceneLife:ISceneLoaded,ISceneUnloaded
    {

    }
}