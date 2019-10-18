#pragma once
#ifndef PORTAL_H
#define PORTAL_H
#include "IInteractable.h"
class Region;
namespace json
{
	class JSON;
}
class Portal : public IInteractable
{
	Region* mActiveRegion;
	Region* mConnectedRegion;
public:
	Portal();
	~Portal();
	void initialize(json::JSON&) override;
};
#endif