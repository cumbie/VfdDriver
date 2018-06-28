using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace VfdDriver
{
    public delegate void ErrorEventHandler(object sender, string error);
    public delegate void ReceiveEventHandler(object sender, byte[] buffer, int bytes_read);

    public class Vfd
    {
        // always connects at 19200,8N1
        SerialPort _serialPort;
        string _portName = string.Empty;
        bool _connected = false;

        // cursor properties
        int _cursorX = 0; // 0 to 19 (columns)
        int _cursorY = 0; // 0 to 1  (rows)
        bool _cursorOn = false;

        // screen properties
        bool _scrollingOn = false;

        CharacterSetType _charSetType = CharacterSetType.Normal;

        #region Constructors

        /// <summary>
        /// Base constructor.  
        /// Initializes VFD object by presetting internal serial port settings to:
        /// 19200 baud, 8 data bits, No parity, 1 stop bit.
        /// </summary>
        public Vfd()
        {
            _serialPort = new SerialPort();

            _serialPort.BaudRate = 19200;
            _serialPort.DataBits = 8;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;

            _serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

            _connected = false;
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="port_name">Serial port name</param>
        public Vfd(string port_name) : this()
        {   
            _serialPort.PortName = port_name;
        }
        
        #endregion

        #region Events and Handlers

        /// <summary>
        /// Event for processing errors.
        /// </summary>
        public ErrorEventHandler ErrorEvent;
        /// <summary>
        /// Event for processing data received by the VFD (VFD doesn't send data).
        /// </summary>
        public event ReceiveEventHandler ReceiveEvent;

        /// <summary>
        /// Publish error message to event handler.
        /// </summary>
        /// <param name="error">Error message</param>
        private void OnError(string error)
        {
            if (ErrorEvent != null)
                ErrorEvent(this, error);
        }

        /// <summary>
        /// Publish receive event data to receive handlers.
        /// </summary>
        /// <param name="buffer">Buffer containing received data</param>
        /// <param name="bytesRead">Number of bytes received</param>
        private void OnReceive(byte[] buffer, int bytesRead)
        {
            if (ReceiveEvent != null)
                ReceiveEvent(this, buffer, bytesRead);
        }

        /// <summary>
        /// Process the SerialDataReceivedEventHandler of the SerialPort.
        /// The VFD apparently does return any data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_connected)
                return;

            int numBytes = _serialPort.BytesToRead;
            byte[] data = new byte[numBytes];

            int bytesRead = _serialPort.Read(data, 0, numBytes);

            OnReceive(data, bytesRead);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the serial port name.
        /// </summary>
        public string PortName
        {
            get { return _portName; }
            set 
            { 
                _portName = value;
                if (_serialPort != null)
                    _serialPort.PortName = _portName;
            }
        }

        /// <summary>
        /// Gets or sets the connection state of the serial port.
        /// </summary>
        public bool Connected
        {
            get { return _connected; }
        }

        /// <summary>
        /// Gets or sets the cursor x-position.
        /// </summary>
        public int CursorX
        {
            get { return _cursorX; }
            private set
            {
                int pos = value;

                // moving left at top-left corner
                if (pos < 0)
                {
                    if (_cursorY == 0)
                        pos = 0;
                    else if (_cursorY == 1)
                    {
                        _cursorY = 0;
                        pos = 19;
                    }
                }

                // moving right at bottom-right corner
                if (pos > 19)
                {
                    pos = 0; // move to start of line

                    if (_cursorY == 1)
                    {
                        if (!_scrollingOn)
                        {
                            _cursorY = 0; // move to top-left corner
                        }
                    }
                    else if (_cursorY == 0)
                    {   
                        _cursorY = 1; // start of next line
                    }
                }

                _cursorX = pos;
            }
        }

        /// <summary>
        /// Gets or sets the cursor y-position.
        /// </summary>
        public int CursorY
        {
            get { return _cursorY; }
            private set
            {
                int pos = value;

                // moving up on row 0
                if (pos < 0)
                {
                    if (_scrollingOn)
                        pos = 0;
                    else
                        pos = 1;
                }

                // moving down on line 1
                if (pos > 1)
                {
                    if (_scrollingOn)
                        pos = 1;
                    else
                        pos = 0; // moves to line 0
                }

                _cursorY = pos;
            }
        }

        /// <summary>
        /// Gets the on-state of the cursor.
        /// </summary>
        public bool CursorOn
        {
            get { return _cursorOn; }
        }

        /// <summary>
        /// Gets the scrolling state.
        /// </summary>
        public bool ScrollingOn
        {
            get { return _scrollingOn; }
        }

        /// <summary>
        /// Gets the current character set.
        /// </summary>
        public CharacterSetType CharSetType
        {
            get { return _charSetType; }
        }

        #endregion

        #region Connect Functions

        /// <summary>
        /// Opens the serial port connection to the VFD.
        /// </summary>
        public void Connect()
        {
            if (_serialPort == null)
            {
                OnError("SerialPort is null");
            }

            if (string.IsNullOrEmpty(_portName))
            {
                OnError("The Comm port has not beed set.");
            }

            // connect to RS-232
            try
            {
                _serialPort.Open();
            }
            catch (Exception e)
            {
                OnError("Failed to open serial port (" + _portName + ").\r\n" + e.Message);
            }

            _connected = true;
        }

        /// <summary>
        /// Closes the serial port connection.
        /// </summary>
        public void Disconnect()
        {
            if (!_connected)
                return;

            _connected = false;
            _serialPort.Close();
        }

        #endregion

        /// <summary>
        /// Scans through the buffer and updates the cursor position.
        /// </summary>
        /// <param name="buffer">Data buffer sent to VFD</param>
        /// <param name="offset">Start of data buffer</param>
        /// <param name="count">Number of bytes to send</param>
        private void UpdateCursor(byte[] buffer, int offset, int count)
        {
            for (int i = offset; i < (offset + count); i++)
            {
                // first check for any commands
                VfdCommands cmd = (VfdCommands)buffer[i];
                switch (cmd)
                {
                    case VfdCommands.MoveCursorLeft:
                        CursorX--;
                        break;
                    case VfdCommands.MoveCursorRight:
                        CursorX++;
                        break;
                    case VfdCommands.MoveCursorDown:
                        CursorY++;
                        break;
                    case VfdCommands.MoveCursorToTopLeft:
                        CursorX = 0;
                        CursorY = 0;
                        break;
                    case VfdCommands.MoveCursorToLineStart:
                        CursorX = 0;
                        break;
                    default:
                        break;
                }

                // any visible chars move cursor to the right
                if (buffer[i] > 30)
                {
                    CursorX++;
                }
            }
        }

        #region Send Functions

        /// <summary>
        /// Common send function.
        /// </summary>
        /// <param name="buffer">Buffer to send</param>
        /// <param name="offset">Offset in buffer to start send</param>
        /// <param name="count">Number of bytes to send from offset</param>
        private void Send(byte[] buffer, int offset, int count)
        {
            if (!_connected)
            {
                OnError("Cannot send while not connected!");
                return;
            }

            UpdateCursor(buffer, offset, count);

            _serialPort.Write(buffer, offset, count);
        }

        /// <summary>
        /// Sends a command byte to the VFD.
        /// </summary>
        /// <param name="cmd">The VFD command to send</param>
        public void SendCommand(VfdCommands cmd)
        {
            SendData((byte)cmd);
        }

        /// <summary>
        /// Sends 1 byte to the VFD.
        /// </summary>
        /// <param name="data">Byte to send</param>
        public void SendData(byte data)
        {
            byte[] b = new byte[1];
            b[0] = data;

            Send(b, 0, b.Length);
        }

        /// <summary>
        /// Sends a byte buffer to the VFD.
        /// </summary>
        /// <param name="data">Buffer to send</param>
        public void SendData(byte [] data)
        {
            Send(data, 0, data.Length);
        }

        /// <summary>
        /// Sends a byte buffer to the VFD.
        /// </summary>
        /// <param name="data">Buffer to send</param>
        /// <param name="offset">Offset in buffer to start send</param>
        /// <param name="count">Number of bytes to send from offset</param>
        public void SendData(byte[] data, int offset, int count)
        {
            Send(data, 0, data.Length);
        }

        /// <summary>
        /// Sends a string to the VFD.
        /// </summary>
        /// <param name="data">String to send</param>
        public void SendData(string data)
        {
            byte[] b = Encoding.ASCII.GetBytes(data);

            Send(b, 0, b.Length);
        }

        #endregion

        #region Base VFD Commands

        /// <summary>
        /// Clears the screen.
        /// </summary>
        public void ClearScreen()
        {
            SendCommand(VfdCommands.ClearScreen);
        }

        /// <summary>
        /// Turns on/off scrolling.
        /// </summary>
        /// <param name="on">True to turn on scrolling</param>
        public void SetScrolling(bool on)
        {
            SendCommand((_scrollingOn = on) ? VfdCommands.EnableScroll : VfdCommands.DisableScroll);
        }

        /// <summary>
        /// Sets the character set.
        /// </summary>
        /// <param name="char_set">Character set</param>
        public void SetCharacterSet(CharacterSetType char_set)
        {
            _charSetType = char_set;
            if (char_set == CharacterSetType.Normal)
                SendCommand(VfdCommands.NormalCharacterSet);
            else if (char_set == CharacterSetType.Other)
                SendCommand(VfdCommands.OtherCharacterSet);
        }

        /// <summary>
        /// Turns on/off the cursor.
        /// </summary>
        /// <param name="on">True to turn on the cursor</param>
        public void SetCursor(bool on)
        {
            SendCommand((_cursorOn = on) ? VfdCommands.CursorOn : VfdCommands.CursorOff);
        }

        /// <summary>
        /// Moves the cursor left.
        /// </summary>
        public void CursorLeft()
        {
            SendCommand(VfdCommands.MoveCursorLeft);

            CursorX--;
        }

        /// <summary>
        /// Moves the cursor right.
        /// </summary>
        public void CursorRight()
        {
            SendCommand(VfdCommands.MoveCursorRight);

            CursorX++;
        }

        /// <summary>
        /// Moves the cursor down.
        /// </summary>
        public void CursorDown()
        {
            SendCommand(VfdCommands.MoveCursorDown);

            CursorY++;
        }

        /// <summary>
        /// Moves the cursor up.
        /// </summary>
        public void CursorUp()
        {   
            if (_scrollingOn)
            {
                if (_cursorY == 1)
                {
                    // have to move left 20 times
                    byte[] cmds = new byte[20];
                    for (int i = 0; i < cmds.Length; i++)
                        cmds[i] = (byte)VfdCommands.MoveCursorLeft;

                    SendData(cmds);
                    CursorY--;
                }
            }
            else
            {
                if (_cursorY == 1)
                {
                    SendCommand(VfdCommands.MoveCursorDown);
                    CursorY--;
                }
            }
        }

        /// <summary>
        /// Move the cursor to the start of the line.
        /// </summary>
        public void MoveCursorToLineStart()
        {
            SendCommand(VfdCommands.MoveCursorToLineStart);
            CursorX = 0;
        }

        /// <summary>
        /// Moves the cursor to the top left of the screen.
        /// </summary>
        public void MoveCursorToTopLeft()
        {
            SendCommand(VfdCommands.MoveCursorToTopLeft);
            CursorX = 0;
            CursorY = 0;
        }    

        #endregion

        #region Specialized VFD Commands

        /// <summary>
        /// Resets the display to the following configuration:
        ///  - clear screen
        ///  - cursor positioned to top left of screen
        ///  - scrolling off
        ///  - normal character set
        /// </summary>
        public void ResetDisplay()
        {
            MoveCursorToTopLeft();
            SetScrolling(false);
            SetCharacterSet(CharacterSetType.Normal);

            ClearScreen();
        }

        /// <summary>
        /// Moves the cursor position to the specified coordinates.
        /// </summary>
        /// <param name="x">X-position (0 to 19)</param>
        /// <param name="y">Y-position (0 to 1)</param>
        public void MoveCursor(int x, int y)
        {
            if (x < 0 || x > 19)
                return;
            if (y < 0 || y > 1)
                return;

            // based on current position, determine how to move
            int x_delta = x - _cursorX;
            int y_delta = y - _cursorY;

            int x_moves = 0;
            byte[] x_move_buf;


            if (x_delta != 0) // move left or right
            {
                x_moves = Math.Abs(x_delta);
                x_move_buf = new byte[x_moves];

                for (int i = 0; i < x_moves; i++)
                    x_move_buf[i] = (x_delta < 0) ? (byte)VfdCommands.MoveCursorLeft : (byte)VfdCommands.MoveCursorRight;

                SendData(x_move_buf);
                if (x_delta < 0)
                    CursorX -= x_moves;
                else
                    CursorX += x_moves;
            }

            if (y_delta < 0) // move up
                CursorUp();
            else if (y_delta > 0) // move down
                CursorDown();
        }

        #endregion
    }
}
