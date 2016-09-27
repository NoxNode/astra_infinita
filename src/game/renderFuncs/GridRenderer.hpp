#pragma once

#include <SDL2/SDL.h>

void GridRenderer(GameObject* parent, SDL_Surface* drawSurface) {
    Uint32* pixels = (Uint32*)drawSurface->pixels;

    pixels[0] = 0xFFFF0000;
}
