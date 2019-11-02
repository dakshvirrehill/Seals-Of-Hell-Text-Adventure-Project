#pragma once
#ifndef KILL_ZONE_H
#define KILL_ZONE_H
#include "IUpdatable.h"
#include "IInteractable.h"
/*
################
KILLZONE IS A SPECIAL UPDATABLE WHICH MAY OR MAY NOT HAVE A DISABLING OBJECT
IT KILLS PLAYER IF THERE IS NO DISABLING OBJECT OR IF THE PLAYER ISN'T WEARING
OR DROPPED THE PICKABLE OBJECT
################
*/
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