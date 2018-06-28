using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

using VfdDriver;

namespace VfdGui
{
    public partial class Form1 : Form
    {
        Vfd vfd = new Vfd();

        string[] cmdNames;
        byte[] cmds;

        public Form1()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
        }

        void dbg(string msg)
        {
            _txtDebug.AppendText(DateTime.Now.ToString("hh:mm:ss.fff") + ": " + msg + Environment.NewLine);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // populate ports
            _cmdPorts.Items.AddRange(SerialPort.GetPortNames());
            _cmdPorts.SelectedIndex = 0;

            // populate commands
            cmdNames = Enum.GetNames(typeof(VfdCommands));
            cmds = (byte[])Enum.GetValues(typeof(VfdCommands));
            
            string[] cmd_list = new string[cmds.Length];
            for (int i = 0; i < cmds.Length; i++)
                cmd_list[i] = "0x" + cmds[i].ToString("X2") + ": " + cmdNames[i];

            _cmdCommands.Items.AddRange(cmd_list);
            _cmdCommands.SelectedIndex = 0;

            vfd.ErrorEvent += new ErrorEventHandler(vfd_ErrorEvent);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (vfd.Connected)
                vfd.Disconnect();
        }

        private void _btnConnect_Click(object sender, EventArgs e)
        {
            if (_btnConnect.Text == "Connect")
            {
                string port = (string)_cmdPorts.SelectedItem;
               
                dbg("Connecting to port " + port + "...");

                vfd.PortName = port;
                vfd.ReceiveEvent += new ReceieveEventHandler(vfd_ReceiveEvent);
                vfd.Connect();

                dbg("Connnected!");
                _btnConnect.Text = "Disconnect";
            }
            else
            {
                vfd.Disconnect();

                _btnConnect.Text = "Connect";
            }
        }

        void vfd_ErrorEvent(object sender, string error)
        {
            dbg("ERROR: " + error);
        }

        void vfd_ReceiveEvent(object sender, byte[] buffer, int bytes_read)
        {
            dbg("Received " + bytes_read.ToString() + " from the VFD.");

            string blob = " Data:\r\n";
            foreach (byte b in buffer)
                blob += "   " + b.ToString("X2") + " " + ((char)b).ToString() + "\r\n";

            dbg(blob);   
        }

        private void _btnSendCommand_Click(object sender, EventArgs e)
        {
            int cmdIndex = _cmdCommands.SelectedIndex;

            dbg("Sending cmd (" + cmds[cmdIndex].ToString() + "): " + Enum.GetName(typeof(VfdCommands), cmds[cmdIndex]));

            vfd.SendCommand((VfdCommands)cmds[cmdIndex]);
        }

        private void _btnSendData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_txtData.Text.Trim()))
                return;

            string data = _txtData.Text.Trim();

            dbg("Sending \"" + data + "\" to the VFD.");

            vfd.SendData(data);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte tb = byte.Parse(_txtTest.Text);

            dbg("Sending test val: " + tb.ToString() + " (0x" + tb.ToString("X2") +", '"+ ((char)tb).ToString() +"')");

            vfd.SendData(tb);

            //testVal++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vfd.ResetDisplay();
        }
        
        private void _txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_chkSendContinuous.Checked)
            {
                char kv = e.KeyChar;

                dbg("Sending keyValue = " + kv.ToString() + " (0x" + ((byte)kv).ToString("X2") + ", '" + ((char)kv).ToString() + "')");

                vfd.SendData((byte)kv);
                dbg("Cursor pos = (" + vfd.CursorX.ToString() + ", " + vfd.CursorY.ToString() + ")");
            }
        }

        private void _chkScroll_CheckedChanged(object sender, EventArgs e)
        {
            if (!vfd.Connected)
                return;

            dbg("Scrolling "+ (_chkScroll.Checked ? "On" : "Off"));

            vfd.SetScrolling(_chkScroll.Checked);
        }

        private void _chkCursor_CheckedChanged(object sender, EventArgs e)
        {
            if (!vfd.Connected)
                return;

            dbg("Cursor " + (_chkCursor.Checked ? "On" : "Off"));

            vfd.SetCursor(_chkCursor.Checked);
        }

        private void _radNormalChar_CheckedChanged(object sender, EventArgs e)
        {
            if (!vfd.Connected)
                return;

            if (_radNormalChar.Checked)
            {
                dbg("Normal character set selected.");

                vfd.SendCommand(VfdCommands.NormalCharacterSet);
            }
        }

        private void _radOtherChar_CheckedChanged(object sender, EventArgs e)
        {
            if (!vfd.Connected)
                return;

            if (_radOtherChar.Checked)
            {
                dbg("Other character set selected.");

                vfd.SendCommand(VfdCommands.OtherCharacterSet);
            }
        }

        int testVal = 0;
        private void _btnTest2_Click(object sender, EventArgs e)
        {
            if (!vfd.Connected)
                return;
            
            //while (testVal < 256)
            //{
                testVal = int.Parse(_txtTest2.Text.Trim());

                dbg("Sending test val: " + testVal.ToString() + " (0x" + testVal.ToString("X2") + ", '" + ((char)testVal).ToString() + "')");

                vfd.ResetDisplay();
                string txt = "VAL (" + testVal.ToString() + ") = '";

                vfd.SendData(txt);

                vfd.SendData((byte)testVal);

                vfd.SendData("'");

                testVal++;
                _txtTest2.Text = testVal.ToString();
            //    System.Threading.Thread.Sleep(250);
            //}
        }

        private void _btnCursorUp_Click(object sender, EventArgs e)
        {
            vfd.CursorUp();
            dbg("Cursor pos = (" + vfd.CursorX.ToString() + ", " + vfd.CursorY.ToString() + ")");
        }

        private void _btnCursorDown_Click(object sender, EventArgs e)
        {
            vfd.CursorDown();
            dbg("Cursor pos = (" + vfd.CursorX.ToString() + ", " + vfd.CursorY.ToString() + ")");
        }

        private void _btnCursorLeft_Click(object sender, EventArgs e)
        {
            vfd.CursorLeft();
            dbg("Cursor pos = (" + vfd.CursorX.ToString() + ", " + vfd.CursorY.ToString() + ")");
        }

        private void _btnCursorRight_Click(object sender, EventArgs e)
        {
            vfd.CursorRight();
            dbg("Cursor pos = (" + vfd.CursorX.ToString() + ", " + vfd.CursorY.ToString() + ")");
        }

        private void _txtCursorPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                string[] xy = _txtCursorPos.Text.Trim().Split(new char[] { ',' });

                vfd.MoveCursor(int.Parse(xy[0]), int.Parse(xy[1]));
                dbg("Moved Cursor pos = (" + vfd.CursorX.ToString() + ", " + vfd.CursorY.ToString() + ")");
            }
        }

        string[] messages = new string[5];
        int msgCnt = 0;
        int msgIndex = 0;
        int msgDisplayIndex = 0;
        int MaxMsgs = 5;

        private void AddMessage(string new_msg)
        {
            if (msgCnt == 0)
                System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ShowMessageThread));

            // reset
            if (msgIndex == MaxMsgs)
                msgIndex = 0;

            // add new message to message list
            messages[msgIndex++] = new_msg;

            if (msgCnt < MaxMsgs)
                msgCnt++;
        }

        private void _btnTestDisplayMessages_Click(object sender, EventArgs e)
        {
            string new_msg = _txtMessageAdd.Text.Trim();
            AddMessage(new_msg);
        }

        private void _btnPrePopMessages_Click(object sender, EventArgs e)
        {
            AddMessage("The quick brown fox jumped over the lazy dog.");
            AddMessage("\"Booyah!\", said the VFD.");
            AddMessage("Broken build on isle 9.");
        }

        private void ShowMessageThread(object state)
        {
            while (true)
            {
                if (msgDisplayIndex == msgCnt)
                    msgDisplayIndex = 0;

                byte [] msg_bytes = Encoding.ASCII.GetBytes(messages[msgDisplayIndex]);
                int cnt = msg_bytes.Length;
                int offset = 0;
                int multiDisplay = 3; // how many times to show multiline messages
                int lineDelay = 2000;
                int charDelay = 80;

                vfd.ResetDisplay();
                vfd.SetScrolling(true);

                if (cnt < 39)
                {
                    for (int i = 0; i < multiDisplay; i++)
                    {
                        for (int j = 0; j < msg_bytes.Length; j++)
                        {
                            vfd.SendData(msg_bytes[j]);
                            System.Threading.Thread.Sleep(charDelay);
                        }
                        dbg("Showing message: '" + Encoding.ASCII.GetString(msg_bytes, offset, cnt) + "' offset = " + offset.ToString() + ",  cnt = " + cnt.ToString());
                        
                        System.Threading.Thread.Sleep(lineDelay);
                        vfd.ResetDisplay();
                        vfd.SetScrolling(true);
                    }
                }
                else if (cnt >= 39)
                {
                    for (int i = 0; i < multiDisplay; i++)
                    {
                        while (cnt > 0)
                        {
                            // show first 39 characters
                            if (offset == 0)
                            {
                                for (int j = offset; j < 39; j++)
                                {
                                    vfd.SendData(msg_bytes[j]);
                                    System.Threading.Thread.Sleep(charDelay);
                                }
                                //vfd.SendData(msg_bytes, offset, 39);
                                dbg("Showing message: '" + Encoding.ASCII.GetString(msg_bytes, offset, 39) + "' offset = "+ offset.ToString() +",  cnt = "+ cnt.ToString());

                                // update to display next line of msg
                                offset += 39;
                                cnt -= 39;
                            }
                            else
                            {
                                if (cnt > 19)
                                {
                                    for (int j = offset; j < (offset+19); j++)
                                    {
                                        vfd.SendData(msg_bytes[j]);
                                        System.Threading.Thread.Sleep(charDelay);
                                    }
                                    //vfd.SendData(msg_bytes, offset, 19);                                    
                                    dbg("Showing message: '" + Encoding.ASCII.GetString(msg_bytes, offset, 19) + "' offset = " + offset.ToString() + ",  cnt = " + cnt.ToString());

                                    offset += 19;
                                    cnt -= 19;
                                }
                                else
                                {
                                    for (int j = offset; j < (offset+cnt); j++)
                                    {
                                        vfd.SendData(msg_bytes[j]);
                                        System.Threading.Thread.Sleep(charDelay);
                                    }
                                    //vfd.SendData(msg_bytes, offset, cnt);
                                    dbg("Showing message: '" + Encoding.ASCII.GetString(msg_bytes, offset, cnt) + "' offset = " + offset.ToString() + ",  cnt = " + cnt.ToString());
                                    cnt = 0;
                                    // done, next message...
                                }
                            }

                            
                        }
                        
                        System.Threading.Thread.Sleep(lineDelay);
                        offset = 0;
                        cnt = msg_bytes.Length;
                        vfd.ResetDisplay();
                        vfd.SetScrolling(true);
                    }
                }
                

                msgDisplayIndex++;
            }
        }
    }
}