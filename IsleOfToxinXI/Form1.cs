using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IsleOfToxinXI
{
    public partial class Form1 : Form
    {
        private delegate void StringDelegate(string text);
        private delegate void BoolDelegate(bool value);
        private delegate void IntDelegate(int value);
        private Character _character;
        private Map _map;
        public bool B1Clicked = false;
        public bool B2Clicked = false;
        public bool B3Clicked = false;
        public static EventWaitHandle Wait = new EventWaitHandle(false, EventResetMode.AutoReset);
        public Form1()
        {
            InitializeComponent();
        }

        private void SafeAddLine(string text)
        {
            if (textBox1.InvokeRequired)
            {
                var del = new StringDelegate(SafeAddLine);
                textBox1.Invoke(del, new object[] {text});
            }
            else
            {
                textBox1.Text = string.Concat(textBox1.Text, "\r\n" + text);
            }
        }
        public void AddLine(string newText)
        {
            SafeAddLine(newText);
        }

        private void SafeClearText(string text)
        { 
            text = "";
            if (textBox1.InvokeRequired)
            {
                var del = new StringDelegate(SafeClearText);
                textBox1.Invoke(del, new object[] {text});
            }
            else
            {
                textBox1.Text = "";
            }
        }
        public void ClearText()
        {
            SafeClearText("");
        }

        private void SafeButton1TextChange(string text)
        {
            if (button1.InvokeRequired)
            {
                var del = new StringDelegate(SafeButton1TextChange);
                button1.Invoke(del, new object[] {text});
            }
            else
            {
                button1.Text = text;
            }
        }
        public void ChangeB1Text(string text)
        {
            SafeButton1TextChange(text);
        }
        private void SafeButton2TextChange(string text)
        {
            if (button2.InvokeRequired)
            {
                var del = new StringDelegate(SafeButton2TextChange);
                button2.Invoke(del, new object[] {text});
            }
            else
            {
                button2.Text = text;
            }
        }
        public void ChangeB2Text(string text)
        {
            SafeButton2TextChange(text);
        }
        
        private void SafeButton3TextChange(string text)
        {
            if (button2.InvokeRequired)
            {
                var del = new StringDelegate(SafeButton3TextChange);
                button3.Invoke(del, new object[] {text});
            }
            else
            {
                button3.Text = text;
            }
        }
        public void ChangeB3Text(string text)
        {
            SafeButton3TextChange(text);
        }

        private void SafeDisableB3(bool value)
        {
            if (button3.InvokeRequired)
            {
                var del = new BoolDelegate(SafeDisableB3);
                button3.Invoke(del,new object[]{value});
            }
            else
            {
                button3.Enabled = false;
            }
        }
        public void DisableB3()
        {
           SafeDisableB3(false);
        }

        private void SafeSetHealthBar(int amount)
        {
            if (progressBar1.InvokeRequired)
            {
                var del = new IntDelegate(SafeSetHealthBar);
                progressBar1.Invoke(del, new object[] {amount});
            }
            else
            {
                progressBar1.Value = amount;

            }
        }
        public void SetHealthBar(int amount)
        {
            SafeSetHealthBar(amount);
        }

        private void SafeEnableButtons(bool value)
        {
            if (button1.InvokeRequired)
            {
                var del = new BoolDelegate(SafeEnableButtons);
                button1.Invoke(del, new object[] {value});
            }
            else
            {
                button1.Enabled = true;
            }
            if (button2.InvokeRequired)
            {
                var del = new BoolDelegate(SafeEnableButtons);
                button2.Invoke(del, new object[] {value});
            }
            else
            {
                button2.Enabled = true;
            }
            
            if (button3.InvokeRequired)
            {
                var del = new BoolDelegate(SafeEnableButtons);
                button3.Invoke(del, new object[] {value});
            }
            else
            {
                button3.Enabled = true;
            }
        }
        
        public void EnableButtons()
        {
           SafeEnableButtons(true);
        }
        private void SafeDisableButtons(bool value)
        {
            if (button1.InvokeRequired)
            {
                var del = new BoolDelegate(SafeDisableButtons);
                button1.Invoke(del, new object[] {value});
            }
            else
            {
                button1.Enabled = false;
            }
            if (button2.InvokeRequired)
            {
                var del = new BoolDelegate(SafeDisableButtons);
                button2.Invoke(del, new object[] {value});
            }
            else
            {
                button2.Enabled = false;
            }
            
            if (button3.InvokeRequired)
            {
                var del = new BoolDelegate(SafeDisableButtons);
                button3.Invoke(del, new object[] {value});
            }
            else
            {
                button3.Enabled = false;
            }
        }
        public void DisableButtons()
        {
            SafeDisableButtons(false);
        }

        public void ResetButtons()
        {
            B1Clicked = false;
            B2Clicked = false;
            B3Clicked = false;
        }
        


        public void button1_Click(object sender, EventArgs e)
        {
            
            B1Clicked = true;
            // signals that the button is clicked.
            DisableButtons();
            Debug.WriteLine("Button 1 click");
            Wait.Set();

        }

        public void button2_Click(object sender, EventArgs e)
        {
            B2Clicked = true;
           // signals that the button is clicked.
            DisableButtons();
            Debug.WriteLine("Button 2 click");
            Wait.Set();

        }

        public void button3_Click(object sender, EventArgs e)
        {
            B3Clicked = true;
            // signals that the button is clicked.
            DisableButtons();
            Debug.WriteLine("Button 3 click");
            Wait.Set();
        }
        
        public void Start()
        { 
            DisableButtons();
           _character = new Character();
           SetHealthBar((int)_character.getHealth());
           ClearText();
           _map = new Map();
           AddLine(">Choose:");
           ChangeB1Text("Start");
           ChangeB2Text("Exit");
           EnableButtons();
           DisableB3();
           Wait.WaitOne();
           Debug.WriteLine("Wait ended in Start");
           if (B1Clicked)
           {
               AddLine(">A secret organization called “The Syndicate” who have \r\n"
                       + ">been making weapons and selling to the highest bidder has created a new bio-weapon \r\n"
                       + ">called “Toxin XI” and made a test run on an uncharted island near Japan. Players \r\n"
                       + ">will have the role of an agent of The Syndicate who have been sent to the island \r\n"
                       + ">to gather information and samples from the animals and plants which were affected \r\n"
                       + ">from the Toxin XI.Due to the circumstances you were only able to have a lighter, \r\n"
                       + ">a pocket knife and a roll of duct tape with you when the player came to the island \r\n"
                       + ">so they will have to search for items and craft tools to survive . As the game moves \r\n"
                       + ">on, players will run into creatures which are living beings that were affected by \r\n"
                       + ">the bio-weapon and were mutated into abominations. Some of them are wild and will \r\n"
                       + ">attack you on sight whereas some of them are peaceful. It will be the player’s \r\n"
                       + ">choice to kill the creatures or leave them unharmed. Depending on their choice, \r\n"
                       + ">the amount of info and samples they gather will change.");
               AddLine(">Character info: ");
               AddLine(_character.printInfo());
               AddLine(">You Jump out of your Plane Just Above the Isle.");
               _map.StartPoint(_character);
           }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var thread = new Thread(Start);
            thread.Start();
            Debug.WriteLine("Button 4 click");
            button4.Enabled = false;
            button4.Visible = false;
            
        }
    }
}