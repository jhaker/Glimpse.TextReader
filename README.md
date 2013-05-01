Glimpse.TextReader
============

Plugin for Glimpse reads text file content for 1-many in directory path


Set the following configuration in your application.
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
	<add key="Glimpse.TextReader.DateSort" value="Desc" /> <!-- sort by file created date "Desc" or "Asc"  -->
	<add key="Glimpse.TextReader.FileLimit" value="1" /> <!-- limit the number of files to be read --> 
	<add key="Glimpse.TextReader.Folder" value="" /> <!-- your folder path -->
</configuration>