﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms ;

namespace CustomerMaintenance
{
    public static class Validator
    {
        private static string title = "Entry Error";

        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        public static bool IsPresent(Control control)
        {
            if (control.GetType ().ToString () == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if(textBox .Text == "")
                {
                    MessageBox.Show(textBox .Tag + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            else if(control.GetType().ToString () == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if(comboBox.SelectedIndex == -1)
                {
                    MessageBox.Show(comboBox.Tag + " is  a required field", Title);
                    comboBox.Focus();
                    return false;
                }               
            }
            return true;
        }

        public static bool IsDecimal(TextBox textBox)
        {
            try
            {
                Convert.ToDecimal(textBox.Text);
                return true;
            }catch(FormatException )
            {
                MessageBox.Show(textBox .Tag + " must be a decimal number.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                Convert.ToInt32(textBox.Text);
                return true;
            }catch(FormatException ){
                MessageBox.Show(textBox.Tag + " must be an integer.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
        {
            decimal number = Convert.ToDecimal(textBox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(textBox.Tag + " must be between " + min + " and " + max +".", Title);
                textBox.Focus();
                return false;
            }
            return true;
        }

    }
}
