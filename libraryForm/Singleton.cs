using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libraryForm
{
    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        public static Timer clipNotif = new Timer();
        public static int clipTime, tickRepeat = 0;
        public static string[] course;
        public static int courseLim;
        public static int booksLim;
        public static bool studRad = false;
        public static bool bookRadCheck = false;
        public static List<GroupBox> grr = new List<GroupBox>();
        public static int colorAlternate = 0;
        public static int fineAmount = 0;
        public static Form1 parent;
        public static string borrower;
        public static string weekNow, monthYearNow;
        public static Label getContWeek;
        public static MyTextBox test = new MyTextBox();
        public static bool noID = false;
        public static int newOffense = 0;
        // Explicit static constructor to tell C# compiler  
        // not to mark type as beforefieldinit  
        static Singleton()
        {
        }
        private Singleton()
        {
        }
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
