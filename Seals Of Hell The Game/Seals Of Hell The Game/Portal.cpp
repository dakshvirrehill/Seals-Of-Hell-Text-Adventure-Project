#include <iostream>
#include "GameManager.h"
#include "Portal.h"
#include "Region.h"
#include "AnalyticsManager.h"
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
		AnalyticsManager::instance().UpdateActionData("Teleport");
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

json::JSON Portal::getItemJSON()
{
	json::JSON aJSON = json::JSON::Object();
	addCommons(aJSON);
	aJSON["mType"] = "Portal";
	aJSON["mActiveRegion"] = mActiveRegion->getName();
	aJSON["mConnectedRegion"] = mConnectedRegion->getName();
	aJSON["mIntType"] = 6;
	return aJSON;
}

void Portal::resetPortal(Region* pFirstRegion)
{
	if (mActiveRegion != pFirstRegion)
	{
		Region* aTemp = mActiveRegion;
		mActiveRegion = pFirstRegion;
		mConnectedRegion = aTemp;
	}
}
