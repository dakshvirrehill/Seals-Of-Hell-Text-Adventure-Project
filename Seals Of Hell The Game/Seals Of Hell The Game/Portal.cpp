#include <iostream>
#include "GameManager.h"
#include "Portal.h"

Portal::~Portal()
{
}

void Portal::initialize(Region* pActiveRegion, Region* pConnectedRegion, bool& pIsVisible, bool& pIsInteractable)
{
	mActiveRegion = pActiveRegion;
	mConnectedRegion = pConnectedRegion;
	makeVisible(pIsVisible);
	makeInteractable(pIsInteractable);
}

void Portal::teleportRegion()
{
	if (isInteractable() && isVisible())
	{
		std::cout << "Teleporting..." << std::endl;
		Region* aTemp = mActiveRegion;
		mActiveRegion = mConnectedRegion;
		mConnectedRegion = aTemp;
		GameManager::instance().setCurrentRegion(mActiveRegion);
	}
}
