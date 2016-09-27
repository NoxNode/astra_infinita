#pragma once
#include "../input/Input.hpp"
#include "../gfx/Renderer.hpp"
#include "../util/LinkedList.hpp"

// because I have to do forward declaration to have classes with pointers to each other, I just put all of the classes that are part of the core engine that need forward declaration in the same file

class Scene;

// NOTE: inteded use is to make a subclass of Game and implement the Init function that init's the first scene and any other variables for the game that should be kept across scenes, to start this new Game, instaniate it in main.cpp, then call Init() then Run()
class Game {
public:
    Game(const char* title, int width, int height);
    ~Game();
    void Run();
    void Update();
    void Render();

    virtual void Init() = 0;

    inline Input* GetInput() {return _input;}
    inline Renderer* GetRenderer() {return _renderer;}
    inline Scene* GetCurScene() {return _curScene;}
    inline void SetNextScene(Scene* nextScene) {_nextScene = nextScene;}

private:
    Input*    _input;
    Renderer* _renderer;
    Scene*    _curScene;
    Scene*    _nextScene; // set this variable to switch the scene after the current one is done updating and rendering the current frame
};

class GameObject;
class UpdateFuncContainer;
class RenderFuncContainer;

typedef LinkedNode<GameObject>          LinkedGameObject;
typedef LinkedList<GameObject>          LinkedGameObjects;

typedef LinkedNode<UpdateFuncContainer> LinkedUpdateFunc;
typedef LinkedList<UpdateFuncContainer> LinkedUpdateFuncs;

typedef LinkedNode<RenderFuncContainer> LinkedRenderFunc;
typedef LinkedList<RenderFuncContainer> LinkedRenderFuncs;

// NOTE: intended use is to make a subclass of Scene and implement the Init function that init's all initial game objects and update and render functions and any other variables for the scene, to switch to this new scene, set nextScene to an instaniation of your new subclass of Scene
class Scene {
public:
    Scene(Game* param_game);
    ~Scene();
    void Update(Input* input);
    void Render(SDL_Surface* drawSurface);
    void RemoveOldGameObjects();

    virtual void Init() = 0;

    Game*              game;
    LinkedGameObjects  gameObjects;
    LinkedUpdateFuncs* updateFuncs;
    int                nUpdateFuncLayers;
    LinkedRenderFuncs* renderFuncs;
    int                nRenderFuncLayers;
};

// NOTE: intended use is to make a subclass of GameObject and implement the Init function that init's all variables for the game object, to add this object to the scene, instaniate it either in a Scene's Init() or in some updateFunc of another GameObject that spawns it, then add it to the scene's root object's children, then add any update and render funcs it needs to whichever layer
class GameObject {
public:
    GameObject(Scene* param_scene, GameObject* param_parent) :
    removeMe(false),
    scene(param_scene),
    parent(param_parent)
    {}

    virtual void Init() = 0;

    Scene*            scene;
    GameObject*       parent;
    LinkedGameObjects children;
    bool              removeMe;
};

// NOTE: intended use is to make update functions in separate cpp files and instaniate an object of this class and set the run variable to the separate function
class UpdateFuncContainer {
public:
    UpdateFuncContainer(void (*param_run)(GameObject* parent, Input* input), GameObject* param_parent, bool param_removeMeOnNullParent) :
    run(param_run),
    parent(param_parent),
    removeMe(false),
    removeMeOnNullParent(param_removeMeOnNullParent)
    {}

    void (*run)(GameObject* parent, Input* input);

    GameObject* parent;
    bool        removeMe;
    bool        removeMeOnNullParent;
};

// NOTE: intended use is to make update functions in separate cpp files and instaniate an object of this class and set the run variable to the separate function
class RenderFuncContainer {
public:
    RenderFuncContainer(void (*param_run)(GameObject* parent, SDL_Surface* drawSurface), GameObject* param_parent, bool param_removeMeOnNullParent) :
    run(param_run),
    parent(param_parent),
    removeMe(false),
    removeMeOnNullParent(param_removeMeOnNullParent)
    {}

    void (*run)(GameObject* parent, SDL_Surface* drawSurface);

    GameObject* parent;
    bool        removeMe;
    bool        removeMeOnNullParent;
};
