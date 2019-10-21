#include "Room.h"
#include "IInteractable.h"
#include <map>
#include <string>
#include <iostream>
Room::Room()
	:BasicObject(),mRoomObjects()
{
}

Room::~Room()
{
	
}

void Room::initialize()
{
}

void Room::look()
{
	std::cout << getName() << std::endl;
	std::cout << getStory() << std::endl << std::endl << std::endl;
	//call lookobject on all interactables
	for (auto& iter : mRoomObjects)
	{
		iter.second->lookObject();
	}
}

IInteractable* Room::getRoomObject(std::string& pObjectName)
{
	if (mRoomObjects.find(pObjectName) != mRoomObjects.end())
	{
		return mRoomObjects[pObjectName];
	}
	return nullptr;
}

void Room::removeInteractable(IInteractable* pInteractable)
{
	mRoomObjects.erase(pInteractable->getName());
}

void Room::addInteractable(IInteractable* pInteractable)
{
	mRoomObjects.emplace(pInteractable->getName(), pInteractable);
}

void Room::enterRoom()
{
	//do init code everytime
}
