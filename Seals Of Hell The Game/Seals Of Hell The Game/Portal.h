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
	Portal();
	~Portal();

};
#endif