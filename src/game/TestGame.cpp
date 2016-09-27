#include "TestGame.hpp"
#include "scenes/TestScene.hpp"

#include <iostream>
using namespace std;
void TestGame::Init() {
    cout << "working" << endl;
    TestScene* myScene = new TestScene((Game*)this);
    myScene->Init();
    SetNextScene(myScene);
}
