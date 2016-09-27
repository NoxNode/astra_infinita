#pragma once
#include "../engine/core/CoreClasses.hpp"

class TestGame : public Game {
public:
    using Game::Game;
    virtual void Init();
};
