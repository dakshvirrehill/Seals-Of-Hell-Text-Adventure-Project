#pragma once
#ifndef ROOM_H
#define ROOM_H
#include "BasicObject.h"
#include<string>
#include<map>
#include<list>
class IUpdatable;
class IInteractable;
class Room : public BasicObject
{
	std::map<std::string, IInteractable*> mRoomObjects;
	std::list<IUpdatable*> mUpdatableObjects;
public:
	Room() :BasicObject(), mRoomObjects(), mUpdatableObjects() {}
	~Room();
	void look();
	IInteractable* getRoomObject(std::string&);
	void removeInteractable(IInteractable*);
	void removeUpdatable(IUpdatable*);
	void addInteractable(IInteractable*);
	void addUpdatable(IUpdatable*);
	void updateRoom();
};
#endif