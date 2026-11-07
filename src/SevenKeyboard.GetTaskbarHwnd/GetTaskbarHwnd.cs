//==============================================================
// getTaskbarHwnd — Gets the taskbar window handle (Shell_TrayWnd)
//
// GitHub: https://github.com/SevenKeyboard/get-taskbar-hwnd
// Author: SevenKeyboard Ltd. (2026)
// License: The Unlicense
//==============================================================

using System.Runtime.InteropServices;

namespace SevenKeyboard;

public static partial class GetTaskbarHwnd
{
    public static nint Get() => FindWindowExW(0, 0, "Shell_TrayWnd", 0);

    [LibraryImport("user32.dll", EntryPoint = "FindWindowExW", StringMarshalling = StringMarshalling.Utf16)]
    [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
    private static partial nint FindWindowExW(nint parent, nint after, string className, nint title);
}
