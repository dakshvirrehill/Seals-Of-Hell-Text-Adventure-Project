#pragma once
#ifndef ROOM_H
#define ROOM_H
#include "BasicObject.h"
#include<string>
#include<map>
class IInteractable;
class Room : public BasicObject
{
	std::map<std::string, IInteractable*> mRoomObjects;
public:
	Room();
	~Room();
	void initialize();
	void look();
	IInteractable* getRoomObject(std::string&);
	void removeInteractable(IInteractable*);
	void addInteractable(IInteractable*);
	void enterRoom();
};
#endif