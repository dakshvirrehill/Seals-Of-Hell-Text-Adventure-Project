#pragma once
#ifndef ROOM_H
#define ROOM_H
#include "BasicObject.h"
#include<string>
#include<map>
#include<list>
class IUpdatable;
class IInteractable;
class Gateway;
class Room : public BasicObject
{
	std::map<std::string, IInteractable*> mRoomObjects;
	std::list<IUpdatable*> mUpdatableObjects;
	Gateway* mIntoRoomGateway;
public:
	Room() :BasicObject(), mRoomObjects(), mUpdatableObjects(), mIntoRoomGateway(nullptr) {}
	~Room();
	void look();
	IInteractable* getRoomObject(std::string&);
	Room* getPreviousRoom();
	std::list<IInteractable*> getAllPortals();
	std::list<Gateway*> getAllGateways();
	void removeInteractable(IInteractable*);
	void removeUpdatable(IUpdatable*);
	void addInteractable(IInteractable*);
	void addGateway(IInteractable*, int, int);
	void addUpdatable(IUpdatable*);
	void setIntoRoomGateway(Gateway*);
	void updateRoom();
	void enterRoom();
};
#endif