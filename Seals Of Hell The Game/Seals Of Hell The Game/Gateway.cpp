#include "Gateway.h"
#include "Room.h"
#include "GameManager.h"
#include <iostream>

void Gateway::initialize(Room* pCurrentRoom, Room* pConnectedRoom, bool& pIsVisible, bool& pIsInteractable)
{
	mCurrentRoom = pCurrentRoom;
	mConnectedRoom = pConnectedRoom;
	makeInteractable(pIsInteractable);
	makeVisible(pIsVisible);
}

void Gateway::lookObject()
{
	if (isVisible())
	{
		std::cout << getStory() << " in the " << getName() << " direction." << std::endl;
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
