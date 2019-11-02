#pragma once
#ifndef PORTAL_H
#define PORTAL_H
#include "IInteractable.h"
class Region;
/*
################
A Portal is a special interactable that has pointers to the main and current region
They go back and forth when teleport command is used on them
################
*/
class Portal : public IInteractable
{
	Region* mActiveRegion;
	Region* mConnectedRegion;
	bool mInitialized;
public:
	Portal() : IInteractable(), mActiveRegion(nullptr), mConnectedRegion(nullptr), mInitialized(false) {};
	~Portal();
	void initialize(Region*,Region*);
	void teleportRegion() override;
	bool& isInitialized() { return mInitialized; }
	bool isPortal() override { return true; }
	Region* getOtherRegion(Region* pFirstRegion);
	json::JSON getItemJSON() override;
	std::string getType() override { return "Portal"; }
	void resetPortal(Region* pFirstRegion);
};
#endif