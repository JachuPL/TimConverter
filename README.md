Tim Converter
===========

This is a simple script that converts tim's packer xml files into DaRealFreak unpacker tool list

Almost everything is done, I'll apply some bugfixes and commit here asap.

What is JachuPL define statement and why it won't work for you:
This define statement indicates that script can use my LogTracer library, which is not available for now.
Compiling this code with defined "JachuPL" will fail.

Proper and recommended Syntax:
timconv.exe [-v] -f file1.xml|file2.xml|file3.xml|file4.xml [-o temp.txt]

where:
-v - script effects are shown on command line

-f file1.xml|file2.xml|file3.xml|file4.xml - passes file names to convert. Remember, there's no need to place | on the beginning or ending of file list!

-o temp.txt - script output will be saved in temp.txt

