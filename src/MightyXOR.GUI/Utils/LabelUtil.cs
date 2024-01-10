using MetroFramework.Controls;

namespace MightyXOR.GUI.Utils
{
    /// <summary>
    /// Utility class for labels
    /// </summary>
    internal class LabelUtil
    {
        public static void UpdateLabel(MetroLabel label, string value)
        {
            label.Text = value;
            label.FontSize = DefaultLblSizeAfterSelection;
            label.Location = new Point(label.Location.X, label.Location.Y + YShift);
        }

        public static void Truncate(Label label)
        => label.Text = InsertEllipsis(label.Text);

        private static string InsertEllipsis(string rawString, int maxLength = 30, char delimiter = '\\')
        {
            maxLength -= 3;

            if (rawString.Length <= maxLength)
            {
                return rawString;
            }

            var loops = 0;
            while (loops++ < 100)
            {
                var parts = rawString.Split(delimiter).ToList();
                parts.RemoveRange(parts.Count - 1 - loops, loops);
                if (parts.Count == 1)
                {
                    return parts.Last();
                }

                parts.Insert(parts.Count - 1, "...");
                var final = string.Join(delimiter.ToString(), parts);
                if (final.Length < maxLength)
                {
                    return final;
                }
            }

            return rawString.Split(delimiter).ToList().Last();
        }
    }
}