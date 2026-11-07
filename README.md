# get-taskbar-hwnd

Gets the primary Shell_TrayWnd window handle on Windows using .NET 10.

```csharp
nint taskbar = SevenKeyboard.GetTaskbarHwnd.Get();
```

Returns zero when absent. Uses FindWindowExW with null parent, previous window,
and title; does not search secondary taskbars.

Version 1.0.0 preserves the original handle semantics. Supports x64, x86 and NativeAOT.
