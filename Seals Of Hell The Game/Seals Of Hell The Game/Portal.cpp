#include <iostream>
#include "GameManager.h"
#include "Portal.h"

Portal::~Portal()
{
	mActiveRegion = nullptr;
	mConnectedRegion = nullptr;
}

void Portal::initialize(Region* pActiveRegion, Region* pConnectedRegion)
{
	mActiveRegion = pActiveRegion;
	mConnectedRegion = pConnectedRegion;
	mInitialized = true;
}

void Portal::teleportRegion()
{
	if (isInteractable() && isVisible())
	{
		std::cout << "Teleporting..." << std::endl << std::endl;
		Region* aTemp = mActiveRegion;
		mActiveRegion = mConnectedRegion;
		mConnectedRegion = aTemp;
		GameManager::instance().setCurrentRegion(mActiveRegion);
	}
}

Region* Portal::getOtherRegion(Region* pFirstRegion)
{
	if (pFirstRegion == mActiveRegion)
	{
		return mConnectedRegion;
	}
	else
	{
		return mActiveRegion;
	}
}
