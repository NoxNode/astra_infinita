#pragma once
#include <SDL2/SDL.h>
#include "Mouse.hpp"

#define NKEYS 256

// TODO: mouse wheel

class Input {
public:
    Input();
    void Update();
    KeyStroke* GetKey(int keysym);
    inline Mouse* GetMouse() {return &_mouse;}
    inline bool isClosing() {return _isClosing;}
    inline void setIsClosing(bool isClosing) {_isClosing = isClosing;}

private:
    KeyStroke _keys[NKEYS];
    Mouse     _mouse;
    SDL_Event _event;
    bool      _isClosing;
};
