::C:\Windows\System32\cmd.exe /E:ON /V:ON /T:0E /K "C:\Program Files\Microsoft SDKs\Windows\v7.1\Bin\SetEnv.cmd" /x64
call "C:\Program Files\Microsoft SDKs\Windows\v7.1\Bin\SetEnv.cmd"  /Release /x64 
cmake -version
echo %CMAKE_HOME%
::set
::cd C:\tutor\lab1
::del CMakeCache.txt
::rmdir /s /q  CMakeFiles
::pause
::call cmake -G "Visual Studio 10 Win64" .
cmake -H. -Bbuild
cmake --build build
pause
::mspdb100.dll