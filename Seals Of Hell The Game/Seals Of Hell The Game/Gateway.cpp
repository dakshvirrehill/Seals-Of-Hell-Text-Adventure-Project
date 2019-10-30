#include "Gateway.h"
#include "Room.h"
#include "GameManager.h"
#include <iostream>

Gateway::~Gateway()
{
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
	}
}
