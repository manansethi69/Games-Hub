using System.Collections;
using System.Collections.Generic;
namespace QSTXFramework.Core.Interfaces
{
    public interface IAppEntry
    {
        void OnAppEntry();
    }
    public interface IAppExit
    {
        void OnAppExit();
    }
    public interface IAppLife:IAppEntry,IAppExit
    {
        
    }
}
