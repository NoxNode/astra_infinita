#pragma once

#include <SDL2/SDL.h>

void TestUpdateFunc(GameObject* parent, Input* input) {
    if(input->GetMouse()->buttons[3].down) {
        ((TestObject*)parent)->myVar++;
    }
    if(input->GetMouse()->buttons[1].down) {
        ((TestObject*)parent)->myVar--;
    }
    if(input->GetKey(SDLK_d)->down) {
        ((TestObject*)parent)->myVar++;
    }
    if(input->GetKey(SDLK_a)->down) {
        ((TestObject*)parent)->myVar--;
    }
}
