#include "Mouse.hpp"

Mouse::Mouse() :
x(0),
y(0)
{}

void Mouse::Update() {
    for(int i = 0; i < NMOUSEBUTTONS; i++) {
        buttons[i].Update();
    }
}
