#include "Input.hpp"

Input::Input() :
_isClosing(false)
{}

KeyStroke* Input::GetKey(int keysym) {
    if(keysym < NKEYS) {
        return &_keys[keysym];
    }
}

void Input::Update() {
    // TODO: maybe optimize this later if it's a problem
    for(int i = 0; i < NKEYS; i++) {
        _keys[i].Update();
    }
    _mouse.Update();

	while(SDL_PollEvent(&_event)) {
        switch(_event.type) {
            case SDL_KEYDOWN: {
                int sym = _event.key.keysym.sym;
                if(sym < NKEYS) {
                    if(!_keys[sym].down) {
                        _keys[sym].justDown = true;
                        _keys[sym].timestamp = _event.key.timestamp;
                    }
                    _keys[sym].down = true;
                }
            } break;
            case SDL_KEYUP: {
                int sym = _event.key.keysym.sym;
                if(sym < NKEYS) {
                    _keys[sym].down = false;
                    _keys[sym].justUp = true;
                    _keys[sym].timestamp = _event.key.timestamp;
                }
            } break;
            case SDL_MOUSEMOTION: {
                _mouse.x = _event.motion.x;
                _mouse.y = _event.motion.y;
            } break;
            case SDL_MOUSEBUTTONDOWN: {
                int button = _event.button.button;
                if(button < NMOUSEBUTTONS) {
                    if(!_mouse.buttons[button].down) {
                        _mouse.buttons[button].justDown = true;
                        _mouse.buttons[button].timestamp = _event.button.timestamp;
                    }
                    _mouse.buttons[button].down = true;
                }
            } break;
            case SDL_MOUSEBUTTONUP: {
                int button = _event.button.button;
                if(button < NMOUSEBUTTONS) {
                    _mouse.buttons[button].down = false;
                    _mouse.buttons[button].justUp = true;
                    _mouse.buttons[button].timestamp = _event.button.timestamp;
                }
            } break;
            case SDL_QUIT: {
                _isClosing = true;
            } break;
        }
	}
}
