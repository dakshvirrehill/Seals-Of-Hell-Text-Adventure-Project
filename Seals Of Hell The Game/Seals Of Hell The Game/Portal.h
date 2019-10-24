#pragma once
#ifndef PORTAL_H
#define PORTAL_H
#include "IInteractable.h"
class Region;
class Portal : public IInteractable
{
	Region* mActiveRegion;
	Region* mConnectedRegion;
public:
	Portal() : IInteractable(), mActiveRegion(nullptr), mConnectedRegion(nullptr) {};
	~Portal();
	void initialize(Region*,Region*);
	void teleportRegion() override;
};
#endif