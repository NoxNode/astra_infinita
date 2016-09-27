pushd src
g++ -o../bin/main.exe -std=c++11 ^
 ^
engine\gfx\Renderer.cpp ^
engine\input\Input.cpp ^
engine\input\KeyStroke.cpp ^
engine\input\Mouse.cpp ^
engine\core\Game.cpp ^
engine\core\Scene.cpp ^
game\TestGame.cpp ^
 ^
main.cpp ^
testmain.cpp ^
 ^
-I../include -L../lib -lSDL2
popd
