#pragma once

#include <SDL2/SDL.h>

void TestRenderFunc(GameObject* parent, SDL_Surface* drawSurface) {
    SDL_Rect rect;
    rect.x = ((TestObject*)parent)->myVar;
    rect.y = 50;
    rect.w = 32;
    rect.h = 32;
    SDL_FillRect(drawSurface, &rect, 0xFFFF0000);
}
