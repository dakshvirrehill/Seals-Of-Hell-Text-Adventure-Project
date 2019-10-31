#pragma once
#ifndef PORTAL_H
#define PORTAL_H
#include "IInteractable.h"
class Region;
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
};
#endif