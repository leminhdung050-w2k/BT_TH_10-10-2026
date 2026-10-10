namespace Bai5_3
{
    internal static class Program
    {
        /// <summary>
        /// Điểm khởi chạy chính của ứng dụng.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}
