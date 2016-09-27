#include "KeyStroke.hpp"

KeyStroke::KeyStroke() :
down(false),
justDown(false),
justUp(false),
timestamp(0)
{}

void KeyStroke::Update() {
    justDown = false;
    justUp = false;
}
