cd
cmake -H. -Bbuild -G "Visual Studio 14 2015 Win64"
cmake --build build
rem build nuget package
nuget pack hello.nuspec 
