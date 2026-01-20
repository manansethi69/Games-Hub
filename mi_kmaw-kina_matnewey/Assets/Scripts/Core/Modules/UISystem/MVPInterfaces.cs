using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFramework.UI.MVP.Interfaces
{
    using QSTXFramework.UI.MVP;
    public interface IView
    {
        void PreInit(IPresenter presenter, IModel model = null);
        void OnViewEnter();
        void OnViewExit();
    }
    public interface IModel
    {
        void PreInit(IPresenter presenter);
    }
    public interface IPresenter
    {
        void PreInit(IView view, IModel model = null);
    }
    public static class MVPInterfaceExtension
    {
        public static T Get<T>(this IModel model) where T:Model
        {
            return (T)model;
        }
        public static T Get<T>(this IPresenter presenter) where T : Presenter
        {
            return (T)presenter;
        }
        public static T Get<T>(this IView view) where T : View
        {
            return (T)view;
        }
    }
}
