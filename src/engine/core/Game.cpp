#include "CoreClasses.hpp"

Game::Game(const char* title, int width, int height) :
_curScene(NULL),
_nextScene(NULL)
{
    _input = new Input();
    _renderer = new Renderer(title, width, height);
}

Game::~Game() {
    delete _input;
    delete _renderer;
    if(_curScene != NULL) {
        delete _curScene;
    }
}

void Game::Update() {
    _input->Update();
    if(_curScene != NULL) {
        _curScene->Update(_input);
    }
}

void Game::Render() {
    if(_curScene != NULL) {
        _curScene->Render(_renderer->GetDrawSurface());
    }
    _renderer->Update();
}

void Game::Run() {
    while(!_input->isClosing()) {
        Update();
        Render();
        if(_curScene != NULL) {
            _curScene->RemoveOldGameObjects();
        }
        if(_curScene != _nextScene) {
            delete _curScene;
            _curScene = _nextScene;
        }
    }
}
