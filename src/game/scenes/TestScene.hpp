#pragma once

#include "../../engine/core/CoreClasses.hpp"
#include "../gameObjects/TestObject.hpp"

#define NTESTUPDATELAYERS 5
#define NTESTRENDERLAYERS 4

class TestScene : public Scene {
public:
    using Scene::Scene;
    virtual void Init() {
        nUpdateFuncLayers = 5;
        nRenderFuncLayers = 4;
        updateFuncs = new LinkedUpdateFuncs[NTESTUPDATELAYERS];
        renderFuncs = new LinkedRenderFuncs[NTESTRENDERLAYERS];
        myOtherVar = 0;
        TestObject* myTestObj = new TestObject((Scene*)this, NULL);
        myTestObj->Init();
        gameObjects.Add(myTestObj, true);
    }
private:
    int myOtherVar;
};
