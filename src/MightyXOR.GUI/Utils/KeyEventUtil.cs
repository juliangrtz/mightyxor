using MightyXOR.GUI.Forms.Tools;

namespace MightyXOR.GUI.Utils
{
    internal class KeyEventUtil
    {
        public static void HandleKeyDownEvent(KeyEventArgs args)
        {
            if (args.Control && args.KeyCode == Keys.G) // Ctrl+G
            {
                new KeyGenerator().Show();
            }
            //...
        }
    }
}