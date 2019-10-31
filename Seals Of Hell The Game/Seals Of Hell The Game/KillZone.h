#pragma once
#ifndef KILL_ZONE_H
#define KILL_ZONE_H
#include "IUpdatable.h"
#include "IInteractable.h"
class KillZone : public IUpdatable,public IInteractable
{
public:
	KillZone() : IUpdatable(), IInteractable() {}
	~KillZone();
	void onEnable() override;
	void update() override;
	void endUpdate() override;
	json::JSON getItemJSON() override;
	std::string getType() override { return "KillZone"; }
};
#endif