using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace AkibasTripItems
{
    public partial class Form1 : Form
    {
        private volatile bool canrun = false;
        private volatile bool success = true;
        private int nag = 0;

        int osversionmajor = Environment.OSVersion.Version.Major;
        private int osversionminor = Environment.OSVersion.Version.Minor;

        private Process proc;
        private ProcessModule procm;

        private IntPtr handle = (IntPtr)0;

        private System.Threading.Thread thread;

        private byte[] pointerbuffer = new byte[4];
        private int fpsoffset = 0;
        private int playeroffset = 0;
        private int tempoffset = 0;
        private byte[] statsbytearray = new byte[24];
        private List<byte[]> statsbytearraylist = new List<byte[]>(6) { new byte[4], new byte[4], new byte[4], new byte[4], new byte[4], new byte[4] };
        private byte[] statstempbuffer;
        //private string[] characternames = new string[6];
        //private byte[] wcbuffer = new byte[32];
        //private byte[] npcidbuffer = new byte[200 * 4];

        private readonly byte[] MONEY = new byte[4] { 0xff, 0xff, 0xff, 0x7f };
        private readonly byte[] WEAPON_ATK = new byte[2] { 0x0f, 0x27 };
        private readonly byte[] PLAYER_STATS = new byte[13] { 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff, 0xff, 0x7f, 0xff, 0xff, 0xff, 0x7f, 0x62 };
        private readonly byte[] CLOTHING_DUR = new byte[2] { 0xe7, 0x03 };
        private readonly byte[] FPS_NORM = new byte[1] { 0x1e };
        private readonly byte[] FPS_HACK = new byte[1] { 0x3c };
        private readonly byte[] ZERO_STATS = new byte[12];
        private readonly byte[] NULL_STATS = new byte[4] { 0xff, 0xff, 0xff, 0xff };
        
        public Form1()
        {
            InitializeComponent();

            l_status.Text = "Start the game";

            fpsoffset = osversionmajor > 6 ? 0x0018FDFC : osversionminor == 1 ? 0x0018FE04 : 0x0018FDFC;

            thread = new Thread(RunCheats);

            this.FormClosing += (object o, FormClosingEventArgs e) =>
            {
                //if (thread.ThreadState == System.Threading.ThreadState.Running)
                //{
                //    WriteProcessMemory(
                //            handle,
                //            (IntPtr)fpsoffset,
                //            FPS_NORM,
                //            (uint)FPS_NORM.Length,
                //            out nag);
                //}

                canrun = false;
                if (thread.IsAlive) thread.Join();
            };
        }
        
        private bool FindAndAttachProcess()
        {
            proc = null;
            proc = Process.GetProcessesByName("AkibaUU").FirstOrDefault();
            if (proc == null)
            {
                l_status.Text = "Start the game";
                return false;
            }

            procm = proc.MainModule;

            handle = OpenProcess(ProcessAccessFlags.All, false, proc.Id);

            if ((int)handle == 0)
            {
                l_status.Text = "Start the game";
                return false;
            }

            return true;
        }


        #region KERNEL32

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }


        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint dwSize, out int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern Int32 CloseHandle(IntPtr hProcess);


        #endregion KERNEL32

        private void b_run_Click(object sender, EventArgs e)
        {
            if (!FindAndAttachProcess())
            {
                return;
            }

            //for (int i = 0; i < 6; i++)
            //{
            //    ReadProcessMemory(
            //        handle,
            //        procm.BaseAddress + 0x495578 + (0x41c * i),
            //        wcbuffer,
            //        wcbuffer.Length,
            //        ref nag);

            //    characternames[i] = Encoding.Unicode.GetString(wcbuffer);
            //}

            canrun = success = true;
            l_status.Text = "CHEATS ON";

            if (!thread.IsAlive)
            {
                thread.Start();
                while (!thread.IsAlive) ;
            }
        }

        private void RunCheats()
        {
            while (canrun)
            {
                if (ch_money.Checked)
                {
                    success = WriteProcessMemory(
                        handle,
                        (IntPtr)procm.BaseAddress + 0x49f750,
                        MONEY,
                        (uint)MONEY.Length,
                        out nag);

                    if (!success)
                    {
                        System.Diagnostics.Debug.WriteLine("Error occurred writing memory: MONEY");
                    }
                }

                if (ch_weaponatk.Checked)
                {
                    success = WriteProcessMemory(
                        handle,
                        (IntPtr)procm.BaseAddress + 0x4947d4,
                        WEAPON_ATK,
                        (uint)WEAPON_ATK.Length,
                        out nag);

                    if (!success)
                    {
                        System.Diagnostics.Debug.WriteLine("Error occurred writing memory: WEAPON ATK");
                    }
                }

                if (ch_clothingdur.Checked)
                {
                    success = WriteProcessMemory(
                        handle,
                        (IntPtr)procm.BaseAddress + 0x4942f4,
                        CLOTHING_DUR,
                        (uint)CLOTHING_DUR.Length,
                        out nag);

                    if (!success)
                    {
                        System.Diagnostics.Debug.WriteLine("Error occurred writing memory: CLOTHING DUR");
                        goto CONTINUE_ON_CLOTHING_WRITE_FAILURE;
                    }

                    WriteProcessMemory(
                        handle,
                        (IntPtr)procm.BaseAddress + 0x4942f4 + 0x60,
                        CLOTHING_DUR,
                        (uint)CLOTHING_DUR.Length,
                        out nag);

                    WriteProcessMemory(
                        handle,
                        (IntPtr)procm.BaseAddress + 0x4942f4 + 0x60 + 0x60,
                        CLOTHING_DUR,
                        (uint)CLOTHING_DUR.Length,
                        out nag);
                }

            CONTINUE_ON_CLOTHING_WRITE_FAILURE: { }

                if (ch_fps.Checked)
                {
                    success = WriteProcessMemory(
                        handle,
                        (IntPtr)fpsoffset,
                        FPS_HACK,
                        (uint)FPS_HACK.Length,
                        out nag);

                    if (!success)
                    {
                        System.Diagnostics.Debug.WriteLine("Error occurred writing memory: FPS HACK");
                    }
                }
                else if (!ch_fps.Checked)
                {
                    success = WriteProcessMemory(
                        handle,
                        (IntPtr)fpsoffset,
                        FPS_NORM,
                        (uint)FPS_NORM.Length,
                        out nag);

                    if (!success)
                    {
                        System.Diagnostics.Debug.WriteLine("Error occurred writing memory: FPS HACK");
                    }
                }

                playeroffset = 0;

                if (ch_invincible.Checked)
                {
                    success = ReadProcessMemory(
                        handle,
                        procm.BaseAddress + 0x469710,
                        pointerbuffer,
                        pointerbuffer.Length,
                        ref nag);

                    if (!success)
                    {
                        System.Diagnostics.Debug.WriteLine("Error occurred reading memory: PLAYER");
                        goto CONTINUE_ON_READWRITE_TO_PLAYER_FAILURE;
                    }

                    playeroffset = BitConverter.ToInt32(pointerbuffer, 0);

                    if (playeroffset > 0)
                    {
                        success = ReadProcessMemory(
                            handle,
                            (IntPtr)(playeroffset + 0x9e0),
                            statsbytearray,
                            statsbytearray.Length,
                            ref nag);

                        if (!success)
                        {
                            System.Diagnostics.Debug.WriteLine("Error occurred reading memory: PLAYER -> STATS");
                            goto CONTINUE_ON_READWRITE_TO_PLAYER_FAILURE;
                        }

                        for (byte i = 0; i < 6; i++)
                        {
                            statsbytearraylist[i] =
                                statsbytearray.Skip(i * 4).Take(4).ToArray();
                        }

                        if (BitConverter.ToInt32(statsbytearraylist[3], 0) > 0)
                            statsbytearraylist[0] = statsbytearraylist[3];
                        if (BitConverter.ToInt32(statsbytearraylist[4], 0) > 0)
                            statsbytearraylist[1] = statsbytearraylist[4];
                        if (BitConverter.ToInt32(statsbytearraylist[5], 0) > 0)
                            statsbytearraylist[2] = statsbytearraylist[5];

                        statstempbuffer = statsbytearraylist.SelectMany(a => a).ToArray();

                        success = WriteProcessMemory(
                            handle,
                            (IntPtr)(playeroffset + 0x9e0),
                            statstempbuffer,
                            (uint)statstempbuffer.Length,
                            out nag);

                        if (!success)
                        {
                            System.Diagnostics.Debug.WriteLine("Error occurred writing memory: PLAYER -> STATS");
                            goto CONTINUE_ON_READWRITE_TO_PLAYER_FAILURE;
                        }
                    }
                }

                if (ch_stripping.Checked)
                {
                    if (playeroffset == 0)
                    {
                        success = ReadProcessMemory(
                            handle,
                            procm.BaseAddress + 0x469710,
                            pointerbuffer,
                            pointerbuffer.Length,
                            ref nag);

                        if (!success)
                        {
                            System.Diagnostics.Debug.WriteLine("Error occurred reading memory: PLAYER");
                            goto CONTINUE_ON_READWRITE_TO_PLAYER_FAILURE;
                        }

                        playeroffset = BitConverter.ToInt32(pointerbuffer, 0);
                    }

                    if (playeroffset > 0)
                    {
                        success = ReadProcessMemory(
                            handle,
                            (IntPtr)(playeroffset + 0x9d8),
                            pointerbuffer,
                            pointerbuffer.Length,
                            ref nag);

                        if (!success)
                        {
                            System.Diagnostics.Debug.WriteLine("Error occurred reading memory: PLAYER -> TARGET");
                            goto CONTINUE_ON_READWRITE_TO_PLAYER_FAILURE;
                        }

                        tempoffset = BitConverter.ToInt32(pointerbuffer, 0);

                        if (tempoffset > 0)
                        {
                            //if (!ReadProcessMemory(
                            //    handle,
                            //    (IntPtr)(tempoffset + 0x9e0),
                            //    statsbytearray,
                            //    statsbytearray.Length,
                            //    ref nag)) 
                            //    break;

                            //for (byte i = 0; i < 6; i++)
                            //{
                            //    statsbytearraylist[i] =
                            //        statsbytearray.Skip(i * 4).Take(4).ToArray();
                            //}

                            //if (BitConverter.ToInt32(statsbytearraylist[3], 0) > 0)
                            //    statsbytearraylist[0] = ZERO_STATS;
                            //if (BitConverter.ToInt32(statsbytearraylist[4], 0) > 0)
                            //    statsbytearraylist[1] = ZERO_STATS;
                            //if (BitConverter.ToInt32(statsbytearraylist[5], 0) > 0)
                            //    statsbytearraylist[2] = ZERO_STATS;

                            statstempbuffer = statsbytearraylist.SelectMany(a => a).ToArray();

                            success = WriteProcessMemory(
                                handle,
                                (IntPtr)(tempoffset + 0x9e0),
                                ZERO_STATS,
                                (uint)ZERO_STATS.Length,
                                out nag);

                            if (!success)
                            {
                                System.Diagnostics.Debug.WriteLine("Error occurred reading memory: PLAYER -> TARGET -> STATS");
                            }
                        }
                    }
                }

            CONTINUE_ON_READWRITE_TO_PLAYER_FAILURE: { }

                while (!success)
                {
                    l_status.Text = "Start the game";
                }
            }
        }

        private void b_playerstats_Click(object sender, EventArgs e)
        {
            if (!FindAndAttachProcess()) return;

            bool success = WriteProcessMemory(
                handle,
                (IntPtr)procm.BaseAddress + 0x494834,
                PLAYER_STATS,
                (uint)PLAYER_STATS.Length,
                out nag);

            if (!success)
            {
                System.Diagnostics.Debug.WriteLine("Error occurred reading memory: PLAYER");
            }
        }
    }
}
