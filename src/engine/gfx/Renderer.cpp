#include "Renderer.hpp"

Renderer::Renderer(const char* title, int width, int height) {
    _window = SDL_CreateWindow(title, SDL_WINDOWPOS_CENTERED, SDL_WINDOWPOS_CENTERED, width, height, SDL_WINDOW_SHOWN);
    _screenSurface = SDL_GetWindowSurface(_window);
    _drawSurface = SDL_CreateRGBSurface(0, width, height, 32, 0, 0, 0, 0);
}

Renderer::~Renderer() {
    SDL_FreeSurface(_drawSurface);
}

void Renderer::Update() {
    SDL_BlitSurface(_drawSurface, NULL, _screenSurface, NULL);
    SDL_UpdateWindowSurface(_window);
    SDL_FillRect(_drawSurface, NULL, 0);
}
