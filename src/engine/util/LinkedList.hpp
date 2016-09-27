#pragma once

template <class T>
class LinkedNode {
public:
    LinkedNode() :
    item(NULL),
    next(NULL),
    delOnDest(false)
    {}

    LinkedNode(bool param_delOnDest) :
    item(NULL),
    next(NULL),
    delOnDest(param_delOnDest)
    {}
        
    ~LinkedNode() {
        if(item != NULL && delOnDest) {
            delete item;
        }
    }

    T*             item;
    LinkedNode<T>* next;
    bool           delOnDest;
};

template <class T2>
class LinkedList {
public:
    LinkedList() :
    _root(NULL)
    {}

    ~LinkedList() {
        LinkedNode<T2>* curNode = _root;
        while(curNode != NULL) {
            LinkedNode<T2>* nextNode = curNode->next;
            delete curNode;
            curNode = nextNode;
        }
    }

    void Add(T2* item, bool delOnDest) {
        LinkedNode<T2>* newNode = new LinkedNode<T2>(delOnDest);
        newNode->item = item;
        newNode->next = _root;
        _root = newNode;
    }

    LinkedNode<T2>* GetRoot() {return _root;}

private:
    LinkedNode<T2>* _root;
};
