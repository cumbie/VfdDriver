using System;
using System.Collections.Generic;
using System.Text;

namespace VfdDriver
{
    /// <summary>
    /// VFD Commands.
    /// </summary>
    public enum VfdCommands : byte
    {
        Nothing = 0x00,
        MoveCursorLeft = 0x08, // backspace
        MoveCursorRight = 0x09, // tab
        MoveCursorDown = 0x0A, // linefeed
        MoveCursorToTopLeft = 0x0C, // formfeed
        MoveCursorToLineStart = 0xD, // carriage return
        ClearScreen = 0x0E,
        DisableScroll = 0x11,
        EnableScroll = 0x12,
        CursorOff = 0x14,
        CursorOn = 0x15,
        CursorOff2 = 0x16,
        CursorOff3 = 0x17,
        OtherCharacterSet = 0x19,
        NormalCharacterSet = 0x1A
    }

    /// <summary>
    /// Character set type.
    /// </summary>
    public enum CharacterSetType
    {
        Normal,
        Other
    }
}
