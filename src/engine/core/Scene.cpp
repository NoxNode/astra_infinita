#include "CoreClasses.hpp"

Scene::Scene(Game* param_game) :
updateFuncs(NULL),
renderFuncs(NULL),
nUpdateFuncLayers(0),
nRenderFuncLayers(0),
game(param_game)
{}

Scene::~Scene() {
    if(updateFuncs != NULL) {
        delete [] updateFuncs;
    }
    if(renderFuncs != NULL) {
        delete [] renderFuncs;
    }
}

void Scene::Update(Input* input) {
    for(int i = 0; i < nUpdateFuncLayers; i++) {
        LinkedUpdateFunc* curFunc = updateFuncs[i].GetRoot();
        // TODO: handle error of NULL item or item->run better
        while(curFunc != NULL && curFunc->item != NULL && curFunc->item->run != NULL) {
            LinkedUpdateFunc* nextFunc = curFunc->next;
            if(curFunc->item->removeMe) {
                delete curFunc;
            }
            else if(curFunc->item->parent == NULL && curFunc->item->removeMeOnNullParent){
                delete curFunc;
            }
            else {
                curFunc->item->run(curFunc->item->parent, input);
            }
            curFunc = nextFunc;
        }
    }
}

void Scene::Render(SDL_Surface* drawSurface) {
    for(int i = 0; i < nRenderFuncLayers; i++) {
        LinkedRenderFunc* curFunc = renderFuncs[i].GetRoot();
        // TODO: handle error of NULL item or item->run better
        while(curFunc != NULL && curFunc->item != NULL && curFunc->item->run != NULL) {
            LinkedRenderFunc* nextFunc = curFunc->next;
            if(curFunc->item->removeMe) {
                delete curFunc;
            }
            else if(curFunc->item->parent == NULL && curFunc->item->removeMeOnNullParent){
                delete curFunc;
            }
            else {
                curFunc->item->run(curFunc->item->parent, drawSurface);
            }
            curFunc = nextFunc;
        }
    }
}

void Scene::RemoveOldGameObjects() {
    LinkedGameObject* curObj = gameObjects.GetRoot();
    while(curObj != NULL) {
        LinkedGameObject* nextObj = curObj->next;
        if(curObj->item != NULL && curObj->item->removeMe) {
            delete curObj;
        }
        curObj = nextObj;
    }
}
