using System.Windows.Forms;

namespace Professional_GUI
{
    internal class HandlingExceptions
    {
        public static void HandlingException(string message)
        {
            MessageBox.Show(
                 message,
                 "Ошибка",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
