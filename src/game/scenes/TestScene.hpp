#pragma once

#include "../../engine/core/CoreClasses.hpp"
#include "../gameObjects/TestObject.hpp"

#define NTESTUPDATELAYERS 5
#define NTESTRENDERLAYERS 4

void GridRenderer(GameObject* parent, SDL_Surface* drawSurface);

class TestScene : public Scene {
public:
    using Scene::Scene;
    virtual void Init() {
        nUpdateFuncLayers = 5;
        nRenderFuncLayers = 4;
        updateFuncs = new LinkedUpdateFuncs[NTESTUPDATELAYERS];
        renderFuncs = new LinkedRenderFuncs[NTESTRENDERLAYERS];
        RenderFuncContainer* gridRenderer = new RenderFuncContainer(&GridRenderer, NULL, false);
        renderFuncs[0].Add(gridRenderer, true);
        myOtherVar = 0;
        TestObject* myTestObj = new TestObject((Scene*)this, NULL);
        myTestObj->Init();
        gameObjects.Add(myTestObj, true);
    }
private:
    int myOtherVar;
};

#include "../renderFuncs/GridRenderer.hpp"
