# ESRI Background and WEB Service

ESRI Background collects data from REST Api and processes data in every 5 minutes.

ESRI WEB Service provides data via http - with two data formats = html and json you can specify by /format=json /format=html

States data you can specify one state to return by /state=StateName for example /state=Alabama

example query: http://thisdomain.com/stats/state=Missouri&format=json - this returns Missouri population in JSON format

Project is created on C# .NET CORE 3.1 with two console applications. You must run them permanently.
