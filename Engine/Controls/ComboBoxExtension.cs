using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace TwoTrails.Forms
{
    public static class ComboBoxExtension
    {
        public static int FindString(this ComboBox box, string value)
        {
            if (value == null || value == "")
                return -1;
            string valueLower = value.ToLower();
            for (int i = 0; i < box.Items.Count; i++)
            {
                string itemLower = box.Items[i].ToString().ToLower();
               
                if( itemLower == valueLower)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int FindStringExact(this ComboBox box, string value)
        {
            for (int i = 0; i < box.Items.Count; i++)
            {
                if (value == box.Items[i].ToString())
                    return i;
            }
            return -1;
        }

        public static void AddRange(this ComboBox.ObjectCollection items, object[] values)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items.Add(values[i]);
            }
        }

    }
}
