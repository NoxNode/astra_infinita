#pragma once

void TestRenderFunc(GameObject* parent, SDL_Surface* drawSurface);
void TestUpdateFunc(GameObject* parent, Input* input);

class TestObject : public GameObject {
public:
    using GameObject::GameObject;
    virtual void Init() {
        myVar = 0;
        UpdateFuncContainer* myFuncContainer = new UpdateFuncContainer(&TestUpdateFunc, (GameObject*)this, true);
        scene->updateFuncs[0].Add(myFuncContainer, true);
        RenderFuncContainer* myFuncContainer2 = new RenderFuncContainer(&TestRenderFunc, (GameObject*)this, true);
        scene->renderFuncs[0].Add(myFuncContainer2, true);
    }
    
    int myVar;
};

#include "../updateFuncs/TestUpdateFunc.hpp"
#include "../renderFuncs/TestRenderFunc.hpp"
