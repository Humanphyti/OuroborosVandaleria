using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace OuroborosVandaleria.UserInterface
{
    class Button
    {

        Button next;
        Button previous;

        protected virtual void OnSelect()
        {

        }

        public virtual bool IsSelected()
        {
            return false;
        }

        protected virtual void OnClick()
        {

        }

        public virtual bool IsClicked()
        {
            return false;
        }

    }
}
