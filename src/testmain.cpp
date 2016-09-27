#include <iostream>
#include <SDL2/SDL.h>

using namespace std;

#undef main
int main1(int argc, char** argv) {
    SDL_Init(SDL_INIT_EVERYTHING);

    SDL_Window* window = SDL_CreateWindow("boxeo", SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, 800, 600, SDL_WINDOW_SHOWN);
    SDL_Surface* screen = SDL_GetWindowSurface(window);

	bool isClosing = false;
	bool keyA = false;
	SDL_Rect rect;
	rect.x = 0;
	rect.y = 0;
	rect.w = 32;
	rect.h = 32;

	while(!isClosing) {
	    SDL_Event event;
		while(SDL_PollEvent(&event)) {
			if(event.type == SDL_QUIT || event.key.keysym.sym == SDLK_ESCAPE) {
				isClosing = true;
			}
			if(event.key.keysym.sym == SDLK_a && event.key.state == SDL_PRESSED) {
				keyA = true;
			}
			else if(event.key.keysym.sym == SDLK_a && event.key.state == SDL_RELEASED) {
				keyA = false;
			}
		}
		SDL_FillRect(screen, NULL, 0xFF00FF00);
		if(keyA) {
			SDL_FillRect(screen, &rect, 0xFFFF0000);
		}
	    SDL_UpdateWindowSurface(window);
	}

    SDL_Quit();
	return 0;
}
