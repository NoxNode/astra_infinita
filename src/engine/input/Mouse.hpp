#pragma once
#include <SDL2/SDL.h>
#include "KeyStroke.hpp"

#define NMOUSEBUTTONS 5

class Mouse {
public:
    Mouse();
    void Update();

    Uint32    x, y;
    KeyStroke buttons[NMOUSEBUTTONS];
};
