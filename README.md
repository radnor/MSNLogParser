MSNLogParser
============

A small WPF program that parses MSN Messenger XML log files and outputs them in a convenient, IRC-style text format.

Before
------
```xml
<Log FirstSessionID="533" LastSessionID="544">
  <Message Date="6/28/2012" Time="2:28:33 PM" DateTime="2012-06-28T21:28:33.323Z" SessionID="533">
  	<From>
			<User FriendlyName="Kevin Lo"/>
		</From>
		<To>
			<User FriendlyName="Coffee Train"/>
		</To>
		<Text Style="font-family:ProggySquare; color:#000000; ">even ebert gave it 3.5/4</Text>
	</Message>
	<Message Date="6/28/2012" Time="2:34:29 PM" DateTime="2012-06-28T21:34:29.706Z" SessionID="533">
		<From>
			<User FriendlyName="Stuart Schwartz"/>
		</From>
		<To>
			<User FriendlyName="Coffee Train"/>
		</To>
		<Text Style="font-family:Segoe UI; color:#000000; ">Visual Studio is busy so I'm here.</Text>
	</Message>
</Log>
```

After
-----
	[2012-06-28 14:28:33] <Kevin> even ebert gave it 3.5/4
	[2012-06-28 14:34:29] <Stuart> Visual Studio is busy so I'm here.
