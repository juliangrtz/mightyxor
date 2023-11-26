using Amgine.GUI.Forms.Tools;

namespace Amgine.GUI.Utils
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