#Requires AutoHotkey v1.1.0+
;==============================================================
; getTaskbarHwnd — Gets the taskbar window handle (Shell_TrayWnd)
;
; GitHub: https://github.com/SevenKeyboard/get-taskbar-hwnd
; Author: SevenKeyboard Ltd. (2026)
; License: The Unlicense
;==============================================================
class VersionManager_getTaskbarHwnd
{
    static _ := VersionManager_getTaskbarHwnd._init()
    _init()    {
        global
        GETTASKBARHWND_VERSION := "1.0.0"
    }
}
getTaskbarHwnd()    {
    return dllCall("User32.dll\FindWindowEx", "Ptr",0, "Ptr",0, "Str","Shell_TrayWnd", "Ptr",0, "Ptr")    
}