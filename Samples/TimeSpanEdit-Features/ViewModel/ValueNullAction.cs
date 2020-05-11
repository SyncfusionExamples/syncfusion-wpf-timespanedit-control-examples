using Syncfusion.Windows.Shared;
using System;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace TimeSpanEdit_Features
{
    class ValueNullAction : TargetedTriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            if (((TimeSpanEdit)TargetObject).AllowNull)
            {
               ((TimeSpanEdit)TargetObject).Value = null;
            }
            else if(((TimeSpanEdit)TargetObject).Value == null)
            {
                ((TimeSpanEdit)TargetObject).Value = ((TimeSpanEdit)TargetObject).MinValue;
            }
        }
    }
}