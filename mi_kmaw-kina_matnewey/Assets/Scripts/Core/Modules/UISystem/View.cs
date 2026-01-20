using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFramework.UI.MVP
{
    using Interfaces;
    public abstract class View : MonoBehaviour, IView
    {
        protected IPresenter _presenter;

        protected abstract void Awake();
        public virtual void PreInit(IPresenter presenter, IModel model = null)
        {
            _presenter = presenter;
            _presenter.PreInit(this,model);
        }

        public abstract void OnViewEnter();

        public abstract void OnViewExit();

        public virtual void OnViewFocus()
        {

        }

        public virtual void OnViewBlur()
        {

        }
    }
}

