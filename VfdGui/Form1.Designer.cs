namespace VfdGui
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnConnect = new System.Windows.Forms.Button();
            this._cmdCommands = new System.Windows.Forms.ComboBox();
            this._btnSendCommand = new System.Windows.Forms.Button();
            this._cmdPorts = new System.Windows.Forms.ComboBox();
            this._txtDebug = new System.Windows.Forms.TextBox();
            this._txtData = new System.Windows.Forms.TextBox();
            this._btnSendData = new System.Windows.Forms.Button();
            this._btnTest = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._chkSendContinuous = new System.Windows.Forms.CheckBox();
            this._txtTest = new System.Windows.Forms.TextBox();
            this._chkScroll = new System.Windows.Forms.CheckBox();
            this._chkCursor = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._radOtherChar = new System.Windows.Forms.RadioButton();
            this._radNormalChar = new System.Windows.Forms.RadioButton();
            this._btnTest2 = new System.Windows.Forms.Button();
            this._txtTest2 = new System.Windows.Forms.TextBox();
            this._btnCursorUp = new System.Windows.Forms.Button();
            this._btnCursorDown = new System.Windows.Forms.Button();
            this._btnCursorRight = new System.Windows.Forms.Button();
            this._btnCursorLeft = new System.Windows.Forms.Button();
            this._txtCursorPos = new System.Windows.Forms.TextBox();
            this._btnTestDisplayMessages = new System.Windows.Forms.Button();
            this._txtMessageAdd = new System.Windows.Forms.TextBox();
            this._btnPrePopMessages = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnConnect
            // 
            this._btnConnect.Location = new System.Drawing.Point(8, 3);
            this._btnConnect.Name = "_btnConnect";
            this._btnConnect.Size = new System.Drawing.Size(75, 23);
            this._btnConnect.TabIndex = 0;
            this._btnConnect.Text = "Connect";
            this._btnConnect.UseVisualStyleBackColor = true;
            this._btnConnect.Click += new System.EventHandler(this._btnConnect_Click);
            // 
            // _cmdCommands
            // 
            this._cmdCommands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._cmdCommands.FormattingEnabled = true;
            this._cmdCommands.Location = new System.Drawing.Point(483, 3);
            this._cmdCommands.MaxDropDownItems = 15;
            this._cmdCommands.Name = "_cmdCommands";
            this._cmdCommands.Size = new System.Drawing.Size(162, 21);
            this._cmdCommands.TabIndex = 1;
            // 
            // _btnSendCommand
            // 
            this._btnSendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSendCommand.Location = new System.Drawing.Point(653, 3);
            this._btnSendCommand.Name = "_btnSendCommand";
            this._btnSendCommand.Size = new System.Drawing.Size(92, 23);
            this._btnSendCommand.TabIndex = 2;
            this._btnSendCommand.Text = "Send Command";
            this._btnSendCommand.UseVisualStyleBackColor = true;
            this._btnSendCommand.Click += new System.EventHandler(this._btnSendCommand_Click);
            // 
            // _cmdPorts
            // 
            this._cmdPorts.FormattingEnabled = true;
            this._cmdPorts.Location = new System.Drawing.Point(88, 5);
            this._cmdPorts.Name = "_cmdPorts";
            this._cmdPorts.Size = new System.Drawing.Size(70, 21);
            this._cmdPorts.TabIndex = 3;
            // 
            // _txtDebug
            // 
            this._txtDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDebug.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtDebug.Location = new System.Drawing.Point(3, 157);
            this._txtDebug.Multiline = true;
            this._txtDebug.Name = "_txtDebug";
            this._txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtDebug.Size = new System.Drawing.Size(742, 234);
            this._txtDebug.TabIndex = 4;
            // 
            // _txtData
            // 
            this._txtData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtData.Location = new System.Drawing.Point(205, 32);
            this._txtData.Multiline = true;
            this._txtData.Name = "_txtData";
            this._txtData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._txtData.Size = new System.Drawing.Size(440, 119);
            this._txtData.TabIndex = 5;
            this._txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtData_KeyPress);
            // 
            // _btnSendData
            // 
            this._btnSendData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnSendData.Location = new System.Drawing.Point(653, 30);
            this._btnSendData.Name = "_btnSendData";
            this._btnSendData.Size = new System.Drawing.Size(92, 23);
            this._btnSendData.TabIndex = 6;
            this._btnSendData.Text = "Send Data";
            this._btnSendData.UseVisualStyleBackColor = true;
            this._btnSendData.Click += new System.EventHandler(this._btnSendData_Click);
            // 
            // _btnTest
            // 
            this._btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnTest.Location = new System.Drawing.Point(651, 107);
            this._btnTest.Name = "_btnTest";
            this._btnTest.Size = new System.Drawing.Size(42, 23);
            this._btnTest.TabIndex = 7;
            this._btnTest.Text = "Test";
            this._btnTest.UseVisualStyleBackColor = true;
            this._btnTest.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(670, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // _chkSendContinuous
            // 
            this._chkSendContinuous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._chkSendContinuous.AutoSize = true;
            this._chkSendContinuous.Checked = true;
            this._chkSendContinuous.CheckState = System.Windows.Forms.CheckState.Checked;
            this._chkSendContinuous.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkSendContinuous.Location = new System.Drawing.Point(651, 61);
            this._chkSendContinuous.Name = "_chkSendContinuous";
            this._chkSendContinuous.Size = new System.Drawing.Size(94, 16);
            this._chkSendContinuous.TabIndex = 9;
            this._chkSendContinuous.Text = "Send Continuous";
            this._chkSendContinuous.UseVisualStyleBackColor = true;
            // 
            // _txtTest
            // 
            this._txtTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTest.Location = new System.Drawing.Point(693, 109);
            this._txtTest.Name = "_txtTest";
            this._txtTest.Size = new System.Drawing.Size(52, 20);
            this._txtTest.TabIndex = 10;
            // 
            // _chkScroll
            // 
            this._chkScroll.AutoSize = true;
            this._chkScroll.Location = new System.Drawing.Point(6, 19);
            this._chkScroll.Name = "_chkScroll";
            this._chkScroll.Size = new System.Drawing.Size(83, 17);
            this._chkScroll.TabIndex = 11;
            this._chkScroll.Text = "Scrolling On";
            this._chkScroll.UseVisualStyleBackColor = true;
            this._chkScroll.CheckedChanged += new System.EventHandler(this._chkScroll_CheckedChanged);
            // 
            // _chkCursor
            // 
            this._chkCursor.AutoSize = true;
            this._chkCursor.Location = new System.Drawing.Point(6, 39);
            this._chkCursor.Name = "_chkCursor";
            this._chkCursor.Size = new System.Drawing.Size(86, 17);
            this._chkCursor.TabIndex = 12;
            this._chkCursor.Text = "Show Cursor";
            this._chkCursor.UseVisualStyleBackColor = true;
            this._chkCursor.CheckedChanged += new System.EventHandler(this._chkCursor_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._txtCursorPos);
            this.groupBox1.Controls.Add(this._btnCursorLeft);
            this.groupBox1.Controls.Add(this._btnCursorRight);
            this.groupBox1.Controls.Add(this._btnCursorDown);
            this.groupBox1.Controls.Add(this._btnCursorUp);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this._chkCursor);
            this.groupBox1.Controls.Add(this._chkScroll);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 119);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Functions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._radOtherChar);
            this.groupBox2.Controls.Add(this._radNormalChar);
            this.groupBox2.Location = new System.Drawing.Point(6, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 51);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Char Set";
            // 
            // _radOtherChar
            // 
            this._radOtherChar.AutoSize = true;
            this._radOtherChar.Location = new System.Drawing.Point(89, 19);
            this._radOtherChar.Name = "_radOtherChar";
            this._radOtherChar.Size = new System.Drawing.Size(51, 17);
            this._radOtherChar.TabIndex = 14;
            this._radOtherChar.TabStop = true;
            this._radOtherChar.Text = "Other";
            this._radOtherChar.UseVisualStyleBackColor = true;
            this._radOtherChar.CheckedChanged += new System.EventHandler(this._radOtherChar_CheckedChanged);
            // 
            // _radNormalChar
            // 
            this._radNormalChar.AutoSize = true;
            this._radNormalChar.Checked = true;
            this._radNormalChar.Location = new System.Drawing.Point(6, 19);
            this._radNormalChar.Name = "_radNormalChar";
            this._radNormalChar.Size = new System.Drawing.Size(58, 17);
            this._radNormalChar.TabIndex = 14;
            this._radNormalChar.TabStop = true;
            this._radNormalChar.Text = "Normal";
            this._radNormalChar.UseVisualStyleBackColor = true;
            this._radNormalChar.CheckedChanged += new System.EventHandler(this._radNormalChar_CheckedChanged);
            // 
            // _btnTest2
            // 
            this._btnTest2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnTest2.Location = new System.Drawing.Point(651, 131);
            this._btnTest2.Name = "_btnTest2";
            this._btnTest2.Size = new System.Drawing.Size(42, 23);
            this._btnTest2.TabIndex = 14;
            this._btnTest2.Text = "Test2";
            this._btnTest2.UseVisualStyleBackColor = true;
            this._btnTest2.Click += new System.EventHandler(this._btnTest2_Click);
            // 
            // _txtTest2
            // 
            this._txtTest2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTest2.Location = new System.Drawing.Point(693, 131);
            this._txtTest2.Name = "_txtTest2";
            this._txtTest2.Size = new System.Drawing.Size(52, 20);
            this._txtTest2.TabIndex = 15;
            this._txtTest2.Text = "1";
            // 
            // _btnCursorUp
            // 
            this._btnCursorUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCursorUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCursorUp.Location = new System.Drawing.Point(153, 11);
            this._btnCursorUp.Name = "_btnCursorUp";
            this._btnCursorUp.Size = new System.Drawing.Size(20, 17);
            this._btnCursorUp.TabIndex = 15;
            this._btnCursorUp.Text = "u";
            this._btnCursorUp.UseVisualStyleBackColor = true;
            this._btnCursorUp.Click += new System.EventHandler(this._btnCursorUp_Click);
            // 
            // _btnCursorDown
            // 
            this._btnCursorDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCursorDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCursorDown.Location = new System.Drawing.Point(153, 43);
            this._btnCursorDown.Name = "_btnCursorDown";
            this._btnCursorDown.Size = new System.Drawing.Size(20, 17);
            this._btnCursorDown.TabIndex = 16;
            this._btnCursorDown.Text = "d";
            this._btnCursorDown.UseVisualStyleBackColor = true;
            this._btnCursorDown.Click += new System.EventHandler(this._btnCursorDown_Click);
            // 
            // _btnCursorRight
            // 
            this._btnCursorRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCursorRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCursorRight.Location = new System.Drawing.Point(165, 27);
            this._btnCursorRight.Name = "_btnCursorRight";
            this._btnCursorRight.Size = new System.Drawing.Size(20, 17);
            this._btnCursorRight.TabIndex = 17;
            this._btnCursorRight.Text = "r";
            this._btnCursorRight.UseVisualStyleBackColor = true;
            this._btnCursorRight.Click += new System.EventHandler(this._btnCursorRight_Click);
            // 
            // _btnCursorLeft
            // 
            this._btnCursorLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCursorLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnCursorLeft.Location = new System.Drawing.Point(142, 27);
            this._btnCursorLeft.Name = "_btnCursorLeft";
            this._btnCursorLeft.Size = new System.Drawing.Size(20, 17);
            this._btnCursorLeft.TabIndex = 18;
            this._btnCursorLeft.Text = "l";
            this._btnCursorLeft.UseVisualStyleBackColor = true;
            this._btnCursorLeft.Click += new System.EventHandler(this._btnCursorLeft_Click);
            // 
            // _txtCursorPos
            // 
            this._txtCursorPos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._txtCursorPos.Location = new System.Drawing.Point(121, 45);
            this._txtCursorPos.Name = "_txtCursorPos";
            this._txtCursorPos.Size = new System.Drawing.Size(31, 20);
            this._txtCursorPos.TabIndex = 19;
            this._txtCursorPos.Text = "5,1";
            this._txtCursorPos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtCursorPos_KeyPress);
            // 
            // _btnTestDisplayMessages
            // 
            this._btnTestDisplayMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnTestDisplayMessages.Location = new System.Drawing.Point(162, 5);
            this._btnTestDisplayMessages.Name = "_btnTestDisplayMessages";
            this._btnTestDisplayMessages.Size = new System.Drawing.Size(52, 21);
            this._btnTestDisplayMessages.TabIndex = 16;
            this._btnTestDisplayMessages.Text = "AddMsg";
            this._btnTestDisplayMessages.UseVisualStyleBackColor = true;
            this._btnTestDisplayMessages.Click += new System.EventHandler(this._btnTestDisplayMessages_Click);
            // 
            // _txtMessageAdd
            // 
            this._txtMessageAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this._txtMessageAdd.Location = new System.Drawing.Point(216, 6);
            this._txtMessageAdd.Name = "_txtMessageAdd";
            this._txtMessageAdd.Size = new System.Drawing.Size(196, 20);
            this._txtMessageAdd.TabIndex = 17;
            // 
            // _btnPrePopMessages
            // 
            this._btnPrePopMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._btnPrePopMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._btnPrePopMessages.Location = new System.Drawing.Point(414, 6);
            this._btnPrePopMessages.Name = "_btnPrePopMessages";
            this._btnPrePopMessages.Size = new System.Drawing.Size(67, 21);
            this._btnPrePopMessages.TabIndex = 18;
            this._btnPrePopMessages.Text = "PrePopMsgs";
            this._btnPrePopMessages.UseVisualStyleBackColor = true;
            this._btnPrePopMessages.Click += new System.EventHandler(this._btnPrePopMessages_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 395);
            this.Controls.Add(this._btnPrePopMessages);
            this.Controls.Add(this._txtMessageAdd);
            this.Controls.Add(this._btnTestDisplayMessages);
            this.Controls.Add(this._txtTest2);
            this.Controls.Add(this._btnTest2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._txtTest);
            this.Controls.Add(this._chkSendContinuous);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._btnTest);
            this.Controls.Add(this._btnSendData);
            this.Controls.Add(this._txtData);
            this.Controls.Add(this._txtDebug);
            this.Controls.Add(this._cmdPorts);
            this.Controls.Add(this._btnSendCommand);
            this.Controls.Add(this._cmdCommands);
            this.Controls.Add(this._btnConnect);
            this.Name = "Form1";
            this.Text = "NCR VFD Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnConnect;
        private System.Windows.Forms.ComboBox _cmdCommands;
        private System.Windows.Forms.Button _btnSendCommand;
        private System.Windows.Forms.ComboBox _cmdPorts;
        private System.Windows.Forms.TextBox _txtDebug;
        private System.Windows.Forms.TextBox _txtData;
        private System.Windows.Forms.Button _btnSendData;
        private System.Windows.Forms.Button _btnTest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox _chkSendContinuous;
        private System.Windows.Forms.TextBox _txtTest;
        private System.Windows.Forms.CheckBox _chkScroll;
        private System.Windows.Forms.CheckBox _chkCursor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton _radOtherChar;
        private System.Windows.Forms.RadioButton _radNormalChar;
        private System.Windows.Forms.Button _btnTest2;
        private System.Windows.Forms.TextBox _txtTest2;
        private System.Windows.Forms.Button _btnCursorLeft;
        private System.Windows.Forms.Button _btnCursorRight;
        private System.Windows.Forms.Button _btnCursorDown;
        private System.Windows.Forms.Button _btnCursorUp;
        private System.Windows.Forms.TextBox _txtCursorPos;
        private System.Windows.Forms.Button _btnTestDisplayMessages;
        private System.Windows.Forms.TextBox _txtMessageAdd;
        private System.Windows.Forms.Button _btnPrePopMessages;
    }
}

