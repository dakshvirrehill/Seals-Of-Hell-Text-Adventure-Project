#include "Gateway.h"
#include "Room.h"
#include "GameManager.h"
#include <iostream>

Gateway::~Gateway()
{
	mCurrentRoom = nullptr;
	mConnectedRoom = nullptr;
	mInitialized = false;
}

void Gateway::initialize(Room* pCurrentRoom, Room* pConnectedRoom, bool pNotDefault)
{
	mCurrentRoom = pCurrentRoom;
	mConnectedRoom = pConnectedRoom;
	mInitialized = pNotDefault;
}

void Gateway::setCurrentRoom(Room* pCurrentRoom)
{
	if (mCurrentRoom != pCurrentRoom)
	{
		Room* aTemp = mCurrentRoom;
		mCurrentRoom = mConnectedRoom;
		mConnectedRoom = aTemp;
	}
}

void Gateway::lookObject()
{
	if (isVisible() && mCurrentRoom != nullptr)
	{
		IInteractable::lookObject();
	}
}

void Gateway::goDirection()
{
	if (!isInteractable())
	{
		IInteractable::goDirection();
	}
	else
	{
		Room* aTemp = mCurrentRoom;
		mCurrentRoom = mConnectedRoom;
		mConnectedRoom = aTemp;
		GameManager::instance().setCurrentRoom(mCurrentRoom);
		mCurrentRoom->setIntoRoomGateway(this);
	}
}

json::JSON Gateway::getItemJSON()
{
	json::JSON aJSON = json::JSON::Object();
	addCommons(aJSON);
	aJSON["mType"] = "Gateway";
	aJSON["mCurrentRoom"] = mCurrentRoom->getName();
	aJSON["mConnectedRoom"] = mConnectedRoom->getName();
	aJSON["mIntType"] = 2;
	return aJSON;
}
