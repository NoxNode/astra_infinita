#pragma once
#include <SDL2/SDL.h>

// TODO: update screen while dragging window

class Renderer {
public:
    Renderer(const char* title, int width, int height);
    ~Renderer();
    void Update();
    inline SDL_Surface* GetDrawSurface() {return _drawSurface;}

private:
    SDL_Window*  _window;
    SDL_Surface* _screenSurface;
    SDL_Surface* _drawSurface;
};
