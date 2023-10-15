using WindowsInput;
using WindowsInput.Native;

namespace Userinterface.Utilities
{
    public static class FileUploadUtils
    {
        private static readonly InputSimulator sim = new InputSimulator();
        public static void UploadImage(string imageName)
        {
            string imageFullPath = Path.Combine(Environment.CurrentDirectory, "Resources\\Images", imageName);
            sim.Keyboard.Sleep(1500).TextEntry(imageFullPath);
            sim.Keyboard.Sleep(500).KeyPress(VirtualKeyCode.RETURN);
        }
    }
}
