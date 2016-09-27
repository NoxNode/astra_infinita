#include <iostream>
#include "game/TestGame.hpp"

using namespace std;

// NOTE: development of engine started 6/15/2016
// NOTE: look at src/engine/core/CoreClasses.hpp to see how the engine works

#undef main
int main(int argc, char** argv) {
    SDL_Init(SDL_INIT_EVERYTHING);

    TestGame testGame("TestGame", 800, 600);
    testGame.Init();
    testGame.Run();

    SDL_Quit();
	return 0;
}
