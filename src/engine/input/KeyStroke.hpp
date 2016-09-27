#pragma once
#include <SDL2/SDL.h>

class KeyStroke {
public:
    KeyStroke();
    void Update();

    bool   down;
    bool   justDown;
    bool   justUp;
    Uint32 timestamp;
};
