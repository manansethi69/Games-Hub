using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFramework.UI.MVP
{
    using Interfaces;
    public abstract class Presenter : IPresenter
    {
        protected IView _view;
        protected IModel _model;

        public virtual void PreInit(IView view, IModel model = null)
        {
            _view = view;
            _model = model;
            _model?.PreInit(this);
        }
    }
}

