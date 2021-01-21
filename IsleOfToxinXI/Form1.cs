using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private delegate void ItemDelegate(Item ıtem);
        private Character _character;
        private Map _map;
        public bool B1Clicked = false;
        public bool B2Clicked = false;
        public bool B3Clicked = false;
        public static EventWaitHandle Wait = new EventWaitHandle(false, EventResetMode.AutoReset);
        public static int HighestInfo = 0;
        public static int HighestSamp = 0;
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
                textBox1.AppendText("\r\n"+text);
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
                button3.Visible = false;
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
                button3.Visible = true;
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
           _character = Character.getInstance();
           SetHealthBar((int)_character.getHealth());
           ClearText();
           _map = Map.getInstance();
           AddLine(">Choose:");
           ChangeB1Text("Start");
           ChangeB2Text("Exit");
           EnableButtons();
           DisableB3();
           Wait.WaitOne();
           Debug.WriteLine("Wait ended in Start");
           if (B1Clicked)
           {
               AddLine(">A secret organization called “The Syndicate” who have ");Thread.Sleep(500);
               AddLine(">been making weapons and selling to the highest bidder has created a new bio-weapon ");Thread.Sleep(500);
               AddLine(">called “Toxin XI” and made a test run on an uncharted island near Japan. Players ");Thread.Sleep(500);
               AddLine(">will have the role of an agent of The Syndicate who have been sent to the island ");Thread.Sleep(500);
               AddLine(">to gather information and samples from the animals and plants which were affected ");Thread.Sleep(500);
               AddLine(">from the Toxin XI.Due to the circumstances you were only able to have a lighter, ");Thread.Sleep(500);
               AddLine(">a pocket knife and a roll of duct tape with you when the player came to the island ");Thread.Sleep(500);
               AddLine(">so they will have to search for items and craft tools to survive . As the game moves ");Thread.Sleep(500);
               AddLine(">on, players will run into creatures which are living beings that were affected by ");Thread.Sleep(500);
               AddLine(">the bio-weapon and were mutated into abominations. Some of them are wild and will ");Thread.Sleep(500);
               AddLine(">attack you on sight whereas some of them are peaceful. It will be the player’s ");Thread.Sleep(500);
               AddLine(">choice to kill the creatures or leave them unharmed. Depending on their choice, ");Thread.Sleep(500);
               AddLine(">the amount of info and samples they gather will change.");Thread.Sleep(500);
               AddLine(">Character info: ");Thread.Sleep(500);
               AddLine(_character.printInfo());Thread.Sleep(500);
               AddLine(">You Jump out of your Plane Just Above the Isle.");Thread.Sleep(500);
               _map.StartPoint(_character);
           }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ReadFile();
            var thread = new Thread(Start);
            thread.Start();
            Debug.WriteLine("Button 4 click");
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Enabled = false;
            button4.Visible = false;
            
        }

        private void SafeChangeHighest(string text)
        {
            if (highestInfo.InvokeRequired)
            {
                text = "Information: " + _character.getInfoGathered();
                var del = new StringDelegate(SafeChangeCurrent);
                highestInfo.Invoke(del, new object[] {text});
            }
            else
            {
                highestInfo.Text = "Information: " + _character.getInfoGathered();
            }
            
            if (highestSamp.InvokeRequired)
            {
                text = "Samples: " + _character.getInfoGathered();
                var del = new StringDelegate(SafeChangeCurrent);
                highestSamp.Invoke(del, new object[] {text});
            }
            else
            {
                highestSamp.Text = "Samples: " + _character.getSampleCollected();
            }
            
        }

        public void ChangeHighestScores()
        {
           SafeChangeHighest("");
           Interlocked.Exchange(ref HighestInfo, _character.getInfoGathered());
           Interlocked.Exchange(ref HighestSamp, _character.getSampleCollected());
        }

        private void SafeChangeCurrent(string text)
        {
            if (currInfo.InvokeRequired)
            {
                text = "Information: " + _character.getInfoGathered();
                var del = new StringDelegate(SafeChangeCurrent);
                currInfo.Invoke(del, new object[] {text});
            }
            else
            {
                currInfo.Text = "Information: " + _character.getInfoGathered();
                if (_character.getInfoGathered() > HighestInfo)
                {
                    ChangeHighestScores();
                }
            }
            
            if (currSamp.InvokeRequired)
            {
                text = "Samples: " + _character.getInfoGathered();
                var del = new StringDelegate(SafeChangeCurrent);
                currSamp.Invoke(del, new object[] {text});
            }
            else
            {
                currSamp.Text = "Samples: " + _character.getSampleCollected();
                if (_character.getSampleCollected() > HighestSamp)
                {
                    ChangeHighestScores();
                }
            }
            
        }
        public void ChangeCurrentScores()
        {
            SafeChangeCurrent("");
        }

        public int ExtractDigits(string text)
        {
            var digit = "";

            foreach (var c in text)
            {
                if (char.IsDigit(c))
                    digit += c;
            }

            return int.Parse(digit);
        }

        public void WriteToFile()
        {
            const string fileName = @"C:\Users\Arda\RiderProjects\IsleOfToxinXI\IsleOfToxinXI\Scores.txt";

            if (File.Exists(fileName))    
            {    
                File.Delete(fileName);    
            } 
            using (var stream = File.CreateText(fileName))
            {
                stream.WriteLine("Information: "+HighestInfo);
                stream.WriteLine("Samples: "+HighestSamp);
            }
            
        }

        public void ReadFile()
        {
            const string fileName = @"C:\Users\Arda\RiderProjects\IsleOfToxinXI\IsleOfToxinXI\Scores.txt";
            using (var reader = File.OpenText(fileName))
            {
                var line = "";
                var lineCount = 0;
                while ((line = reader.ReadLine()) != null)
                {
                    if (lineCount == 0)
                    {
                        HighestInfo = ExtractDigits(line);
                        highestInfo.Text ="Information: "+HighestInfo.ToString();
                    }
                    else
                    {
                        HighestSamp = ExtractDigits(line);
                        highestSamp.Text ="Samples: "+HighestSamp.ToString();
                    }

                    lineCount++;
                }
            }
                

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddLine(">Saving scores..");
            AddLine(">Exiting game..");
            //Thread.Sleep(2000);
            WriteToFile();
        }

        private void SafeAddItem(Item item)
        {
            if (checkedListBox1.InvokeRequired)
            {
                var del = new ItemDelegate(SafeAddItem);
                checkedListBox1.Invoke(del, new object[] {item});
            }
            else
            {
                checkedListBox1.Items.Add(item.ItemName + "->" + item.ItemDamage + " dps.");
            }
        }
        public void AddItemToInventory(Item item)
        {
            SafeAddItem(item);
        }
        
    }
}