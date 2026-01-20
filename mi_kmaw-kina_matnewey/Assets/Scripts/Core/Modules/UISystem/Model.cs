using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QSTXFramework.UI.MVP
{
    using Interfaces;
    public abstract class Model : IModel
    {
        protected IPresenter _presenter;

        public virtual void PreInit(IPresenter presenter)
        {
            _presenter = presenter;
        }
    }
}
