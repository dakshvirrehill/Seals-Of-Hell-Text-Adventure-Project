#include "Room.h"
#include "IInteractable.h"
#include "IUpdatable.h"
#include "Gateway.h"
#include <map>
#include <string>
#include <iostream>

Room::~Room()
{
	
}

void Room::look()
{
	std::cout << getName() << std::endl;
	std::cout << getStory() << std::endl << std::endl << std::endl;
	for (auto& iter : mRoomObjects)
	{
		if (iter.second->isGateway() && iter.second->isInteractable())
		{
			std::cout << "In the " << iter.first << " direction..." << std::endl;
		}
		iter.second->lookObject();
	}
}

IInteractable* Room::getRoomObject(std::string& pObjectName)
{
	if (mRoomObjects.count(pObjectName) == 1)
	{
		return mRoomObjects[pObjectName];
	}
	return nullptr;
}

void Room::removeInteractable(IInteractable* pInteractable)
{
	mRoomObjects.erase(pInteractable->getName());
}

void Room::removeUpdatable(IUpdatable* pUpdatable)
{
	mUpdatableObjects.remove(pUpdatable);
}

void Room::addInteractable(IInteractable* pInteractable)
{
	mRoomObjects.emplace(pInteractable->getName(), pInteractable);
}

void Room::addGateway(IInteractable* pGateway, int pPath, int pRoomId)
{
	if (pPath == 0)
	{
		if (pRoomId == 0)
		{
			if (mRoomObjects.count("NORTH") == 1)
			{
				mRoomObjects["NORTH"] = pGateway;
			}
			else
			{
				mRoomObjects.emplace("NORTH", pGateway);
			}
		}
		else
		{
			if (mRoomObjects.count("SOUTH") == 1)
			{
				mRoomObjects["SOUTH"] = pGateway;
			}
			else
			{
				mRoomObjects.emplace("SOUTH", pGateway);
			}
		}
	}
	else if (pPath == 1)
	{
		if (pRoomId == 0)
		{
			if (mRoomObjects.count("EAST") == 1)
			{
				mRoomObjects["EAST"] = pGateway;
			}
			else
			{
				mRoomObjects.emplace("EAST", pGateway);
			}
		}
		else
		{
			if (mRoomObjects.count("WEST") == 1)
			{
				mRoomObjects["WEST"] = pGateway;
			}
			else
			{
				mRoomObjects.emplace("WEST", pGateway);
			}
		}
	}
	else if (pPath == 2)
	{
		if (pRoomId == 0)
		{
			if (mRoomObjects.count("NORTH-EAST") == 1)
			{
				mRoomObjects["NORTH-EAST"] = pGateway;
			}
			else
			{
				mRoomObjects.emplace("NORTH-EAST", pGateway);
			}
		}
		else
		{
			if (mRoomObjects.count("SOUTH-WEST") == 1)
			{
				mRoomObjects["SOUTH-WEST"] = pGateway;
			}
			else
			{
				mRoomObjects.emplace("SOUTH-WEST", pGateway);
			}
		}
	}
	else if (pPath == 3)
	{
		if (pRoomId == 0)
		{
			if (mRoomObjects.count("NORTH-WEST") == 1)
			{
				mRoomObjects["NORTH-WEST"] = pGateway;
			}
			else
			{
				mRoomObjects.emplace("NORTH-WEST", pGateway);
			}
		}
		else
		{
			if (mRoomObjects.count("SOUTH-EAST") == 1)
			{
				mRoomObjects["SOUTH-EAST"] = pGateway;
			}
			else
			{
				mRoomObjects.emplace("SOUTH-EAST", pGateway);
			}
		}
	}
}

void Room::addUpdatable(IUpdatable* pUpdatable)
{
	mUpdatableObjects.push_back(pUpdatable);
}

void Room::updateRoom()
{
	for (auto& iter : mUpdatableObjects)
	{
		iter->update();
	}
}

void Room::enterRoom()
{
	for (auto& iter : mUpdatableObjects)
	{
		iter->onEnable();
	}
	for (auto& iter : mRoomObjects)
	{
		if (iter.second->isGateway())
		{
			Gateway* aGateway = (Gateway*)iter.second;
			aGateway->setCurrentRoom(this);
		}
	}
}
