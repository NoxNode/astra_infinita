pushd src
cl /Fe../bin/main.exe /Fo../bin/ /EHsc ^
 ^
engine\render\window.cpp ^
engine\render\surface.cpp ^
engine\input\input.cpp ^
engine\input\button.cpp ^
engine\input\keyboard.cpp ^
engine\core\coreengine.cpp ^
engine\core\game.cpp ^
engine\core\scene.cpp ^
engine\core\gameobject.cpp ^
engine\io\stb_image.c ^
engine\asset\assetmanager.cpp ^
engine\asset\assetgroup.cpp ^
 ^
main.cpp ^
gamecomponents.cpp ^
 ^
/I../include ../lib/SDL2.lib
popd
