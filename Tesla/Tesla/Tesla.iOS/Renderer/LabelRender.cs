﻿using Foundation;
using System.Linq;
using Tesla.Control;
using Tesla.Gestures;
using Tesla.iOS.Renderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(KeypadLabel), typeof(LabelRender))]
namespace Tesla.iOS.Renderer
{
    public class LabelRender : LabelRenderer
    {
        private class TouchLabel : UILabel
        {
            Label Element = null;
            public TouchLabel(Label element)
            {
                Element = element;
                this.Text = element.Text;
            }

            public override void TouchesBegan(NSSet touches, UIEvent evt)
            {
                base.TouchesBegan(touches, evt);
                foreach (var recognizer in this.Element.GestureRecognizers.Where(x => x.GetType() == typeof(PressedGestureRecognizer)))
                {
                    var gesture = recognizer as PressedGestureRecognizer;
                    if (gesture != null)
                        if (gesture.Command != null)
                            gesture.Command.Execute(gesture.CommandParameter);
                }
            }
            public override void TouchesCancelled(NSSet touches, UIEvent evt)
            {
                base.TouchesCancelled(touches, evt);
                foreach (var recognizer in this.Element.GestureRecognizers.Where(x => x.GetType() == typeof(ReleasedGestureRecognizer)))
                {
                    var gesture = recognizer as ReleasedGestureRecognizer;
                    if (gesture != null)
                        if (gesture.Command != null)
                            gesture.Command.Execute(gesture.CommandParameter);
                }
            }

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            if (Control == null)
                SetNativeControl(new TouchLabel(Element) { });

            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                if (!e.NewElement.GestureRecognizers.Any())
                    return;

                Control.UserInteractionEnabled = true;

            }
        }

    }
}
