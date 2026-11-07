using System;
using System.Runtime.InteropServices;
using SevenKeyboard;

internal static unsafe class Program
{
    private static int Main()
    {
        nint library = NativeLibrary.Load("user32.dll", typeof(Program).Assembly, DllImportSearchPath.System32);
        try
        {
            // Resolve the export independently from the production LibraryImport.
            var query = (delegate* unmanaged[Stdcall]<nint, nint, char*, char*, nint>)
                NativeLibrary.GetExport(library, "FindWindowExW");
            int checks = 0;
            fixed (char* className = "Shell_TrayWnd")
            {
                for (int i = 0; i < 100; i++)
                {
                    nint before = query(0, 0, className, null);
                    nint actual = GetTaskbarHwnd.Get();
                    nint after = query(0, 0, className, null);
                    if (before != after)
                        continue; // Explorer may restart between independent observations.
                    if (actual != before)
                        throw new InvalidOperationException("Primary taskbar query differs from native FindWindowExW.");
                    checks++;
                }
            }
            if (checks == 0)
                throw new InvalidOperationException("No stable native taskbar observations.");
            Console.WriteLine($"PASS: {checks} native comparisons, {RuntimeInformation.ProcessArchitecture}; HWND={GetTaskbarHwnd.Get()}.");
            return 0;
        }
        catch (Exception error)
        {
            Console.Error.WriteLine(error);
            return 1;
        }
        finally
        {
            NativeLibrary.Free(library);
        }
    }
}
