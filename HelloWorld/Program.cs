/*Console.Write("Введите число:");
int FirstNum = Convert.ToInt32(Console.ReadLine());
if (FirstNum > 5 && FirstNum < 10)
    Console.WriteLine("Число больше 5 и меньше 10");
else Console.WriteLine("Неизвестное число");*/
using System.Security.Principal;
using System.IO;

bool isElevated;
using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
{
    WindowsPrincipal principal = new WindowsPrincipal(identity);
    isElevated = principal.IsInRole(WindowsBuiltInRole.Administrator);
    string path = Path.GetFullPath("HelloWorld.exe");
    if (isElevated == true)
    {
        Console.WriteLine("Программа работает от имени администратора");
        Console.ReadLine();
    }
    else
    {
        Console.WriteLine("Программа работает без прав администратора");
        System.Diagnostics.Process.Start("cmd.exe", "/C powershell start-process " + path + " -verb runas");

    }
    //Console.WriteLine(path);
    //string command = "ping google.com -t";
    //System.Diagnostics.Process.Start("cmd.exe", "/C " + command);

    //Console.ReadLine();
}